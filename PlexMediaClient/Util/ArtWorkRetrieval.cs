using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PlexMediaClient.Plex.Xml;
using System.Drawing;
using PlexMediaClient.Gui;
using System.Net;
using System.IO;

namespace PlexMediaClient.Util {
    static class ArtWorkRetrieval {

        public static event OnArtWorkRetrievedEventHandler OnArtWorkRetrieved;
        public delegate void OnArtWorkRetrievedEventHandler();

        private static Dictionary<string, Image> ImageCache { get; set; }

        static ArtWorkRetrieval() {
            ImageCache = new Dictionary<string, Image>();
            foreach (string plexType in Enum.GetNames(typeof(EPlexItemTypes))) {
                try {
                    ImageCache.Add(plexType, Image.FromFile(String.Format(@"\Resources\{0}.png", plexType)));
                } catch {
                    //throw; 
                }
            }
        }

        internal static Image GetArtWork(string imageIndex) {
            if (String.IsNullOrEmpty(imageIndex)) {
                return Properties.Resources.icon_empty_artwork;
            } else if (!ImageCache.ContainsKey(imageIndex)) {
                ImageCache.Add(imageIndex, Properties.Resources.icon_empty_artwork);
                try {
                    DownloadImage(imageIndex);
                } catch { 
                    //ToDo
                }
            }
            return ImageCache[imageIndex];
        }

        internal static void DownloadImage(string imageIndex) {
            WebClient ArtWorkRetriever = new WebClient();            
            ServerManager.Instance.PlexServerCurrent.AddAuthHeaders(ref ArtWorkRetriever);            
            ArtWorkRetriever.DownloadDataCompleted += new DownloadDataCompletedEventHandler(ArtWorkRetriever_DownloadDataCompleted);
            ArtWorkRetriever.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ArtWorkRetriever_DownloadProgressChanged);
            ArtWorkRetriever.DownloadDataAsync(new Uri(ServerManager.Instance.PlexServerCurrent.UriPlexBase, imageIndex), imageIndex);
        }

        static void ArtWorkRetriever_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            //throw new NotImplementedException();
        }

        static void ArtWorkRetriever_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {
            if (e.Error != null) {
                //ToDo handle
                return;
            }
            if (e.Result != null) {
                if (e.UserState is string) {
                    string artWorkIndex = (string)e.UserState;
                    if (ImageCache.ContainsKey(artWorkIndex)) {
                        using (MemoryStream ms = new MemoryStream(e.Result)) {
                            ImageCache[artWorkIndex] = Image.FromStream(ms);
                            OnArtWorkRetrieved();
                        }
                    }
                }
            }
        }
    }
}

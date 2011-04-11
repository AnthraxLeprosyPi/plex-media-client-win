using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using PlexMediaClient.Gui;
using System.Net;
using System.IO;
using PlexMediaClient.Plex;

namespace PlexMediaClient.Util {
    static class MediaRetrieval {

        public static event OnArtWorkRetrievedEventHandler OnArtWorkRetrieved;
        public delegate void OnArtWorkRetrievedEventHandler();
        public static event OnShowLargeArtWorkEventHandler OnShowLargeArtWork;
        public delegate void OnShowLargeArtWorkEventHandler(Image largeArtWork);
        public static event OnDetailsRetrievedEventHandler OnDetailsRetrieved;
        public delegate void OnDetailsRetrievedEventHandler(object infoObject);
        public static event OnPlayListRetrievedEventHandler OnPlayListRetrieved;
        public delegate void OnPlayListRetrievedEventHandler(object playList);

        private static Dictionary<string, Image> ImageCache { get; set; }

        static MediaRetrieval() {
            ImageCache = new Dictionary<string, Image>();
            foreach (string plexType in Enum.GetNames(typeof(EPlexItemTypes))) {
                try {
                    ImageCache.Add(plexType, Image.FromFile(String.Format(@"\Resources\{0}.png", plexType)));
                } catch {
                    //throw; 
                }
            }
        }

        private static object sync = new object();

        internal static Image GetArtWork(string imageIndex) {
            lock (sync) {
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
        }

        internal static void DownloadImage(string imageIndex) {
            WebClient ArtWorkRetriever = new WebClient();
            PlexInterface.PlexServerCurrent.AddAuthHeaders(ref ArtWorkRetriever);
            ArtWorkRetriever.DownloadDataCompleted += new DownloadDataCompletedEventHandler(ArtWorkRetriever_DownloadDataCompleted);
            ArtWorkRetriever.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ArtWorkRetriever_DownloadProgressChanged);
            ArtWorkRetriever.DownloadDataAsync(new Uri(PlexInterface.PlexServerCurrent.UriPlexBase, imageIndex), imageIndex);
        }

        internal static void ShowLargeArtWork(Image largeArtWork) {
            OnShowLargeArtWork(largeArtWork);
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
                            try {
                                ImageCache[artWorkIndex] = Image.FromStream(ms);
                                OnArtWorkRetrieved();
                            } catch { }
                        }
                    }
                }
            }
        }
        
        internal static void ShowDetails(object infoObject) {
            OnDetailsRetrieved(infoObject);
        }
    }
}

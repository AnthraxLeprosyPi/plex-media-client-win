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
        }


        static void DownloadArt(MediaContainer theContainer) {

        }

        internal static Image GetArtWork(string imageIndex) {
            if (String.IsNullOrEmpty(imageIndex)) {
                return Properties.Resources.icon_empty_artwork;
            } else if (!ImageCache.ContainsKey(imageIndex)) {
                ImageCache.Add(imageIndex, Properties.Resources.icon_empty_artwork);
                DownloadImage(imageIndex);
            }
            return ImageCache[imageIndex];
        }

        internal static void DownloadImage(string imageIndex) {
            WebClient ArtWorkRetriever = new WebClient();
            ArtWorkRetriever.Headers["X-Plex-User"] = PlexInterface.PlexServer.UserName;
            ArtWorkRetriever.Headers["X-Plex-Pass"] = PlexInterface.PlexServer.UserPass;
            ArtWorkRetriever.DownloadDataCompleted += new DownloadDataCompletedEventHandler(ArtWorkRetriever_DownloadDataCompleted);
            ArtWorkRetriever.DownloadDataAsync(new Uri(PlexInterface.PlexServer.UriPlexBase, imageIndex), imageIndex);
        }

        static void ArtWorkRetriever_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {
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

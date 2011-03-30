using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Gui;
using PlexMediaClient.Plex;
using System.IO;
using System.Drawing;
using PlexMediaClient.Util;

namespace PlexMediaClient.Plex {
    static class PlexInterface {

        private static WebClient WebClient { get; set; }
        public static bool IsConnected { get; private set; }
        public static bool IsBusy { get { return WebClient.IsBusy; } }

        public static event OnResponseProgressEventHandler OnResponseProgress;
        public delegate void OnResponseProgressEventHandler(int progress);
        public static event OnPlexErrorEventHandler OnPlexError;
        public delegate void OnPlexErrorEventHandler(Exception e);
        public static event OnPlexConnectedEventHandler OnPlexConnected;
        public delegate void OnPlexConnectedEventHandler(MediaContainer plexSections);

        static PlexInterface() {
            WebClient = new WebClient();

        }


        public static void Reconnect() {
            if (ServerManager.Instance.PlexServerCurrent == null) {
                //TODO: Server selection

            } else {
              
            }
        }
       
        public static void Login() {
            Authenticate(ServerManager.Instance.PlexServerCurrent);
        }

        private static void Authenticate(PlexServer plexServer) {
            WebClient.Headers["X-Plex-User"] = plexServer.UserName;
            WebClient.Headers["X-Plex-Pass"] = plexServer.UserPass;
            TryGetPlexSections(plexServer);
        }

        public static void TryGetPlexSections(PlexServer plexServer) {
            OnPlexConnected(RequestPlexItems(plexServer.UriPlexSections));
            IsConnected = true;
        }

        public static MediaContainer RequestPlexItems(Uri selectedPath) {
            try {
                MediaContainer requestedContainer = XmlSerialization.DeSerializeXML<MediaContainer>(WebClient.DownloadString(selectedPath));
                requestedContainer.UriSource = selectedPath;
                return requestedContainer;
            } catch (Exception e) {
                OnPlexError(e);
                return null;
            }
        }


        internal static bool TryConnectLastServer() {
            return true;
        }

        internal static bool PlexServersAvailable {
            get {
                return ServerManager.Instance.PlexServers != null && ServerManager.Instance.PlexServers.Count > 0;
            }
        }
    }
}

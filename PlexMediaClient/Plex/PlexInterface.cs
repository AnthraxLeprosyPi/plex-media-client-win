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

        private static WebClient _webClient;
        public static bool IsConnected { get; private set; }
        public static bool IsBusy { get { return _webClient.IsBusy; } }

        public static event OnResponseProgressEventHandler OnResponseProgress;
        public delegate void OnResponseProgressEventHandler(int progress);
        public static event OnPlexErrorEventHandler OnPlexError;
        public delegate void OnPlexErrorEventHandler(Exception e);
        public static event OnPlexConnectedEventHandler OnPlexConnected;
        public delegate void OnPlexConnectedEventHandler(PlexServer plexServer, MediaContainer plexSections);

        static PlexInterface() {
            _webClient = new WebClient();
        }

        internal static bool Login(PlexServer plexServer) {
           return ServerManager.Instance.Authenticate(ref _webClient, plexServer);            
        }

        public static MediaContainer TryGetPlexSections(PlexServer plexServer) {
            return RequestPlexItems(plexServer.UriPlexSections);
        }

        public static MediaContainer RequestPlexItems(Uri selectedPath) {
            try {
                MediaContainer requestedContainer = XmlSerialization.DeSerializeXML<MediaContainer>(_webClient.DownloadString(selectedPath));
                requestedContainer.UriSource = selectedPath;
                return requestedContainer;
            } catch (Exception e) {
                OnPlexError(e);
                return null;
            }
        }


        internal static MediaContainer TryConnectLastServer() {
            if (PlexServersAvailable && Login(ServerManager.Instance.PlexServerCurrent)) {
                  return TryGetPlexSections(ServerManager.Instance.PlexServerCurrent);                     
            } else {
                return null;
            }
        }

        internal static bool PlexServersAvailable {
            get {
                return ServerManager.Instance.PlexServers != null
                    && ServerManager.Instance.PlexServers.Count > 0
                    && ServerManager.Instance.PlexServerCurrent != null;
            }
        }

        internal static void RefreshBonjourServers() {
            ServerManager.Instance.RefrehBonjourServers();
        }       
    }
}

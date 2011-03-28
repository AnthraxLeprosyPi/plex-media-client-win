using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Gui;
using PlexMediaClient.Plex;
using System.IO;
using System.Drawing;

namespace PlexMediaClient.Util {
    static class PlexInterface {

        private static WebClient WebClient { get; set; }
        public static bool IsConnected { get; private set; }
        public static bool IsBusy { get { return WebClient.IsBusy; } }

        private static List<PlexServer> PlexServers { get; set; }

        public static event OnResponseProgressEventHandler OnResponseProgress;
        public delegate void OnResponseProgressEventHandler(int progress);
        public static event OnPlexErrorEventHandler OnPlexError;
        public delegate void OnPlexErrorEventHandler(Exception e);
        public static event OnPlexConnectedEventHandler OnPlexConnected;
        public delegate void OnPlexConnectedEventHandler(MediaContainer plexSections);

        public static PlexServer PlexServer { get; private set; }
        public static MediaContainer PlexSections { get; private set; }

        static PlexInterface() {
            WebClient = new WebClient();
            LoadKnownPlexServers();
        }




        private static void LoadKnownPlexServers() {
            if (File.Exists("PlexServers.xml")) {
                PlexServers = XmlSerialization.Deserialize<List<PlexServer>>("PlexServers.xml");
            }
            if (Properties.Settings.Default.LastServer != null) {
                SetPlexServer(Properties.Settings.Default.LastServer);
            }
        }

        public static void SetPlexServer(PlexServer server) {
            if (Properties.Settings.Default.LastServer.UriPlexSections != server.UriPlexSections) {
                Properties.Settings.Default.LastServer = server;
                Properties.Settings.Default.Save();
            }
            Login(server);
        }


        public static void Reconnect() {
            if (PlexServer == null) {
                //TODO: Server selection

            } else {
                Login(PlexServer);
            }
        }

        public static void Login(string hostName, string userName, string userPass) {
            Login(new PlexServer(hostName, userName, userPass));
        }

        private static void Login(PlexServer plexServer) {
            Authenticate(plexServer);
        }

        private static void Authenticate(PlexServer plexServer) {
            PlexServer = plexServer;
            WebClient.Headers["X-Plex-User"] = plexServer.UserName;
            WebClient.Headers["X-Plex-Pass"] = plexServer.UserPass;            
            TryGetPlexSections();
        }

        private static void TryGetPlexSections() {
            try {
                PlexSections = RequestSectionItems(PlexServer.UriPlexSections);
                if (PlexSections.Directory != null && PlexSections.Directory.Count > 0) {
                    IsConnected = true;
                    OnPlexConnected(PlexSections);
                }
            } catch (Exception e) {
                OnPlexError(e);
            }
        }

        public static MediaContainer RequestSectionItems(Uri selectedPath) {
            try {
                string t = WebClient.DownloadString(selectedPath);
                MediaContainer requestedContainer = XmlSerialization.Deserialize<MediaContainer>(WebClient.DownloadString(selectedPath));
                requestedContainer.UriSource = selectedPath;
                return requestedContainer;
            } catch (Exception e) {
                OnPlexError(e);
                return PlexSections;
            }
        }

        static void PlexResponseProgress(object sender, DownloadProgressChangedEventArgs e) {
            OnResponseProgress(e.ProgressPercentage);
        }



        
    }
}

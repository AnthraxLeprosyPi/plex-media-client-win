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
using System.Threading;

namespace PlexMediaClient.Plex {
   public static class PlexInterface {

        private static WebClient _webClient;
        public static bool IsConnected { get; private set; }
        public static bool IsBusy { get { return _webClient.IsBusy; } }

        public static event OnResponseProgressEventHandler OnResponseProgress;
        public delegate void OnResponseProgressEventHandler(int progress);
        public static event OnResponseReceivedEventHandler OnResponseReceived;
        public delegate void OnResponseReceivedEventHandler(MediaContainer response);
        public static event OnPlexErrorEventHandler OnPlexError;
        public delegate void OnPlexErrorEventHandler(Exception e);
        public static event OnPlexConnectedEventHandler OnPlexConnected;
        public delegate void OnPlexConnectedEventHandler(PlexServer plexServer, MediaContainer plexSections);

        static PlexInterface() {
            _webClient = new WebClient();
            _webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(_webClient_DownloadDataCompleted);
            _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(_webClient_DownloadProgressChanged);
        }               

        static void _webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            OnResponseProgress(e.ProgressPercentage);
            Console.WriteLine(e.ProgressPercentage + " (" + e.BytesReceived + " / " + e.TotalBytesToReceive + ")");
        }

        static void _webClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {            
            OnResponseReceived(XmlSerialization.DeSerializeXML<MediaContainer>(System.Text.ASCIIEncoding.Default.GetString(e.Result)));                
        }               

        public static bool Login(PlexServer plexServer) {
           return ServerManager.Instance.Authenticate(ref _webClient, plexServer);            
        }

        public static MediaContainer TryGetPlexSections() {
            return TryGetPlexSections(PlexServerCurrent);
        }

        public static MediaContainer TryGetPlexSections(PlexServer plexServer) {
            if (Login(plexServer)) {
                try {
                    ServerManager.Instance.SetPlexServer(plexServer);
                    return RequestPlexItems(plexServer.UriPlexSections);
                } catch (Exception e) {
                    throw e;
                }
            } else {                
                return null;
            }
        }

        public static MediaContainer TryGetPlexServerRoot(PlexServer plexServer) {
            if (Login(plexServer)) {
                try {
                    ServerManager.Instance.SetPlexServer(plexServer);
                    return RequestPlexItems(plexServer.UriPlexBase);
                } catch (Exception e) {
                    throw e;
                }
            } else {
                OnPlexError(new Exception("Unable to login to:" + plexServer.HostAdress));
                return null;
            }
        }

        public static MediaContainer RequestPlexItems(Uri selectedPath) {   
            try {              
                MediaContainer requestedContainer = XmlSerialization.DeSerializeXML<MediaContainer>(_webClient.DownloadString(selectedPath));                
                requestedContainer.UriSource = selectedPath;
                return requestedContainer;
            } catch (Exception e) {
                OnPlexError(e);
                throw e;               
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

        internal static void RequestPlexItemsAsync(Uri path) {
            _webClient.DownloadDataAsync(path);
        }

        internal static IEnumerable<string> GetAllVideoPartKeys(MediaContainerVideo videoContainer) {
            foreach (Media media in videoContainer.Media) {                
                foreach (MediaPart part in media.Part) {
                    yield return part.key;
                }
            }
        }

        public static PlexServer PlexServerCurrent { get { return ServerManager.Instance.PlexServerCurrent; } }

        public static bool Is3GConnected { get; set; }

        public static bool IsLANConnected { get { return PlexServerCurrent.IsBonjour; } }

        public static bool ShouldTranscode { get; set; }
    }
}

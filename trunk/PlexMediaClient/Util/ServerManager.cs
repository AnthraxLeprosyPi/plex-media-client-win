using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using System.IO;

namespace PlexMediaClient.Util {

    public sealed class ServerManager {

        static readonly ServerManager instance = new ServerManager();

        public static event OnPlexServersChangedEventHandler OnPlexServersChanged;
        public delegate void OnPlexServersChangedEventHandler(List<PlexServer> updatedServerList);

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ServerManager() {
        }

        ServerManager() {
            PlexServers = LoadPlexServers();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.LastServer.HostAdress)) {
                PlexServerCurrent = Properties.Settings.Default.LastServer;
            }
            BonjourDiscovery.OnBonjourServer += new BonjourDiscovery.OnBonjourServerEventHandler(BonjourDiscovery_OnBonjourServer);            
        }

        ~ServerManager() {
            SavePlexServers(PlexServers);
        }
        public static ServerManager Instance { get { return instance; } }

        public List<PlexServer> PlexServers { get; private set; }

        private PlexServer _plexServerCurrent;
        public PlexServer PlexServerCurrent {
            get {
                return _plexServerCurrent;
            }
            private set {
                _plexServerCurrent = value;
                if (!PlexServers.Contains(value)) {
                    PlexServers.Insert(0, value);                    
                }
                SavePlexServers(PlexServers);               
            }
        }

        private List<PlexServer> LoadPlexServers() {
            List<PlexServer> plexServers = new List<PlexServer>();
            if (File.Exists("PlexServers.xml")) {
                try {
                    plexServers = XmlSerialization.DeSerialize<List<PlexServer>>("PlexServers.xml");                    
                } catch {
                    //ToDo Log
                }
            }
            return plexServers;
        }

        private void SavePlexServers(List<PlexServer> plexServers) {
            Properties.Settings.Default.LastServer = PlexServerCurrent;
            Properties.Settings.Default.Save();
            if (plexServers == null) {
                return;
            }
            try {
                XmlSerialization.Serialize("PlexServers.xml", plexServers.Where(ser => !ser.IsBonjour).ToList());
            } catch {
                //ToDo Log
            }
        }



        public void SetPlexServer(PlexServer server) {
            PlexServerCurrent = server;
        }

        void BonjourDiscovery_OnBonjourServer(PlexServer bojourDiscoveredServer) {
            if (!PlexServers.Contains<PlexServer>(bojourDiscoveredServer)) {
                PlexServers.Add(bojourDiscoveredServer);
                OnPlexServersChanged(PlexServers);
            }
        }

        public void RefrehBonjourServers() {
            PlexServers.RemoveAll(svr => svr.IsBonjour);
            if (PlexServers.Count > 0) {
                OnPlexServersChanged(PlexServers);
            }
            BonjourDiscovery.RefreshBonjourDiscovery();
        }               


        internal bool Authenticate(ref System.Net.WebClient _webClient, PlexServer plexServer) {
            if (plexServer.Authenticate(ref _webClient)) {
                PlexServerCurrent = plexServer;
                return true;
            } else {
                return false;
            }
        }
    }
}

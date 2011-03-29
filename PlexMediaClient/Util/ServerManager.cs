using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using System.IO;

namespace PlexMediaClient.Util {

    public sealed class ServerManager {

        static readonly ServerManager instance = new ServerManager();


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ServerManager() {
        }

        ServerManager() {
            PlexServers = LoadPlexServers();       
            StartBonjourDiscovery();
        }

        ~ServerManager() {
            SavePlexServers(PlexServers);
        }
        public static ServerManager Instance { get { return instance; } }





        private List<PlexServer> PlexServers { get; set; }
        public PlexServer PlexServerCurrent { get; private set; }

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
            if (plexServers == null) {
                return;
            }
            try {
                XmlSerialization.Serialize("PlexServers.xml", plexServers.Where(ser => ser.IsBonjour).ToList());
            } catch {
                //ToDo Log
            }
        }



        public void SetPlexServer(PlexServer server) {
            Properties.Settings.Default.LastServer = server;
            Properties.Settings.Default.Save();
            //Login(server);
        }

        private void StartBonjourDiscovery() {
            BonjourDiscovery.OnBonjourServer += new BonjourDiscovery.OnBonjourServerEventHandler(BonjourDiscovery_OnBonjourServer);
            BonjourDiscovery.StartBonjourServerDiscovery();
        }

        void BonjourDiscovery_OnBonjourServer(PlexServer bojourDiscoveredServer) {
            if (!PlexServers.Contains<PlexServer>(bojourDiscoveredServer)) {
                PlexServers.Add(bojourDiscoveredServer);
            }
        }


    }
}

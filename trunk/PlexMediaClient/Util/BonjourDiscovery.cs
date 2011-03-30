using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroconfService;
using PlexMediaClient.Plex;
using System.Net;

namespace PlexMediaClient.Util {
    static class BonjourDiscovery {

        private static NetServiceBrowser BonjourBrowser { get; set; }

        public static event OnBonjourServerEventHandler OnBonjourServer;
        public delegate void OnBonjourServerEventHandler(PlexServer bojourDiscoveredServer);

        static BonjourDiscovery() {
            BonjourBrowser = new NetServiceBrowser();
            BonjourBrowser.DidFindDomain += new NetServiceBrowser.DomainFound(_browser_DidFindDomain);
            BonjourBrowser.DidFindService += new NetServiceBrowser.ServiceFound(_browser_DidFindService);           
        }

        static void _browser_DidFindService(NetServiceBrowser browser, NetService service, bool moreComing) {
            try {
                service.DidResolveService += new NetService.ServiceResolved(service_DidResolveService);
                service.ResolveWithTimeout(60);
            } catch (Exception e) {
                
                throw e;
            }
        }

        static void service_DidResolveService(NetService service) {
            try {
                PlexServer bonjourServer = new PlexServer(service.HostName, ((IPEndPoint)service.Addresses[0]).Address.ToString());
                bonjourServer.IsBonjour = true;
                OnBonjourServer(bonjourServer);
            } catch (Exception e) {
                
                throw e;
            }
        }

        static void _browser_DidFindDomain(NetServiceBrowser browser, string domainName, bool moreComing) {
            try {
                BonjourBrowser.SearchForService("_plexmediasvr._tcp", domainName);
            } catch (Exception e) {

                throw e;
            }
        }
        public static void StartBonjourDiscovery() {
            try {
                BonjourBrowser.SearchForBrowseableDomains();
            } catch {
                //Debug ("Couldn't locate servers via Bonjour.");
            }
        }

        public static void RefreshBonjourDiscovery() {
            try {
                BonjourBrowser.Stop();
                BonjourBrowser.SearchForBrowseableDomains();
            } catch {
                //Debug ("Couldn't locate servers via Bonjour.");
            }
        }
    }
}

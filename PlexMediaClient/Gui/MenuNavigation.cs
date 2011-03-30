using System;
using System.Collections.Generic;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using PlexMediaClient.Plex;

namespace PlexMediaClient.Gui {
    public static class MenuNavigation {

        private static Stack<IMenuItem> History { get; set; }
        public static bool IsFetching { get; set; }

        public static event OnCloseEventHandler OnClose;
        public delegate void OnCloseEventHandler(string reason);
        public static event OnErrorOccuredEventHandler OnErrorOccured;
        public delegate void OnErrorOccuredEventHandler(Exception e);
        public static event OnMenuItemsFetchedEventHandler OnMenuItemsFetched;
        public delegate void OnMenuItemsFetchedEventHandler(List<IMenuItem> fetchedMenuItems);

        static MenuItem RootItem { get; set; }        
        static ActionItem BackItem { get; set; }
        static ActionItem ServerItem { get; set; }
        static ActionItem ExitItem { get; set; }

        static MenuNavigation() {
            History = new Stack<IMenuItem>();
            CreateStaticMenuItems();
            PlexInterface.OnPlexError += new PlexInterface.OnPlexErrorEventHandler(PlexInterface_OnPlexError);
            PlexInterface.OnPlexConnected += new PlexInterface.OnPlexConnectedEventHandler(PlexInterface_OnPlexConnected);
            ServerManager.OnPlexServersChanged += new ServerManager.OnPlexServersChangedEventHandler(ServerManager_OnPlexServersChanged);
        }

        private static void CreateStaticMenuItems() {
            RootItem = new MenuItem("Root Item");
            ServerItem = new ActionItem("Plex Servers", Properties.Resources.icon_server_bonjour, () => ShowMenuServerSelection());
            RootItem.SubMenu.Add(ServerItem);
            ExitItem = new ActionItem("Exit", Properties.Resources.icon_server_offline, () => OnClose("User exited..."));
            RootItem.SubMenu.Add(ExitItem);
            BackItem = new ActionItem("Back...", Properties.Resources.icon_server_online, () => MenuNavigation.FetchPreviousMenu());
        }



        static void PlexInterface_OnPlexError(Exception e) {
            OnErrorOccured(e);
        }

        static void PlexInterface_OnPlexConnected(MediaContainer plexSections) {
            BuildSubMenu(GetCreatePlexMenuItem(plexSections));
        }

        internal static void FetchPreviousMenu() {
            if (History != null && History.Count > 1) {
                History.Pop();
                OnMenuItemsFetched(History.Peek().SubMenu);
            }
        }

        internal static void BuildSubMenu(IMenuItem parentItem) {
            History.Push(parentItem);
            //if (parentItem is PlexMenuItem) {
            //    OnMenuItemsFetched(FetchSubMenu(parentItem));
            //} else 
                if (parentItem.SubMenu.Count > 0) {
                OnMenuItemsFetched(parentItem.SubMenu);
            } else {
                return;
            }

        }

        private static List<IMenuItem> FetchSubMenu(IMenuItem parentItem) {
            IsFetching = true;
            parentItem.SubMenu = GetSubMenuItems(PlexInterface.RequestPlexItems(parentItem.Path));
            parentItem.SubMenu.Add(BackItem);
            IsFetching = false;
            return parentItem.SubMenu;
        }

        private static IMenuItem GetCreatePlexMenuItem(MediaContainer plexResponseConatiner) {
            PlexMenuItem newMenuItem = new PlexMenuItem(plexResponseConatiner.title1, plexResponseConatiner.UriSource);
            newMenuItem.SubMenu = GetSubMenuItems(plexResponseConatiner);
            newMenuItem.SubMenu.Add(BackItem);
            return newMenuItem;
        }

        private static List<IMenuItem> GetSubMenuItems(MediaContainer plexResponseConatiner) {
            //Add ActionItems
            return plexResponseConatiner.Directory.ConvertAll<IMenuItem>(dir => new PlexMenuItem());
        }

        internal static void ShowMenuRoot() {
            BuildSubMenu(RootItem);
        }

        internal static void ShowMenuServerSections() {
            //MenuItem main = new MenuItem("Main");
            //MenuItem c = new MenuItem("Configuration");
            //c.SubMenu.Add(new MenuItem("Server"));
            //c.SubMenu.Add(new MenuItem("Server"));
            //c.SubMenu.Add(new MenuItem("Server"));
            //c.SubMenu.Add(new MenuItem("Server"));
            //c.SubMenu.Add(new MenuItem("Server"));
            //main.SubMenu.Add(c);
            //main.SubMenu.Add(new ActionItem("Plex Servers", Properties.Resources.icon_server_bonjour, () => ShowMenuServerSelection()));
            //main.SubMenu.Add(new ActionItem("Exit", Properties.Resources.icon_server_offline, () => OnClose("User exited...")));
            //BuildSubMenu(main);
        }

        static List<IMenuItem> ServerMenu { get; set; }

        static void ServerManager_OnPlexServersChanged(List<PlexServer> updatedServerList) {            
            ServerMenu = new List<IMenuItem>();
            ServerMenu.AddRange(updatedServerList.ConvertAll<ServerItem>(svr => new ServerItem(svr)));
            ServerMenu.Add(new ActionItem("Refresh Bonjour", Properties.Resources.icon_server_bonjour, () => RefreshBonjourServers()));
            ServerMenu.Add(BackItem);
            ServerItem.SubMenu = ServerMenu;            
        }

         static void RefreshBonjourServers() {
             OnMenuItemsFetched(ServerMenu);
             ServerManager.Instance.RefrehBonjourServers();
        }

        internal static void ShowMenuServerSelection() {
           BuildSubMenu(ServerItem);
        }

        
    }
}

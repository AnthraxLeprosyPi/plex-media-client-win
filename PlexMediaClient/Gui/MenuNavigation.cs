using System;
using System.Collections.Generic;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using PlexMediaClient.Plex;

namespace PlexMediaClient.Gui {
    public static class MenuNavigation {

        public static bool IsFetching { get; set; }

        public static event OnCloseEventHandler OnClose;
        public delegate void OnCloseEventHandler(string reason);
        public static event OnErrorOccuredEventHandler OnErrorOccured;
        public delegate void OnErrorOccuredEventHandler(Exception e);
        public static event OnMenuItemsFetchedEventHandler OnMenuItemsFetched;
        public delegate void OnMenuItemsFetchedEventHandler(List<IMenuItem> fetchedMenuItems);

        static MenuItem RootItem { get; set; }
        static MenuItem ServerItem { get; set; }
        static List<IMenuItem> ServerMenu { get; set; }


        static MenuNavigation() {
            RootItem = new MenuItem(null, "Root Item");
            ServerItem = new MenuItem(RootItem, "Plex Servers");
            ServerMenu = new List<IMenuItem>();
            PlexInterface.OnPlexError += new PlexInterface.OnPlexErrorEventHandler(PlexInterface_OnPlexError);
            PlexInterface.OnPlexConnected += new PlexInterface.OnPlexConnectedEventHandler(PlexInterface_OnPlexConnected);
            ServerManager.OnPlexServersChanged += new ServerManager.OnPlexServersChangedEventHandler(ServerManager_OnPlexServersChanged);
        }

        static void PlexInterface_OnPlexError(Exception e) {
            OnErrorOccured(e);
        }

        static void PlexInterface_OnPlexConnected(MediaContainer plexSections) {
            //ShowCurrentMenu(GetCreatePlexMenuItem(plexSections));
        }

        internal static void FetchPreviousMenu(IMenuItem currentItem) {
            if (currentItem != null && currentItem.Parent != null) {
                ShowCurrentMenu(currentItem.Parent);
            }
        }

        internal static void ShowCurrentMenu(IMenuItem parentItem) {
            //if (parentItem is PlexMenuItem) {
            //    OnMenuItemsFetched(FetchSubMenu(parentItem));
            //} else 
            if (parentItem.ChildItems.Count > 0) {
                OnMenuItemsFetched(parentItem.ChildItems);
            } else {
                return;
            }

        }

        private static List<IMenuItem> FetchSubMenu(PlexItem parentItem) {
            IsFetching = true;
            parentItem.SetChildItems(GetSubMenuItems(parentItem, PlexInterface.RequestPlexItems(parentItem.Path)));
            IsFetching = false;
            return parentItem.ChildItems;
        }

        //private static IMenuItem GetCreatePlexMenuItem(MediaContainer plexResponseConatiner) {
        //    PlexItem newMenuItem = new PlexItem(plexResponseConatiner.title1, plexResponseConatiner.UriSource);
        //    newMenuItem.ChildItems = GetSubMenuItems(newMenuItem, plexResponseConatiner);            
        //    return newMenuItem;
        //}

        public static List<IMenuItem> GetSubMenuItems(IMenuItem parentItem, MediaContainer plexResponseConatiner) {
            //Add ActionItems
            return plexResponseConatiner.Directory.ConvertAll<IMenuItem>(dir => new PlexItem(parentItem, "", new Uri("")));
        }

        internal static void ShowMenuRoot() {


            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerMenu.Add(new MenuItem(ServerItem, "Test"));
            ServerItem.SetChildItems(ServerMenu);
            RootItem.SetChildItems(new List<IMenuItem>() { ServerItem });
            ShowCurrentMenu(RootItem);
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



        static void ServerManager_OnPlexServersChanged(List<PlexServer> updatedServerList) {
            ServerMenu = new List<IMenuItem>();
            ServerMenu.AddRange(updatedServerList.ConvertAll<MenuItem>(svr => new MenuItem(ServerItem, svr.HostAdress)));
        }

        static void RefreshBonjourServers() {
            ServerManager.Instance.RefrehBonjourServers();
        }

        internal static void ExitApplication(string reason) {
            OnClose(reason);
        }
    }
}

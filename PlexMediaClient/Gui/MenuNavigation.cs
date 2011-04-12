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

        static PlexItem RootItem { get; set; }
        static List<IMenuItem> RootMenu { get; set; }
        static MenuItem ServerItem { get; set; }
        static List<IMenuItem> ServerMenu { get; set; }
        public static IMenuItem ExitItem { get; set; }
        static IMenuItem CurrentItem { get; set; }


        static MenuNavigation() {
            PlexInterface.OnPlexError += new PlexInterface.OnPlexErrorEventHandler(PlexInterface_OnPlexError);           
            ServerManager.OnPlexServersChanged += new ServerManager.OnPlexServersChangedEventHandler(ServerManager_OnPlexServersChanged);
            RootItem = new PlexItem(null, "Root Item", null);
            ExitItem = new ActionItem(null, "Exit", Properties.Resources.icon_server_offline, () => MenuNavigation.OnClose("User exited..."));
            ServerItem = new MenuItem(RootItem, "Plex Servers");
            RootMenu = new List<IMenuItem>();
            RootMenu.Add(ServerItem);
            RootMenu.Add(new ActionItem(null, "Settings", Properties.Resources.icon_server_online, () => MenuNavigation.ShowSettingsDialog()));
            RootMenu.Add(ExitItem);
            RootItem.SetChildItems(RootMenu);
        }

       
        static void PlexInterface_OnPlexError(Exception e) {
            OnErrorOccured(e);
        }

        static void ShowRootMenu(MediaContainer plexSections) {
            RootItem.Path = plexSections.UriSource;
            RootMenu = GetSubMenuItems(RootItem, plexSections);
            RootMenu.Add(ServerItem);
            RootMenu.Add(ExitItem);
            RootItem.SetChildItems(RootMenu);
            ShowCurrentMenu(RootItem);
        }

        static void ServerManager_OnPlexServersChanged(List<PlexServer> updatedServerList) {
            ServerMenu = updatedServerList.ConvertAll<IMenuItem>(svr => new ActionItem(ServerItem, svr.HostAdress, Properties.Resources.icon_server_offline, () => ShowRootMenu(PlexInterface.TryGetPlexServerRoot(svr))));
            ServerMenu.Add(new ActionItem(null, "Add New...", Properties.Resources.icon_server_online, () => AddNewServer()));
            ServerMenu.Add(new ActionItem(null, "Refresh Bonjouor...", Properties.Resources.icon_server_bonjour, () => PlexInterface.RefreshBonjourServers()));
            ServerItem.SetChildItems(ServerMenu);
            if (CurrentItem == ServerItem) {
                ShowCurrentMenu(ServerItem);
            }
        }

        internal static bool CreateStartupMenu() {
            RefreshServerMenu();
            try {
                ShowRootMenu(PlexInterface.TryGetPlexSections());
            } catch (Exception e) {
                if (PlexInterface.PlexServersAvailable) {
                    ShowCurrentMenu(ServerItem);
                } else {
                    return AddNewServer();
                }
            }
            return true;
        }

        private static bool AddNewServer() {
            try {
                ShowRootMenu(PlexInterface.TryGetPlexSections(ShowNewServerDialog()));
                RefreshServerMenu();
                return true;
            } catch {
                return false;
            }
        }

        private static PlexServer ShowNewServerDialog() {
            using (DialogNewPlexServer dlgServer = new DialogNewPlexServer()) {
                dlgServer.ShowDialog();
                return dlgServer.NewServer;
            }
        }

        internal static void FetchPreviousMenu(IMenuItem currentItem) {
            if (currentItem != null && currentItem.Parent != null) {
                ShowCurrentMenu(currentItem.Parent);
            }
        }

        internal static void ShowCurrentMenu(IMenuItem parentItem) {
            if (parentItem.ChildItems.Count > 0) {
                CurrentItem = parentItem;
                OnMenuItemsFetched(parentItem.ChildItems);
            } else {
                return;
            }
        }

        internal static List<IMenuItem> GetSubMenuItems(PlexItem parentItem, MediaContainer plexResponseConatiner) {
            //Add ActionItems
            List<IMenuItem> tmpList = new List<IMenuItem>();
            tmpList.AddRange(plexResponseConatiner.Directory.ConvertAll<IMenuItem>(dir => new PlexItemDirectory(parentItem, dir.title, new Uri(parentItem.Path, dir.key), dir)));
            tmpList.AddRange(plexResponseConatiner.Video.ConvertAll<IMenuItem>(vid => new PlexItemVideo(parentItem, vid.title, new Uri(parentItem.Path, vid.key), vid)));
            return tmpList;
        }

        internal static void RefreshServerMenu() {
            PlexInterface.RefreshBonjourServers();
        }

        private static object ShowSettingsDialog() {
            throw new NotImplementedException();
        }        
             
    }
}

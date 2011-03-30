using System;
using System.Collections.Generic;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;

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

        static ActionItem BackItem { get; set; }

        static MenuNavigation() {
            History = new Stack<IMenuItem>();
            BackItem = new ActionItem("Back...", Properties.Resources.icon_server_online, () => MenuNavigation.FetchPreviousMenu());
            PlexInterface.OnPlexError += new PlexInterface.OnPlexErrorEventHandler(PlexInterface_OnPlexError);
            PlexInterface.OnPlexConnected += new PlexInterface.OnPlexConnectedEventHandler(PlexInterface_OnPlexConnected);
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
                BuildSubMenu(History.Peek());
            }
        }

        internal static void BuildSubMenu(IMenuItem parentItem) {
            History.Push(parentItem);        
            if (parentItem is PlexMenuItem ) {
                OnMenuItemsFetched(FetchSubMenu(parentItem));
            } else if (parentItem.SubMenu.Count > 0) {
                if (History.Count > 1 && !parentItem.SubMenu.Contains(BackItem)) {
                    parentItem.SubMenu.Add(BackItem);
                }
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
            return newMenuItem;
        }

        private static List<IMenuItem> GetSubMenuItems(MediaContainer plexResponseConatiner) {
            //Add ActionItems
            return new List<IMenuItem>();
        }

        internal static void ShowMenuServerSections() {
            MenuItem main = new MenuItem("Main");
            MenuItem c = new MenuItem("Configuration");
            c.SubMenu.Add(new MenuItem("Server"));
            c.SubMenu.Add(new MenuItem("Server"));
            c.SubMenu.Add(new MenuItem("Server"));
            c.SubMenu.Add(new MenuItem("Server"));
            c.SubMenu.Add(new MenuItem("Server"));
            main.SubMenu.Add(c);
            main.SubMenu.Add(new ActionItem("Exit", Properties.Resources.icon_server_offline, () => OnClose("User exited...")));
            BuildSubMenu(main);
        }

        internal static void ShowMenuServerSelection() {
            throw new NotImplementedException();
        }
    }
}

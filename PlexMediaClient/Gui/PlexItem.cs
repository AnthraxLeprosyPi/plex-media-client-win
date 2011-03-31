using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;

namespace PlexMediaClient.Gui {
    class PlexItem : MenuItem {
         

        public PlexItem(IMenuItem parentItem, string title, Uri path) : base(parentItem, title) {
            Path = path;
        }

        public Uri Path { get; set; }

        public override void OnClicked(object sender, EventArgs e) {
            try {
                SetChildItems(MenuNavigation.GetSubMenuItems(this, PlexInterface.RequestPlexItems(Path)));
            } catch {
                throw;
            }
            MenuNavigation.ShowCurrentMenu(this);
        }
    }
}

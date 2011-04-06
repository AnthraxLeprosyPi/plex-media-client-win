using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using System.Web;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
    class PlexItem : MenuItem {
         

        public PlexItem(IMenuItem parentItem, string title, Uri path) : base(parentItem, title) {
            if (path != null) {
                Path = path.AbsoluteUri.Contains("?") ? path : new Uri(VirtualPathUtility.AppendTrailingSlash(path.AbsoluteUri));
            }
            PlexInterface.OnResponseProgress += new PlexInterface.OnResponseProgressEventHandler(PlexInterface_OnResponseProgress);
            PlexInterface.OnResponseReceived += new PlexInterface.OnResponseReceivedEventHandler(PlexInterface_OnResponseReceived);
        }

        void PlexInterface_OnResponseReceived(MediaContainer response) {
            SetChildItems(MenuNavigation.GetSubMenuItems(this, response));
            MenuNavigation.ShowCurrentMenu(this);
        }


        void PlexInterface_OnResponseProgress(int progress) {
           
        }

        public override System.Drawing.Image Icon {
            get {
                return ArtWorkRetrieval.GetArtWork(Path.AbsoluteUri);
            }
        }

        public override void OnClicked(object sender, EventArgs e) {
            try {
                PlexInterface.RequestPlexItemsAsync(Path);
            } catch {
                throw;
            }            
        }
    }
}

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
        }     

        public override System.Drawing.Image Icon {
            get {
                return MediaRetrieval.GetArtWork(Path.AbsoluteUri);
            }
        }

        public override void OnClicked(object sender, EventArgs e) {
            try {
                SetChildItems(MenuNavigation.GetSubMenuItems(this, PlexInterface.RequestPlexItems(Path)));
                MenuNavigation.ShowCurrentMenu(this);
            } catch {
              
            }            
        }
    }
}

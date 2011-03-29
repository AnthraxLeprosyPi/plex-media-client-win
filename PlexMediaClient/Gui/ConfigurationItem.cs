using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
    public class ConfigurationItem : IMenuItem {

        public ConfigurationItem(string title) {
            Title = title;
            ChildItems = new List<IMenuItem>();
        }

        public List<IMenuItem> ChildItems { get; set; }
        public string Title { get; set; }

        public System.Drawing.Image Icon {
            get { return ArtWorkRetrieval.GetArtWork(Title); }
        }

        public void OnClicked(object sender, EventArgs e) {
            MenuNavigation.BuildMenuItems(ChildItems);
        }
    }
}

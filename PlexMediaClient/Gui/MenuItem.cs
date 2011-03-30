using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
   public class MenuItem : IMenuItem {

        public MenuItem(string title) {
            Title = title;
            SubMenu = new List<IMenuItem>();
            Path = null;
        }

        public string Title { get; set; }

        public Uri Path { get; set; }
        public List<IMenuItem> SubMenu { get; set; }
        
        public virtual System.Drawing.Image Icon {
            get { return ArtWorkRetrieval.GetArtWork(Title); }
        }

        public virtual void OnClicked(object sender, EventArgs e) {
            MenuNavigation.BuildSubMenu(this);
        }

        #region IEquatable<IMenuItem> Members

        public bool Equals(IMenuItem other) {
            return this.Equals(other);
        }

        #endregion
   }
}

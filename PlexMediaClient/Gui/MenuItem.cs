using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlexMediaClient.Gui {
    public class MenuItem : IMenuItem {

        public MenuItem(IMenuItem parent, string title) {
            Parent = parent;
            Title = title;
        }

        public IMenuItem Parent { get; set; }
        public Uri Path { get; set; }
        public string Title { get; set; }
        public List<IMenuItem> ChildItems { get; set; }

        public virtual System.Drawing.Image Icon {
            get { return Properties.Resources.icon_empty_artwork; }
        }

        public virtual void OnClicked(object sender, EventArgs e) {
            if (ChildItems != null && ChildItems.Count > 0) {
                MenuNavigation.ShowCurrentMenu(this);
            }
        }

        public List<IMenuItem> GetChildItems() {
            return ChildItems;
        }
        public void SetChildItems(List<IMenuItem> childItems) {
            childItems.ForEach(ch => ch.Parent = this);
            if (Parent != null) {
                childItems.Add(new ActionItem(Parent, "Back", Properties.Resources.icon_server_bonjour, () => MenuNavigation.FetchPreviousMenu(this)));
            }
            ChildItems = childItems;
        }

        public virtual void OnPaint(object sender, DataGridViewCellPaintingEventArgs e) {
            e.Paint(e.ClipBounds, e.PaintParts);
        }
             
        public virtual void OnSelected() {
            return;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PlexMediaClient.Gui {
    public interface IMenuItem {
        IMenuItem Parent { get; set; }
        Uri Path { get; set; }
        String Title { get; set; }
        object Details { get; }
        Image Icon { get; }
        Image ArtWork { get; } 
        List<IMenuItem> ChildItems { get;}
        void OnClicked(object sender, EventArgs e);
        void OnPaint(object sender, DataGridViewCellPaintingEventArgs e);
        void OnSelected();
    }
}

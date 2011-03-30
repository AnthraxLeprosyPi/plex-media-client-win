using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlexMediaClient.Gui {
    public interface IMenuItem {
        String Title { get; set; }
        Image Icon { get; }
        Uri Path { get; set; } 
        List<IMenuItem> SubMenu { get; set; }

        void OnClicked(object sender, EventArgs e);
    }
}

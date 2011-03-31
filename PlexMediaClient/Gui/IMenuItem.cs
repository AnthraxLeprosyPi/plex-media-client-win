using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlexMediaClient.Gui {
    public interface IMenuItem {
        IMenuItem Parent { get; set; }       
        String Title { get; set; }
        Image Icon { get; }        
        List<IMenuItem> ChildItems { get;}
        void OnClicked(object sender, EventArgs e);
    }
}

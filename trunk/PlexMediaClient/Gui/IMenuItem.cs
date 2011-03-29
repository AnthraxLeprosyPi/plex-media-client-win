using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlexMediaClient.Gui {
    public interface IMenuItem  {
        String Title { get; set; }
        Image Icon { get; }

        void OnClicked(object sender, EventArgs e);
    }
}

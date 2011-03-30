using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlexMediaClient.Gui {
    class ActionItem : MenuItem {

        Image SpecialIcon { get; set; }
        Action Action { get; set; }

        public ActionItem(string title, Image specialIcon, Action actionDelegate)
            : base(title) {
            Action = actionDelegate;
            SpecialIcon = specialIcon;
        }

        public override Image Icon { get { return SpecialIcon; } }

        public override void OnClicked(object sender, EventArgs e) {
            Action();
        }
    }
}

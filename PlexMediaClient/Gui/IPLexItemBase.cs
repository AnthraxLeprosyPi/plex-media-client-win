using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
    interface IPlexItemBase {
        string Title { get; set; }
        string RelativePath { get; set; }
        string ThumbPath { get; set; }
        Image ThumbImage { get; }
        EPlexItemTypes PlexType { get; set; }

        void SetCellPosition(int colIndex, int rowIndex);
        void OnClickedEventHandler(object sender, EventArgs e);
        
        string ToString();
    }
}

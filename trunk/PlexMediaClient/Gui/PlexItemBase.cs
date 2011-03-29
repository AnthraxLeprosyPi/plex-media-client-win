using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using System.Windows.Forms;


namespace PlexMediaClient.Gui {
    class PlexItemBase : IPlexItemBase {


        public PlexItemBase(string title, string relativePath, string thumbPath, string artPath, string type) {
            Title = title;
            RelativePath = relativePath;
            ThumbPath = thumbPath;
            try {
                PlexType = (EPlexItemTypes)Enum.Parse(typeof(EPlexItemTypes), type);
            } catch {
                PlexType = EPlexItemTypes.generic;
            }
            ListView n = new ListView();
            ListViewItem i = new ListViewItem();

        }       

        #region IPLexItem Members

        public string Title { get; set; }

        public string RelativePath { get; set; }

        public string ArtPath { get; set; }

        public System.Drawing.Image ArtImage {
            get {
                return ArtWorkRetrieval.GetArtWork(!String.IsNullOrEmpty(ArtPath) ? ArtPath : PlexType.ToString());
            }
        }

        public string ThumbPath { get; set; }

        public System.Drawing.Image ThumbImage {
            get {
                return ArtWorkRetrieval.GetArtWork(!String.IsNullOrEmpty(ThumbPath) ? ThumbPath : PlexType.ToString());
            }
        }

        public EPlexItemTypes PlexType { get; set; }

        public void SetCellPosition(int colIndex, int rowIndex) {
            throw new NotImplementedException();
        }

        public void OnClickedEventHandler(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion
    }
}

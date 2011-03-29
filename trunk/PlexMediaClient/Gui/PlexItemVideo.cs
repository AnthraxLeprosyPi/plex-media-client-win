using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexMediaClient.Gui {
    class PlexItemVideo : IPlexItemBase{
        #region IPLexItem Members

        public string Title {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public string RelativePath {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public string ThumbPath {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Image ThumbImage {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public void SetCellPosition(int colIndex, int rowIndex) {
            throw new NotImplementedException();
        }

        public void OnClickedEventHandler(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion

        #region IPLexItem Members


        public EPlexItemTypes PlexType {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PlexMediaClient.Gui {
    class PlexMenuItem : IMenuItem {
        private string p;
        private Uri uri;

        public PlexMenuItem(string p, Uri uri) {
            // TODO: Complete member initialization
            this.p = p;
            this.uri = uri;
        }
        #region IMenuItem Members

        public string Title {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Image Icon {
            get { throw new NotImplementedException(); }
        }

        public Uri Path {
            get { return Path; }
            set {
                if(value.AbsoluteUri.Contains("?")){
                    Path = value;
                }else{                    
                    Path = new Uri(VirtualPathUtility.AppendTrailingSlash(value.AbsoluteUri));                   
                } 
            }
        }

        public List<IMenuItem> SubMenu {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public void OnClicked(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion

        #region IEquatable<IMenuItem> Members

        public bool Equals(IMenuItem other) {
            throw new NotImplementedException();
        }

        #endregion
    }
}

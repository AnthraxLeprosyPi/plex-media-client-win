using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using System.Windows.Forms;
using System.Drawing;

namespace PlexMediaClient.Gui {
    class PlexItemDirectory : PlexItem{

        MediaContainerDirectory Directory { get; set; }

        public PlexItemDirectory(IMenuItem parentItem, string title, Uri path, MediaContainerDirectory directory) : base(parentItem, title, path) {
            Directory = directory;        
        }

        public override System.Drawing.Image Icon {
            get {
                return MediaRetrieval.GetArtWork(Directory.thumb);
            }
        }

        public override System.Drawing.Image ArtWork {
            get {
                return MediaRetrieval.GetArtWork(Directory.art ?? Directory.thumb);
            }
        }

        public override object Details {
            get {
                return Directory;
            }
        }

        public override void OnPaint(object sender, DataGridViewCellPaintingEventArgs e) {            
            base.OnPaint(sender, e);
        }

        public override void OnSelected() {           
        }

      
    }
}

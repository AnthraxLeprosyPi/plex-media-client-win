using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;
using System.Drawing;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
    public class ListItem {
        public MediaContainerVideo Video { get; set; }
        public MediaContainerDirectory Directory { get; set; }
        public string ArtWorkIndex { get; set; }
        public Image ArtWork { get { return ArtWorkRetrieval.GetArtWork(ArtWorkIndex); } }

        public ListItem(MediaContainerDirectory directory) {
            Directory = directory;
            Title = directory.title;
            Index = directory.key;
            ArtWorkIndex = directory.art;           
        }

        public ListItem(MediaContainerVideo video) {
            Video = video;
            Title = video.title;
            Index = video.key;
            ArtWorkIndex = video.thumb;
        }

        public string Title { get; private set; }
        public string Index { get; private set; }

        public override string ToString() {
            return String.Format("[{0}] {1}", Index, Title);
        }
    }
}

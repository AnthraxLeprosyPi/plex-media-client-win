using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;
using System.Drawing;

namespace PlexMediaClient.Gui {
    public class ListItem {
        private MediaContainerVideo Video { get; set; }
        private MediaContainerDirectory Directory { get; set; }

        public ListItem(MediaContainerDirectory directory) {
            Directory = directory;
            Title = directory.title;
            Index = directory.key;
        }

        public ListItem(MediaContainerVideo video) {
            Video = video;
            Title = video.title;
            Index = video.key;
        }

        public string Title { get; private set; }
        public string Index { get; private set; }

        public override string ToString() {
            return String.Format("[{0}] {1}", Index, Title);
        }
    }
}

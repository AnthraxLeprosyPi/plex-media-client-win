﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;
using PlexMediaClient.Util;
using System.Windows.Forms;
using System.Drawing;

namespace PlexMediaClient.Gui {
    class PlexItemVideo : PlexItem{

        MediaContainerVideo Video { get; set; }

        public PlexItemVideo(IMenuItem parentItem, string title, Uri path, MediaContainerVideo video)
            : base(parentItem, title, path) {
            Video = video;        
        }

        public override Image Icon {
            get {
                return ArtWorkRetrieval.GetArtWork(Video.thumb ?? Video.art);
            }
        }

        public override void OnPaint(object sender, DataGridViewCellPaintingEventArgs e) {
            base.OnPaint(sender, e);
        }

        public override void OnClicked(object sender, EventArgs e) {
           string t = Transcoding.GetTranscodeUrl(ServerManager.Instance.PlexServerCurrent, Video.Media[0].Part[0].key);
            base.OnClicked(sender, e);
        }

    }
}

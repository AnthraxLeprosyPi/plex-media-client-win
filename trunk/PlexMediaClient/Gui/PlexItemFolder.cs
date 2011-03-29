using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;

namespace PlexMediaClient.Gui {
    class PlexItemFolder : PlexItemBase, IPlexItemFolder {

        public PlexItemFolder(MediaContainerDirectory plexDirectory) :
            base(plexDirectory.title, plexDirectory.key, plexDirectory.thumb, plexDirectory.art, plexDirectory.type) {
            if (String.IsNullOrEmpty(plexDirectory.scanner)) {
                PlexType = EPlexItemTypes.section;
            } else if (String.IsNullOrEmpty(plexDirectory.type)) {
                PlexType = EPlexItemTypes.folder;
            }
            
        }

    }
}

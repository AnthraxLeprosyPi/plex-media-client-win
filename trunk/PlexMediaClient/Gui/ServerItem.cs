using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using PlexMediaClient.Util;

namespace PlexMediaClient.Gui {
    class ServerItem : MenuItem  {
        PlexServer PlexServer { get; set; }

        public ServerItem (PlexServer plexServer) : base(String.Format("{0} ({1})",plexServer.HostName, plexServer.HostAdress)) {
            PlexServer = plexServer;
        }

        public override System.Drawing.Image Icon {
            get {
                return PlexServer.IsBonjour ? Properties.Resources.icon_server_bonjour : PlexServer.IsConnected ? Properties.Resources.icon_server_online : Properties.Resources.icon_server_offline;
            }
        }

        public override void OnClicked(object sender, EventArgs e) {
            PlexInterface.TryGetPlexSections(this.PlexServer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Util;
using System.Xml.Serialization;

namespace PlexMediaClient.Plex {
    [Serializable]
    class PlexServer {
        public Uri UriPlexBase { get; private set; }
        public String UserName { get; private set; }
        public String UserPass { get; private set; }
        const int PlexPort = 32400;

        public PlexServer(string hostName, string userName, string userPass) {
            UriPlexBase = new UriBuilder("http", hostName, PlexPort).Uri;
            UserName = userName;
            UserPass = Encryption.GetSHA1Hash(userName.ToLower() + Encryption.GetSHA1Hash(userPass));
        }

        public override string ToString() {
            return String.Format("{0}@{1}", UserName, UriPlexBase.Host);
        }

        [XmlIgnore]
        public Uri UriPlexSections {
            get {
                return new Uri(UriPlexBase, "/library/sections/");
            }
        }

    }
}

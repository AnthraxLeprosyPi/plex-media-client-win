using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Util;
using System.Xml.Serialization;

namespace PlexMediaClient.Plex {
    [Serializable]
    public class PlexServer : IEquatable<PlexServer> {

        public String HostName { get; set; }
        public String HostAdress { get; set; }
        public String UserName { get; set; }
        public String UserPass { get; set; }

        public bool IsConnected { get; set; }
        public bool IsBonjour { get; set; }
        const int PlexPort = 32400;

        public PlexServer() { }

        public PlexServer(string hostName, string hostAdress, string userName, string userPass) {
            HostName = hostName;
            HostAdress = hostAdress;
            UserName = userName;
            UserPass = Encryption.GetSHA1Hash(userName.ToLower() + Encryption.GetSHA1Hash(userPass));
        }

        public PlexServer(string hostName, string hostAdress) {
            HostName = hostName;
            HostAdress = hostAdress;
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

        [XmlIgnore]
        public Uri UriPlexBase { get { return new UriBuilder("http", HostAdress, PlexPort).Uri; } }

        public bool Equals(PlexServer other) {
            return HostAdress.Equals(other.HostAdress);
        }
    }
}

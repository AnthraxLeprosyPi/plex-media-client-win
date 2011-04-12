using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Util;
using System.Xml.Serialization;
using System.Net;
using PlexMediaClient.Plex.Xml;

namespace PlexMediaClient.Plex {
    [Serializable]
    public class PlexServer : IEquatable<PlexServer> {

        public String HostName { get; set; }
        public String HostAdress { get; set; }
        public String UserName { get; set; }
        public String UserPass { get; set; }

        public PlexServerCapabilities ServerCapabilities { get; private set; }

        [XmlIgnore]
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

        public void AddAuthHeaders(ref WebClient webClient) {
            webClient.Headers["X-Plex-User"] = this.UserName;
            webClient.Headers["X-Plex-Pass"] = this.UserPass;
        }

        public bool Authenticate(ref WebClient webClient) {
            webClient.Headers["X-Plex-User"] = this.UserName;
            webClient.Headers["X-Plex-Pass"] = this.UserPass;
            try {
                string serverXmlResponse = webClient.DownloadString(this.UriPlexBase);
                SetServerCapabilities(XmlSerialization.DeSerializeXML<MediaContainer>(serverXmlResponse));
                return ServerCapabilities != null;
            } catch (Exception e) {
                //Log
                return false;
            }
        }

        private void SetServerCapabilities(MediaContainer serverResponse) {
            ServerCapabilities = new PlexServerCapabilities(serverResponse);
        }
    }
}

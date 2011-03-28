using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PlexMediaClient.Util {
    static class XmlSerialization {

        public static T Deserialize<T>(string xml) {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml)) {
                return (T)xs.Deserialize(sr);
            }
        }

    }
}

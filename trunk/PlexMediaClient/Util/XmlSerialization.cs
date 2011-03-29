using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlexMediaClient.Util {
    public static class XmlSerialization {
        public enum FileType {
            Binary,
            XML
        }

        public static void Serialize(string fileName, object objectToSerialize) {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                Serialize(fs, objectToSerialize);
                fs.Close();
            }
        }

        public static void Serialize(string fileName, object objectToSerialize, FileType fileType) {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                Serialize(fs, objectToSerialize, fileType);
            }
        }

        public static void Serialize(Stream serializedStream, object objectToSerialize) {
            Serialize(serializedStream, objectToSerialize, FileType.XML);
        }

        public static void Serialize(Stream serializedStream, object objectToSerialize, FileType fileType) {
            switch (fileType) {
                case FileType.Binary:
                    SerializeBinary(serializedStream, objectToSerialize);
                    break;
                case FileType.XML:
                    SerializeXML(serializedStream, objectToSerialize);
                    break;
                default:
                    throw new FormatException();
            }
        }

        public static T DeSerialize<T>(string fileName) {
            using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                return DeSerialize<T>(fs);
            }
        }

        public static T DeSerialize<T>(string fileName, FileType fileType) {
            using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                return DeSerialize<T>(fs, fileType);
            }
        }

        public static T DeSerialize<T>(Stream serializedStream) {
            return DeSerialize<T>(serializedStream, FileType.XML);
        }

        public static T DeSerialize<T>(Stream serializedStream, FileType fileType) {
            switch (fileType) {
                case FileType.Binary:
                    return DeSerializeBinary<T>(serializedStream);
                case FileType.XML:
                    return DeSerializeXML<T>(serializedStream);
                default:
                    throw new FormatException();
            }
        }

        private static void SerializeBinary(Stream binaryStream, object objectToSerialize) {
            using (binaryStream) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(binaryStream, objectToSerialize);
            }
        }

        private static T DeSerializeBinary<T>(Stream binaryStream) {
            using (binaryStream) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(binaryStream);
            }
        }

        private static void SerializeXML(Stream xmlStream, object objectToSerialize) {
            using (xmlStream) {
                XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
                xmlSerializer.Serialize(xmlStream, objectToSerialize);
            }
        }

        private static T DeSerializeXML<T>(Stream xmlStream) {
            using (xmlStream) {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.CheckCharacters = false;
                return (T)xmlSerializer.Deserialize(XmlReader.Create(xmlStream, settings));
            }
        }

        public static T DeSerializeXML<T>(string xmlString) {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xmlString)) {
                return (T)xs.Deserialize(sr);
            }
        }
    }
}

using assignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace assignment.Xml
{
    public class XmlOperations
    {
        XmlSerializer serializer;
        string path;
        public XmlOperations()
        {
            serializer = new XmlSerializer(typeof(BeachCollectionXml));
            path = AppDomain.CurrentDomain.BaseDirectory + "xml/beaches.xml";
        }

        public void Serialization(BeachXml[] arrBeach)
        {
            List<string> str = new List<string>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, arrBeach);
            }
        }

        public BeachXml[] Deserialization()
        {
            List<string> str = new List<string>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BeachCollectionXml beachCollection = (BeachCollectionXml)serializer.Deserialize(fs);
                return beachCollection.arrBeach;
            }

        }
    }
}

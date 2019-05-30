using System;
using System.Xml.Serialization;

namespace assignment.Models
{
    [Serializable()]
    public class BeachXml
    {
        [XmlElement("FACILITYID")]
        public long Id { get; set; }
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("NAME_FR")]
        public string NameFr { get; set; }
        [XmlElement("ADDRESS")]
        public string Address { get; set; }
        [XmlElement("ADDRESS_FR")]
        public string AddressFr { get; set; }
        [XmlElement("BEACH_TYPE")]
        public string BeachType { get; set; }
        [XmlElement("ACCESSIBLE")]
        public string Accessible { get; set; }
        [XmlElement("OPEN")]
        public string Open { get; set; }
        [XmlElement("NOTES")]
        public string Notes { get; set; }
        [XmlElement("MODIFIED_D")]
        public string ModifiedDate { get; set; }
        [XmlElement("REATED_DA")]
        public string CreatedDate { get; set; }
        [XmlElement("LINK")]
        public string Link { get; set; }
        [XmlElement("LINK_FR")]
        public string LinkFr { get; set; }
        [XmlElement("LINK_LABEL")]
        public string LinkLabel { get; set; }
        [XmlElement("LINK_LAB_1")]
        public string LinkLab1 { get; set; }
        [XmlElement("LINK_DESCR")]
        public string LinkDescr { get; set; }
        [XmlElement("LINK_DES_1")]
        public string LinkDes1 { get; set; }
        [XmlElement("POSTAL_CODE")]
        public string PostalCode { get; set; }

        [XmlElement("PHOTO")]
        public string Photo { get; set; }
        [XmlElement("geometry", typeof(CoordinatesXml))]
        public CoordinatesXml Geometry { get; set; }
    }

    [Serializable()]
    public class CoordinatesXml 
    {
        [XmlElement("X")]
        public double X { get; set; }
        [XmlElement("Y")]
        public double Y { get; set; }
    }

    [Serializable()]
    [XmlRoot("root")]
    public class BeachCollectionXml
    {
        [XmlArray("features")]
        [XmlArrayItem("properties", typeof(BeachXml))]
        public BeachXml[] arrBeach { get; set; }
    }
}

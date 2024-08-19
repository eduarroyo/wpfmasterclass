using System.Xml.Serialization;

namespace RssReader.Model;

[XmlRoot(ElementName = "rss")]
public class Rss
{

    [XmlElement(ElementName = "channel")]
    public Channel Channel { get; set; }

    [XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Atom { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public double Version { get; set; }

    [XmlText]
    public string Text { get; set; }
}

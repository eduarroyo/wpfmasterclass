using System.Xml.Serialization;

namespace RssReader.Model;

// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Rss));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Rss)serializer.Deserialize(reader);
// }

[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
public class Link
{

    [XmlAttribute(AttributeName = "href")]
    public string Href { get; set; }

    [XmlAttribute(AttributeName = "rel")]
    public string Rel { get; set; }

    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
}
using System.Xml.Serialization;

namespace RssReader.Model;


[XmlRoot(ElementName = "guid")]
public class Guid
{

    [XmlAttribute(AttributeName = "isPermaLink")]
    public bool IsPermaLink { get; set; }

    [XmlText]
    public string Text { get; set; }
}
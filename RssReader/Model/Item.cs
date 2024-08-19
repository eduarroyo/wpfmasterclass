using System.Globalization;
using System.Xml.Serialization;

namespace RssReader.Model;

[XmlRoot(ElementName = "item")]
public class Item
{
    private static string DateTimeFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";

    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "author")]
    public string Author { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "link")]
    public string Link { get; set; }

    [XmlElement(ElementName = "guid")]
    public Guid Guid { get; set; }

    [XmlElement(ElementName = "category")]
    public string Category { get; set; }

    private string pubDate;

    [XmlElement(ElementName = "pubDate")]
    public string PubDate
    {
        get => pubDate;
        set
        {
            pubDate = value;
            PublicationDate = DateTime.ParseExact(pubDate.Insert(pubDate.Length - 2, ":"), DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }

    [XmlIgnore]
    public DateTime PublicationDate { get; private set; }

}
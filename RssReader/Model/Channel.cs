using System.Globalization;
using System.Xml.Serialization;

namespace RssReader.Model;

[XmlRoot(ElementName = "channel")]
public class Channel
{
    private static string DateTimeFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";

    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "link")]
    public List<string> Link { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "language")]
    public string Language { get; set; }

    [XmlElement(ElementName = "copyright")]
    public string Copyright { get; set; }

    private string lastBuildDate;

    [XmlElement(ElementName = "lastBuildDate")]
    public string LastBuildDateString
    {
        get => lastBuildDate;
        set
        {
            lastBuildDate = value;
            LastBuildDate = DateTime.ParseExact(lastBuildDate.Insert(lastBuildDate.Length- 2, ":"), DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }

    [XmlIgnore]
    public DateTime LastBuildDate { get; private set; }

    [XmlElement(ElementName = "generator")]
    public string Generator { get; set; }

    [XmlElement(ElementName = "docs")]
    public string Docs { get; set; }

    [XmlElement(ElementName = "item")]
    public List<Item> Items { get; set; }
}

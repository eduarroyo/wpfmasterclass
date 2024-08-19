using RssReader.Model;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace RssReader.ViewModel;

public class RssHelper
{
    private static readonly Uri uri = new("https://www.microsiervos.com/index.xml");
    
    public static async Task<List<Item>> GetPosts()
    {
        List<Item> posts = new List<Item>();
        XmlSerializer xmlSerializer = new(typeof(Rss));

        using (HttpClient client = new())
        {
            string xml = await client.GetStringAsync(uri);
            using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                Rss blog = (Rss)xmlSerializer.Deserialize(reader);
                posts = blog.Channel.Items;
            } 
        }

        return posts;
    }
}

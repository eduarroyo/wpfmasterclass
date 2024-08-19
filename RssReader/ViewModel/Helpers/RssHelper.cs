using Microsoft.Extensions.Configuration;
using RssReader.Model;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace RssReader.ViewModel;

public class RssHelper : IRssHelper
{
    private readonly Uri uri;
    
    public RssHelper(IConfiguration config)
    {
        string? url = config.GetSection("RssHelper")["url"];
        uri = new Uri(url!);
    }

    public async Task<List<Item>> GetPosts()
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

using RssReader.Model;

namespace RssReader.ViewModel;

public class FakeRssHelper : IRssHelper
{
    public Task<List<Item>> GetPosts()
    {
        string datetime = "Mon, 19 Aug 2024 18:30:00 +0100";

        List<Item> posts = 
        [
            new Item()
            {
                Title = "111111111111111",
                PubDate = datetime
            },
            new Item()
            {
                Title = "2222222222222222",
                PubDate = datetime
            },
            new Item()
            {
                Title = "33333333333333333",
                PubDate = datetime
            },
            new Item()
            {
                Title = "444444444444444444",
                PubDate = datetime
            }
        ];

        return Task.FromResult(posts);
    }
}

using RssReader.Model;

namespace RssReader.ViewModel;

public interface IRssHelper
{
    public Task<List<Item>> GetPosts();
}

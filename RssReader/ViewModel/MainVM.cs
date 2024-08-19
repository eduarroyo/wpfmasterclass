using RssReader.Model;
using System.Collections.ObjectModel;

namespace RssReader.ViewModel;

public class MainVM
{
    public ObservableCollection<Item> Items { get; set; }
    private IRssHelper rssHelper;

    public MainVM(IRssHelper rssHelper)
    {
        this.rssHelper = rssHelper;
        Items = new ObservableCollection<Item>();
        ReadRss();
    }

    private async void ReadRss()
    {
        List<Item> posts = await rssHelper.GetPosts();
        Items.Clear();
        foreach(Item item in posts)
        {
            Items.Add(item);
        }
    }
}

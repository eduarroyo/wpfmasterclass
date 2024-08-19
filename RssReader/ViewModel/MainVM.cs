using RssReader.Model;
using System.Collections.ObjectModel;

namespace RssReader.ViewModel;

public class MainVM
{
    public ObservableCollection<Item> Items { get; set; }

    public MainVM()
    {
        Items = new ObservableCollection<Item>();
        ReadRss();
    }

    private async void ReadRss()
    {
        List<Item> posts = await RssHelper.GetPosts();
        Items.Clear();
        foreach(Item item in posts)
        {
            Items.Add(item);
        }
    }
}

using RssReader.ViewModel;
using System.Windows;

namespace RssReader;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainVM vm)
    {
        this.DataContext = vm;
        InitializeComponent();
    }
}
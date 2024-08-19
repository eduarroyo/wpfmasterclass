using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RssReader.ViewModel;
using System.Text;
using System.Windows;

namespace RssReader;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; set; }
    public IConfiguration Configuration { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        Configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", false, true)
           .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, Configuration);
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(ServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddSingleton<IConfiguration>(config);
        serviceCollection.AddScoped<IRssHelper, RssHelper>();
        serviceCollection.AddScoped(typeof(MainVM));
        serviceCollection.AddTransient(typeof(MainWindow));
    }
}
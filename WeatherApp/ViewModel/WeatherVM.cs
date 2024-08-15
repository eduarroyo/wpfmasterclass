using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Models;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel;

public class WeatherVM: INotifyPropertyChanged
{
    #region Properties

    public bool DesignMode 
    {
        get => DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
    }

    private AccuWeatherHelper accuWeatherHelper;

    public SearchCommand SearchCommand { get; set; }

    private string query;
    public string Query
    {
        get => query;
        set 
        {
            query = value;
            OnPropertyChanged(nameof(Query));
        }
    }

    private CurrentConditions currentConditions;
    public CurrentConditions CurrentConditions
    {
        get => currentConditions;
        set
        {
            currentConditions = value;
            OnPropertyChanged(nameof(CurrentConditions));
        }
    }

    private City? selectedCity;
    public City? SelectedCity
    {
        get => selectedCity;
        set
        {
            selectedCity = value;
            OnPropertyChanged(nameof(SelectedCity));
            if (SelectedCity != null)
            {
                GetCurrentConditions();
            }
        }
    }

    public ObservableCollection<City> Cities { get; private set; }


    #endregion Properties

    public WeatherVM()
    {
        if (DesignMode)
        {
            DesignModeInitialization();
        }

        accuWeatherHelper = new AccuWeatherHelper();
        SearchCommand = new SearchCommand(this);
        Cities = new ObservableCollection<City>();
    }

    private void DesignModeInitialization()
    {
        SelectedCity = new City
        {
            LocalizedName = "New York City"
        };
        CurrentConditions = new CurrentConditions
        {
            WeatherText = "Partially cloudy",
            Temperature = new Temperature
            {
                Metric = new Units
                {
                    Value = "21"
                }
            }
        };
    }
    
    #region Commands

    public async Task SearchCities()
    {
        IEnumerable<City> cities = await accuWeatherHelper.GetCities(Query);
        Cities.Clear();
        foreach (City city in cities)
        {
            Cities.Add(city);
        }
    }

    public async void GetCurrentConditions()
    {
        CurrentConditions = await accuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
    }

    #endregion

    #region Implementation of INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}

﻿using System.ComponentModel;
using WeatherApp.Models;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel;

public class WeatherVM: INotifyPropertyChanged
{
    public bool DesignMode 
    {
        get => DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
    }

    #region Properties

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

    private City selectedCity;
    public City SelectedCity
    {
        get => selectedCity;
        set
        {
            selectedCity = value;
            OnPropertyChanged(nameof(SelectedCity));
        }
    }

    #endregion Properties

    public WeatherVM()
    {
        if (DesignMode)
        {
            DesignModeInitialization();
        }

        accuWeatherHelper = new AccuWeatherHelper();
        SearchCommand = new SearchCommand(this);
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
                    Value = 21
                }
            }
        };
    }

    #region Commands

    public async Task MakeQuery()
    {
        IEnumerable<City> cities = await accuWeatherHelper.GetCities(Query);
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

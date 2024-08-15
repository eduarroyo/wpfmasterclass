using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.ViewModel.Helpers;

internal class AccuWeatherHelper
{
    private const string APIKEY = "UWPpWqF3EwAXBRlYYJcFrgkBS1GFNSy6";
    private const string BASE_URL = "http://dataservice.accuweather.com/";
    private const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
    private const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

    public async Task<IEnumerable<City>> GetCities(string query)
    {
        IEnumerable<City>? cities;
        string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, APIKEY, query);
        using (HttpClient http = new())
        {
            HttpResponseMessage response = await http.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            cities = JsonSerializer.Deserialize<IEnumerable<City>>(json);
        }
        return cities ?? [];
    }

    public async Task<CurrentConditions?> GetCurrentConditions(string locationKey)
    {
        CurrentConditions? currentConditions;
        string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, locationKey, APIKEY);
        using (HttpClient http = new())
        {
            HttpResponseMessage response = await http.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            currentConditions = (JsonSerializer.Deserialize<IEnumerable<CurrentConditions>>(json))?.FirstOrDefault();
        }
        return currentConditions;
    }
}

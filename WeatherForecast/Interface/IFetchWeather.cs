using WeatherForecast.Models;

namespace WeatherForecast.Interface
{
    public interface IFetchWeather
    {
        public Task<WeatherModel> FeatchWeatherDetails(string City, string CountryCode, string apiKey);
    }
}

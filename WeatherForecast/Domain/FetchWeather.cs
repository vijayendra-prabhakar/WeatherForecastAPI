using System.Text.Json;
using WeatherForecast.Interface;
using WeatherForecast.Models;

namespace WeatherForecast.Domain
{
    public class FetchWeather : IFetchWeather
    {
        private IWeatherService _weatherService;
        public FetchWeather(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherModel> FeatchWeatherDetails(string City, string CountryCode, string apiKey)
        {
            var result = await _weatherService.GetTaskAsync(City, CountryCode, apiKey);
            var resultJson = JsonDocument.Parse(result);
            var weather = new WeatherModel();

            resultJson.RootElement.TryGetProperty("name", out var city);
            weather.City = city.ToString();

            resultJson.RootElement.TryGetProperty("wind", out var wind);

            wind.TryGetProperty("speed", out var speed);
            weather.windSpeed = speed.ToString() + " m/s";

            resultJson.RootElement.TryGetProperty("coord", out var coord);

            coord.TryGetProperty("lat", out var lat);
            weather.coordinates = new Coordinates();
            weather.coordinates.latitude = Convert.ToDouble(lat.ToString());

            coord.TryGetProperty("lon", out var lon);
            weather.coordinates.longitude = Convert.ToDouble(lon.ToString());

            resultJson.RootElement.TryGetProperty("main", out var main);

            main.TryGetProperty("temp", out var temp);
            weather.forecast = new Forecast();
            weather.forecast.temperature = temp.ToString() + "°C";

            main.TryGetProperty("temp_min", out var temp_min);
            weather.forecast.minTemperature = temp_min.ToString() + "°C";

            main.TryGetProperty("temp_max", out var temp_max);
            weather.forecast.maxTemperature = temp_max.ToString() + "°C";

            main.TryGetProperty("humidity", out var humidity);
            weather.forecast.humidity = humidity.ToString()+"%";

            resultJson.RootElement.TryGetProperty("weather", out var weatherVal);

            weatherVal[0].TryGetProperty("description", out var description);
            weather.forecast.weatherReport = description.ToString();

            return weather;            
        }
    }
}

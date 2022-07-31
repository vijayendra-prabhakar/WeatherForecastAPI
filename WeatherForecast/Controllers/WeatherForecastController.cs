using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Interface;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFetchWeather _fetchWeather;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFetchWeather fetchWeather)
        {
            _logger = logger;
            _fetchWeather = fetchWeather;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet(Name = "GetWeatherForecast/{City}/{CountryCode}/{apiKey}")]
        public async Task<WeatherModel> Get(string City, string CountryCode,string apiKey)
        {
            var result =  await _fetchWeather.FeatchWeatherDetails(City, CountryCode, apiKey);
            return result;
        }
    }
}
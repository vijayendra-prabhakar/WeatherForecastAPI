namespace WeatherForecast.Interface
{
    public interface IWeatherService
    {
        public Task<string> GetTaskAsync(string City, string CountryCode, string apiKey);
    }
}

using WeatherForecast.Interface;

namespace WeatherForecast.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;

        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetTaskAsync(string City, string CountryCode, string apiKey)
        {
            using (var client = new HttpClient())
            {
                var apiProvider = _configuration.GetValue<string>("ProviderUrl");
                client.BaseAddress = new Uri($"{apiProvider}{City},{CountryCode}&appid={apiKey}&units=metric");
                var result = await client.GetAsync(client.BaseAddress);
                var resultContent = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                return resultContent;
            }
        }
    }
}

namespace WeatherForecast.Models
{
    public class WeatherModel
    {
        public Coordinates coordinates { get; set; }
        public Forecast forecast { get; set; }
        public string City { get; set; }
        public string windSpeed { get; set; }
    }

    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Forecast
    {
        public string temperature { get; set; }
        public string minTemperature { get; set; }
        public string maxTemperature { get; set; }
        public string humidity { get; set; }
        public string weatherReport { get; set; }
    }
}
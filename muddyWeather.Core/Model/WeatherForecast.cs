using System.Collections.Generic;

namespace muddyWeather.Core.Model
{
    public class WeatherForecast
    {
        public IEnumerable<DayForcast> Daily { get; set; }
    }
}
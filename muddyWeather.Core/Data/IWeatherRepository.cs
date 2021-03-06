using muddyWeather.Core.Model;

using System;
using System.Threading.Tasks;

namespace muddyWeather.Core.Data
{
    public interface IWeatherRepository
    {
        Task<WeatherForecast> GetWeatherForecastAsync(GeoLocation location);
    }
}

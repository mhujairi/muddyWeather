using muddyWeather.Core.Model;

using System.Threading.Tasks;

namespace muddyWeather.Core.Data
{
    public interface IWeatherRepository
    {
        Task<WeatherForecast> GetAsync(GeoLocation location);
    }
}

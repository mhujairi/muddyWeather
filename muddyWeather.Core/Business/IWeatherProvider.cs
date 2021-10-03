using muddyWeather.Core.Model;

using System.Threading.Tasks;

namespace muddyWeather.Core.Business
{
    public interface IWeatherProvider
    {
        Task<bool> IsMuddyAsync(GeoLocation geoLocation);
    }
}
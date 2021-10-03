
using muddyWeather.Core.Data;
using muddyWeather.Core.Model;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace muddyWeather.Core.Business
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IWeatherRepository weatherRepository;
        private readonly int daysToCheck;
        private readonly double rainPersent;
        private readonly double freezingTemp;

        public WeatherProvider(IWeatherRepository weatherRepository, int daysToCheck, double rainPersent, double freezingTemp)
        {
            if (weatherRepository is null)
            {
                throw new ArgumentNullException(nameof(weatherRepository));
            }

            this.weatherRepository = weatherRepository;
            this.daysToCheck = daysToCheck;
            this.rainPersent = rainPersent;
            this.freezingTemp = freezingTemp;
        }

        public async Task<bool> IsMuddyAsync(GeoLocation geoLocation)
        {
            var forcast = await weatherRepository.GetWeatherForecastAsync(geoLocation);

            foreach (var dayForcast in forcast.Daily.Take(daysToCheck))
            {
                //if it does not in the next 3 consagitive days then it will not be muddly
                if (dayForcast.Rain == null || dayForcast.Rain < rainPersent)
                {
                    return false;
                }

                //if it freezes in the next 3 consagitive days then it will not be muddly
                if (dayForcast.temp.Max <= freezingTemp || dayForcast.temp.Min <= freezingTemp)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
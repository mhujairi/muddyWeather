using muddyWeather.Core.Model;

using System.Threading.Tasks;

namespace muddyWeather.Core.Data
{
    public class OpenWeatherRepository : IWeatherRepository
    {
        private readonly string appId;
        private readonly string baseUrl;

        public OpenWeatherRepository(string appId,string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new System.ArgumentException($"'{nameof(appId)}' cannot be null or whitespace.", nameof(appId));
            }

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new System.ArgumentException($"'{nameof(baseUrl)}' cannot be null or whitespace.", nameof(baseUrl));
            }

            this.appId = appId;
            this.baseUrl = baseUrl;
        }

        public async Task<WeatherForecast> GetAsync(GeoLocation location)
        {
            throw new System.NotImplementedException();
        }
    }
}

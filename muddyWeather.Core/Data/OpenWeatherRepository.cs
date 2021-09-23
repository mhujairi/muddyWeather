using muddyWeather.Core.Model;

using RestSharp;

using System;
using System.Threading.Tasks;

namespace muddyWeather.Core.Data
{
    public class OpenWeatherRepository : IWeatherRepository
    {
        private readonly string appId;
        private readonly IRestClient client;

        public OpenWeatherRepository(string appId,IRestClient client)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new System.ArgumentException($"'{nameof(appId)}' cannot be null or whitespace.", nameof(appId));
            }

            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.appId = appId;
            this.client = client;
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(GeoLocation location)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            var request = new RestRequest("onecall", Method.GET)
                .AddParameter("lat", location.Latitude)
                .AddParameter("lon", location.Longitude)
                .AddParameter("exclude", "current,minutely,hourly,alerts")
                .AddParameter("appid", appId)
                ;
            var response = await client.ExecuteAsync<WeatherForecast>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            if(response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            if(response.IsSuccessful == false)
            {
                throw new Exception(response.StatusDescription);
            }

            return response.Data;
        }

    }
}

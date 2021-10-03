using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using muddyWeather.Core.Business;
using muddyWeather.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muddyWeather.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWeatherProvider weatherProvider;

        public IndexModel(IWeatherProvider weatherProvider, IConfiguration configuration)
        {
            if (weatherProvider is null)
            {
                throw new ArgumentNullException(nameof(weatherProvider));
            }

            this.weatherProvider = weatherProvider;

            GeoLocation = new GeoLocation
            {
                Latitude = long.Parse(configuration["muddyWeather:goeLocation:Latitude"]),
                Longitude = long.Parse(configuration["muddyWeather:goeLocation:Longitude"])
            };
        }

        public async void OnGet()
        {
            IsMuddy =await  weatherProvider.IsMuddyAsync(GeoLocation);
        }

        public bool IsMuddy { get; private set; }

        public GeoLocation GeoLocation { get; set; }
    }
}

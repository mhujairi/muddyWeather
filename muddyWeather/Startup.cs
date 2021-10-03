using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using muddyWeather.Core.Business;
using muddyWeather.Core.Data;
using muddyWeather.Core.Model;

using RestSharp;

namespace muddyWeather
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            openWeatherApiKey = Configuration["muddyWeather:openWeatherApiKey"];
            openWeatherApiUrl = Configuration["muddyWeather:openWeatherApiUrl"];
            daysToCheck = int.Parse(Configuration["muddyWeather:daysToCheck"]);
            rainyPercent =double.Parse(Configuration["muddyWeather:rainyPercent"]);
            frozenTempreture = double.Parse(Configuration["muddyWeather:frozenTempreture"]);

        }

        public IConfiguration Configuration { get; }

        private string openWeatherApiKey;
        private string openWeatherApiUrl;
        private int daysToCheck;
        private double rainyPercent;
        private double frozenTempreture;
        private GeoLocation geoLocation;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IRestClient, RestClient>(
                serviceProvider =>
                {
                    return new RestSharp.RestClient(
                       openWeatherApiUrl
                    );
                }
            );

            services.AddScoped<IWeatherRepository, OpenWeatherRepository>(
                serviceProvider =>
                {
                    return new OpenWeatherRepository(
                        appId: openWeatherApiKey,
                        client: serviceProvider.GetRequiredService<IRestClient>()
                    );
                }
            );

            services.AddScoped<IWeatherProvider, WeatherProvider>(
                serviceProvider =>
                {
                    return new WeatherProvider(
                        weatherRepository:serviceProvider.GetRequiredService<IWeatherRepository>(),
                        daysToCheck: daysToCheck,
                        rainPersent: rainyPercent,
                        freezingTemp: frozenTempreture
                    );
                }
            );

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

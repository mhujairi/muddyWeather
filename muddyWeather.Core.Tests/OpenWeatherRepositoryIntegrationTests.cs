using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using muddyWeather.Core.Data;
using muddyWeather.Core.Model;

using System;
using System.IO;

namespace muddyWeather.Core.Tests
{
    [TestClass]
    public class OpenWeatherRepositoryIntegrationTests
    {
        // A class that contains MSTest unit tests. (Required)
        [TestClass]
        public class YourUnitTests
        {
            private static string openWeatherApiKey;
            private OpenWeatherRepository subject;

            [ClassInitialize]
            public static void TestFixtureSetup(TestContext context)
            {
                var thisAssembly = typeof(YourUnitTests).Assembly;
                var appSettings = new ConfigurationBuilder()
                    .AddUserSecrets(thisAssembly)
                    .Build();

                openWeatherApiKey = "261f3a94d947281c26f2b6181db830a0";// appSettings["muddyWeather:openWeatherApiKey"];


            }

            [TestInitialize]
            public void Setup()
            {
                // Runs before each test. (Optional)
                subject = new OpenWeatherRepository(
                    appId: openWeatherApiKey,
                    client: new RestSharp.RestClient(
                        "http://api.openweathermap.org/data/2.5"
                        )
                    );
            }

            [ClassCleanup]
            public static void TestFixtureTearDown()
            {
                // Runs once after all tests in this class are executed. (Optional)
                // Not guaranteed that it executes instantly after all tests from the class.
            }

            [TestCleanup]
            public void TearDown()
            {
                // Runs after each test. (Optional)
            }

            // Mark that this is a unit test method. (Required)
            [TestMethod]
            [ExpectedException(typeof(Exception), "Unauthorized")]
            public void UnAuthrized()
            {
                // Your test code goes here.
                var location = new GeoLocation();
                subject = new OpenWeatherRepository(
                    appId: "Dummy",
                    client: new RestSharp.RestClient(
                        "http://pro.openweathermap.org/data/2.5/forecast"
                        )
                    );
                var result = subject.GetWeatherForecastAsync(location).Await();

            }

            [TestMethod]
            public void SuccessfullCall()
            {
                // Your test code goes here.
                var location = new GeoLocation();
                var result = subject.GetWeatherForecastAsync(location).Await();

            }
        }
    }
}

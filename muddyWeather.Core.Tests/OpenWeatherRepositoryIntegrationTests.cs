using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using muddyWeather.Core.Data;
using muddyWeather.Core.Model;

using System;
using System.Linq;

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

                openWeatherApiKey = appSettings["muddyWeather:openWeatherApiKey"];
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
                //Assemble
                var location = new GeoLocation();
                subject = new OpenWeatherRepository(
                    appId: "Dummy",
                    client: new RestSharp.RestClient(
                        "http://pro.openweathermap.org/data/2.5/forecast"
                        )
                    );

                //Action
                var result = subject.GetWeatherForecastAsync(location).Await();

            }

            [TestMethod]
            public void SuccessfullCall()
            {
                //Assemble
                var location = new GeoLocation();

                //Action
                var result = subject.GetWeatherForecastAsync(location).Await();

                //Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Daily);
                Assert.IsTrue(result.Daily.Count() > 0);
            }
        }
    }
}

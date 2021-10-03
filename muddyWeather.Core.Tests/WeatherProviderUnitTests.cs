using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using muddyWeather.Core.Business;
using muddyWeather.Core.Data;
using muddyWeather.Core.Model;

using System.Threading.Tasks;

namespace muddyWeather.Core.Tests
{
    [TestClass]
    public class WeatherProviderUnitTests
    {
        private Mock<IWeatherRepository> mockWeatherRepository;
        private WeatherProvider subject;
        private static Tempreture notFrozenTempreture;
        private static DayForcast notFrozenRainyDay;
        private static DayForcast notFrozenDryDay;
        private static DayForcast frozenRainyDay;
        private static DayForcast frozenDryDay;
        private static double rainy;
        private static Tempreture frozenTempreture;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            rainy = .1;

            frozenTempreture = new Tempreture
            {
                Min = 0,
                Max = 0
            };

            notFrozenTempreture =  new Tempreture
            {
                Min = 10,
                Max = 20
            };

            notFrozenRainyDay = new DayForcast
            {
                Rain = rainy,
                temp = notFrozenTempreture
            };

            notFrozenDryDay = new DayForcast
            {
                Rain = null,
                temp = notFrozenTempreture
            };

            frozenRainyDay = new DayForcast
            {
                Rain = rainy,
                temp = frozenTempreture
            };

            frozenDryDay = new DayForcast
            {
                Rain = null,
                temp = frozenTempreture
            };
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            mockWeatherRepository = new Mock<IWeatherRepository>();
            subject = new WeatherProvider(
                mockWeatherRepository.Object,
                daysToCheck:3,
                freezingTemp: frozenTempreture.Max,
                rainPersent:rainy);
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
        public void MuddyWeatherTest1()
        {
            //Assemble
            var location = new GeoLocation();

            var muddyWather = new WeatherForecast
            {
                Daily = new []
                {
                    notFrozenRainyDay,
                    notFrozenRainyDay,
                    notFrozenRainyDay,
                }
            };

            mockWeatherRepository.Setup(
                repo => repo.GetWeatherForecastAsync(location)
                ).Returns(Task.FromResult(muddyWather));

            //Action
            var result = subject.IsMuddyAsync(location).Await();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotMuddyWeatherTest1()
        {
            //Assemble
            var location = new GeoLocation();

            var muddyWather = new WeatherForecast
            {
                Daily = new[]
                {
                    frozenRainyDay,
                    notFrozenRainyDay,
                    notFrozenRainyDay,
                }
            };

            mockWeatherRepository.Setup(
                repo => repo.GetWeatherForecastAsync(location)
                ).Returns(Task.FromResult(muddyWather));

            //Action
            var result = subject.IsMuddyAsync(location).Await();

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void NotMuddyWeatherTest2()
        {
            //Assemble
            var location = new GeoLocation();

            var muddyWather = new WeatherForecast
            {
                Daily = new[]
                {
                    notFrozenDryDay,
                    notFrozenRainyDay,
                    notFrozenRainyDay,
                }
            };

            mockWeatherRepository.Setup(
                repo => repo.GetWeatherForecastAsync(location)
                ).Returns(Task.FromResult(muddyWather));

            //Action
            var result = subject.IsMuddyAsync(location).Await();

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void NotMuddyWeatherTest3()
        {
            //Assemble
            var location = new GeoLocation();

            var muddyWather = new WeatherForecast
            {
                Daily = new[]
                {
                    frozenDryDay,
                    notFrozenRainyDay,
                    notFrozenRainyDay,
                }
            };

            mockWeatherRepository.Setup(
                repo => repo.GetWeatherForecastAsync(location)
                ).Returns(Task.FromResult(muddyWather));

            //Action
            var result = subject.IsMuddyAsync(location).Await();

            //Assert
            Assert.IsFalse(result);
        }
    }
}

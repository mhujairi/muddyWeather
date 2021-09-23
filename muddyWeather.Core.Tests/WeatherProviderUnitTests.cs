using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace muddyWeather.Core.Tests
{
    public class WeatherProviderUnitTests
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
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
        public void YouTestMethod()
        {
            // Your test code goes here.
        }
    }
}

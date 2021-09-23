using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace muddyWeather.Core.Tests
{
    [TestClass]
    public class ProjectAssembly
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Executes once before the test run. (Optional)
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
        }
    }
}

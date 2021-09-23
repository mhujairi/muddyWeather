using System.Threading.Tasks;

namespace muddyWeather.Core.Tests
{
    public static class TaskExt
    {
        public static T Await<T>(this Task<T> task)
        {
            try
            {
                Task.WaitAll(task);
                return task.Result;
            }
            catch (System.AggregateException ex)
            {

                throw ex.InnerExceptions[0];
            }
        }
    }
}

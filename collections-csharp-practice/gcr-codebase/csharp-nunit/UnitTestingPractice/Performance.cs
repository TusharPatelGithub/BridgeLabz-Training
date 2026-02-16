using System.Threading;

namespace PerformanceUtilities
{
    public class PerformanceService
    {
        public string LongRunningTask()
        {
            // Simulate long-running operation
            Thread.Sleep(3000);
            return "Completed";
        }
    }
}

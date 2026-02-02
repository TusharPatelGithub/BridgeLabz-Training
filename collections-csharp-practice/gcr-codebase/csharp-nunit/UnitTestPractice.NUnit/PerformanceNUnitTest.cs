using NUnit.Framework;
using PerformanceUtilities;

namespace PerformanceUtilities.Tests.NUnit
{
    public class PerformanceServiceTests
    {
        private PerformanceService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PerformanceService();
        }

        [Test]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFailIfExceedsTimeout()
        {
            _service.LongRunningTask();
        }
    }
}

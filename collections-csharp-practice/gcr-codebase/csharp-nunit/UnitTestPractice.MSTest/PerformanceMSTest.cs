using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceUtilities;

namespace PerformanceUtilities.Tests.MSTest
{
    [TestClass]
    public class PerformanceServiceTests
    {
        private PerformanceService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new PerformanceService();
        }

        [TestMethod]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFailIfExceedsTimeout()
        {
            _service.LongRunningTask();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateUtilities;
using System;

namespace DateUtilities.Tests.MSTest
{
    [TestClass]
    public class DateFormatterTests
    {
        private DateFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        [TestMethod]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string result = _formatter.FormatDate("2025-01-15");

            Assert.AreEqual("15-01-2025", result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatDate_InvalidFormat_ThrowsException()
        {
            _formatter.FormatDate("15/01/2025");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatDate_InvalidDate_ThrowsException()
        {
            _formatter.FormatDate("2025-13-40");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatDate_NullInput_ThrowsException()
        {
            _formatter.FormatDate(null);
        }
    }
}

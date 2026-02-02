using NUnit.Framework;
using DateUtilities;
using System;

namespace DateUtilities.Tests.NUnit
{
    public class DateFormatterTests
    {
        private DateFormatter _formatter;

        [SetUp]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        [TestCase("2024-12-31", "31-12-2024")]
        [TestCase("2025-01-01", "01-01-2025")]
        public void FormatDate_ValidDates_ReturnFormattedDate(string input, string expected)
        {
            string result = _formatter.FormatDate(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("31-12-2024")]
        [TestCase("2024/12/31")]
        [TestCase("2024-99-99")]
        [TestCase("")]
        [TestCase(null)]
        public void FormatDate_InvalidDates_ThrowFormatException(string input)
        {
            Assert.Throws<FormatException>(() =>
                _formatter.FormatDate(input)
            );
        }
    }
}

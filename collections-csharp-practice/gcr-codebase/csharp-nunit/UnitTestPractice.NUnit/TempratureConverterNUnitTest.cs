using NUnit.Framework;
using UtilityConverters;

namespace UtilityConverters.Tests.NUnit
{
    public class TemperatureConverterTests
    {
        private TemperatureConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        public void CelsiusToFahrenheit_ValidValues_ReturnsCorrectResult(double celsius, double expectedFahrenheit)
        {
            double result = _converter.CelsiusToFahrenheit(celsius);
            Assert.AreEqual(expectedFahrenheit, result, 0.001);
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        public void FahrenheitToCelsius_ValidValues_ReturnsCorrectResult(double fahrenheit, double expectedCelsius)
        {
            double result = _converter.FahrenheitToCelsius(fahrenheit);
            Assert.AreEqual(expectedCelsius, result, 0.001);
        }
    }
}

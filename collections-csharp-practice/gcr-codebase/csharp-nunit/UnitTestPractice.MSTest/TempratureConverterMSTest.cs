using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityConverters;

namespace UtilityConverters.Tests.MSTest
{
    [TestClass]
    public class TemperatureConverterTests
    {
        private TemperatureConverter _converter;

        [TestInitialize]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [TestMethod]
        public void CelsiusToFahrenheit_ZeroCelsius_Returns32Fahrenheit()
        {
            double result = _converter.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result, 0.001);
        }

        [TestMethod]
        public void CelsiusToFahrenheit_HundredCelsius_Returns212Fahrenheit()
        {
            double result = _converter.CelsiusToFahrenheit(100);
            Assert.AreEqual(212, result, 0.001);
        }

        [TestMethod]
        public void FahrenheitToCelsius_ThirtyTwoFahrenheit_ReturnsZeroCelsius()
        {
            double result = _converter.FahrenheitToCelsius(32);
            Assert.AreEqual(0, result, 0.001);
        }

        [TestMethod]
        public void FahrenheitToCelsius_TwoTwelveFahrenheit_ReturnsHundredCelsius()
        {
            double result = _converter.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result, 0.001);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
using System;
namespace CalculatorApp.Tests.MSTest
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;
        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = _calculator.Add(10, 5);
            Assert.AreEqual(15, result);
        }
        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int result = _calculator.Subtract(10, 5);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int result = _calculator.Multiply(10, 5);
            Assert.AreEqual(50, result);
        }
        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int result = _calculator.Divide(10, 5);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsException()
        {
            _calculator.Divide(10, 0);
        }
    }
}

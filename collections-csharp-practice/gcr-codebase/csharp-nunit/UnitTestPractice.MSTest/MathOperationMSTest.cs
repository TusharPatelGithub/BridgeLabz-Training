using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathUtilities;
using System;

namespace MathUtilities.Tests.MSTest
{
    [TestClass]
    public class MathOperationsTests
    {
        private MathOperations _math;

        [TestInitialize]
        public void Setup()
        {
            _math = new MathOperations();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            _math.Divide(10, 0);
        }

        [TestMethod]
        public void Divide_ValidNumbers_ReturnsQuotient()
        {
            int result = _math.Divide(10, 2);
            Assert.AreEqual(5, result);
        }
    }
}

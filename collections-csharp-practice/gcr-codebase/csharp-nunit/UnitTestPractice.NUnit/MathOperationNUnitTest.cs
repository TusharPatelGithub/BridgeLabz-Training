using NUnit.Framework;
using MathUtilities;
using System;

namespace MathUtilities.Tests.NUnit
{
    public class MathOperationsTests
    {
        private MathOperations _math;

        [SetUp]
        public void Setup()
        {
            _math = new MathOperations();
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() => _math.Divide(10, 0));
        }

        [Test]
        public void Divide_ValidNumbers_ReturnsQuotient()
        {
            int result = _math.Divide(10, 2);
            Assert.AreEqual(5, result);
        }
    }
}

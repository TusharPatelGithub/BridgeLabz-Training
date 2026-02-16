using NUnit.Framework;
using NumberUtilities;

namespace NumberUtilities.Tests.NUnit
{
    public class NumberUtilsTests
    {
        private NumberUtils _numberUtils;

        [SetUp]
        public void Setup()
        {
            _numberUtils = new NumberUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_MultipleValues_ReturnsExpectedResult(int number, bool expected)
        {
            bool result = _numberUtils.IsEven(number);
            Assert.AreEqual(expected, result);
        }
    }
}

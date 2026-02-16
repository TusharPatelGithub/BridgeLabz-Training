using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberUtilities;

namespace NumberUtilities.Tests.MSTest
{
    [TestClass]
    public class NumberUtilsTests
    {
        private NumberUtils _numberUtils;

        [TestInitialize]
        public void Setup()
        {
            _numberUtils = new NumberUtils();
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_MultipleValues_ReturnsExpectedResult(int number, bool expected)
        {
            bool result = _numberUtils.IsEven(number);
            Assert.AreEqual(expected, result);
        }
    }
}

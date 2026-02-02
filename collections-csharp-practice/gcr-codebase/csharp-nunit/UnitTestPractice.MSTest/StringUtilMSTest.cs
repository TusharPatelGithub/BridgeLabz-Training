using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringUtilities;
namespace StringUtilities.Tests.MSTest
{
    [TestClass]
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;
        [TestInitialize]
        public void Setup()
        {
            _stringUtils = new StringUtils();
        }
        [TestMethod]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = _stringUtils.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }
        [TestMethod]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            bool result = _stringUtils.IsPalindrome("madam");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            bool result = _stringUtils.IsPalindrome("hello");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ToUpperCase_LowerCaseString_ReturnsUpperCase()
        {
            string result = _stringUtils.ToUpperCase("hello");
            Assert.AreEqual("HELLO", result);
        }
        [TestMethod]
        public void Reverse_NullString_ReturnsNull()
        {
            string result = _stringUtils.Reverse(null);
            Assert.IsNull(result);
        }
    }
}

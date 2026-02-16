using NUnit.Framework;
using StringUtilities;
namespace StringUtilities.Tests.NUnit
{
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;
        [SetUp]
        public void Setup()
        {
            _stringUtils = new StringUtils();
        }
        [Test]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = _stringUtils.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }
        [Test]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            bool result = _stringUtils.IsPalindrome("madam");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            bool result = _stringUtils.IsPalindrome("hello");
            Assert.IsFalse(result);
        }
        [Test]
        public void ToUpperCase_LowerCaseString_ReturnsUpperCase()
        {
            string result = _stringUtils.ToUpperCase("hello");
            Assert.AreEqual("HELLO", result);
        }
        [Test]
        public void Reverse_NullString_ReturnsNull()
        {
            string result = _stringUtils.Reverse(null);
            Assert.IsNull(result);
        }
    }
}

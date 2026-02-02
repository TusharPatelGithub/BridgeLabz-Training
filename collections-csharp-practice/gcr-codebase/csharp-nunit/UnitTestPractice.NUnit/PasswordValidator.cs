using NUnit.Framework;
using SecurityUtilities;

namespace SecurityUtilities.Tests.NUnit
{
    public class PasswordValidatorTests
    {
        private PasswordValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        [TestCase("StrongPass1", true)]
        [TestCase("short1A", false)]
        [TestCase("password1", false)]
        [TestCase("Password", false)]
        [TestCase(null, false)]
        public void IsValid_MultiplePasswords_ReturnsExpectedResult(string password, bool expected)
        {
            bool result = _validator.IsValid(password);
            Assert.AreEqual(expected, result);
        }
    }
}

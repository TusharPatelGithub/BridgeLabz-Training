using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityUtilities;

namespace SecurityUtilities.Tests.MSTest
{
    [TestClass]
    public class PasswordValidatorTests
    {
        private PasswordValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        [TestMethod]
        public void IsValid_ValidPassword_ReturnsTrue()
        {
            bool result = _validator.IsValid("StrongPass1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_TooShortPassword_ReturnsFalse()
        {
            bool result = _validator.IsValid("Ab1");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NoUppercase_ReturnsFalse()
        {
            bool result = _validator.IsValid("password1");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NoDigit_ReturnsFalse()
        {
            bool result = _validator.IsValid("Password");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_NullPassword_ReturnsFalse()
        {
            bool result = _validator.IsValid(null);
            Assert.IsFalse(result);
        }
    }
}

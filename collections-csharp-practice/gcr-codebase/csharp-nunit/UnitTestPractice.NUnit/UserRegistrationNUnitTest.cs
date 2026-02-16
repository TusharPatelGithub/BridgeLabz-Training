using NUnit.Framework;
using UserManagement;
using System;

namespace UserManagement.Tests.NUnit
{
    public class UserRegistrationTests
    {
        private UserRegistration _registration;

        [SetUp]
        public void Setup()
        {
            _registration = new UserRegistration();
        }

        [Test]
        public void RegisterUser_ValidInput_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() =>
                _registration.RegisterUser(
                    "john_doe",
                    "john@example.com",
                    "secure123"
                )
            );
        }

        [TestCase("", "john@example.com", "secure123")]
        [TestCase("john_doe", "johnexample.com", "secure123")]
        [TestCase("john_doe", "john@example.com", "123")]
        [TestCase(null, "john@example.com", "secure123")]
        public void RegisterUser_InvalidInput_ThrowsArgumentException(
            string username, string email, string password)
        {
            Assert.Throws<ArgumentException>(() =>
                _registration.RegisterUser(username, email, password)
            );
        }
    }
}

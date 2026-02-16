using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManagement;
using System;

namespace UserManagement.Tests.MSTest
{
    [TestClass]
    public class UserRegistrationTests
    {
        private UserRegistration _registration;

        [TestInitialize]
        public void Setup()
        {
            _registration = new UserRegistration();
        }

        [TestMethod]
        public void RegisterUser_ValidInput_DoesNotThrowException()
        {
            _registration.RegisterUser(
                "john_doe",
                "john@example.com",
                "secure123"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_InvalidUsername_ThrowsException()
        {
            _registration.RegisterUser(
                "",
                "john@example.com",
                "secure123"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            _registration.RegisterUser(
                "john_doe",
                "johnexample.com",
                "secure123"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_ShortPassword_ThrowsException()
        {
            _registration.RegisterUser(
                "john_doe",
                "john@example.com",
                "123"
            );
        }
    }
}

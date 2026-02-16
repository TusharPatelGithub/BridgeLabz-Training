using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingDomain;
using System;

namespace BankingDomain.Tests.MSTest
{
    [TestClass]
    public class BankAccountTests
    {
        private BankAccount _account;

        [TestInitialize]
        public void Setup()
        {
            _account = new BankAccount(1000);
        }

        [TestMethod]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            _account.Deposit(500);

            Assert.AreEqual(1500, _account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            _account.Withdraw(300);

            Assert.AreEqual(700, _account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_InsufficientFunds_ShouldFail()
        {
            _account.Withdraw(2000);
        }

        [TestMethod]
        public void GetBalance_ReturnsCorrectBalance()
        {
            Assert.AreEqual(1000, _account.GetBalance());
        }
    }
}

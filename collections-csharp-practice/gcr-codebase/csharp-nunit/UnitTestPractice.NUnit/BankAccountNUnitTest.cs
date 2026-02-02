using NUnit.Framework;
using BankingDomain;
using System;

namespace BankingDomain.Tests.NUnit
{
    public class BankAccountTests
    {
        private BankAccount _account;

        [SetUp]
        public void Setup()
        {
            _account = new BankAccount(1000);
        }

        [Test]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            _account.Deposit(500);

            Assert.AreEqual(1500, _account.GetBalance());
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            _account.Withdraw(300);

            Assert.AreEqual(700, _account.GetBalance());
        }

        [Test]
        public void Withdraw_InsufficientFunds_ShouldFail()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _account.Withdraw(2000)
            );
        }

        [Test]
        public void GetBalance_ReturnsCorrectBalance()
        {
            Assert.AreEqual(1000, _account.GetBalance());
        }
    }
}

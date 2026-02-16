using NUnit.Framework;
using System;
//marks this class as a test class
[TestFixture]
public class UnitTest
{
    //tests whether deposit correctly increases balance
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000);
        account.Deposit(500);
        Assert.AreEqual(1500, account.Balance);
    }
    //tests whether deposit throws exception for negative amount
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000);
        Exception ex = Assert.Throws<Exception>(() => account.Deposit(-200));
        Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
    }
    //tests whether withdraw correctly decreases balance
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000);
        account.Withdraw(400);
        Assert.AreEqual(600, account.Balance);
    }
    //tests whether withdraw throws exception when balance is insufficient
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500);
        Exception ex = Assert.Throws<Exception>(() => account.Withdraw(800));
        Assert.AreEqual("Insufficient funds.", ex.Message);
    }
}

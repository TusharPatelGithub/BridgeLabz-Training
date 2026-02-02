using System;
public class Program
{
    public decimal Balance { get; private set; }
    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }
    //adds amount to balance, throws exception if amount is negative
    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new Exception("Deposit amount cannot be negative");
        Balance += amount;
    }
    //deducts amount from balance, throws exception if insufficient funds
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds.");
        Balance -= amount;
    }
}

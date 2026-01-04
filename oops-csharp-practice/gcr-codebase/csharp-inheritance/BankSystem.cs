using System;

class BankAccount
{
    public int AccountNumber;
    public double Balance;

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
}

class SavingsAccount : BankAccount
{
    public double InterestRate;

    public SavingsAccount(int accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type : Savings Account");
    }
}

class CheckingAccount : BankAccount
{
    public double WithdrawalLimit;

    public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
        : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type : Checking Account");
    }
}

class FixedDepositAccount : BankAccount
{
    public int LockInPeriod;

    public FixedDepositAccount(int accountNumber, double balance, int lockInPeriod)
        : base(accountNumber, balance)
    {
        LockInPeriod = lockInPeriod;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type : Fixed Deposit Account");
    }
}

class BankSystem
{
    static void Main(string[] args)
    {
        SavingsAccount sa = new SavingsAccount(101, 50000, 4.5);
        CheckingAccount ca = new CheckingAccount(102, 30000, 10000);
        FixedDepositAccount fd = new FixedDepositAccount(103, 100000, 24);

        sa.DisplayAccountType();
        ca.DisplayAccountType();
        fd.DisplayAccountType();
    }
}

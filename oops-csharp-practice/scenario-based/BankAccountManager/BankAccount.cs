class BankAccount
{
    public string Name;
    public int AccountNumber;
    public int Balance;

    public BankAccount(string name, int accountNumber, int balance)
    {
        Name = name;
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public void Deposit(int amount)
    {
        Balance += amount;
        Console.WriteLine("Updated Balance: " + Balance);
    }

    public void Withdraw(int amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }
        Balance -= amount;
        Console.WriteLine("Updated Balance: " + Balance);
    }
}

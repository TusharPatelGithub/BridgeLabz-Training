class BankAccount{
    double balance = 5000;
    public void Withdraw(double amount){
        if (amount < 0)
            throw new ArgumentException("Invalid amount!");
        if (amount > balance)
            throw new InsufficientFundsException("Insufficient balance!");
        balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + balance);
    }
}
class BankAccount
{
   
    String name;
    int AccountNumber;
    int balance;
     BankAccount(int name, int AccountNumber,int balance)
    {
        this.name=name;
        this.AccountNumber=AccountNumber;
        this.balance=balance;
    }
    
    private void Deposit(int ammount)
    {
        balance=balance+ammount;
        Console.WriteLine($"Your updated balance is {balance}");
    }
    private void Withdraw(int amount)
    {
        balance=balance-amount;
        Console.WriteLine($"Your updated balance is{balance}");
        
    }

}
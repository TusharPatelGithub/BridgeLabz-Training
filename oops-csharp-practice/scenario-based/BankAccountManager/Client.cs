class Client
{
    public void Run()
    {
        BankAccount[] accounts = new BankAccount[3];

        accounts[0] = new BankAccount("Tushar", 101, 5000);
        accounts[1] = new BankAccount("Amit", 102, 3000);
        accounts[2] = new BankAccount("Neha", 103, 7000);

        Console.Write("Enter account number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        BankAccount selected = null;

        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accNo)
            {
                selected = acc;
                break;
            }
        }

        if (selected == null)
        {
            Console.WriteLine("Account not found!");
            return;
        }

        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. View All Accounts");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter amount: ");
            selected.Deposit(Convert.ToInt32(Console.ReadLine()));
        }
        else if (choice == 2)
        {
            Console.Write("Enter amount: ");
            selected.Withdraw(Convert.ToInt32(Console.ReadLine()));
        }
        else if (choice == 3)
        {
            Manager manager = new Manager();
            manager.ViewAllAccounts(accounts);
        }
    }
}

using System;
using System.Collections.Generic;
class BankingSystem
{
    // Store account balances: AccountNumber -> Balance
    private Dictionary<int, double> accounts = new Dictionary<int, double>();
    // Queue for withdrawal requests (AccountNumber, Amount)
    private Queue<Tuple<int, double>> withdrawalQueue = new Queue<Tuple<int, double>>();
    // Add a new account
    public void AddAccount(int accountNumber, double balance)
    {
        if (!accounts.ContainsKey(accountNumber))
        {
            accounts[accountNumber] = balance;
            Console.WriteLine($"Account {accountNumber} added with balance ${balance:0.00}");
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} already exists.");
        }
    }
    // Add withdrawal request to queue
    public void RequestWithdrawal(int accountNumber, double amount)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            withdrawalQueue.Enqueue(new Tuple<int, double>(accountNumber, amount));
            Console.WriteLine($"Withdrawal request queued: Account {accountNumber}, Amount ${amount:0.00}");
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} does not exist.");
        }
    }
    // Process all withdrawals in queue
    public void ProcessWithdrawals()
    {
        Console.WriteLine("\nProcessing Withdrawals:");
        while (withdrawalQueue.Count > 0)
        {
            var request = withdrawalQueue.Dequeue();
            int acc = request.Item1;
            double amount = request.Item2;
            if (accounts[acc] >= amount)
            {
                accounts[acc] -= amount;
                Console.WriteLine($"Withdrawal successful: Account {acc}, Amount ${amount:0.00}, New Balance ${accounts[acc]:0.00}");
            }
            else
            {
                Console.WriteLine($"Withdrawal failed: Account {acc}, Amount ${amount:0.00}, Insufficient Balance ${accounts[acc]:0.00}");
            }
        }
    }
    // Display all accounts sorted by balance
    public void DisplayAccountsByBalance()
    {
        Console.WriteLine("\nAccounts sorted by balance:");
        // SortedDictionary: Balance -> List of Accounts with that balance
        SortedDictionary<double, List<int>> sortedAccounts = new SortedDictionary<double, List<int>>();
        foreach (var pair in accounts)
        {
            double balance = pair.Value;
            int accNum = pair.Key;
            if (!sortedAccounts.ContainsKey(balance))
                sortedAccounts[balance] = new List<int>();
            sortedAccounts[balance].Add(accNum);
        }
        // Display sorted
        foreach (var pair in sortedAccounts)
        {
            foreach (int accNum in pair.Value)
            {
                Console.WriteLine($"Account {accNum}: ${pair.Key:0.00}");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        BankingSystem bank = new BankingSystem();
        // Add accounts
        bank.AddAccount(101, 500.0);
        bank.AddAccount(102, 1500.0);
        bank.AddAccount(103, 800.0);
        bank.AddAccount(104, 1200.0);
        // Queue withdrawal requests
        bank.RequestWithdrawal(101, 200);
        bank.RequestWithdrawal(103, 900); // insufficient
        bank.RequestWithdrawal(102, 500);
        // Process withdrawals
        bank.ProcessWithdrawals();
        // Display accounts sorted by balance
        bank.DisplayAccountsByBalance();
    }
}
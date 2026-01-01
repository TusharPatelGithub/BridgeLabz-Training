class Manager
{
    public void ViewAllAccounts(BankAccount[] accounts)
    {
        Console.WriteLine("\n---- ACCOUNT DETAILS ----");

        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] != null)
            {
                Console.WriteLine(
                    $"Name: {accounts[i].Name}, " +
                    $"Account No: {accounts[i].AccountNumber}, " +
                    $"Balance: {accounts[i].Balance}"
                );
            }
        }
    }
}

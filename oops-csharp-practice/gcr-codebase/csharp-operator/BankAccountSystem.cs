class BankAccount
{
    public static string BankName="abc bank";
    string AccountHolderName;
    readonly int AccountNumber;
    static int totalAccount=0;
    // int i=1;
   public BankAccount(string AccountHolderName,int AccountNumber)
    {
        this.AccountHolderName=AccountHolderName;
        this.AccountNumber=AccountNumber;
        totalAccount++;
    }
    public void GetAccountsDetails()
    {
        
        Console.WriteLine($"Account detail is: {AccountHolderName}, {AccountNumber} ");
    }
    public void Show()
    {
        Console.WriteLine($"Total number of account is {totalAccount}");
    }
}
class BankAccountSystem
{
    public static void Main(string[] args)
    {
        BankAccount bankAccount1=new BankAccount("Tushar", 1000);
        BankAccount bankAccount2=new BankAccount("Ravi Teja",2000);
        bankAccount1.GetAccountsDetails();
        bankAccount1.Show();
    }
}
using System;
class Program{
    public static void Main(){
        BankAccount account = new BankAccount();
        try{
            Console.Write("Enter withdrawal amount: ");
            double amount = double.Parse(Console.ReadLine()!);
            account.Withdraw(amount);
        }
        catch (InsufficientFundsException ex){
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex){
            Console.WriteLine(ex.Message);
        }
    }
}
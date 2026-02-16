using System;
using System.Text.RegularExpressions;
class ValidateCardNumber{
    static void Main(string[] args){
        Console.WriteLine("enter credit card number:");
        string cardNumber = Console.ReadLine();
        string pattern = "^(4\\d{15}|5\\d{15})$";
        if(Regex.IsMatch(cardNumber, pattern)){
            Console.WriteLine("valid credit card number");
        }
        else{
            Console.WriteLine("invalid credit card number");
        }
    }
}
using System;
using System.Text.RegularExpressions;
class SocialSecurityNumber{
    static void Main(string[] args){
        Console.WriteLine("enter a text containing security number:");
        string text = Console.ReadLine();
        string pattern = "\\b\\d{3}-\\d{2}-\\d{4}\\b";
        Match match = Regex.Match(text, pattern);
        if(match.Success){
            Console.WriteLine("valid number");
            Console.WriteLine("Number Found: " + match.Value);
        }
        else{
            Console.WriteLine("Invalid no.");
        }
    }
}
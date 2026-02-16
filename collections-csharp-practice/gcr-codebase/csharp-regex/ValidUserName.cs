using System;
using System.Text.RegularExpressions;
class ValidUserName{
    static void Main(string[] args){
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        //regex pattern for valid username
        string pattern = "^[A-Za-z][A-Za-z0-9_]{4,14}$";
        //check if username matches the pattern
        if(Regex.IsMatch(username, pattern)){
            Console.WriteLine("Valid Username");
        }
        else{
            Console.WriteLine("Invalid Username");
        }
        Console.ReadLine();
    }
}
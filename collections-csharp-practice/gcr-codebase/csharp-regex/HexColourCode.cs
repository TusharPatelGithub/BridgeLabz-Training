using System;
using System.Text.RegularExpressions;
class HexColourCode{
    static void Main(string[] args){
        Console.Write("enter hex color code: ");
        string colorCode = Console.ReadLine();
        string pattern = "^#[0-9A-Fa-f]{6}$";
        if(Regex.IsMatch(colorCode, pattern)){ //validate hex color code
            Console.WriteLine("Valid Hex Color Code");
        }else{
            Console.WriteLine("Invalid Hex Color Code");
        }
    }
}
using System;
using System.Text.RegularExpressions;
class ModifyStrings{
    static void Main(string[] args){
        Console.WriteLine("enter a sentence with extra spaces:");
        string input = Console.ReadLine();
        string pattern = "\\s+";
        string result = Regex.Replace(input, pattern, " ");
        Console.WriteLine("\nafter removing extra spaces:");
        Console.WriteLine(result);
    }
}

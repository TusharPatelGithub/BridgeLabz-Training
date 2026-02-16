using System;
using System.Text.RegularExpressions;
class CensorWords{
    static void Main(string[] args){
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();
        string pattern = "\\b(bruh|bitch)\\b";
        string censoredText = Regex.Replace(sentence,pattern,"****",RegexOptions.IgnoreCase);
        //display censored sentence
        Console.WriteLine("\nCensored Output:");
        Console.WriteLine(censoredText);
    }
}
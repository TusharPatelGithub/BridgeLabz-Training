using System;
using System.Text.RegularExpressions;
class ExtractCurrencyValue{
    static void Main(string[] args){
        Console.WriteLine("Enter text containing currency values:");
        string text = Console.ReadLine();
        string pattern = "\\$?\\s?\\d+(\\.\\d{2})?";
        MatchCollection match = Regex.Matches(text, pattern);
        if(match.Count == 0){
            Console.WriteLine("\nno currency values found.");
        }
        else{
            Console.WriteLine("\nextracted Currency Values:");
            for(int i = 0; i < match.Count; i++){
                string value = match[i].Value.Trim().Replace("$", "");
                Console.WriteLine(value);
            }
        }
    }
}
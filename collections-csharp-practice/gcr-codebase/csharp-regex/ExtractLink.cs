using System;
using System.Text.RegularExpressions;
class ExtractLinks{
    static void Main(string[] args){
        Console.WriteLine("Enter text containing links:");
        string text = Console.ReadLine();
        string pattern = "https?://[^\\s]+";
        MatchCollection match = Regex.Matches(text, pattern);
        if(match.Count == 0){
            Console.WriteLine("\nno links found.");
        }
        else{
            Console.WriteLine("\nextracted Links:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Value);
            }
        }
    }
}
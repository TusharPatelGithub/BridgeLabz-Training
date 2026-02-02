using System;
using System.Text.RegularExpressions;
class ExtraCapitalWord{
    static void Main(string[] args){
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();
        string pattern = "\\b[A-Z][a-z]*\\b";
        MatchCollection match = Regex.Matches(sentence, pattern);
        if(match.Count == 0){
            Console.WriteLine("\nNo capitalized words found.");
        }
        else{
            Console.WriteLine("\nCapitalized Words:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Value);
            }
        }
    }
}
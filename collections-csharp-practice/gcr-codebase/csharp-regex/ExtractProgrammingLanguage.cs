using System;
using System.Text.RegularExpressions;
class ExtractProgrammingLanguages{
    static void Main(string[] args){
        Console.WriteLine("enter a sentence containing programming languages:");
        string text = Console.ReadLine();
        string pattern = "\\b(Java|Python|JavaScript|Go|C|C\\+\\+|C#)\\b";
        MatchCollection match = Regex.Matches(text,pattern,RegexOptions.IgnoreCase);
        if(match.Count == 0){
            Console.WriteLine("\nno programming languages found.");
        }
        else{
            Console.WriteLine("\nextracted programming languages:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Value);
            }
        }
    }
}
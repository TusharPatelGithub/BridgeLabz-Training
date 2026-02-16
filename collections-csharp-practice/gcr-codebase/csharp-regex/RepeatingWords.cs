using System;
using System.Text.RegularExpressions;
class RepeatingWords{
    static void Main(string[] args){
        Console.WriteLine("enter a sentence:");
        string sentence = Console.ReadLine();
        string pattern = "\\b(\\w+)\\s+\\1\\b";
        MatchCollection match = Regex.Matches(sentence,pattern,RegexOptions.IgnoreCase);
        if(match.Count == 0){
            Console.WriteLine("\nno repeating words found.");
        }
        else{
            Console.WriteLine("\nrepeating Words:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Groups[1].Value);
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;
class ExtractDates{
    static void Main(string[] args){
        Console.WriteLine("Enter text haveing date(dd/mm/yyyy):");
        string text = Console.ReadLine();
        string pattern = "\\b\\d{2}/\\d{2}/\\d{4}\\b";
        MatchCollection match = Regex.Matches(text, pattern);
        if(match.Count == 0){
            Console.WriteLine("\nNo dates found.");
        }
        else{
            Console.WriteLine("\nExtracted Dates:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Value);
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;
class ExtractEmail{
    static void Main(string[] args){
        Console.WriteLine("enter text containing email addresses:");
        string text = Console.ReadLine();
        string pattern = "[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}"; //regex pattern to find email addresses
        MatchCollection match = Regex.Matches(text, pattern);
        if(match.Count == 0){
            Console.WriteLine("\nno email addresses found.");
        }else{
            Console.WriteLine("\nextracted email addresses:");
            for(int i = 0; i < match.Count; i++){
                Console.WriteLine(match[i].Value);
            }
        }
    }
}
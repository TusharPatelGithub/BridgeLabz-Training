using System;

class Substring
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";

        Console.Write("Enter start index: ");
        int start = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter end index: ");
        int end = int.Parse(Console.ReadLine() ?? "0");

        string resultUsingCharAt = "";

        for (int i = start; i < end; i++)
        {
            resultUsingCharAt += input[i];
        }

        string resultUsingSubstring = input.Substring(start, end - start);

        Console.WriteLine("Substring using charAt logic: " + resultUsingCharAt);
        Console.WriteLine("Substring using Substring(): " + resultUsingSubstring);
    }
}

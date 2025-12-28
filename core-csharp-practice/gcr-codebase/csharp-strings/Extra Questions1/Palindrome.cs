using System;

class PalindromeCheck
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";
        string reversed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }
        if (input == reversed)
            Console.WriteLine("The string is a Palindrome.");
        else
            Console.WriteLine("The string is NOT a Palindrome.");
    }
}

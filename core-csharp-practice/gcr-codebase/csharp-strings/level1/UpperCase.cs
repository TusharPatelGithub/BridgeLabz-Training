using System;

class UpperCase
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";

        string customUpper = ConvertToUpper(input);
        string builtInUpper = input.ToUpper();

        Console.WriteLine("Using ASCII logic: " + customUpper);
        Console.WriteLine("Using ToUpper(): " + builtInUpper);
    }

    static string ConvertToUpper(string text)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            if (ch >= 'a' && ch <= 'z')
                result[i] = (char)(ch - 32);
            else
                result[i] = ch;
        }

        return new string(result);
    }
}

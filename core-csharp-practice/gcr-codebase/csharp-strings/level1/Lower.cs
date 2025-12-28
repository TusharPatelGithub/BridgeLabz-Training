using System;

class Lower
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";

        string customLower = ConvertToLower(input);
        string builtInLower = input.ToLower();

        Console.WriteLine("Using ASCII logic: " + customLower);
        Console.WriteLine("Using ToLower(): " + builtInLower);
    }

    static string ConvertToLower(string text)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            if (ch >= 'A' && ch <= 'Z')
                result[i] = (char)(ch + 32);
            else
                result[i] = ch;
        }

        return new string(result);
    }
}

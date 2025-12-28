using System;

class ToggleCase
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (ch >= 'A' && ch <= 'Z')
                result += (char)(ch + 32);
            else if (ch >= 'a' && ch <= 'z')
                result += (char)(ch - 32);
            else
                result += ch;
        }

        Console.WriteLine("Toggled string: " + result);
    }
}

using System;

class RemoveCharacter
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";

        Console.Write("Enter character to remove: ");
        char removeChar = Console.ReadLine()[0];

        string result = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != removeChar)
                result += input[i];
        }

        Console.WriteLine("Modified String: " + result);
    }
}

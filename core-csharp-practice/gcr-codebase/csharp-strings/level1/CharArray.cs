using System;

class CharArray
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";
        char[] customArray = GetCharacters(input);
        char[] builtInArray = input.ToCharArray();
        Console.WriteLine("Characters using loop:");
        foreach (char c in customArray)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine("\nCharacters using ToCharArray():");
        foreach (char c in builtInArray)
        {
            Console.Write(c + " ");
        }
    }
    static char[] GetCharacters(string input)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            result[i] = input[i];
        }

        return result;
    }
}

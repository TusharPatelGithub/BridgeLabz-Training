
using System;

class RemoveDuplicate
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
            bool isDuplicate = false;

            for (int j = 0; j < result.Length; j++)
            {
                if (input[i] == result[j])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                result += input[i];
            }
        }

        Console.WriteLine("String after removing duplicates: " + result);
    }
}

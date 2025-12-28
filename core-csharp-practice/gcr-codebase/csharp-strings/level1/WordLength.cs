using System;

class WordLengt
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine() ?? "";

        string[,] result = SplitAndCount(input);

        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.WriteLine(result[i, 0] + " - " + result[i, 1]);
        }
    }
    static string[,] SplitAndCount(string text)
    {
        string[] temp = new string[100];
        int wordCount = 0;
        string word = "";

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                word += text[i];
            }
            else if (word != "")
            {
                temp[wordCount++] = word;
                word = "";
            }
        }
        if (word != "")
            temp[wordCount++] = word;

        string[,] result = new string[wordCount, 2];

        for (int i = 0; i < wordCount; i++)
        {
            result[i, 0] = temp[i];
            result[i, 1] = GetLength(temp[i]).ToString();
        }

        return result;
    }

    static int GetLength(string str)
    {
        int count = 0;
        foreach (char c in str)
            count++;
        return count;
    }
}

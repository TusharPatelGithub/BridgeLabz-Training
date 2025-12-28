using System;

class ReplaceWord
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine() ?? "";
        Console.Write("Enter word to replace: ");
        string oldWord = Console.ReadLine() ?? "";
        Console.Write("Enter new word: ");
        string newWord = Console.ReadLine() ?? "";
        string result = ReplaceWordInSentence(sentence, oldWord, newWord);
        Console.WriteLine("Updated sentence: " + result);
    }

    static string ReplaceWordInSentence(string sentence, string oldWord, string newWord)
    {
        string result = "";
        int i = 0;

        while (i < sentence.Length)
        {
            bool match = true;

            if (i + oldWord.Length <= sentence.Length)
            {
                for (int j = 0; j < oldWord.Length; j++)
                {
                    if (sentence[i + j] != oldWord[j])
                    {
                        match = false;
                        break;
                    }
                }
            }
            else
            {
                match = false;
            }

            if (match)
            {
                result += newWord;
                i += oldWord.Length;
            }
            else
            {
                result += sentence[i];
                i++;
            }
        }

        return result;
    }
}

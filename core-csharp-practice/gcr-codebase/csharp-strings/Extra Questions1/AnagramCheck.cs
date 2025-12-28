using System;

class AnagramCheck
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine() ?? "";
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine() ?? "";
        if (str1.Length != str2.Length)
        {
            Console.WriteLine("The strings are NOT anagrams.");
            return;
        }
        int[] count = new int[256];
        for (int i = 0; i < str1.Length; i++)
        {
            count[str1[i]]++;
            count[str2[i]]--;
        }
        bool isAnagram = true;
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] != 0)
            {
                isAnagram = false;
                break;
            }
        }
        if (isAnagram)
            Console.WriteLine("The strings are anagrams.");
        else
            Console.WriteLine("The strings are NOT anagrams.");
    }
}

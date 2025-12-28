using System;

class PalindromeChecker
{
    static void Main()
    {
        string input = GetInput();
        bool isPalindrome = CheckPalindrome(input);
        DisplayResult(isPalindrome);
    }

    static string GetInput()
    {
        Console.Write("Enter a string: ");
        return Console.ReadLine() ?? "";
    }
    static bool CheckPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;

        while (left < right)
        {
            if (text[left] != text[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
    static void DisplayResult(bool result)
    {
        if (result)
            Console.WriteLine("The string is a Palindrome.");
        else
            Console.WriteLine("The string is NOT a Palindrome.");
    }
}

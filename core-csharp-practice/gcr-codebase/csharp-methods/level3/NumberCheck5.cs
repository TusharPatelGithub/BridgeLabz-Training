using System;

public class NumberCheck5
{
    public static int CountDigits(int number)
    {
        int count = 0;
        while (number != 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    public static int[] GetDigitsArray(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    public static int[] ReverseArray(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        int index = 0;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            reversed[index++] = digits[i];
        }

        return reversed;
    }

    public static bool AreArraysEqual(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        return true;
    }

    public static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseArray(digits);
        return AreArraysEqual(digits, reversed);
    }

    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
        {
            if (d != 0)
                return true;
        }
        return false;
    }

    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Digit Count: " + CountDigits(number));

        Console.WriteLine("Is Palindrome: " + IsPalindrome(digits));
        Console.WriteLine("Is Duck Number: " + IsDuckNumber(digits));

        Console.WriteLine("Original Digits:");
        foreach (int d in digits)
            Console.Write(d + " ");

        Console.WriteLine("\nReversed Digits:");
        int[] reversed = ReverseArray(digits);
        foreach (int d in reversed)
            Console.Write(d + " ");
    }
}

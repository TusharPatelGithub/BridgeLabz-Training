using System;

public class NumberCheck3
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

    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
        {
            if (d != 0)
                return true;
        }
        return false;
    }

    public static bool IsArmstrong(int[] digits)
    {
        int power = digits.Length;
        int sum = 0;

        foreach (int d in digits)
        {
            sum += (int)Math.Pow(d, power);
        }

        int original = 0;
        foreach (int d in digits)
        {
            original = original * 10 + d;
        }

        return sum == original;
    }

    public static void FindLargestAndSecondLargest(int[] digits, out int largest, out int secondLargest)
    {
        largest = int.MinValue;
        secondLargest = int.MinValue;

        foreach (int d in digits)
        {
            if (d > largest)
            {
                secondLargest = largest;
                largest = d;
            }
            else if (d > secondLargest && d != largest)
            {
                secondLargest = d;
            }
        }
    }

    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Total Digits: " + CountDigits(number));
        Console.WriteLine("Is Duck Number: " + IsDuckNumber(digits));
        Console.WriteLine("Is Armstrong Number: " + IsArmstrong(digits));

        FindLargestAndSecondLargest(digits, out int largest, out int secondLargest);

        Console.WriteLine("Largest Digit: " + largest);
        Console.WriteLine("Second Largest Digit: " + secondLargest);
    }
}

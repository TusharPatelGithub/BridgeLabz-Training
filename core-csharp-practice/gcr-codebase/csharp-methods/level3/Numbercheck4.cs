using System;

public class NumberCheck4
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

    public static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits)
        {
            sum += d;
        }
        return sum;
    }

    public static double SumOfSquares(int[] digits)
    {
        double sum = 0;
        foreach (int d in digits)
        {
            sum += Math.Pow(d, 2);
        }
        return sum;
    }

    public static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return number % sum == 0;
    }

    public static int[,] DigitFrequency(int[] digits)
    {
        int[,] freq = new int[10, 2];

        for (int i = 0; i < 10; i++)
            freq[i, 0] = i;

        foreach (int d in digits)
        {
            freq[d, 1]++;
        }

        return freq;
    }

    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Total Digits: " + CountDigits(number));
        Console.WriteLine("Sum of Digits: " + SumOfDigits(digits));
        Console.WriteLine("Sum of Squares of Digits: " + SumOfSquares(digits));
        Console.WriteLine("Is Harshad Number: " + IsHarshadNumber(number, digits));

        int[,] frequency = DigitFrequency(digits);
        Console.WriteLine("Digit Frequencies:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i, 1] > 0)
                Console.WriteLine("Digit " + frequency[i, 0] + " → " + frequency[i, 1] + " times");
        }
    }
}

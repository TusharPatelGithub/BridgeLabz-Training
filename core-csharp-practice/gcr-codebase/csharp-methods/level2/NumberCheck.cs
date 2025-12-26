using System;

public class NumberChecker
{
    public static bool IsPositive(int number)
    {
        return number >= 0;
    }

    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static int Compare(int num1, int num2)
    {
        if (num1 > num2)
            return 1;
        else if (num1 == num2)
            return 0;
        else
            return -1;
    }

    public static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());

            if (IsPositive(numbers[i]))
            {
                if (IsEven(numbers[i]))
                    Console.WriteLine("Positive and Even");
                else
                    Console.WriteLine("Positive and Odd");
            }
            else
            {
                Console.WriteLine("Negative number");
            }
        }

        int result = Compare(numbers[0], numbers[4]);

        if (result == 1)
            Console.WriteLine("First number is greater than last number");
        else if (result == 0)
            Console.WriteLine("First number is equal to last number");
        else
            Console.WriteLine("First number is less than last number");
    }
}

using System;

public class NumberCheck6
{
    public static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    public static bool IsNeonNumber(int number)
    {
        int square = number * number;
        int sum = 0;

        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }

        return sum == number;
    }

    public static bool IsSpyNumber(int number)
    {
        int sum = 0;
        int product = 1;

        while (number > 0)
        {
            int digit = number % 10;
            sum += digit;
            product *= digit;
            number /= 10;
        }

        return sum == product;
    }

    public static bool IsAutomorphic(int number)
    {
        int square = number * number;
        int temp = number;

        while (temp > 0)
        {
            if (temp % 10 != square % 10)
                return false;

            temp /= 10;
            square /= 10;
        }
        return true;
    }

    public static bool IsBuzzNumber(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }

    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Is Prime: " + IsPrime(number));
        Console.WriteLine("Is Neon Number: " + IsNeonNumber(number));
        Console.WriteLine("Is Spy Number: " + IsSpyNumber(number));
        Console.WriteLine("Is Automorphic Number: " + IsAutomorphic(number));
        Console.WriteLine("Is Buzz Number: " + IsBuzzNumber(number));
    }
}

using System;

public class NumberCheck7
{
    public static int[] GetFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    public static int GreatestFactor(int[] factors)
    {
        int max = factors[0];
        foreach (int f in factors)
        {
            if (f > max)
                max = f;
        }
        return max;
    }

    public static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
            sum += f;
        return sum;
    }

    public static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int f in factors)
            product *= f;
        return product;
    }

    public static double ProductOfCubes(int[] factors)
    {
        double product = 1;
        foreach (int f in factors)
            product *= Math.Pow(f, 3);
        return product;
    }

    public static bool IsPerfectNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum == number;
    }

    public static bool IsAbundantNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum > number;
    }

    public static bool IsDeficientNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum < number;
    }

    public static bool IsStrongNumber(int number)
    {
        int temp = number;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }

        return sum == number;
    }

    private static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;
        return fact;
    }

    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = GetFactors(number);

        Console.WriteLine("Factors:");
        foreach (int f in factors)
            Console.Write(f + " ");

        Console.WriteLine("\nGreatest Factor: " + GreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + SumOfFactors(factors));
        Console.WriteLine("Product of Factors: " + ProductOfFactors(factors));
        Console.WriteLine("Product of Cube of Factors: " + ProductOfCubes(factors));
        Console.WriteLine("Is Perfect Number: " + IsPerfectNumber(number));
        Console.WriteLine("Is Abundant Number: " + IsAbundantNumber(number));
        Console.WriteLine("Is Deficient Number: " + IsDeficientNumber(number));
        Console.WriteLine("Is Strong Number: " + IsStrongNumber(number));
    }
}

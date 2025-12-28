using System;

class PrimeNumberChecker
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine() ?? "0");

        if (IsPrime(number))
            Console.WriteLine($"{number} is a Prime number.");
        else
            Console.WriteLine($"{number} is NOT a Prime number.");
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}

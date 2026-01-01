using System;

class MathUtility
{
    public static long Factorial(int n)
    {
        if (n < 0)
        {
            Console.WriteLine("Factorial not defined for negative numbers.");
            return -1;
        }

        long result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;

        return result;
    }

    public static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static int Fibonacci(int n)
    {
        if (n < 0)
        {
            Console.WriteLine("Invalid input");
            return -1;
        }

        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("---- Math Utility Program ----");

        Console.WriteLine("1. Factorial");
        Console.WriteLine("2. Prime Check");
        Console.WriteLine("3. GCD");
        Console.WriteLine("4. Fibonacci");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter number: ");
                int f = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Result: " + MathUtility.Factorial(f));
                break;

            case 2:
                Console.Write("Enter number: ");
                int p = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(MathUtility.IsPrime(p) ? "Prime Number" : "Not a Prime");
                break;

            case 3:
                Console.Write("Enter first number: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("GCD = " + MathUtility.GCD(a, b));
                break;

            case 4:
                Console.Write("Enter n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Fibonacci = " + MathUtility.Fibonacci(n));
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}

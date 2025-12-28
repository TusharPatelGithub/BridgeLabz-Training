using System;

class GcdLcm
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine() ?? "0");

        int gcd = FindGCD(a, b);
        int lcm = FindLCM(a, b);

        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }
    static int FindGCD(int a, int b)
    {
        int gcd = 1;
        int min = a < b ? a : b;

        for (int i = 1; i <= min; i++)
        {
            if (a % i == 0 && b % i == 0)
                gcd = i;
        }

        return gcd;
    }
    static int FindLCM(int a, int b)
    {
        int max = a > b ? a : b;

        for (int i = max; ; i++)
        {
            if (i % a == 0 && i % b == 0)
                return i;
        }
    }
}

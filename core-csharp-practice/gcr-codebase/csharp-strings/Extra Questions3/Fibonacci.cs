using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter number of terms: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        GenerateFibonacci(n);
    }

    static void GenerateFibonacci(int n)
    {
        int a = 0, b = 1;

        if (n <= 0)
            return;

        Console.Write("Fibonacci Series: ");

        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");
            int next = a + b;
            a = b;
            b = next;
        }
    }
}


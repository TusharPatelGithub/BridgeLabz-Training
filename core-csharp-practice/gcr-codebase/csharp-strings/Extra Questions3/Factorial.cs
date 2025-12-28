using System;

class FactorialProgram
{
    static void Main()
    {
        int number = GetInput();
        long result = CalculateFactorial(number);
        DisplayResult(number, result);
    }
    static int GetInput()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine() ?? "0");
    }
    static long CalculateFactorial(int n)
    {
        if (n <= 1)
            return 1;

        return n * CalculateFactorial(n - 1);
    }

    static void DisplayResult(int number, long result)
    {
        Console.WriteLine($"Factorial of {number} is: {result}");
    }
}

using System;

class MaximumOfNumber
{
    static void Main()
    {
        int a = ReadNumber("Enter first number: ");
        int b = ReadNumber("Enter second number: ");
        int c = ReadNumber("Enter third number: ");

        int max = FindMaximum(a, b, c);

        Console.WriteLine("The maximum number is: " + max);
    }

    static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine() ?? "");
    }
    static int FindMaximum(int a, int b, int c)
    {
        int max = a;
        if (b > max)
            max = b;
        if (c > max)
            max = c;
        return max;
    }
}

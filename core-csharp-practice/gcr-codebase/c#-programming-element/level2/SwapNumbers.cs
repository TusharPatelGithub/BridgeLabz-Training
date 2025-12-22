using System;

class SwapNumbers
{
    public static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine("After swapping:");
        Console.WriteLine("First number = " + a);
        Console.WriteLine("Second number = " + b);
    }
}

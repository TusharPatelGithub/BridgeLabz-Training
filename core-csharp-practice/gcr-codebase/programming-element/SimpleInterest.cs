// Write a program to calculate simple interest using the formula:
// Simple Interest = (Principal * Rate * Time) / 100.
// Take Principal, Rate, and Time as inputs from the user.

using System;

class SimpleIntrest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Rate");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Time");
        double time = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Principal");
        double principal = Convert.ToDouble(Console.ReadLine());

        double si = (principal * rate * time) / 100.0;

        Console.WriteLine("Total Simple Interest = " + si);
    }
}
using System;
class CalculateAge
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter 1st number:");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 2nd number:");
        int number2 = Convert.ToInt32(Console.ReadLine());
        int quotients = number1/number2;
        int remainder = number1%number2;
        Console.WriteLine("The Quotient is " + quotient +" and Remainder is " + remainder +" of two numbers " + number1 + " and " + number2);
    }
}
using System;

class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        double first = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double second = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter operator (+, -, *, /):");
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
                Console.WriteLine("Result = " + (first + second));
                break;

            case "-":
                Console.WriteLine("Result = " + (first - second));
                break;

            case "*":
                Console.WriteLine("Result = " + (first * second));
                break;

            case "/":
                if (second != 0)
                {
                    Console.WriteLine("Result = " + (first / second));
                }
                else
                {
                    Console.WriteLine("Division by zero is not allowed");
                }
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}

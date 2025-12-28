using System;

class Calculator2
{
    static void Main()
    {
        Console.WriteLine("Basic Calculator");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Choose an operation (1-4): ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Result: " + Add(num1, num2));
                break;

            case 2:
                Console.WriteLine("Result: " + Subtract(num1, num2));
                break;

            case 3:
                Console.WriteLine("Result: " + Multiply(num1, num2));
                break;

            case 4:
                if (num2 != 0)
                    Console.WriteLine("Result: " + Divide(num1, num2));
                else
                    Console.WriteLine("Error: Division by zero!");
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        return a / b;
    }
}

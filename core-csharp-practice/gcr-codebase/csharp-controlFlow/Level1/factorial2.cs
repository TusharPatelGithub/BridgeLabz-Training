using System;

class FactorialForLoop
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
            int factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The factorial of " + number + " is " + factorial);
        }
        else
        {
            Console.WriteLine("Please enter a positive integer");
        }
    }
}

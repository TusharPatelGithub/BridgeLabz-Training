using System;

class Factorial
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
            int factorial = 1;
            int counter = 1;

            while (counter <= number)
            {
                factorial *= counter;
                counter++;
            }

            Console.WriteLine("The factorial of " + number + " is " + factorial);
        }
        else
        {
            Console.WriteLine("Please enter a positive integer");
        }
    }
}

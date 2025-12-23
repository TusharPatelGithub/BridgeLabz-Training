using System;

class NaturalNumberSum
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
            int sum = number * (number + 1) / 2;
            Console.WriteLine("The sum of " + number + " natural numbers is " + sum);
        }
        else
        {
            Console.WriteLine("The number " + number + " is not a natural number");
        }
    }
}

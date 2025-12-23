using System;

class OddEvenNumbers
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " is even number");
                }
                else
                {
                    Console.WriteLine(i + " is odd number");
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a natural number");
        }
    }
}

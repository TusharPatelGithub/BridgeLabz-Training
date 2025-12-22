using System;

class FactorsOfnumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}

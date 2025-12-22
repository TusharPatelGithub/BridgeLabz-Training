using System;

class MultiplesBelowHundred
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}

using System;

class GreatestFactor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());
        int greatestFactor = 1;
        for (int i = number - 1; i >= 1; i--)
        {
            if (number % i == 0)
            {
                greatestFactor = i;
                break;
            }
        }

        Console.WriteLine("Greatest factor (besides itself) is: " + greatestFactor);
    }
}

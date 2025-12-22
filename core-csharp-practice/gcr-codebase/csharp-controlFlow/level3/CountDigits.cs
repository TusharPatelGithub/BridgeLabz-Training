using System;

class CountDigits
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int count = 0;

        if (number == 0)
        {
            count = 1;
        }
        else
        {
            while (number != 0)
            {
                number = number / 10;
                count++;
            }
        }

        Console.WriteLine("Number of digits = " + count);
    }
}

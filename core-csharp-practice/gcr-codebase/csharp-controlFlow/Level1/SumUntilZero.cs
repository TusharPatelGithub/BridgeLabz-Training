using System;

class SumUntilZero
{
    public static void Main(string[] args)
    {
        double total = 0.0;
        double number;

        Console.Write("Enter a number (0 to stop): ");
        number = Convert.ToDouble(Console.ReadLine());

        while (number != 0)
        {
            total += number;

            Console.Write("Enter a number (0 to stop): ");
            number = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("The total sum is " + total);
    }
}

using System;

class SumUntilZero2
{
    public static void Main(string[] args)
    {
        double total = 0.0;
        while (true)
        {
            Console.Write("Enter a number (0 or negative to stop): ");
            double number = Convert.ToDouble(Console.ReadLine());

            if (number <= 0)
            {
                break;
            }
            total+=number;
        }
        Console.WriteLine("The total sum is " + total);
    }
}

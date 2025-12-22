using System;

class WeightConversion
{
    public static void Main(string[] args)
    {
        Console.Write("Enter weight in pounds: ");
        double pounds = Convert.ToDouble(Console.ReadLine());

        double kilograms = pounds * 0.453592;

        Console.WriteLine("Weight in kilograms = " + kilograms);
    }
}

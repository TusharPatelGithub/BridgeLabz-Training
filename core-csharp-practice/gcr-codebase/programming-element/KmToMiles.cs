using System;

class KmToMiles
{
    static void Main()
    {
        Console.Write("Enter distance in kilometers: ");
        double kilometers = Convert.ToDouble(Console.ReadLine());

        double miles = kilometers * 0.621371;

        Console.WriteLine("Distance in miles = " + miles);
    }
}

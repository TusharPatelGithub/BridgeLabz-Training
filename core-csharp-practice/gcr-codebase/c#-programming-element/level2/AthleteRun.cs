using System;

class AthleteRun
{
    public static void Main(string[] args)
    {
        Console.Write("Enter side 1 (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2 (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3 (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        double perimeter = side1 + side2 + side3;
        double totalDistance = 5000;

        double rounds = totalDistance / perimeter;

        Console.WriteLine("Number of rounds required = " + rounds);
    }
}

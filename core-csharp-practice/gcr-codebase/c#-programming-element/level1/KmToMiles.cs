using System;

class KmToMiles
{
    static void Main(string[] args){
        double km;
        Console.WriteLine("Enter distance in kilometers:");
        km = Convert.ToDouble(Console.ReadLine());
        double miles = km / 1.6;
        Console.WriteLine("The total miles is" + miles + " mile for the given " + km + "km");
    }
}

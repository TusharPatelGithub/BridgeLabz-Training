// Write a program to calculate the volume of a cylinder. Take the radius and
// height as inputs and use the formula:
// Volume = π * radius^2 * height.

using System;
class CylinderVol{
    static void Main(string[] args)
    {


         Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter height: ");
        double height = Convert.ToDouble(Console.ReadLine());

        double volume = Math.PI * radius * radius * height;

        Console.WriteLine("Volume of the cylinder = " + volume);

    }
}
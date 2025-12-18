// Write a program to calculate the perimeter of a rectangle. Take the length
// and width as inputs and use the formula:
// Perimeter = 2 * (length + width).

using System;

class RectPerimeter
{
    public static void Main(string[] args)
    {
        Console.Write("Enter length: ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter width: ");
        double width = Convert.ToDouble(Console.ReadLine());
        double perimeter = 2 * (length + width);
        Console.WriteLine("Perimeter of the rectangle = " + perimeter);
    }
}
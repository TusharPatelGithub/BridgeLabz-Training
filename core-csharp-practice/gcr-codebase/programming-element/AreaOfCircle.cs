using System;

class AreaOfCircle
{
    static void Main(string[] args)
    {
        Console.Write("Enter radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double area = 3.14159 * radius * radius;

        Console.WriteLine("Area of circle = " + area);
    }
}

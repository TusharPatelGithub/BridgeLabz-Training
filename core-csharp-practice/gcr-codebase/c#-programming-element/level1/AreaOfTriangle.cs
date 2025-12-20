using System;
class AreaOfTriangle{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter base of triangle:");
        double baseInch = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter height of triangle:");
        double heightInch = Convert.ToDouble(Console.ReadLine());
        double areaSqInch = 0.5 * baseInch * heightInch;
        double areaSqCm = areaSqInch * 6.4516;
        Console.WriteLine("The area of triangle is " + areaSqInch +" square inches and " + areaSqCm +" square centimeters");
    }
}
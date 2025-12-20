using System;

class HeightConverter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your height in centimeters:");
        double heightCm = Convert.ToDouble(Console.ReadLine());
        double totalInches = heightCm / 2.54;
        int feet = (int)(totalInches / 12);
        double inches = totalInches % 12;
        Console.WriteLine("Your Height in cm is " + heightCm +" while in feet is " + feet +" and inches is " + inches);
    }
}

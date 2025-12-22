using System;

class TemperatureConversion2
{
    public static void Main(string[] args)
    {
        Console.Write("Enter temperature in Fahrenheit: ");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());

        double celsius = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine("Temperature in Celsius = " + celsius);
    }
}

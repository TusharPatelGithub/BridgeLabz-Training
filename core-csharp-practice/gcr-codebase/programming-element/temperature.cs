using System;

class Temperature
{
    static void Main(string[] args)
    {
        Console.Write("Enter temp in Celsius: ");
        double celsius = double.Parse(Console.ReadLine());

        double fahrenheit = (celsius * 9 / 5) + 32;

        Console.WriteLine("Temperature in Fahrenheit = " + fahrenheit);
    }
}

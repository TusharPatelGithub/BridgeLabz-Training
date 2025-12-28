using System;

class Temperature2
{
    static void Main()
    {
        Console.WriteLine("1. Fahrenheit to Celsius");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());
            double c = FahrenheitToCelsius(f);
            Console.WriteLine("Temperature in Celsius: " + c);
        }
        else if (choice == 2)
        {
            Console.Write("Enter temperature in Celsius: ");
            double c = Convert.ToDouble(Console.ReadLine());
            double f = CelsiusToFahrenheit(c);
            Console.WriteLine("Temperature in Fahrenheit: " + f);
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }
}

using System;

class BMI
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter weight in kg:");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter height in cm:");
        double heightCm = Convert.ToDouble(Console.ReadLine());

        double heightMeter = heightCm / 100;
        double bmi = weight / (heightMeter * heightMeter);

        Console.WriteLine("BMI = " + bmi);

        if (bmi <= 18.4)
        {
            Console.WriteLine("Status: Underweight");
        }
        else if (bmi >= 18.5 && bmi <= 24.9)
        {
            Console.WriteLine("Status: Normal");
        }
        else if (bmi >= 25.0 && bmi <= 39.9)
        {
            Console.WriteLine("Status: Overweight");
        }
        else
        {
            Console.WriteLine("Status: Obese");
        }
    }
}

using System;

public class BMICalculator
{
    public static void Main()
    {
        double[,] data = new double[10, 3];
        string[] status = new string[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter weight (kg) for person " + (i + 1) + ": ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (cm) for person " + (i + 1) + ": ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());

            data[i, 2] = CalculateBMI(data[i, 0], data[i, 1]);
            status[i] = GetBMIStatus(data[i, 2]);
        }

        Console.WriteLine("\nBMI Report:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Person " + (i + 1) +
                " | Weight: " + data[i, 0] +
                " | Height: " + data[i, 1] +
                " | BMI: " + data[i, 2] +
                " | Status: " + status[i]);
        }
    }

    public static double CalculateBMI(double weight, double heightCm)
    {
        double heightMeter = heightCm / 100;
        return weight / (heightMeter * heightMeter);
    }

    public static string GetBMIStatus(double bmi)
    {
        if (bmi <= 18.4)
            return "Underweight";
        else if (bmi >= 18.5 && bmi <= 24.9)
            return "Normal";
        else if (bmi >= 25.0 && bmi <= 39.9)
            return "Overweight";
        else
            return "Obese";
    }
}

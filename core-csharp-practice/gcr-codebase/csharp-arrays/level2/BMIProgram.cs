using System;

class BMIProgram
{
    static void Main(String[] args)
    {
        Console.Write("Enter number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] height = new double[n];
        double[] weight = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter details for Person " + (i + 1));
            Console.Write("Enter height (in meters): ");
            height[i] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter weight (in kg): ");
            weight[i] = Convert.ToDouble(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] <= 18.4)
                status[i] = "Underweight";
            else if (bmi[i] <= 24.9)
                status[i] = "Normal";
            else if (bmi[i] <= 39.9)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }
        Console.WriteLine("\n--- BMI Report ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Person " + (i + 1));
            Console.WriteLine("Height: " + height[i]);
            Console.WriteLine("Weight: " + weight[i]);
            Console.WriteLine("BMI: " + bmi[i]);
            Console.WriteLine("Status: " + status[i]);
            Console.WriteLine();
        }
    }
}

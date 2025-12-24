using System;

class BMIArray
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        int number = Convert.ToInt32(Console.ReadLine());
        double[][] personData = new double[number][];
        string[] weightStatus = new string[number];
        for (int i = 0; i < number; i++)
        {
            personData[i] = new double[3];
            Console.WriteLine("\nEnter details for Person " + (i + 1));
            Console.Write("Enter weight (kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter height (meters): ");
            double height = Convert.ToDouble(Console.ReadLine());
            if (weight <= 0 || height <= 0)
            {
                Console.WriteLine("Invalid input! Enter positive values.");
                i--;
                continue;
            }
            personData[i][0] = weight;
            personData[i][1] = height;
        }
        for (int i = 0; i < number; i++)
        {
            double bmi = personData[i][0] / 
                        (personData[i][1] * personData[i][1]);

            personData[i][2] = bmi;
            if (bmi <= 18.4)
                weightStatus[i] = "Underweight";
            else if (bmi <= 24.9)
                weightStatus[i] = "Normal";
            else if (bmi <= 39.9)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }
        Console.WriteLine("\n--- BMI Report ---");
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine("Person " + (i + 1));
            Console.WriteLine("Weight: " + personData[i][0]);
            Console.WriteLine("Height: " + personData[i][1]);
            Console.WriteLine("BMI: " + personData[i][2]);
            Console.WriteLine("Status: " + weightStatus[i]);
            Console.WriteLine();
        }
    }
}

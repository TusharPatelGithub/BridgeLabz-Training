using System;

public class RandomNumber
{
    public static int[] Generate4DigitRandomArray(int size)
    {
        int[] numbers = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            numbers[i] = rand.Next(1000, 10000); // 4-digit numbers
        }

        return numbers;
    }

    public static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];

            if (numbers[i] > max)
                max = numbers[i];

            sum += numbers[i];
        }

        double average = sum / numbers.Length;

        return new double[] { average, min, max };
    }

    public static void Main()
    {
        int[] randomNumbers = Generate4DigitRandomArray(5);

        Console.WriteLine("Generated Numbers:");
        foreach (int num in randomNumbers)
        {
            Console.WriteLine(num);
        }

        double[] result = FindAverageMinMax(randomNumbers);

        Console.WriteLine("\nAverage: " + result[0]);
        Console.WriteLine("Minimum: " + result[1]);
        Console.WriteLine("Maximum: " + result[2]);
    }
}

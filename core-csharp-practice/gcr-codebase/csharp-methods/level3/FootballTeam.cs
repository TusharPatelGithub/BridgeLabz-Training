using System;

public class FootballTeam
{
    public static int[] GenerateHeights(int size)
    {
        int[] heights = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            heights[i] = rand.Next(150, 251);
        }
        return heights;
    }

    public static int FindSum(int[] heights)
    {
        int sum = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            sum += heights[i];
        }
        return sum;
    }

    public static double FindMean(int[] heights)
    {
        return (double)FindSum(heights) / heights.Length;
    }

    public static int FindShortest(int[] heights)
    {
        int min = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] < min)
                min = heights[i];
        }
        return min;
    }

    public static int FindTallest(int[] heights)
    {
        int max = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > max)
                max = heights[i];
        }
        return max;
    }

    public static void Main()
    {
        int[] heights = GenerateHeights(11);

        Console.WriteLine("Player Heights:");
        foreach (int h in heights)
        {
            Console.WriteLine(h);
        }

        Console.WriteLine("\nMean Height: " + FindMean(heights));
        Console.WriteLine("Shortest Height: " + FindShortest(heights));
        Console.WriteLine("Tallest Height: " + FindTallest(heights));
    }
}

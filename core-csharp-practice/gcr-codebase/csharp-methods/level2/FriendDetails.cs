using System;

public class FriendDetails
{
    public static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter age of " + names[i] + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter height of " + names[i] + ": ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        int youngestIndex = FindYoungest(ages);
        int tallestIndex = FindTallest(heights);

        Console.WriteLine("Youngest friend is: " + names[youngestIndex]);
        Console.WriteLine("Tallest friend is: " + names[tallestIndex]);
    }

    public static int FindYoungest(int[] ages)
    {
        int minIndex = 0;
        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[minIndex])
                minIndex = i;
        }
        return minIndex;
    }

    public static int FindTallest(double[] heights)
    {
        int maxIndex = 0;
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }
}

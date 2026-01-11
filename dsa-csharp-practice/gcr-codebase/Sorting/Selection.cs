using System;

class Selection
{
    static void Main()
    {
        int[] scores = { 78, 45, 90, 62, 55 };

        Console.WriteLine("Original Exam Scores:");
        PrintArray(scores);

        SelectionSort(scores);

        Console.WriteLine("\nSorted Exam Scores (Ascending Order):");
        PrintArray(scores);
    }

    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int score in arr)
        {
            Console.Write(score + " ");
        }
        Console.WriteLine();
    }
}

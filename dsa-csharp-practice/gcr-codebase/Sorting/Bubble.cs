using System;

class Bubble
{
    static void Main()
    {
        int[] marks = { 78, 45, 90, 62, 55, 88 };

        Console.WriteLine("Original Marks:");
        PrintArray(marks);

        BubbleSort(marks);

        Console.WriteLine("\nSorted Marks (Ascending Order):");
        PrintArray(marks);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int mark in arr)
        {
            Console.Write(mark + " ");
        }
        Console.WriteLine();
    }
}

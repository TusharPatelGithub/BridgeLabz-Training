using System;

class Insertion
{
    static void Main()
    {
        int[] employeeIds = { 105, 101, 110, 102, 108 };

        Console.WriteLine("Original Employee IDs:");
        PrintArray(employeeIds);

        InsertionSort(employeeIds);

        Console.WriteLine("\nSorted Employee IDs (Ascending Order):");
        PrintArray(employeeIds);
    }

    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int id in arr)
        {
            Console.Write(id + " ");
        }
        Console.WriteLine();
    }
}

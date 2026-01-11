using System;

class Heap
{
    static void Main()
    {
        int[] salaries = { 45000, 60000, 30000, 80000, 55000 };

        Console.WriteLine("Original Salary Demands:");
        PrintArray(salaries);

        HeapSort(salaries);

        Console.WriteLine("\nSorted Salary Demands (Ascending Order):");
        PrintArray(salaries);
    }

    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        // Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    static void Heapify(int[] arr, int heapSize, int root)
    {
        int largest = root;
        int left = 2 * root + 1;
        int right = 2 * root + 2;

        if (left < heapSize && arr[left] > arr[largest])
            largest = left;

        if (right < heapSize && arr[right] > arr[largest])
            largest = right;

        if (largest != root)
        {
            int swap = arr[root];
            arr[root] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, heapSize, largest);
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int salary in arr)
        {
            Console.Write(salary + " ");
        }
        Console.WriteLine();
    }
}

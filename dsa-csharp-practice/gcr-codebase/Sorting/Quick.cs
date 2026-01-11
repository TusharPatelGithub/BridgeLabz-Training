using System;

class Quick
{
    static void Main()
    {
        int[] prices = { 899, 299, 1200, 499, 150, 999 };

        Console.WriteLine("Original Product Prices:");
        PrintArray(prices);

        QuickSort(prices, 0, prices.Length - 1);

        Console.WriteLine("\nSorted Product Prices (Ascending Order):");
        PrintArray(prices);
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swap = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = swap;

        return i + 1;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int price in arr)
        {
            Console.Write(price + " ");
        }
        Console.WriteLine();
    }
}

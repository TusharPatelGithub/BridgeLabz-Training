using System;

class MergeSortBookPrices
{
    static void Main()
    {
        int[] prices = { 450, 299, 1200, 799, 150, 999 };

        Console.WriteLine("Original Book Prices:");
        PrintArray(prices);

        MergeSort(prices, 0, prices.Length - 1);

        Console.WriteLine("\nSorted Book Prices (Ascending Order):");
        PrintArray(prices);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
            {
                arr[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = R[jIndex];
                jIndex++;
            }
            k++;
        }

        while (iIndex < n1)
        {
            arr[k] = L[iIndex];
            iIndex++;
            k++;
        }

        while (jIndex < n2)
        {
            arr[k] = R[jIndex];
            jIndex++;
            k++;
        }
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

using System;
using System.Diagnostics;

class SearchComparison
{
    // Linear Search O(N)
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1;
    }

    // Binary Search O(log N) – array must be sorted
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        int[] sizes = { 1000, 10000, 1000000 };

        foreach (int size in sizes)
        {
            Console.WriteLine($"\nDataset Size: {size}");

            int[] data = new int[size];
            for (int i = 0; i < size; i++)
                data[i] = i + 1;

            int target = size; // worst case for linear search

            Stopwatch sw = new Stopwatch();

            // Linear Search
            sw.Start();
            LinearSearch(data, target);
            sw.Stop();
            Console.WriteLine($"Linear Search Time: {sw.ElapsedMilliseconds} ms");

            // Binary Search
            sw.Restart();
            BinarySearch(data, target);
            sw.Stop();
            Console.WriteLine($"Binary Search Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}

using System;

class CountingSortStudentAges
{
    static void Main()
    {
        int[] ages = { 12, 15, 10, 18, 14, 12, 16, 10 };

        Console.WriteLine("Original Student Ages:");
        PrintArray(ages);

        CountingSort(ages, 10, 18);

        Console.WriteLine("\nSorted Student Ages (Ascending Order):");
        PrintArray(ages);
    }

    static void CountingSort(int[] arr, int minAge, int maxAge)
    {
        int range = maxAge - minAge + 1;
        int[] count = new int[range];
        int[] output = new int[arr.Length];

        // Step 1: Count frequency
        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - minAge]++;
        }

        // Step 2: Cumulative count
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        // Step 3: Build output array
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int age = arr[i];
            int index = age - minAge;
            output[count[index] - 1] = age;
            count[index]--;
        }

        // Step 4: Copy back
        for (int i = 0; i < arr.Length; i++)
        {
            ar

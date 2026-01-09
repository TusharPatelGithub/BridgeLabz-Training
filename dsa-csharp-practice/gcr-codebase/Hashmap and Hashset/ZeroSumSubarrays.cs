using System;
using System.Collections.Generic;

class ZeroSumSubarrays
{
    static void FindSubarrays(int[] arr)
    {
        // Dictionary to store prefix sum and list of indices
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

        int sum = 0;

        // Handle subarrays starting from index 0
        map[0] = new List<int> { -1 };

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            // If prefix sum already exists
            if (map.ContainsKey(sum))
            {
                foreach (int startIndex in map[sum])
                {
                    Console.WriteLine($"Subarray found from index {startIndex + 1} to {i}");
                }
            }

            // Add current index to map
            if (!map.ContainsKey(sum))
            {
                map[sum] = new List<int>();
            }
            map[sum].Add(i);
        }
    }

    static void Main()
    {
        int[] arr = { 3, 4, -7, 3, 1, 3, 1, -4 };
        FindSubarrays(arr);
    }
}

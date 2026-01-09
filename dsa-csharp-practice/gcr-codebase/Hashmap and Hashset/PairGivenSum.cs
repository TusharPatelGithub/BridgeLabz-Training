using System;
using System.Collections.Generic;

class PairGivenSum
{
    static bool HasPairWithSum(int[] arr, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (int num in arr)
        {
            int required = target - num;

            // Check if complement exists
            if (map.ContainsKey(required))
            {
                return true;
            }

            // Store current number
            if (!map.ContainsKey(num))
            {
                map[num] = 1;
            }
        }

        return false;
    }

    static void Main()
    {
        int[] arr = { 8, 7, 2, 5, 3, 1 };
        int target = 10;

        Console.WriteLine(HasPairWithSum(arr, target)); // Output: True
    }
}

using System;
using System.Collections.Generic;

class TwoSum
{
    static int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }

            // Store current number with index
            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = i;
            }
        }

        return new int[0]; // No solution (not expected as per problem)
    }

    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        int[] result = FindTwoSum(nums, target);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
}

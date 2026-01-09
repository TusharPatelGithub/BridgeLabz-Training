using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static int FindLongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        HashSet<int> set = new HashSet<int>();
        foreach (int num in nums)
        {
            set.Add(num);
        }

        int longest = 0;

        foreach (int num in nums)
        {
            // Start only if num is the beginning
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int count = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    count++;
                }

                longest = Math.Max(longest, count);
            }
        }

        return longest;
    }

    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(FindLongestConsecutive(nums)); // Output: 4
    }
}

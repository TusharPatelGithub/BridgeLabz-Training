public class Solution
{
    public void SortColors(int[] nums)
    {
        int zero = 0;
        int one = 0;
        int two = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) zero++;
            else if (nums[i] == 1) one++;
            else two++;
        }

        for (int i = 0; i < zero; i++)
        {
            nums[i] = 0;
        }

        for (int i = 0; i < one; i++)
        {
            nums[i + zero] = 1;
        }

        for (int i = 0; i < two; i++)
        {
            nums[i + zero + one] = 2;
        }
    }
}

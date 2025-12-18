public class Solution
{
    public int MaxProfit(int[] arr)
    {
        if (arr.Length <= 1)
            return 0;
        int buy = arr[0];
        int profit = 0;
        int max = int.MinValue;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < buy)
            {
                buy = arr[i];
            }
            profit = arr[i] - buy;
            max = Math.Max(max, profit);
        }
        return max;
    }
}

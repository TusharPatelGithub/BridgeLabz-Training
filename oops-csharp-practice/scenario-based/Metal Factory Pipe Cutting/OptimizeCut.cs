class Optimized : ICut
{
    public int CalculateRevenue(Rod rod, int[] price)
    {
        int n = rod.GetLength();
        int[] dp = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            int max = 0;
            for (int j = 1; j <= i; j++)
            {
                max = System.Math.Max(max, price[j] + dp[i - j]);
            }
            dp[i] = max;
        }
        return dp[n];
    }
}

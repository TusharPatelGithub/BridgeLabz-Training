class OptimizedCutWithWasteStrategy : ICuttingStrategy
{
    public int CalculateRevenue(WoodRod rod, int[] price, int allowedWaste)
    {
        int n = rod.GetLength();
        int[] dp = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            int max = 0;
            for (int j = 1; j <= i; j++)
            {
                if (price[j] > 0)
                {
                    max = System.Math.Max(max, price[j] + dp[i - j]);
                }
            }
            dp[i] = max;
        }

        // Apply waste constraint
        int usableLength = n - allowedWaste;
        return dp[usableLength];
    }
}

using System;

class Factory
{
    static void Main()
    {
        int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20 };

        Rod rod = new Rod(8);
        ICutStrategy optimizedStrategy = new OptimizedCutStrategy();

        //  Optimized revenue
        int revenueA = optimizedStrategy.CalculateRevenue(rod, price);
        Console.WriteLine("Scenario A - Optimized Revenue: " + revenueA);

        //  Custom-length order impact
        price[3] = 12; // custom price for length 3
        int revenueB = optimizedStrategy.CalculateRevenue(rod, price);
        Console.WriteLine("Scenario B - Revenue After Custom Order: " + revenueB);

        // Non-optimized revenue (no cuts)
        int revenueC = price[rod.GetLength()];
        Console.WriteLine("Scenario C - Non Optimized Revenue: " + revenueC);
    }
}

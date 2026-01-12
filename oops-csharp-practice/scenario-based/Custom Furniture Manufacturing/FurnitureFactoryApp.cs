using System;

class FurnitureFactoryApp
{
    static void Main()
    {
        // Price per foot (index = length)
        int[] price = { 0, 2, 5, 7, 8, 10, 13, 17, 18, 20, 24, 25, 30 };

        WoodRod rod = new WoodRod(12);
        ICuttingStrategy strategy = new OptimizedCutWithWasteStrategy();

        // Scenario A: Max revenue
        int revenueA = strategy.CalculateRevenue(rod, price, 0);
        Console.WriteLine("Scenario A - Maximum Revenue: " + revenueA);

        // Scenario B: Fixed waste constraint (2 ft waste)
        int revenueB = strategy.CalculateRevenue(rod, price, 2);
        Console.WriteLine("Scenario B - Revenue with Waste Constraint: " + revenueB);

        // Scenario C: Max revenue + minimal waste
        int minimalWaste = 1;
        int revenueC = strategy.CalculateRevenue(rod, price, minimalWaste);
        Console.WriteLine("Scenario C - Revenue with Minimal Waste: " + revenueC);
    }
}

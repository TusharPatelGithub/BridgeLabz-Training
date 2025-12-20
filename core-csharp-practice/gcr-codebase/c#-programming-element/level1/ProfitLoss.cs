using System;

class ProfitLoss
{
    static void Main(string[] args)
    {
        int costPrice = 129;
        int sellingPrice = 191;

        int profit = sellingPrice - costPrice;
        double profitPercentage = (profit / (double)costPrice) * 100;

        Console.WriteLine("The Cost Price is INR " + costPrice + " and Selling Price is INR " + sellingPrice);
        Console.WriteLine("The Profit is INR " + profit + " and the Profit Percentage is " + profitPercentage);
    }
}

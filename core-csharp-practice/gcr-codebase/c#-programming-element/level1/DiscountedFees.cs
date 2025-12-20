using System;

class DiscountedFees
{
    static void Main(string[] args)
    {
        Console.WriteLine("student fee:");
        double fee = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("discount percentage :");
        double discountPercentage = Convert.ToDouble(Console.ReadLine());
        double discountAmounts = fee*(discountPercentage / 100);
        double finalFee = fee-discountAmounts;
        Console.WriteLine("The discount amount is INR " + discountAmounts +"and final discounted fee is INR " + finalFee);
    }
}

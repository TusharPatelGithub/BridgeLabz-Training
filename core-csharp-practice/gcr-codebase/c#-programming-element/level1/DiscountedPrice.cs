using System;
class DiscountedPrice
{
    static void Main(string[] args)
    {
        int chargedFee = 125000;
        int discountRate = 10;
        double finalFee = chargedFee - (chargedFee * (discountRate / 100.0));
        double discountedPrice = chargedFee - finalFee;
        Console.WriteLine("The discount amount is INR" + discountedPrice +" and final discounted fee is INR" + finalFee);
    }
}
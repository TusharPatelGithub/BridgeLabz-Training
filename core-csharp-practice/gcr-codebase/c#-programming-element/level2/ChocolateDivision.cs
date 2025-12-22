using System;

class ChocolateDivision
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of chocolates: ");
        int chocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int children = Convert.ToInt32(Console.ReadLine());

        int eachChildGets = chocolates / children;
        int remainingChocolates = chocolates % children;

        Console.WriteLine("Each child gets = " + eachChildGets);
        Console.WriteLine("Remaining chocolates = " + remainingChocolates);
    }
}

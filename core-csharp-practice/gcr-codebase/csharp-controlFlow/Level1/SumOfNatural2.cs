using System;

class SumOfNaturalNumbersForLoop
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n > 0)
        {
            int sumByFormula = n * (n + 1) / 2;

            int sumByLoop = 0;

            for (int i = 1; i <= n; i++)
            {
                sumByLoop += i;
            }
            Console.WriteLine("Sum using formula = " + sumByFormula);
            Console.WriteLine("Sum using for loop = " + sumByLoop);
            if (sumByFormula == sumByLoop)
            {
                Console.WriteLine("Both computations are correct.");
            }
            else
            {
                Console.WriteLine("The computations are not equal.");
            }
        }
        else
        {
            Console.WriteLine("The number " + n + " is not a natural number");
        }
    }
}

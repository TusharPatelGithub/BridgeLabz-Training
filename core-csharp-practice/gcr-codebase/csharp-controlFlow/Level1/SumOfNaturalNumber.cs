using System;

class SumOfNaturalNumber
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n > 0)
        {
            int sumByFormula = n * (n + 1) / 2;
            int sumByLoop = 0;
            int counter = 1;

            while (counter <= n)
            {
                sumByLoop += counter;
                counter++;
            }
            Console.WriteLine("Sum using formula = " + sumByFormula);
            Console.WriteLine("Sum using while loop = " + sumByLoop);
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

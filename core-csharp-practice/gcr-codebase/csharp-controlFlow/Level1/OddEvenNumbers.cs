using System;

class OddEvenNumbers
{
    public static void Main(string[] args)
    {
       Console.WriteLine("Enter the number: ");
       int a=Convert.ToInt16(Console.ReadLine());
       for(int i = 1; i <= a; i++)
        {
            if (i % 2 == 1)
            {
                Console.WriteLine(i+ " is odd ");
            }
            else
            {
                Console.WriteLine(i+ " is even ");
            }
        }
    }
}

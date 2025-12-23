using System;

class SmallestCheck
{
    public static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third number: ");
        int number3 = Convert.ToInt32(Console.ReadLine());
        bool isSmallest = number1 < number2 && number1 < number3;
        Console.WriteLine("Is the first number the smallest? " + isSmallest);
    }
}

using System;

class LargestCheck
{
    public static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int number3 = Convert.ToInt32(Console.ReadLine());

        bool isFirstLargest = number1 > number2 && number1 > number3;
        bool isSecondLargest = number2 > number1 && number2 > number3;
        bool isThirdLargest = number3 > number1 && number3 > number2;

        Console.WriteLine("Is the first number the largest? " + isFirstLargest);
        Console.WriteLine("Is the second number the largest? " + isSecondLargest);
        Console.WriteLine("Is the third number the largest? " + isThirdLargest);
    }
}

using System;

class AddTwoNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter 1st no: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter 2nd no: ");
        int num2 = int.Parse(Console.ReadLine());

        int sum = num1 + num2;

        Console.WriteLine("Sum = " + sum);
    }
}

using System;

class IntOperation
{
    public static void Main(string[] args)
    {
        Console.Write("Enter value of a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value of b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value of c: ");
        int c = Convert.ToInt32(Console.ReadLine());

        int result1 = a + b * c;
        int result2 = a * b + c;
        int result3 = c + a / b;
        int result4 = a % b + c;

        Console.WriteLine("a + b * c = " + result1);
        Console.WriteLine("a * b + c = " + result2);
        Console.WriteLine("c + a / b = " + result3);
        Console.WriteLine("a % b + c = " + result4);
    }
}

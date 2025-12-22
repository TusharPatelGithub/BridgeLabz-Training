using System;

class NumberCheck
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine("positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("zero");
        }
    }
}

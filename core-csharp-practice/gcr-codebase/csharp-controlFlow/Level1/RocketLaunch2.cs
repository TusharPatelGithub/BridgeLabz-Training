using System;

class RocketLaunch2
{
    public static void Main(string[] args)
    {
        Console.Write("Enter countdown number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        for (int counter = number; counter >= 1; counter--)
        {
            Console.WriteLine(counter);
        }
    }
}

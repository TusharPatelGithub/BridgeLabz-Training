using System;

class RocketLaunch
{
    public static void Main(string[] args)
    {
        Console.Write("Enter countdown number: ");
        int counter = Convert.ToInt32(Console.ReadLine());
        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }
    }
}

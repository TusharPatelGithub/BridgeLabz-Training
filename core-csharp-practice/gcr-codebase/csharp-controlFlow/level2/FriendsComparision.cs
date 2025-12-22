using System;

class FriendsComparison
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Amar's age:");
        int amarAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Amar's height:");
        double amarHeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Akbar's age:");
        int akbarAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Akbar's height:");
        double akbarHeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Anthony's age:");
        int anthonyAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Anthony's height:");
        double anthonyHeight = Convert.ToDouble(Console.ReadLine());

        if (amarAge <= akbarAge && amarAge <= anthonyAge)
        {
            Console.WriteLine("Amar is the youngest");
        }
        else if (akbarAge <= amarAge && akbarAge <= anthonyAge)
        {
            Console.WriteLine("Akbar is the youngest");
        }
        else
        {
            Console.WriteLine("Anthony is the youngest");
        }

        if (amarHeight >= akbarHeight && amarHeight >= anthonyHeight)
        {
            Console.WriteLine("Amar is the tallest");
        }
        else if (akbarHeight >= amarHeight && akbarHeight >= anthonyHeight)
        {
            Console.WriteLine("Akbar is the tallest");
        }
        else
        {
            Console.WriteLine("Anthony is the tallest");
        }
    }
}

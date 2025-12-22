using System;

class SpringSeason
{
    public static void Main(string[] args)
    {
        int month = Convert.ToInt32(args[0]);
        int day = Convert.ToInt32(args[1]);

        if ((month == 3 && day >= 20) ||
            (month == 4) ||
            (month == 5) ||
            (month == 6 && day <= 20))
        {
            Console.WriteLine("Its a Spring Season");
        }
        else
        {
            Console.WriteLine("Not a Spring Season");
        }
    }
}

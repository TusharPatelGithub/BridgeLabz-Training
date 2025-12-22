using System;

class DayOfWeekProgram
{
    static void Main(string[] args)
    {
        int m = Convert.ToInt32(args[0]);
        int d = Convert.ToInt32(args[1]);
        int y = Convert.ToInt32(args[2]);

        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;

        Console.WriteLine(d0);
    }
}

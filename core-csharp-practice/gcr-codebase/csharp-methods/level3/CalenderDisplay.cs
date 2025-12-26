using System;

public class CalendarDisplay
{
    public static string GetMonthName(int month)
    {
        string[] months =
        {
            "January","February","March","April","May","June",
            "July","August","September","October","November","December"
        };
        return months[month - 1];
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    public static int GetDaysInMonth(int month, int year)
    {
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (month == 2 && IsLeapYear(year))
            return 29;
        return days[month - 1];
    }

    public static int GetFirstDayOfMonth(int month, int year)
    {
        int y = year - (14 - month) / 12;
        int x = y + y / 4 - y / 100 + y / 400;
        int m = month + 12 * ((14 - month) / 12) - 2;
        return (1 + x + (31 * m) / 12) % 7;
    }

    public static void Main()
    {
        Console.Write("Enter month: ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        string monthName = GetMonthName(month);
        int days = GetDaysInMonth(month, year);
        int startDay = GetFirstDayOfMonth(month, year);

        Console.WriteLine("\n    " + monthName + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        for (int i = 0; i < startDay; i++)
            Console.Write("    ");

        for (int day = 1; day <= days; day++)
        {
            Console.Write($"{day,3} ");
            if ((day + startDay) % 7 == 0)
                Console.WriteLine();
        }
    }
}

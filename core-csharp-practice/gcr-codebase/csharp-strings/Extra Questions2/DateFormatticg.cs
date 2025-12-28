using System;

class DateFormatting
{
    static void Main()
    {
        DateTime today = DateTime.Now;

        Console.WriteLine("Format 1 (dd/MM/yyyy): " + today.ToString("dd/MM/yyyy"));
        Console.WriteLine("Format 2 (yyyy-MM-dd): " + today.ToString("yyyy-MM-dd"));
        Console.WriteLine("Format 3 (EEE, MMM dd, yyyy): " + today.ToString("ddd, MMM dd, yyyy"));
    }
}

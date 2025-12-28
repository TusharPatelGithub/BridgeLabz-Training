using System;

class TimeZones
{
    static void Main()
    {
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        TimeZoneInfo gmt = TimeZoneInfo.Utc;
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        Console.WriteLine("Current Time in Different Time Zones:\n");

        Console.WriteLine("GMT : " + TimeZoneInfo.ConvertTime(utcTime, gmt));
        Console.WriteLine("IST : " + TimeZoneInfo.ConvertTime(utcTime, ist));
        Console.WriteLine("PST : " + TimeZoneInfo.ConvertTime(utcTime, pst));
    }
}

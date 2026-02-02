using System;
using System.IO;
using System.Text.RegularExpressions;
class ValidateCSV
{
    static void Main()
    {
        foreach (var line in File.ReadAllLines("employees.csv")[1..])
        {
            var d = line.Split(',');
            if (!Regex.IsMatch(d[4], @"^[^@]+@[^@]+\.[^@]+$") ||
                !Regex.IsMatch(d[5], @"^\d{10}$"))
                Console.WriteLine("Invalid: " + line);
        }
    }
}

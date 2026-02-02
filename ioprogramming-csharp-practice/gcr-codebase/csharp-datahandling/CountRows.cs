using System;
using System.IO;
class CountRows
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");
        Console.WriteLine(lines.Length - 1);
    }
}

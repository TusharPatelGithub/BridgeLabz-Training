using System;
using System.IO;
class ReadCSV
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");
        for (int i = 1; i < lines.Length; i++)
            Console.WriteLine(lines[i].Replace(",", " | "));
    }
}

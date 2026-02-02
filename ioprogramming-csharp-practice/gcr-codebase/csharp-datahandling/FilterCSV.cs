using System;
using System.IO;
class FilterCSV
{
    static void Main()
    {
        foreach (var line in File.ReadAllLines("students.csv")[1..])
        {
            var d = line.Split(',');
            if (int.Parse(d[3]) > 80)
                Console.WriteLine(line);
        }
    }
}

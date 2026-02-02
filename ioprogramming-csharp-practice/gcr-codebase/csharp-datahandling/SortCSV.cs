using System;
using System.IO;
using System.Linq;
class SortCSV
{
    static void Main()
    {
        var sorted = File.ReadAllLines("employees.csv")[1..]
            .OrderByDescending(x => int.Parse(x.Split(',')[3]))
            .Take(5);
        foreach (var s in sorted) Console.WriteLine(s);
    }
}

using System;
using System.IO;
using System.Linq;
class Duplicates
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv")[1..];
        var dupes = lines.GroupBy(l => l.Split(',')[0]).Where(g => g.Count() > 1);
        foreach (var d in dupes.SelectMany(g => g)) Console.WriteLine(d);
    }
}

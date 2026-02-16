using System;
using System.IO;
class FilterStream
{
    static void Main()
    {
        string folder = @"gcr-codebase\collections-csharp-streams";
        using StreamReader sr = new StreamReader(Path.Combine(folder, "input.txt"));
        using StreamWriter sw = new StreamWriter(Path.Combine(folder, "output.txt"));
        string line;
        while ((line = sr.ReadLine()) != null)
            sw.WriteLine(line.ToLower());
    }
}

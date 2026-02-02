using System;
using System.IO;
class LargeFile
{
    static void Main()
    {
        using StreamReader sr =
            new StreamReader(@"gcr-codebase\collections-csharp-streams\large.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
            if (line.ToLower().Contains("error"))
                Console.WriteLine(line);
    }
}
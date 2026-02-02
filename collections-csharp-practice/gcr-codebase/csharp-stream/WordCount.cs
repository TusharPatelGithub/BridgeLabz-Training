using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class WordCount
{
    static void Main()
    {
        Dictionary<string, int> map = new();
        foreach (var word in File.ReadAllText(
            @"gcr-codebase\collections-csharp-streams\text.txt").Split())
        {
            map[word] = map.ContainsKey(word) ? map[word] + 1 : 1;
        }
        foreach (var w in map.OrderByDescending(x => x.Value).Take(5))
            Console.WriteLine(w.Key + " " + w.Value);
    }
}
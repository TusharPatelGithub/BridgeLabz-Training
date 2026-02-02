using System;
using System.Collections.Generic;
class MapInverter
{
    public static void Main(string[] args)
    {
        //original dictionary
        Dictionary<string, int> original = new Dictionary<string, int>
        {
            { "A", 1 },
            { "C", 2 },
            { "D", 1 }
        };
        // Invert the dictionary
        Dictionary<int, List<string>> inverted = InvertDictionary(original);
        // Display result
        Console.WriteLine("Inverted Dictionary:");
        foreach (var pair in inverted)
        {
            Console.WriteLine(pair.Key + " = [" + string.Join(", ", pair.Value) + "]");
        }
    }
    static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> dict)
    {
        Dictionary<V, List<K>> inverted = new Dictionary<V, List<K>>();
        foreach (var pair in dict)
        {
            if (!inverted.ContainsKey(pair.Value))
            {
                inverted[pair.Value] = new List<K>();
            }
            inverted[pair.Value].Add(pair.Key);
        }
        return inverted;
    }
}
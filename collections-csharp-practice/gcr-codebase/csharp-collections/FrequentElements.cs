using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<string> list = new List<string> { "dragon-fruit", "banana", "apple", "orange","dragon-fruit" };
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        //inserting into dictonary via list
        foreach (string item in list)
        {
            if (frequency.ContainsKey(item))
            {
                frequency[item]++;
            }
            else
            {
                frequency[item] = 1;
            }
        }
        //print the dictionary
        foreach (var pair in frequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
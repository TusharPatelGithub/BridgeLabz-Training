using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 1, 2, 3, 4 };
        // Check if set1 is a subset of set2
        bool isSubset = set2.IsSupersetOf(set1);
        Console.WriteLine("Is subset? " + isSubset);
    }
}
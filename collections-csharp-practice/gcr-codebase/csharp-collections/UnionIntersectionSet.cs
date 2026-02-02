using System;
using System.Collections.Generic;
class UnionIntersectionSet
{
    static void Main(string[] args)
    {
        //define two sets
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        //compute union
        HashSet<int> union = new HashSet<int>(set1);
        union.UnionWith(set2);
        //compute intersection
        HashSet<int> intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);
        //display results
        Console.WriteLine("Union: " + string.Join(", ", union));
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));
    }
}
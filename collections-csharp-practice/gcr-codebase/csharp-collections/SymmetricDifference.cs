using System;
using System.Collections.Generic;
class SymmetricDifference
{
    public static void Main(string[] args)
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        // Symmetric difference: elements in either set1 or set2 but not both
        HashSet<int> symmetricDiff = new HashSet<int>(set1);
        symmetricDiff.SymmetricExceptWith(set2);
        Console.WriteLine("Symmetric Difference: " + string.Join(", ", symmetricDiff));
    }
}
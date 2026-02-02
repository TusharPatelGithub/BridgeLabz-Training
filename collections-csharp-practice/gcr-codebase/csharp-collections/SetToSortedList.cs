using System;
using System.Collections.Generic;
class SetToSortedList
{
    public static void Main(string[] args)
    {
        // Input HashSet
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };
        // Convert to List
        List<int> sortedList = new List<int>(set);
        // Sort the list in ascending order
        sortedList.Sort();
        // Display result
        Console.WriteLine("Sorted List: " + string.Join(", ", sortedList));
    }
}
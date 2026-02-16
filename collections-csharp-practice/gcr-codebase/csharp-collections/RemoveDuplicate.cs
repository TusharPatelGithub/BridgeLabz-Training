using System;
using System.Collections.Generic;
class RemoveDuplicate
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 3, 1, 2, 2, 3, 4 };
        List<int> result = RemoveDuplicates(list);
        Console.WriteLine("List after removing duplicates:");
        foreach (int item in result)
        {
            Console.Write(item + " ");
        }
    }
    static List<int> RemoveDuplicates(List<int> list)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();
        foreach (int item in list)
        {
            if (!seen.Contains(item))
            {
                seen.Add(item);
                result.Add(item);
            }
        }
        return result;
    }
}
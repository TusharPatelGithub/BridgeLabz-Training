using System;
using System.Collections.Generic;
class RotateElements
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 10, 20, 30, 40, 50 };
        int k = 2;  // number of positions to rotate
        List<int> rotated = RotateList(list, k);
        Console.WriteLine("Rotated List:");
        foreach (int item in rotated)
        {
            Console.Write(item + " ");
        }
    }
    static List<int> RotateList(List<int> list, int k)
    {
        int n = list.Count;
        k = k % n;  // handle rotations greater than size
        List<int> result = new List<int>();
        // Add elements from k to end
        for (int i = k; i < n; i++)
        {
            result.Add(list[i]);
        }
        // Add first k elements
        for (int i = 0; i < k; i++)
        {
            result.Add(list[i]);
        }
        return result;
    }
}
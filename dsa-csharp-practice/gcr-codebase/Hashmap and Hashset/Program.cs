using System;
using System.Collections.Generic;

class MyHashMap
{
    private const int SIZE = 10;

    // Each bucket is a LinkedList of key-value pairs
    private LinkedList<KeyValuePair<int, int>>[] buckets;

    public MyHashMap()
    {
        buckets = new LinkedList<KeyValuePair<int, int>>[SIZE];
    }

    private int GetIndex(int key)
    {
        return Math.Abs(key.GetHashCode()) % SIZE;
    }

    // Insert or Update
    public void Put(int key, int value)
    {
        int index = GetIndex(key);

        if (buckets[index] == null)
            buckets[index] = new LinkedList<KeyValuePair<int, int>>();

        foreach (var pair in buckets[index])
        {
            if (pair.Key == key)
            {
                buckets[index].Remove(pair);
                buckets[index].AddLast(new KeyValuePair<int, int>(key, value));
                return;
            }
        }

        buckets[index].AddLast(new KeyValuePair<int, int>(key, value));
    }

    // Retrieve value
    public int Get(int key)
    {
        int index = GetIndex(key);

        if (buckets[index] == null)
            return -1;

        foreach (var pair in buckets[index])
        {
            if (pair.Key == key)
                return pair.Value;
        }

        return -1;
    }

    // Remove key
    public void Remove(int key)
    {
        int index = GetIndex(key);

        if (buckets[index] == null)
            return;

        foreach (var pair in buckets[index])
        {
            if (pair.Key == key)
            {
                buckets[index].Remove(pair);
                return;
            }
        }
    }
}
class Program
{
    static void Main()
    {
        MyHashMap map = new MyHashMap();

        map.Put(1, 10);
        map.Put(2, 20);
        map.Put(11, 30); // Collision with key 1

        Console.WriteLine(map.Get(1));  // 10
        Console.WriteLine(map.Get(2));  // 20
        Console.WriteLine(map.Get(11)); // 30

        map.Remove(2);
        Console.WriteLine(map.Get(2));  // -1
    }
}

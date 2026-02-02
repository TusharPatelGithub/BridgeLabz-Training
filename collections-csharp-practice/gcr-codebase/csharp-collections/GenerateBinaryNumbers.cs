using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int N = 5;
        List<string> result = GenerateBinaryNumbers(N);
        Console.WriteLine("First " + N + " binary numbers:");
        Console.WriteLine(string.Join(", ", result));
    }
    static List<string> GenerateBinaryNumbers(int N)
    {
        List<string> result = new List<string>();
        Queue<string> queue = new Queue<string>();
        // Start with "1"
        queue.Enqueue("1");
        for (int i = 0; i < N; i++)
        {
            string front = queue.Dequeue();
            result.Add(front);
            // Append "0" and "1" to front and enqueue
            queue.Enqueue(front + "0");
            queue.Enqueue(front + "1");
        }
        return result;
    }
}
using System;
using System.Collections.Generic;
class ReverseQueueMain
{
    static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        Console.WriteLine("Original Queue: " + string.Join(", ", queue));
        ReverseQueue(queue);
        Console.WriteLine("Reversed Queue: " + string.Join(", ", queue));
    }
    static void ReverseQueue(Queue<int> queue)
    {
        if (queue.Count == 0)
            return;
        // Remove front element
        int front = queue.Dequeue();
        // Recursively reverse remaining queue
        ReverseQueue(queue);
        // Add front element to the back
        queue.Enqueue(front);
    }
}
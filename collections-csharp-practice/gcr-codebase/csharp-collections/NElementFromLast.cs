using System;
using System.Collections.Generic;
class NElementFromLast
{
    static void Main()
    {
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("A");
        linkedList.AddLast("B");
        linkedList.AddLast("C");
        linkedList.AddLast("D");
        linkedList.AddLast("E");
        int N = 2;
        string result = NthFromEnd(linkedList, N);
        Console.WriteLine($"The {N}th element from the end is: {result}");
    }
    static string NthFromEnd(LinkedList<string> list, int N)
    {
        LinkedListNode<string> first = list.First;
        LinkedListNode<string> second = list.First;
        // Move first pointer N nodes ahead
        for (int i = 0; i < N; i++)
        {
            if (first == null)
                return null; // N is larger than the list size
            first = first.Next;
        }
        // Move both pointers until first reaches the end
        while (first != null)
        {
            first = first.Next;
            second = second.Next;
        }
        return second.Value;
    }
}
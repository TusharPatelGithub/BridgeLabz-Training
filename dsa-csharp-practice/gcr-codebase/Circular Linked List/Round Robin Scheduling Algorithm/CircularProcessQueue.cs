using System;

public class CircularProcessQueue
{
    private ProcessNode head;
    private ProcessNode tail;

    // Add process at end
    public void AddProcess(int id, int burstTime, int priority)
    {
        ProcessNode newNode = new ProcessNode(id, burstTime, priority);

        if (head == null)
        {
            head = tail = newNode;
            newNode.Next = newNode;
            return;
        }

        tail.Next = newNode;
        newNode.Next = head;
        tail = newNode;
    }

    // Remove process by ID
    public void RemoveProcess(int id)
    {
        if (head == null)
            return;

        ProcessNode curr = head;
        ProcessNode prev = tail;

        do
        {
            if (curr.ProcessId == id)
            {
                if (curr == head)
                    head = head.Next;

                if (curr == tail)
                    tail = prev;

                prev.Next = curr.Next;

                if (head == curr)
                    head = null;

                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);
    }

    public ProcessNode GetHead()
    {
        return head;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    // Display processes
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue.");
            return;
        }

        ProcessNode temp = head;
        do
        {
            Console.WriteLine($"PID: {temp.ProcessId}, Remaining: {temp.RemainingTime}");
            temp = temp.Next;
        } while (temp != head);
    }
}

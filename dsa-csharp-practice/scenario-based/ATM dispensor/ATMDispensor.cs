using System;

public class ATMDispenser
{
    public static void Dispense(int amount, int[] denominations)
    {
        MyLinkedList list = new MyLinkedList();
        MyStack stack = new MyStack();
        MyQueue queue = new MyQueue();

        foreach (int d in denominations)
            list.AddLast(d);

        Node current = list.GetHead();

        while (current != null)
        {
            int note = current.Data;
            int count = amount / note;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                    stack.Push(note);

                amount -= count * note;
            }

            current = current.Next;
        }

        if (amount != 0)
        {
            Console.WriteLine($" Exact amount not possible. Remaining ₹{amount}");
        }
        while (!stack.IsEmpty())
            queue.Enqueue(stack.Pop());

        Console.WriteLine("Dispensed Notes:");
        while (!queue.IsEmpty())
            Console.WriteLine("₹" + queue.Dequeue());
    }
}

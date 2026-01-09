public class Queue
{
    private Node front, rear;

    public void Enqueue(int data)
    {
        Node node = new Node(data);

        if (rear == null)
        {
            front = rear = node;
            return;
        }

        rear.Next = node;
        rear = node;
    }

    public int Dequeue()
    {
        if (front == null)
            return -1;

        int value = front.Data;
        front = front.Next;

        if (front == null)
            rear = null;

        return value;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
}

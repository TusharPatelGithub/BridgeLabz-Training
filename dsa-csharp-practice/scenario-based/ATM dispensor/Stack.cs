public class MyStack
{
    private Node top;

    public void Push(int data)
    {
        Node node = new Node(data);
        node.Next = top;
        top = node;
    }

    public int Pop()
    {
        if (top == null)
            return -1;

        int value = top.Data;
        top = top.Next;
        return value;
    }

    public bool IsEmpty()
    {
        return top == null;
    }
}

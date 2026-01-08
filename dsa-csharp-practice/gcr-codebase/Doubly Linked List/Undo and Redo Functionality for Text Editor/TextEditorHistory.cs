class TextEditorHistory
{
    private TextStateNode head;
    private TextStateNode tail;
    private TextStateNode current;
    private int size;
    private readonly int maxSize;

    public TextEditorHistory(int limit = 10)
    {
        maxSize = limit;
        size = 0;
    }

    // Add new text state
    public void AddState(string content)
    {
        TextStateNode newNode = new TextStateNode(content);

        // Remove redo history
        if (current != null && current.Next != null)
        {
            current.Next.Prev = null;
            current.Next = null;
            tail = current;
            size = CountNodes();
        }

        if (head == null)
        {
            head = tail = current = newNode;
            size = 1;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
        current = newNode;
        size++;

        // Limit history size
        if (size > maxSize)
        {
            head = head.Next;
            head.Prev = null;
            size--;
        }
    }

    // Undo operation
    public void Undo()
    {
        if (current == null || current.Prev == null)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        current = current.Prev;
        Console.WriteLine("Undo performed.");
    }

    // Redo operation
    public void Redo()
    {
        if (current == null || current.Next == null)
        {
            Console.WriteLine("Nothing to redo.");
            return;
        }

        current = current.Next;
        Console.WriteLine("Redo performed.");
    }

    // Display current text
    public void DisplayCurrentState()
    {
        if (current == null)
        {
            Console.WriteLine("Editor is empty.");
            return;
        }

        Console.WriteLine($"Current Text: \"{current.Content}\"");
    }

    // Helper to recount nodes (used after clearing redo)
    private int CountNodes()
    {
        int count = 0;
        TextStateNode temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }
}

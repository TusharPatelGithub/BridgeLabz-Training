class CircularTaskScheduler
{
    private TaskNode head;
    private TaskNode current;

    // Add at beginning
    public void AddAtBeginning(int id, string name, int priority, DateTime dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = current = newNode;
            newNode.Next = newNode;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
        {
            temp = temp.Next;
        }

        newNode.Next = head;
        temp.Next = newNode;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string name, int priority, DateTime dueDate)
    {
        if (head == null)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        TaskNode newNode = new TaskNode(id, name, priority, dueDate);
        TaskNode temp = head;

        while (temp.Next != head)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
        newNode.Next = head;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int position, int id, string name, int priority, DateTime dueDate)
    {
        if (position <= 1)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        TaskNode temp = head;
        for (int i = 1; i < position - 1 && temp.Next != head; i++)
        {
            temp = temp.Next;
        }

        TaskNode newNode = new TaskNode(id, name, priority, dueDate);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove by Task ID
    public void RemoveByTaskId(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        TaskNode prev = null;

        do
        {
            if (temp.TaskId == taskId)
            {
                if (temp == head)
                {
                    TaskNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    head = head.Next;
                    last.Next = head;
                }
                else
                {
                    prev.Next = temp.Next;
                }

                Console.WriteLine("Task removed successfully.");
                return;
            }

            prev = temp;
            temp = temp.Next;

        } while (temp != head);

        Console.WriteLine("Task not found.");
    }

    // View current task and move to next
    public void ViewCurrentAndMoveNext()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine($"Current Task → ID: {current.TaskId}, Name: {current.TaskName}, Priority: {current.Priority}, Due: {current.DueDate.ToShortDateString()}");
        current = current.Next;
    }

    // Display all tasks
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        do
        {
            Console.WriteLine($"ID: {temp.TaskId}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due: {temp.DueDate.ToShortDateString()}");
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        bool found = false;

        do
        {
            if (temp.Priority == priority)
            {
                Console.WriteLine($"ID: {temp.TaskId}, Name: {temp.TaskName}, Due: {temp.DueDate.ToShortDateString()}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tasks found with this priority.");
    }
}
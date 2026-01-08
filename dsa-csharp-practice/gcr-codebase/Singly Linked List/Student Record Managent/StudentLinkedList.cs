class StudentLinkedList
{
    private StudentNode head;

    // Add at beginning
    public void AddAtBeginning(int rollNo, string name, int age, char grade)
    {
        StudentNode newNode = new StudentNode(rollNo, name, age, grade);
        newNode.Next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int rollNo, string name, int age, char grade)
    {
        StudentNode newNode = new StudentNode(rollNo, name, age, grade);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    // Add at specific position (1-based index)
    public void AddAtPosition(int position, int rollNo, string name, int age, char grade)
    {
        if (position <= 1)
        {
            AddAtBeginning(rollNo, name, age, grade);
            return;
        }

        StudentNode newNode = new StudentNode(rollNo, name, age, grade);
        StudentNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Delete by Roll Number
    public void DeleteByRollNo(int rollNo)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (head.RollNo == rollNo)
        {
            head = head.Next;
            Console.WriteLine("Student record deleted.");
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null && temp.Next.RollNo != rollNo)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        temp.Next = temp.Next.Next;
        Console.WriteLine("Student record deleted.");
    }

    // Search by Roll Number
    public void SearchByRollNo(int rollNo)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.RollNo == rollNo)
            {
                Console.WriteLine($"Found: {temp.RollNo}, {temp.Name}, {temp.Age}, {temp.Grade}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    // Update grade
    public void UpdateGrade(int rollNo, char newGrade)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.RollNo == rollNo)
            {
                temp.Grade = newGrade;
                Console.WriteLine("Grade updated successfully.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    // Display all records
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No student records available.");
            return;
        }

        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"RollNo: {temp.RollNo}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
            temp = temp.Next;
        }
    }
}

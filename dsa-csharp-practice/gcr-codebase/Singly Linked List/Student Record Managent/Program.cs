class Program
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();

        list.AddAtEnd(1, "Tushar", 21, 'A');
        list.AddAtBeginning(2, "Rahul", 22, 'B');
        list.AddAtPosition(2, 3, "Amit", 20, 'A');

        list.Display();

        list.SearchByRollNo(3);
        list.UpdateGrade(2, 'A');
        list.DeleteByRollNo(1);

        Console.WriteLine("\nAfter updates:");
        list.Display();
    }
}
class Program
{
    static void Main()
    {
        CircularTaskScheduler scheduler = new CircularTaskScheduler();

        scheduler.AddAtEnd(1, "DSA Practice", 1, DateTime.Now.AddDays(2));
        scheduler.AddAtBeginning(2, "Project Work", 2, DateTime.Now.AddDays(5));
        scheduler.AddAtPosition(2, 3, "Mock Interview", 1, DateTime.Now.AddDays(1));

        Console.WriteLine("All Tasks:");
        scheduler.DisplayAll();

        Console.WriteLine("\nView Current Task:");
        scheduler.ViewCurrentAndMoveNext();
        scheduler.ViewCurrentAndMoveNext();

        Console.WriteLine("\nSearch by Priority (1):");
        scheduler.SearchByPriority(1);

        Console.WriteLine("\nRemove Task:");
        scheduler.RemoveByTaskId(2);

        Console.WriteLine("\nFinal Task List:");
        scheduler.DisplayAll();
    }
}
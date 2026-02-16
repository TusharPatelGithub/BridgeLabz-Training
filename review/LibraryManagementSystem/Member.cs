using System;

public class Member : User
{
    public Member(Library library) : base(library) { }

    public override void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- User Menu ---");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Search Book");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": library.DisplayBooks(); break;
                case "2":
                    Console.Write("Search: ");
                    library.SearchBook(Console.ReadLine());
                    break;
                case "3": return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}

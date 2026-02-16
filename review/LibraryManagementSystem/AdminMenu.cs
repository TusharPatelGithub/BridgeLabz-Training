using System;

public class Admin : User
{
    public Admin(Library library) : base(library) { }

    public override void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Checkout Book");
            Console.WriteLine("5. Checkin Book");
            Console.WriteLine("6. Logout");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Author: ");
                    string author = Console.ReadLine();
                    library.AddBook(new Book(title, author));
                    break;

                case "2": library.DisplayBooks(); break;
                case "3":
                    Console.Write("Search: ");
                    library.SearchBook(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Title: ");
                    library.CheckoutBook(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Title: ");
                    library.CheckinBook(Console.ReadLine());
                    break;
                case "6": return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}

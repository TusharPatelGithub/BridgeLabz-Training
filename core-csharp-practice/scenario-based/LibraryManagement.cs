using System;

class LibrarySystem
{
    static string[,] books; 

    static void Main()
    {
        Library(); 
    }
    static void Library()
    {
        Console.Write("Enter number of books: ");
        int n = Convert.ToInt32(Console.ReadLine());

        books = new string[n, 3];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter details for Book {i + 1}:");

            Console.Write("Book Name: ");
            books[i, 0] = Console.ReadLine().ToLower();

            Console.Write("Author Name: ");
            books[i, 1] = Console.ReadLine().ToLower();

            books[i, 2] = "Available";
        }

        Menu();
    }
    static void Menu()
    {
        Console.WriteLine("Library Menu: ");
        Console.WriteLine("1. Search Book");
        Console.WriteLine("2. Display All Books");
        Console.Write("Enter your choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: SearchBook();
                break;

            case 2: DisplayBooks();
            break;

            default:Console.WriteLine("Invalid choice: ");
            break;
        }

        Menu();
    }
    static void SearchBook()
    {
        Console.Write("Enter book name to search: ");
        string search = Console.ReadLine().ToLower();

        bool found = false;

        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (books[i, 0].Contains(search))
            {
                Console.WriteLine("\nBook is Found: ");
                Console.WriteLine($"Title  : {books[i, 0]}");
                Console.WriteLine($"Author : {books[i, 1]}");
                Console.WriteLine($"Status : {books[i, 2]}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    static void DisplayBooks()
    {
        Console.WriteLine("--- Book List ---");

        for (int i = 0; i < books.GetLength(0); i++)
        {
            Console.WriteLine($"{i + 1}. {books[i, 0]} | {books[i, 1]} | {books[i, 2]}");
        }
    }
}

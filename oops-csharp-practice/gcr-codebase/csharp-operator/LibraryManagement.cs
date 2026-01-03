using System;

class Book
{
    public static string LibraryName = "Central City Library";

    public string Title;
    public string Author;

    public readonly string ISBN;

    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine("Title  : " + Title);
        Console.WriteLine("Author : " + Author);
        Console.WriteLine("ISBN   : " + ISBN);
    }
}

class LibrarySystem
{
    static void Main(string[] args)
    {
        Book.DisplayLibraryName();
        Console.WriteLine();

        Book book1 = new Book("Clean Code", "Robert C. Martin", "ISBN-101");

        if (book1 is Book)
        {
            Console.WriteLine("Object is a Book instance.\n");
            book1.DisplayBookDetails();
        }
        else
        {
            Console.WriteLine("Object is NOT a Book.");
        }
    }
}

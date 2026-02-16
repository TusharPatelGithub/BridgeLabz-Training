using System;

public class Library : IBookOperations
{
    private Book[] books = new Book[100];
    private int count = 0;
    public void AddBook(Book book)
    {
        books[count++] = book;
        Console.WriteLine("Book added successfully.");
    }
    public void DisplayBooks()
    {
        if (count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(books[i]);
        }
    }
    public void SearchBook(string partialTitle)
    {
        bool found = false;
        for (int i = 0; i < count; i++)
        {
            if (books[i].Title.ToLower().Contains(partialTitle.ToLower()))
            {
                Console.WriteLine(books[i]);
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("No matching books found.");
    }
    public void CheckoutBook(string title)
    {
        foreach (Book book in books)
        {
            if (book != null && book.Title.ToLower() == title.ToLower())
            {
                if (book.Status == "Available")
                {
                    book.Checkout();
                    Console.WriteLine("Book checked out successfully.");
                }
                else
                    Console.WriteLine("Book already checked out.");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }
    public void CheckinBook(string title)
    {
        foreach (Book book in books)
        {
            if (book != null && book.Title.ToLower() == title.ToLower())
            {
                if (book.Status == "Checked Out")
                {
                    book.Checkin();
                    Console.WriteLine("Book checked in successfully.");
                }
                else
                    Console.WriteLine("Book already available.");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }
}

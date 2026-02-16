class BookService : IBookService
{
    private List<Book> books;
        
    public BookService()
    {
        books = new List<Book>();
    }
    
    public void AddBook(Book book)
    {
        foreach(Book existingBook in books)
        {
            if (existingBook.BookID==book.BookID)
            {
                return;
            }
          
        }
          books.Add(book);
    }
    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            System.Console.WriteLine("No books availaible: ");
            return;
        }
        foreach(Book book in books)
        {
            System.Console.WriteLine("Book id: "+book.BookID);
            System.Console.WriteLine("Book Name: "+book.BookName);
            System.Console.WriteLine("Book Author: "+book.Author);
            System.Console.WriteLine("Book Category: "+book.Category);
            System.Console.WriteLine("Book price: "+book.Price);
        }
    }
    public void SearchById(int id)
    {
        foreach(Book book in books)
        {
            if (book.BookID == id)
            {
            System.Console.WriteLine("Book id: "+book.BookID);
            System.Console.WriteLine("Book Name: "+book.BookName);
            System.Console.WriteLine("Book Author: "+book.Author);
            System.Console.WriteLine("Book Category: "+book.Category);
            System.Console.WriteLine("Book price: "+book.Price);
            return;
            }

        }
        System.Console.WriteLine("Book not found: ");
    }
    public void DisplayByCategory(string Category)
    {
        foreach(Book book in books)
        {
            if (book.Category == Category)
            {
                
            }
        }
    }
}
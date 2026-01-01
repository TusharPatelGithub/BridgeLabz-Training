class EBook : Book
{
    public EBook(string isbn, string title, string author)
        : base(isbn, title, author)
    {
    }

    public void DisplayDetails()
    {
        Console.WriteLine("ISBN: " + ISBN);      
        Console.WriteLine("Title: " + title);   
        Console.WriteLine("Author: " + GetAuthor());
    }
}

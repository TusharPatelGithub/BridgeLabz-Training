class Book
{
    public string ISBN;       
    protected string title;   
    private string author;    
r
    public Book(string isbn, string title, string author)
    {
        this.ISBN = isbn;
        this.title = title;
        this.author = author;
    }

    public string GetAuthor()
    {
        return author;
    }
    public void SetAuthor(string author)
    {
        this.author = author;
    }
}

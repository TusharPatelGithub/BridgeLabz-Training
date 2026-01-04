using System;

class Book
{
    protected string Title;
    protected int PublicationYear;

    public Book(string title, int publicationYear)
    {
        Title = title;
        PublicationYear = publicationYear;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Book Title: " + Title);
        Console.WriteLine("Publication Year: " + PublicationYear);
    }
}

class Author : Book
{
    private string Name;
    private string Bio;

    public Author(string title, int publicationYear, string name, string bio)
        : base(title, publicationYear)
    {
        Name = name;
        Bio = bio;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Author Name: " + Name);
        Console.WriteLine("Author Bio: " + Bio);
    }
}

class BooksAuthor
{
    static void Main(string[] args)
    {
        Author bookAuthor = new Author(
            "Clean Code",
            2008,
            "Robert C. Martin",
            "Software engineer and author known for Clean Code principles."
        );

        bookAuthor.DisplayInfo();
    }
}

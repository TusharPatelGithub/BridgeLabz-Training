using System;
public class Book
{
    private string title;
    private string author;
    private string status;
    private string checkoutTime;
    private string checkinTime;
    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
        status = "Available";
        checkoutTime = "N/A";
        checkinTime = "N/A";
    }
    public string Title { get { return title; } }
    public string Author { get { return author; } }
    public string Status { get { return status; } }
    public void Checkout()
    {
        status = "Checked Out";
        checkoutTime = DateTime.Now.ToString();
        checkinTime = "N/A";
    }
    public void Checkin()
    {
        status = "Available";
        checkinTime = DateTime.Now.ToString();
    }
    public override string ToString()
    {
        return $"Title: {title}, Author: {author}, Status: {status}";
    }
}

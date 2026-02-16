public interface IBookOperations
{
    void AddBook(Book book);
    void DisplayBooks();
    void SearchBook(string partialTitle);
    void CheckoutBook(string title);
    void CheckinBook(string title);
}

interface ILibrarySevice
{
    void AddBook(Book book);
    void RemoveBookByID(int id);
    Book SearchBookByISBN(string value);
    void DisplayBooks();
    void AddMember(Member member);
    void BorrowBook(Book book,Member member);
    void ReturnBook(Book book,Member member);
}
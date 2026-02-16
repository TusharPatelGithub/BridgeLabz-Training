interface IBookService
{
     void AddBook(Book book);
     void DisplayBooks();
     void SearchById(int id);
     void DisplayByCategory(string Category);
     void SortByPrice();

}
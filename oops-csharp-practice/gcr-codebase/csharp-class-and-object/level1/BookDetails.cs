class BookDetails
{
    public class Books
    {
        string title;
        string author;
        int price;
        public Books(string title, string author, int price)
        {
            this.title=title;
            this.author=author;
            this.price=price;
        }
        public void display()
        {
            Console.WriteLine($"Title of this book is {title}");
            Console.WriteLine($"Author of this book is {author}");
            Console.WriteLine($"Price of this book is {price}");
            
        }
    }
    public static void Main(string[] args)
    {
        Books b1=new Books("maths","np bali",1000);
        b1.display();
    }
}
using System;
class DynamicOnlineMarketplace
{
    class BookCategory
    {
        public string genre;
        public BookCategory(string genre)
        {
            this.genre = genre;
        }
    }
    class ClothingCategory
    {
        public string size;
        public ClothingCategory(string size)
        {
            this.size = size;
        }
    }
    abstract class Product<TCategory>
    {
        public int productId;
        public string productName;
        public double price;
        public TCategory category;
        protected Product(int productId, string productName, double price, TCategory category)
        {
            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.category = category;
        }
        public abstract void Display();
    }
    class BookProduct : Product<BookCategory>
    {
        public BookProduct(int id, string name, double price, BookCategory category)
            : base(id, name, price, category) { }
        public override void Display()
        {
            Console.WriteLine($"[Book] ID:{productId}, Name:{productName}, Price:{price}, Genre:{category.genre}");
        }
    }
    class ClothingProduct : Product<ClothingCategory>
    {
        public ClothingProduct(int id, string name, double price, ClothingCategory category)
            : base(id, name, price, category) { }
        public override void Display()
        {
            Console.WriteLine($"[Clothing] ID:{productId}, Name:{productName}, Price:{price}, Size:{category.size}");
        }
    }
    static void ApplyDiscount<T>(T product, double percentage) where T : Product<object>
    {
        product.price -= product.price * (percentage / 100);
    }
    public static void Main(string[] args)
    {
        BookProduct[] books = new BookProduct[3];
        ClothingProduct[] clothes = new ClothingProduct[3];
        int bookCount = 0, clothCount = 0;
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== Dynamic Online Marketplace ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Clothing");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Display Clothing");
            Console.WriteLine("5. Apply Discount to Books");
            Console.WriteLine("6. Apply Discount to Clothing");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    if (bookCount < books.Length)
                    {
                        Console.Write("ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Genre: ");
                        string genre = Console.ReadLine();
                        books[bookCount++] =
                            new BookProduct(id, name, price, new BookCategory(genre));
                    }
                    else
                        Console.WriteLine("Book catalog full!");
                    break;
                case 2:
                    if (clothCount < clothes.Length)
                    {
                        Console.Write("ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Size: ");
                        string size = Console.ReadLine();
                        clothes[clothCount++] =
                            new ClothingProduct(id, name, price, new ClothingCategory(size));
                    }
                    else
                        Console.WriteLine("Clothing catalog full!");
                    break;
                case 3:
                    Console.WriteLine("\n--- Books ---");
                    for (int i = 0; i < bookCount; i++)
                        books[i].Display();
                    break;
                case 4:
                    Console.WriteLine("\n--- Clothing ---");
                    for (int i = 0; i < clothCount; i++)
                        clothes[i].Display();
                    break;
                case 5:
                    for (int i = 0; i < bookCount; i++)
                        books[i].price -= books[i].price * 0.10;
                    Console.WriteLine("10% discount applied to all books.");
                    break;
                case 6:
                    for (int i = 0; i < clothCount; i++)
                        clothes[i].price -= clothes[i].price * 0.15;
                    Console.WriteLine("15% discount applied to all clothing.");
                    break;
                case 7:
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

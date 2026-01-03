using System;

class Product
{
    public static double Discount = 10;
    public string ProductName;
    public double Price;
    public int Quantity;
    public readonly int ProductID;

    public Product(string productName, double price, int quantity, int productID)
    {
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
        this.ProductID = productID;
    }

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    public void DisplayProductDetails()
    {
        double discountedPrice = Price - (Price * Discount / 100);

        Console.WriteLine("Product ID   : " + ProductID);
        Console.WriteLine("Product Name : " + ProductName);
        Console.WriteLine("Price        : " + Price);
        Console.WriteLine("Quantity     : " + Quantity);
        Console.WriteLine("Discounted Price : " + discountedPrice);
    }
}

class Shopping
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Laptop", 50000, 1, 201);

        Product.UpdateDiscount(15);

        if (product1 is Product)
        {
            product1.DisplayProductDetails();
        }
        else
        {
            Console.WriteLine("Invalid product object");
        }
    }
}

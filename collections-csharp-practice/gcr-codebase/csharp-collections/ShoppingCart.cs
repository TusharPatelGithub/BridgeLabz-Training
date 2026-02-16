using System;
using System.Collections.Generic;
class ShoppingCart
{
    // Dictionary for product prices
    private Dictionary<string, double> products = new Dictionary<string, double>();
    // List to maintain insertion order (like LinkedDictionary)
    private List<string> productOrder = new List<string>();
    // Add product to cart
    public void AddProduct(string name, double price)
    {
        if (!products.ContainsKey(name))
        {
            products[name] = price;
            productOrder.Add(name);
        }
        else
        {
            Console.WriteLine($"Product '{name}' is already in the cart. Updating price to {price}");
            products[name] = price;
        }
    }
    // Display items in order of insertion
    public void DisplayCartByOrder()
    {
        Console.WriteLine("\nShopping Cart (Insertion Order):");
        foreach (string name in productOrder)
        {
            Console.WriteLine($"{name}: ${products[name]:0.00}");
        }
    }
    // Display items sorted by product name
    public void DisplayCartSortedByName()
    {
        Console.WriteLine("\nShopping Cart (Sorted by Product Name):");
        List<string> names = new List<string>(products.Keys);
        names.Sort();
        foreach (string name in names)
        {
            Console.WriteLine($"{name}: ${products[name]:0.00}");
        }
    }
    // Display items sorted by price
    public void DisplayCartSortedByPrice()
    {
        Console.WriteLine("\nShopping Cart (Sorted by Price):");
        // Convert dictionary to list of KeyValuePair for sorting
        List<KeyValuePair<string, double>> productList = new List<KeyValuePair<string, double>>(products);
        // Bubble sort by price ascending
        for (int i = 0; i < productList.Count - 1; i++)
        {
            for (int j = 0; j < productList.Count - i - 1; j++)
            {
                if (productList[j].Value > productList[j + 1].Value)
                {
                    var temp = productList[j];
                    productList[j] = productList[j + 1];
                    productList[j + 1] = temp;
                }
            }
        }
        foreach (var pair in productList)
        {
            Console.WriteLine($"{pair.Key}: ${pair.Value:0.00}");
        }
    }
}
class Program
{
    public static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart();
        // Adding products
        cart.AddProduct("Laptop", 1200.50);
        cart.AddProduct("smartphone", 25000.75);
        cart.AddProduct("electric kettel", 445.50);
        cart.AddProduct("monitor", 300.00);
        cart.AddProduct("electric heating rod", 312.00); // update price
        // Display shopping cart
        cart.DisplayCartByOrder();
        cart.DisplayCartSortedByName();
        cart.DisplayCartSortedByPrice();
    }
}
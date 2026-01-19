using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Deals
{
    class FlashDealMain
    {
        public static void Main(String[] args)
        {
            Product[] products =
            {
                new Product{productId = 101, productName = "T.V.",discount = 85.60},
                new Product{productId = 234, productName = "Refrigerator", discount = 45},
                new Product{productId = 103, productName = "Smart Phone", discount = 55},
                new Product{productId = 133, productName = "Smart T.V.", discount = 75},
                new Product{productId = 153, productName = "Smart Fridge", discount = 75.9},
                new Product{productId = 113, productName = "Laptop", discount = 67},
                new Product{productId = 451, productName = "Smart Watch", discount = 65.45},
            };
            Console.WriteLine("Before Sorting: ");
            PrintProducts(products);
            QuickSort.Sort(products, 0, products.Length - 1);
            Console.WriteLine("After Sorting: ");
            PrintProducts(products);
        }
        static void PrintProducts(Product[] products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
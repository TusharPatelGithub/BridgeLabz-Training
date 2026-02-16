using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzCollections.ScenarioBased.SmartCheckout
{
    public class CheckoutUtilityImpl : ISmartCheckout
    {
        private Queue<Customer> customerQueue;
        private Dictionary<string, Item> itemMap;
        public CheckoutUtilityImpl()
        {
            customerQueue = new Queue<Customer>();
            itemMap = new Dictionary<string, Item>(); //predefined items and price and their stocks
            itemMap.Add("milk", new Item("milk", 50, 25));
            itemMap.Add("bread", new Item("bread", 70, 35));
            itemMap.Add("eggs", new Item("eggs",8, 250));
            itemMap.Add("sandwitch braed", new Item("sandwitch bread", 70, 15));
            itemMap.Add("ketchup", new Item("ketchup", 80, 35));
        }
        public void AddCustomer() //add a customer in a queue add adds item  for them
        {
            Console.Write("ENter customer name:");
            string customerName = Console.ReadLine();
            Customer customer = new Customer(customerName);
            Console.Write("enter no. of items: ");
            int itemCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < itemCount; i++)
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine();
                if (itemMap.ContainsKey(itemName))
                {
                    customer.Items.Add(itemName);
                }
                else
                {
                    Console.WriteLine("item not available.");
                }
            }
            customerQueue.Enqueue(customer);
            Console.WriteLine("Customer added to queue");
        }
        public void ProcessCustomer() //dequeue a customer and makes their bill
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("No customers in queue.");
                return;
            }
            Customer customer = customerQueue.Dequeue();
            double totalBill = 0;
            Console.WriteLine($"\n billing for {customer.CustomerName}");
            foreach(string itemName in customer.Items)
            {
                Item item = itemMap[itemName];
                if (item.Stock > 0)
                {
                    item.Stock--;
                    totalBill += item.Price;
                    Console.WriteLine($"{itemName} - {item.Price}");
                }
                else
                {
                    Console.WriteLine($"{itemName} is out of stock");
                }
            }
            Console.WriteLine($"total bill: {totalBill}");
        }
        public void ShowQueue() //shows the customer in queue
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("queue is empty");
                return;
            }
            Console.WriteLine("\n customers in queue: ");
            foreach(Customer customer in customerQueue)
            {
                Console.WriteLine(customer.CustomerName);
            }
        }
        public void ShowItems() // show all items and price and stock in store
        {
            Console.WriteLine("\n available items: ");
            foreach(var entry in itemMap)
            {
                Item item = entry.Value;
                Console.WriteLine($"{item.ItemName} | price: {item.Price} | stock: {item.Stock}");
            }
        }
    }
}

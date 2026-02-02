using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzCollections.ScenarioBased.SmartCheckout
{
    public class CheckoutMain
    {
        public static void Main(string[] args)
        {
            ISmartCheckout checkout = new CheckoutUtilityImpl();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n smart checkout system");
                Console.WriteLine("1. add customer to queue");
                Console.WriteLine("2. process customer billing");
                Console.WriteLine("3. show customer queue");
                Console.WriteLine("4. show available items");
                Console.WriteLine("5. exit");
                Console.Write("enter choice: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        checkout.AddCustomer();
                        break;
                    case "2":
                        checkout.ProcessCustomer();
                        break;
                    case "3":
                        checkout.ShowQueue();
                        break;
                    case "4":
                        checkout.ShowItems();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("exiting...");
                        break;
                    default:
                        Console.WriteLine("invalid choice.");
                        return;
                }
            }
        }
    }
}

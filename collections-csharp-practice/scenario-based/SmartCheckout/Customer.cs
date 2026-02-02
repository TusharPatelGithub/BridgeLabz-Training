using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BridgeLabzCollections.ScenarioBased.SmartCheckout
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public List<string> Items { get; set; }
        public Customer(string customerName)
        {
            CustomerName = customerName;
            Items = new List<string>();
        }
    }
}

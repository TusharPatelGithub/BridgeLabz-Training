using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzCollections.ScenarioBased.SmartCheckout
{
    public class Item
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Item(string itemNmae,double price,int stock)
        {
            ItemName = itemNmae;
            Price = price;
            Stock = stock;
        }
    }
}

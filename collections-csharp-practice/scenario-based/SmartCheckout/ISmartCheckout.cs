using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BridgeLabzCollections.ScenarioBased.SmartCheckout
{
    public interface ISmartCheckout
    {
        void AddCustomer(); //interface for adding customer and their items
        void ProcessCustomer(); //deque a customer and makes bill
        void ShowQueue(); //interface for showing all customers in queue
        void ShowItems(); //interface for showing all items their price and stock
    }
}

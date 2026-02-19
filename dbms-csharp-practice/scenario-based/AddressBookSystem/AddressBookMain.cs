using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BridgeLabz.AddressBookSystem
{
    internal class AddressBookMain
    {
        public static async Task Main(string[] args)
        {
            AddressBookMenu menu = new AddressBookMenu();
            await menu.Start();
        }
    }
}

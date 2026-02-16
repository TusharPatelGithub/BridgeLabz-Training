using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BridgeLabz.AddressBookSystem
{
        interface IAddressBook
        {
        void DisplayWelcomeMessage(AddressBookModel model); //uc0
        void AddNewContact(); //uc2+uc5+uc7    
        void DisplayAllContacts(); //uc2(inside selected address book)
        void EditContact(); //uc3
        void DeleteContact(); // uc4
        void CreateAddressBook(); //uc6
        void SelectAddressBook(); //refactor of uc6
        void SearchPersonByCityOrState(); //uc8
        void ViewPersonsByCityOrStateInBook(); //uc9
        void CountPersonsByCityOrState(); //uc10
        void SortContactsByName(); //uc11
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public interface IAddressBook
    {
        bool AddContact(Contact contact);
        void SortByName();
        void DisplayAllContacts();
    }
}

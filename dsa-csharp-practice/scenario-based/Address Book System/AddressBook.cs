using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Collections.Generic;

namespace AddressBookSystem
{
    public class AddressBook : IAddressBook
    {
        private Contact[] contacts = new Contact[5];
        private int index = 0;

        public bool AddContact(Contact contact)
        {
            if (index >= contacts.Length)
                return false;

            for (int i = 0; i < index; i++)
            {
                if (contacts[i].Equals(contact))
                    return false;
            }

            contacts[index++] = contact;
            return true;
        }

        // UC10: Sort alphabetically by First Name
        public void SortByName()
        {
            for (int i = 0; i < index - 1; i++)
            {
                for (int j = 0; j < index - i - 1; j++)
                {
                    if (string.Compare(
                        contacts[j].FirstName,
                        contacts[j + 1].FirstName) > 0)
                    {
                        Contact temp = contacts[j];
                        contacts[j] = contacts[j + 1];
                        contacts[j + 1] = temp;
                    }
                }
            }
        }

        public void DisplayAllContacts()
        {
            for (int i = 0; i < index; i++)
            {
                contacts[i].DisplayContact();
            }
        }
    }
}

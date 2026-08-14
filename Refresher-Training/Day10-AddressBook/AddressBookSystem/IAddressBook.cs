using System;
namespace BridgeLabz.AddressBookSystem
{
        interface IAddressBook
        {
        void DisplayWelcomeMessage(AddressBookModel model);
        void AddNewContact();
        void DisplayAllContacts();
        void EditContact();
        void DeleteContact();
        void CreateAddressBook();
        void SelectAddressBook();
        void SearchPersonByCityOrState();
        void ViewPersonsByCityOrStateInBook();
        void CountPersonsByCityOrState();
        void SortContactsByName();
        }
}

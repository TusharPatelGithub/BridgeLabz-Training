using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        public static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            addressBook.AddContact(
                new Contact("Tushar", "Patel", "A", "Ahmedabad", "Gujarat", "1", "9", "a@mail"));

            addressBook.AddContact(
                new Contact("Amit", "Shah", "B", "Surat", "Gujarat", "2", "8", "b@mail"));

            addressBook.AddContact(
                new Contact("Rahul", "Mehta", "C", "Pune", "Maharashtra", "3", "7", "c@mail"));

            Console.WriteLine("Before Sorting:");
            addressBook.DisplayAllContacts();

            addressBook.SortByName();

            Console.WriteLine("\nAfter Sorting by Name:");
            addressBook.DisplayAllContacts();
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BridgeLabz.AddressBookSystem
{
    class AddressBookUtilityImpl : IAddressBook
    {
        private AppDbContext db;
        private AddressBookEntity currentAddressBook;

        public AddressBookUtilityImpl()
        {
           db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options);
        }

        public void DisplayWelcomeMessage(AddressBookModel model)
        {
            Console.WriteLine("====================================");
            Console.WriteLine(model.WelcomeMessage);
            Console.WriteLine("====================================\n");
        }

        public void CreateAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Address Book name cannot be empty");

            if (db.AddressBooks.Any(a => a.Name == name))
                throw new DuplicateContactException("Address Book already exists");

            AddressBookEntity newBook = new AddressBookEntity { Name = name };
            db.AddressBooks.Add(newBook);
            db.SaveChanges();

            currentAddressBook = newBook;
            Console.WriteLine($"Address Book '{name}' created and selected\n");
        }

        public void AddNewContact()
        {
            if (currentAddressBook == null)
                throw new EmptyInputException("Select an Address Book first");

            AddressBookModel contact = new AddressBookModel();
            contact.AddContact();

            bool duplicate = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .AsEnumerable()
                .Any(c => c.Equals(contact));

            if (duplicate)
                throw new DuplicateContactException("Duplicate contact not allowed");

            contact.AddressBookEntityId = currentAddressBook.Id;
            db.Contacts.Add(contact);
            db.SaveChanges();

            Console.WriteLine("Contact added successfully\n");
        }

        public void DisplayAllContacts()
        {
            if (currentAddressBook == null)
                throw new EmptyInputException("Select Address Book first");

            List<AddressBookModel> contacts = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .ToList();

            foreach (AddressBookModel contact in contacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("------------------------");
            }
        }

        public void EditContact()
        {
            Console.Write("Enter First Name to edit: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Name cannot be empty");

            AddressBookModel contact = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .AsEnumerable()
                .FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
                throw new ContactNotFoundException("Contact not found");

            Console.Write("Enter New City: ");
            contact.City = Console.ReadLine();

            db.SaveChanges();
            Console.WriteLine("Contact updated successfully\n");
        }

        public void DeleteContact()
        {
            Console.Write("Enter First Name to delete: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Name cannot be empty");

            AddressBookModel contact = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .AsEnumerable()
                .FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
                throw new ContactNotFoundException("Contact not found");

            db.Contacts.Remove(contact);
            db.SaveChanges();
            Console.WriteLine("Contact deleted successfully\n");
        }

        public void SelectAddressBook()
        {
            List<AddressBookEntity> books = db.AddressBooks.ToList();

            if (books.Count == 0)
            {
                Console.WriteLine("No Address Books available. Create one first.\n");
                return;
            }

            Console.WriteLine("Available Address Books:");
            foreach (AddressBookEntity book in books)
                Console.WriteLine("- " + book.Name);

            Console.Write("Enter Address Book name: ");
            string nameToSelect = Console.ReadLine();

            AddressBookEntity selected = books.FirstOrDefault(b => b.Name == nameToSelect);

            if (selected == null)
                throw new ContactNotFoundException("Address Book not found");

            currentAddressBook = selected;
            Console.WriteLine($"'{currentAddressBook.Name}' selected\n");
        }

        public void SearchPersonByCityOrState()
        {
            if (!db.AddressBooks.Any())
                throw new ContactNotFoundException("No Address Books available");

            Console.Write("Search by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");

            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");

            List<AddressBookModel> allContacts = db.Contacts.Include(c => c.AddressBookEntity).ToList();

            bool found = false;

            foreach (AddressBookModel contact in allContacts)
            {
                bool match =
                    (option == 1 && contact.City.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                    (option == 2 && contact.State.Equals(value, StringComparison.OrdinalIgnoreCase));

                if (match)
                {
                    if (!found)
                    {
                        Console.WriteLine("\nSearch Results:");
                        found = true;
                    }

                    Console.WriteLine($"Address Book: {contact.AddressBookEntity.Name}");
                    Console.WriteLine(contact);
                    Console.WriteLine("----------------------");
                }
            }

            if (!found)
                throw new ContactNotFoundException("No matching persons found");
        }

        public void ViewPersonsByCityOrStateInBook()
        {
            if (currentAddressBook == null)
                throw new EmptyInputException("Select an Address Book first");

            Console.Write("Search by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");

            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");

            List<AddressBookModel> contacts = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .ToList();

            bool found = false;

            foreach (AddressBookModel contact in contacts)
            {
                bool match =
                    (option == 1 && contact.City.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                    (option == 2 && contact.State.Equals(value, StringComparison.OrdinalIgnoreCase));

                if (match)
                {
                    if (!found)
                    {
                        Console.WriteLine($"\nPersons in '{currentAddressBook.Name}':");
                        found = true;
                    }

                    Console.WriteLine(contact);
                    Console.WriteLine("----------------------");
                }
            }

            if (!found)
                throw new ContactNotFoundException("No persons found in this Address Book");
        }

        public void CountPersonsByCityOrState()
        {
            if (!db.AddressBooks.Any())
                throw new ContactNotFoundException("No Address Books available");

            Console.Write("Count by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");

            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");

            List<AddressBookModel> allContacts = db.Contacts.ToList();

            int count = allContacts.Count(contact =>
                (option == 1 && contact.City.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                (option == 2 && contact.State.Equals(value, StringComparison.OrdinalIgnoreCase))
            );

            Console.WriteLine($"Total persons found: {count}\n");
        }

        public void SortContactsByName()
        {
            if (currentAddressBook == null)
                throw new EmptyInputException("Select an Address Book first");

            List<AddressBookModel> contacts = db.Contacts
                .Where(c => c.AddressBookEntityId == currentAddressBook.Id)
                .ToList();

            if (contacts.Count <= 1)
            {
                Console.WriteLine("Not enough contacts to sort\n");
                return;
            }

            contacts.Sort((c1, c2) =>
                string.Compare(
                    c1.FirstName + c1.LastName,
                    c2.FirstName + c2.LastName,
                    StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nSorted Contacts in '{currentAddressBook.Name}':");

            foreach (AddressBookModel contact in contacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------");
            }
        }
    }
}

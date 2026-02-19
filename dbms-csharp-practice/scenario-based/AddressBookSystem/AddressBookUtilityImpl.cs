using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text.Json;
using System.Net.Http;
using System.Text;
namespace BridgeLabz.AddressBookSystem
{
    class AddressBookUtilityImpl : IAddressBook
    {
        //uc6 – Dictionary of Address Books
        private Dictionary<string, List<AddressBookModel>> addressBooks;
        private string? currentAddressBookName;
        private readonly IDataSource sqlDataSource = new SqlDataSource();
        public AddressBookUtilityImpl()
        {
            addressBooks = new Dictionary<string, List<AddressBookModel>>();
        }
        //uc0
        public void DisplayWelcomeMessage(AddressBookModel model)
        {
            Console.WriteLine("====================================");
            Console.WriteLine(model.WelcomeMessage);
            Console.WriteLine("====================================\n");
        }
        //uc6 – Create New Address Book
        public void CreateAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Address Book name cannot be empty");
            if (addressBooks.ContainsKey(name))
                throw new DuplicateContactException("Address Book already exists");
            addressBooks.Add(name, new List<AddressBookModel>());
            currentAddressBookName = name;
            Console.WriteLine($"Address Book '{name}' created and selected\n");
        }
        // Ensures an address book is selected before performing operations
        private void EnsureAddressBookSelected()
        {
        if (string.IsNullOrWhiteSpace(currentAddressBookName) || !addressBooks.ContainsKey(currentAddressBookName))
            {
                throw new InvalidOperationException("Please select an Address Book first");
            }
        }
        //uc1+uc2+uc5 - add New Contact reusing add contact for uc5, no extra code needed add number selected address book 
        public void AddNewContact()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select an Address Book first");
            AddressBookModel contact = new AddressBookModel();
            contact.AddContact();
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
            if (contacts.Contains(contact))
                throw new DuplicateContactException("Duplicate contact not allowed");
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully\n");
        }
        //uc2- display All Contacts
        public void DisplayAllContacts()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select Address Book first");
            foreach (AddressBookModel contact in addressBooks[currentAddressBookName])
            {
                Console.WriteLine(contact);
                Console.WriteLine("------------------------");
            }
        }
        //uc3 – Edit contact using name
        public void EditContact()
        {
            Console.Write("Enter First Name to edit: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Name cannot be empty");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
            AddressBookModel contact = contacts.Find(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
                throw new ContactNotFoundException("Contact not found");
            Console.Write("Enter New City: ");
            contact.City = Console.ReadLine();
            Console.WriteLine("Contact updated successfully\n");
        }
        //uc4 - delete the contact using name
        public void DeleteContact()
        {
            Console.Write("Enter First Name to delete: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyInputException("Name cannot be empty");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
            AddressBookModel contact = contacts.Find(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
                throw new ContactNotFoundException("Contact not found");
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully\n");
        }
        //uc6– Select Address Book refactor uc6
        public void SelectAddressBook()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books available. Create one first.\n");
                return;
            }
            Console.WriteLine("Available Address Books:");
            foreach (string name in addressBooks.Keys)
                Console.WriteLine("- " + name);
            Console.Write("Enter Address Book name: ");
            string nameToSelect = Console.ReadLine();
            if (!addressBooks.ContainsKey(nameToSelect))
                throw new ContactNotFoundException("Address Book not found");
            currentAddressBookName = nameToSelect;
            Console.WriteLine($"'{currentAddressBookName}' selected\n");
        }
        //uc8 searching person by city or state
        public void SearchPersonByCityOrState()
        {
            if (addressBooks.Count == 0)
                throw new ContactNotFoundException("No Address Books available");
            Console.Write("Search by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");
            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");
            bool found = false;
            foreach (var entry in addressBooks)
            {
                foreach (AddressBookModel contact in entry.Value)
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
                        Console.WriteLine($"Address Book: {entry.Key}");
                        Console.WriteLine(contact);
                        Console.WriteLine("----------------------");
                    }
                }
            }
            if (!found)
                throw new ContactNotFoundException("No matching persons found");
        }
        //uc9-feature to search person by city or state in a book
        public void ViewPersonsByCityOrStateInBook()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select an Address Book first");
            Console.Write("Search by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");
            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
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
                        Console.WriteLine($"\nPersons in '{currentAddressBookName}':");
                        found = true;
                    }
                    Console.WriteLine(contact);
                    Console.WriteLine("----------------------");
                }
            }
            if (!found)
                throw new ContactNotFoundException("No persons found in this Address Book");
        }
        //uc10-count person by city or state across all address books
        public void CountPersonsByCityOrState()
        {
            if (addressBooks.Count == 0)
                throw new ContactNotFoundException("No Address Books available");
            Console.Write("Count by (1) City or (2) State: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid option");
            Console.Write("Enter City/State name: ");
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyInputException("Search value cannot be empty");
            int count = 0;
            foreach (var entry in addressBooks)
            {
                count += entry.Value.Count(contact =>
                    (option == 1 && contact.City.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                    (option == 2 && contact.State.Equals(value, StringComparison.OrdinalIgnoreCase))
                );
            }
            Console.WriteLine($"Total persons found: {count}\n");
        }
        //uc11-sort contacts using person name alphabetically
        public void SortContactsByName()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select an Address Book first");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
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
            Console.WriteLine($"\nSorted Contacts in '{currentAddressBookName}':");
            foreach (AddressBookModel contact in contacts)
            {
                Console.WriteLine(contact); // uses ToString()
                Console.WriteLine("----------------------");
            }
        }
        //uc 12 - sorting contancts by location by city, state, ZIP
        public void SortContactsByLocation()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select an Address Book first");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
            if (contacts.Count <= 1)
            {
                Console.WriteLine("Not enough contacts to sort\n");
                return;
            }
            Console.WriteLine("Sort by:");
            Console.WriteLine("1. City");
            Console.WriteLine("2. State");
            Console.WriteLine("3. Zip");
            Console.Write("Enter the option number: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
                throw new InvalidMenuChoiceException("Invalid sorting option");
            switch (option)
            {
                case 1:
                    contacts.Sort((c1, c2) =>
                        string.Compare(c1.City, c2.City, StringComparison.OrdinalIgnoreCase));
                    break;
                case 2:
                    contacts.Sort((c1, c2) =>
                        string.Compare(c1.State, c2.State, StringComparison.OrdinalIgnoreCase));
                    break;
                case 3:
                    contacts.Sort((c1, c2) =>
                        string.Compare(c1.Zip, c2.Zip, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new InvalidMenuChoiceException("Invalid sorting choice");
            }
            Console.WriteLine($"\nSorted Contacts in '{currentAddressBookName}':");
            foreach (AddressBookModel contact in contacts)
            {
                Console.WriteLine(contact); // Uses overridden ToString()
                Console.WriteLine("----------------------");
            }
        }
        //uc13,uc17 - feature to write to file,ensuring IO operation not blocking main thread while doing curd operation 
        public async Task WriteAddressBookToFileAsync()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select Address Book first");
            string fileName = currentAddressBookName + ".txt";
            using StreamWriter writer = new StreamWriter(fileName);
            foreach (var contact in addressBooks[currentAddressBookName])
            {
                await writer.WriteLineAsync($"{contact.FirstName},{contact.LastName},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}");
            }
            Console.WriteLine("Address Book written to file asynchronously\n");
        }
        //uc13,uc17 - feature to read from file,ensuring IO operation not blocking main thread while doing curd operation
        public async Task ReadAddressBookFromFileAsync()
        {
            
            Console.Write("Enter Address Book name to load: ");
            string bookName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bookName))
                throw new EmptyInputException("Address Book name cannot be empty");
            string fileName = bookName + ".txt";
            if (!File.Exists(fileName))
                throw new ContactNotFoundException("File does not exist");
            List<AddressBookModel> contacts = new List<AddressBookModel>();
            using StreamReader reader = new StreamReader(fileName);
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] data = line.Split(',');
                contacts.Add(new AddressBookModel
                {
                    FirstName = data[0],
                    LastName = data[1],
                    City = data[2],
                    State = data[3],
                    Zip = data[4],
                    PhoneNumber = data[5],
                    Email = data[6]
                });
            }
            addressBooks[bookName] = contacts;
            currentAddressBookName = bookName;
            Console.WriteLine("Address Book loaded asynchronously\n");
        }
        //uc 14,uc17 - feature to write in CSV file,ensuring IO operation not blocking main thread while doing curd operation
        public async Task WriteAddressBookToCSVAsync()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select Address Book first");
            using var writer = new StreamWriter(currentAddressBookName + ".csv");
            using var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
            await csv.WriteRecordsAsync(addressBooks[currentAddressBookName]);
            Console.WriteLine("CSV written asynchronously\n");
        }
        //uc 14,uc17 - feature to write contact to Csv file,ensuring IO operation not blocking main thread while doing curd operation
        public async Task ReadAddressBookFromCSVAsync()
        {
            Console.Write("Enter Address Book name: ");
            string bookName = Console.ReadLine();
            using var reader = new StreamReader(bookName + ".csv");
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            var records = new List<AddressBookModel>();
            await foreach (var record in csv.GetRecordsAsync<AddressBookModel>())
            {
                records.Add(record);
            }
            addressBooks[bookName] = records;
            currentAddressBookName = bookName;
            Console.WriteLine("CSV loaded asynchronously\n");
        }
        //uc15,uc17 - feature to write contacts in JSON file,ensuring IO operation not blocking main thread while doing curd operation
        public async Task WriteAddressBookToJsonAsync()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select Address Book first");
            string json = JsonSerializer.Serialize(addressBooks[currentAddressBookName],
            new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(currentAddressBookName + ".json", json);
            Console.WriteLine("JSON written asynchronously\n");
        }
        //uc15,uc17 - feature to read contacts from JSOn file,ensuring IO operation not blocking main thread while doing curd operation
        public async Task ReadAddressBookFromJsonAsync()
        {
            Console.Write("Enter Address Book name: ");
            string bookName = Console.ReadLine();
            string json = await File.ReadAllTextAsync(bookName + ".json");
            addressBooks[bookName] =
            JsonSerializer.Deserialize<List<AddressBookModel>>(json);
            currentAddressBookName = bookName;
            Console.WriteLine("JSON loaded asynchronously\n");
        }
        //uc16 -- feature to add contacts to JSON server
        public async Task WriteAddressBookToServer()
        {
            if (currentAddressBookName == null)
                throw new EmptyInputException("Select Address Book first");
            List<AddressBookModel> contacts = addressBooks[currentAddressBookName];
            using (HttpClient client = new HttpClient())
            {
                foreach (var contact in contacts)
                    {
                        string json = JsonSerializer.Serialize(contact);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync("http://localhost:3000/contacts", content);
                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Failed to send data to server");
                    }
            }
            Console.WriteLine("Contacts successfully sent to JSON Server\n");
        }
        //uc16 -- feature to read from JSON Server
        public async Task ReadAddressBookFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/contacts");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch data from server");
            string json = await response.Content.ReadAsStringAsync();
            List<AddressBookModel> contacts = JsonSerializer.Deserialize<List<AddressBookModel>>(json);
            Console.Write("Enter Address Book name to store fetched data: ");
            string bookName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bookName))
                throw new EmptyInputException("Address Book name cannot be empty");
            addressBooks[bookName] = contacts;
            currentAddressBookName = bookName;
            Console.WriteLine("Contacts successfully loaded from server\n");
            }
        }
        // uc-18 Save to Database
        public async Task SaveAddressBookToDatabase()
        {
            // Ensure an address book is selected
            EnsureAddressBookSelected();
            // Save contacts asynchronously to avoid blocking main thread
            await Task.Run(() =>
            sqlDataSource.Save(
            currentAddressBookName!,
            addressBooks[currentAddressBookName!]
                                )
            );
            Console.WriteLine("Address Book saved to Database\n");
        }
        // uc-18 Load from Database
        public async Task LoadAddressBookFromDatabase()
        {
                Console.Write("Enter Address Book name: ");
                string name = Console.ReadLine() ?? throw new EmptyInputException("Address Book name cannot be empty");
            // Load asynchronously from database
            var contacts = await Task.Run(() => sqlDataSource.Load(name));
            addressBooks[name] = contacts;
            currentAddressBookName = name;
            Console.WriteLine("Address Book loaded from Database\n");
        }
    }
}

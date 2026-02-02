using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BridgeLabz.AddressBookSystem
{
    class AddressBookMenu
    {
        public static void Start()
        {
            AddressBookModel model = new AddressBookModel();
            model.WelcomeMessage = "WELCOME TO ADDRESS BOOK SYSTEM";
            IAddressBook service = new AddressBookUtilityImpl();
            service.DisplayWelcomeMessage(model);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Add New Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Edit Existing Contact");
                Console.WriteLine("6. Delete a contact");
                Console.WriteLine("7. Search Person by City or State");
                Console.WriteLine("8. View Persons by City or State (Specific Address Book)");
                Console.WriteLine("9. Count Persons by City or State");
                Console.WriteLine("10. Sort Contacts by Name");
                Console.WriteLine("11. Exit");
                try //added the exceptions for the cases following
                {
                    Console.Write("Enter choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                        throw new InvalidMenuChoiceException("Menu choice must be numeric");

                    switch (choice)
                    {
                        case 1: service.CreateAddressBook(); break;
                        case 2: service.SelectAddressBook(); break;
                        case 3: service.AddNewContact(); break;
                        case 4: service.DisplayAllContacts(); break;
                        case 5: service.EditContact(); break;
                        case 6: service.DeleteContact(); break;
                        case 7: service.SearchPersonByCityOrState(); break;
                        case 8: service.ViewPersonsByCityOrStateInBook(); break;
                        case 9: service.CountPersonsByCityOrState(); break;
                        case 10: service.SortContactsByName(); break;
                        case 11:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            throw new InvalidMenuChoiceException("Invalid menu choice");
                    }
                }
                catch (DuplicateContactException ex)
                {
                    Console.WriteLine($"Duplicate Error: {ex.Message}\n");
                }
                catch (ContactNotFoundException ex)
                {
                    Console.WriteLine($"Not Found: {ex.Message}\n");
                }
                catch (EmptyInputException ex)
                {
                    Console.WriteLine($"Input Error: {ex.Message}\n");
                }
                catch (InvalidMenuChoiceException ex)
                {
                    Console.WriteLine($"Menu Error: {ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}\n");
                }

            }
        }
    }
}

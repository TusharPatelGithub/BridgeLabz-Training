using System;

class LibraryManagementMain
{
    static void Main()
    {
        Library library = new Library();
        const string ADMIN_KEY = "admin123";

        while (true)
        {
            Console.WriteLine("\n--- Library System ---");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter Admin Key: ");
                if (Console.ReadLine() == ADMIN_KEY)
                    new Admin(library).ShowMenu();
                else
                    Console.WriteLine("Wrong key.");
            }
            else if (choice == "2")
            {
                new Member(library).ShowMenu();
            }
            else if (choice == "3")
                return;
            else
                Console.WriteLine("Invalid choice.");
        }
    }
}

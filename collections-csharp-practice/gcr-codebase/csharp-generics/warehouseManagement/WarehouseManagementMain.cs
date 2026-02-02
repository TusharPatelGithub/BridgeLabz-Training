using System;
class WarehouseManagementMain
{
    static void Main(string[] args)
    {
        Storage<Electronics> electronicsStorage = new Storage<Electronics>(5);
        Storage<Groceries> groceriesStorage = new Storage<Groceries>(5);
        Storage<Furniture> furnitureStorage = new Storage<Furniture>(5);
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== Smart Warehouse Management ===");
            Console.WriteLine("1. Add Electronics");
            Console.WriteLine("2. Add Groceries");
            Console.WriteLine("3. Add Furniture");
            Console.WriteLine("4. Display Electronics");
            Console.WriteLine("5. Display Groceries");
            Console.WriteLine("6. Display Furniture");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddElectronics(electronicsStorage);
                    break;
                case 2:
                    AddGroceries(groceriesStorage);
                    break;
                case 3:
                    AddFurniture(furnitureStorage);
                    break;
                case 4:
                    electronicsStorage.DisplayItems();
                    break;
                case 5:
                    groceriesStorage.DisplayItems();
                    break;
                case 6:
                    furnitureStorage.DisplayItems();
                    break;
                case 7:
                    exit = true;
                    Console.WriteLine("Exiting application...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
    static void AddElectronics(Storage<Electronics> storage)
    {
        Console.Write("Enter Item ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine();
        Electronics item = new Electronics(id, name);
        storage.AddItem(item);
    }
    static void AddGroceries(Storage<Groceries> storage)
    {
        Console.Write("Enter Item ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine();
        Groceries item = new Groceries(id, name);
        storage.AddItem(item);
    }
    static void AddFurniture(Storage<Furniture> storage)
    {
        Console.Write("Enter Item ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine();
        Furniture item = new Furniture(id, name);
        storage.AddItem(item);
    }
}

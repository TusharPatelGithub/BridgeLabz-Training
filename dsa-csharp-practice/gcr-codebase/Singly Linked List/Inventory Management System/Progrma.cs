class Program
{
    static void Main()
    {
        InventoryLinkedList inventory = new InventoryLinkedList();

        inventory.AddAtEnd(101, "Keyboard", 10, 500);
        inventory.AddAtBeginning(102, "Mouse", 20, 300);
        inventory.AddAtPosition(2, 103, "Monitor", 5, 7000);

        Console.WriteLine("Inventory:");
        inventory.DisplayAll();

        inventory.UpdateQuantity(101, 15);
        inventory.SearchByName("Mouse");

        inventory.CalculateTotalValue();

        Console.WriteLine("\nSorted by Price (Descending):");
        inventory.Sort("price", false);
        inventory.DisplayAll();
    }
}
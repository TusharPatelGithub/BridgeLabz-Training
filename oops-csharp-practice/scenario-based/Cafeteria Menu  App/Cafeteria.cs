class Cafeteria
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
        Console.Write("Select an item number: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        string selectedItem = menu.GetItemByIndex(choice);
        Console.WriteLine("You selected: " + selectedItem);
    }
}
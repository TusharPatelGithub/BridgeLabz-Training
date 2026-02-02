using System;
class Storage<T> where T : WarehouseItem
{
    private T[] items;
    private int count;
    public Storage(int size)
    {
        items = new T[size];
        count = 0;
    }
    public void AddItem(T item)
    {
        if (count < items.Length)
        {
            items[count++] = item;
            Console.WriteLine("Item added successfully.");
        }
        else
        {
            Console.WriteLine("Storage is full!");
        }
    }
    public void DisplayItems()
    {
        if (count == 0)
        {
            Console.WriteLine("No items in storage.");
            return;
        }
        Console.WriteLine("\n--- Stored Items ---");
        for (int i = 0; i < count; i++)
        {
            items[i].Display();
        }
    }
}

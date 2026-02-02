using System;
class Groceries : WarehouseItem
{
    public Groceries(int itemId, string itemName)
        : base(itemId, itemName){}
    public override void Display()
    {
        Console.WriteLine($"[Groceries] ID: {itemId}, Name: {itemName}");
    }
}

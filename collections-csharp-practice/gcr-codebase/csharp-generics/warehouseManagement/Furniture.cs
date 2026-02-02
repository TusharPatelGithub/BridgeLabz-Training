using System;
class Furniture : WarehouseItem
{
    public Furniture(int itemId, string itemName)
        : base(itemId, itemName){}
    public override void Display()
    {
        Console.WriteLine($"[Furniture] ID: {itemId}, Name: {itemName}");
    }
}

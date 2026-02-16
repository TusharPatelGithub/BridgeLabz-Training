using System;
class Electronics : WarehouseItem
{
    public Electronics(int itemId, string itemName)
        : base(itemId, itemName)
    {
    }
    public override void Display()
    {
        Console.WriteLine($"[Electronics] ID: {itemId}, Name: {itemName}");
    }
}

using System;
abstract class WarehouseItem
{
    public int itemId;
    public string itemName;
    public WarehouseItem(int itemId, string itemName)
    {
        this.itemId = itemId;
        this.itemName = itemName;
    }
    public abstract void Display();
}

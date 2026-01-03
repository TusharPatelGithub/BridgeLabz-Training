using System;

class Menu
{
    public string[] items = {
        "Veg Sandwich",
        "Cheese Burger",
        "French Fries",
        "Pizza Slice",
        "Pasta",
        "Cold Coffee",
        "Tea",
        "Veg Momos",
        "Noodles",
        "Ice Cream"
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Cafeteria Menu:");
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine(i + " - " + items[i]);
        }
    }

    public string GetItemByIndex(int index)
    {
        if (index >= 0 && index < items.Length)
            return items[index];
        else
            return "Invalid selection";
    }
}


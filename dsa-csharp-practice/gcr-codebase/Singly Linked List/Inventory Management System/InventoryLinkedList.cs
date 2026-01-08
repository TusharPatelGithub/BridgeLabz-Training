class InventoryLinkedList
{
    private ItemNode head;

    // Add at beginning
    public void AddAtBeginning(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.Next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);

        if (head == null)
        {
            head = newNode;
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int position, int id, string name, int qty, double price)
    {
        if (position <= 1)
        {
            AddAtBeginning(id, name, qty, price);
            return;
        }

        ItemNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove by Item ID
    public void RemoveByItemId(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        if (head.ItemId == id)
        {
            head = head.Next;
            Console.WriteLine("Item removed.");
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null && temp.Next.ItemId != id)
            temp = temp.Next;

        if (temp.Next == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        temp.Next = temp.Next.Next;
        Console.WriteLine("Item removed.");
    }

    // Update quantity
    public void UpdateQuantity(int id, int newQty)
    {
        ItemNode temp = head;

        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                temp.Quantity = newQty;
                Console.WriteLine("Quantity updated.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Item not found.");
    }

    // Search by Item ID
    public void SearchById(int id)
    {
        ItemNode temp = head;

        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                DisplayItem(temp);
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Item not found.");
    }

    // Search by Item Name
    public void SearchByName(string name)
    {
        ItemNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                DisplayItem(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Item not found.");
    }

    // Total inventory value
    public void CalculateTotalValue()
    {
        double total = 0;
        ItemNode temp = head;

        while (temp != null)
        {
            total += temp.Price * temp.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine($"Total Inventory Value: {total}");
    }

    // Sort by name or price
    public void Sort(string by, bool ascending)
    {
        if (head == null)
            return;

        for (ItemNode i = head; i.Next != null; i = i.Next)
        {
            for (ItemNode j = i.Next; j != null; j = j.Next)
            {
                bool swap = false;

                if (by == "name")
                {
                    int cmp = string.Compare(i.ItemName, j.ItemName, true);
                    swap = ascending ? cmp > 0 : cmp < 0;
                }
                else if (by == "price")
                {
                    swap = ascending ? i.Price > j.Price : i.Price < j.Price;
                }

                if (swap)
                {
                    SwapData(i, j);
                }
            }
        }
    }

    private void SwapData(ItemNode a, ItemNode b)
    {
        (a.ItemId, b.ItemId) = (b.ItemId, a.ItemId);
        (a.ItemName, b.ItemName) = (b.ItemName, a.ItemName);
        (a.Quantity, b.Quantity) = (b.Quantity, a.Quantity);
        (a.Price, b.Price) = (b.Price, a.Price);
    }

    // Display all items
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        ItemNode temp = head;
        while (temp != null)
        {
            DisplayItem(temp);
            temp = temp.Next;
        }
    }

    private void DisplayItem(ItemNode item)
    {
        Console.WriteLine($"ID: {item.ItemId}, Name: {item.ItemName}, Qty: {item.Quantity}, Price: {item.Price}");
    }
}
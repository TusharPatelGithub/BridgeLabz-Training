public class Unit{ //represents a hospital unit(node in circular linked list)
    public string Name;
    public bool IsAvailable;
    public Unit Next;
    public Unit(string name, bool isAvailable){ //constructor
        Name = name;
        IsAvailable = isAvailable;
        Next = null;
    }
}
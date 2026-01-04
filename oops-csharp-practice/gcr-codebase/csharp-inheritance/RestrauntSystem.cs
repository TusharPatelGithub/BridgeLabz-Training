using System;

interface Worker
{
    void PerformDuties();
}

class Person
{
    public string Name;
    public int Id;

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

class Chef : Person, Worker
{
    public string SpecialDish;

    public Chef(string name, int id, string specialDish)
        : base(name, id)
    {
        SpecialDish = specialDish;
    }

    public void PerformDuties()
    {
        Console.WriteLine("Role : Chef");
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("ID   : " + Id);
        Console.WriteLine("Task : Preparing " + SpecialDish);
    }
}

class Waiter : Person, Worker
{
    public int TableCount;

    public Waiter(string name, int id, int tableCount)
        : base(name, id)
    {
        TableCount = tableCount;
    }

    public void PerformDuties()
    {
        Console.WriteLine("Role : Waiter");
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("ID   : " + Id);
        Console.WriteLine("Task : Serving " + TableCount + " tables");
    }
}

class RestaurantSystem

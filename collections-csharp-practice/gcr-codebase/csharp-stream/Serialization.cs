using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}
class SerializationDemo
{
    static void Main()
    {
        string file = @"gcr-codebase\collections-csharp-streams\employees.json";
        List<Employee> list = new()
        {
            new Employee{Id=1, Name="A", Department="IT", Salary=50000},
            new Employee{Id=2, Name="B", Department="HR", Salary=40000}
        };
        string json = JsonSerializer.Serialize(list);
        File.WriteAllText(file, json);
        var data = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(file));
        foreach (var e in data)
            Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
    }
}
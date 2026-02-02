using System;
using System.IO;
using System.Collections.Generic;
class Student
{
    public string Name;
    public override string ToString() => Name;
}
class CSVtoObject
{
    static void Main()
    {
        List<Student> list = new();
        foreach (var l in File.ReadAllLines("students.csv")[1..])
            list.Add(new Student { Name = l.Split(',')[1] });
        list.ForEach(Console.WriteLine);
    }
}

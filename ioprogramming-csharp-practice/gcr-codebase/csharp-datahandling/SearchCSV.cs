using System;
using System.IO;
class SearchCSV
{
    static void Main()
    {
        foreach (var line in File.ReadAllLines("employees.csv")[1..])
        {
            var d = line.Split(',');
            if (d[1] == "Rahul")
                Console.WriteLine($"Dept: {d[2]}, Salary: {d[3]}");
        }
    }
}

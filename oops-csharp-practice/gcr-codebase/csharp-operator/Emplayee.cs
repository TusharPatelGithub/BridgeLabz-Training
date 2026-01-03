using System;

class Employee
{
    public static string CompanyName = "Tech Solutions Pvt Ltd";
    private static int totalEmployees = 0;

    public string Name;
    public string Designation;
    public readonly int Id;

    public Employee(string name, int id, string designation)
    {
        this.Name = name;
        this.Id = id;
        this.Designation = designation;
        totalEmployees++;
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Name        : " + Name);
        Console.WriteLine("ID          : " + Id);
        Console.WriteLine("Designation : " + Designation);
    }
}

class EmployeeSystem
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee("Tushar", 101, "Software Engineer");
        Employee emp2 = new Employee("Amit", 102, "Tester");

        Console.WriteLine("Company Name: " + Employee.CompanyName);
        Employee.DisplayTotalEmployees();
        Console.WriteLine();

        if (emp1 is Employee)
        {
            emp1.DisplayEmployeeDetails();
        }
    }
}

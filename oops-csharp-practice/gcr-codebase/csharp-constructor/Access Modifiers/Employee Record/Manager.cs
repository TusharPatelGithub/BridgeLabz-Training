class Manager : Employee
{
    public Manager(int employeeID, string department, double salary)
        : base(employeeID, department, salary)
    {
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Employee ID: " + employeeID);
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Salary: " + GetSalary());
    }
}

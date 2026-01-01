class Employee
{
    public int employeeID;       
    protected string department;
    private double salary;       

    public Employee(int employeeID, string department, double salary)
    {
        this.employeeID = employeeID;
        this.department = department;
        this.salary = salary;
    }

    public void SetSalary(double newSalary)
    {
        salary = newSalary;
    }

    public double GetSalary()
    {
        return salary;
    }
}

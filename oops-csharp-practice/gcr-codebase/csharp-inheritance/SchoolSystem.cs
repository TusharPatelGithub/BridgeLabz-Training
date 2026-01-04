using System;

class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Teacher : Person
{
    public string Subject;

    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role   : Teacher");
        Console.WriteLine("Name   : " + Name);
        Console.WriteLine("Age    : " + Age);
        Console.WriteLine("Subject: " + Subject);
    }
}

class Student : Person
{
    public string Grade;

    public Student(string name, int age, string grade)
        : base(name, age)
    {
        Grade = grade;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role  : Student");
        Console.WriteLine("Name  : " + Name);
        Console.WriteLine("Age   : " + Age);
        Console.WriteLine("Grade : " + Grade);
    }
}

class Staff : Person
{
    public string Department;

    public Staff(string name, int age, string department)
        : base(name, age)
    {
        Department = department;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role       : Staff");
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Age        : " + Age);
        Console.WriteLine("Department : " + Department);
    }
}

class SchoolSystem
{
    static void Main(string[] args)
    {
        Teacher teacher = new Teacher("Tushar", 30, "Mathematics");
        Student student = new Student("Neha", 18, "12th");
        Staff staff = new Staff("Amit", 40, "Administration");

        teacher.DisplayRole();
        Console.WriteLine();

        student.DisplayRole();
        Console.WriteLine();

        staff.DisplayRole();
    }
}

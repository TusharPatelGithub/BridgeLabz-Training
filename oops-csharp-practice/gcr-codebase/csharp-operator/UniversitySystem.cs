using System;

class Student
{
    public static string UniversityName = "Global Tech University";
    private static int totalStudents = 0;

    public string Name;
    public string Grade;
    public readonly int RollNumber;

    public Student(string name, int rollNumber, string grade)
    {
        this.Name = name;
        this.RollNumber = rollNumber;
        this.Grade = grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Roll No    : " + RollNumber);
        Console.WriteLine("Grade      : " + Grade);
    }
}

class UniversitySystem
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Tushar", 1, "A");
        Student s2 = new Student("Neha", 2, "B");

        Console.WriteLine("University Name: " + Student.UniversityName);
        Student.DisplayTotalStudents();
        Console.WriteLine();

        if (s1 is Student)
        {
            s1.DisplayStudentDetails();
        }
    }
}

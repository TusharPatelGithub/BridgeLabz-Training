using System;

class StudentNode
{
    public int RollNo;
    public string Name;
    public int Age;
    public char Grade;
    public StudentNode Next;

    public StudentNode(int rollNo, string name, int age, char grade)
    {
        RollNo = rollNo;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}
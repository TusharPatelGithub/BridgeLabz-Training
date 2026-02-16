class Student
{
    public int StudentId{get; set;}
    public string Name{get; set;}
    public double Marks{get; set;}
    public Student(int StudentId,string Name,double Marks)
    {
        this.StudentId=StudentId;
        this.Name=Name;
        this.Marks=Marks;
    }
}
class StudentRecord : IRecord
{
    private List<Student> students;
    public StudentRecord()
    {
        students=new List<Student>();
    }
    public void AddStudent(Student student)
    {
        students.Add(student);
        System.Console.WriteLine("Student details added");
    }
    public void DisplayStudent()
    {
        foreach (Student student in students)
        {
            System.Console.WriteLine("Student Id:"+student.StudentId);
            System.Console.WriteLine("Student Name: "+student.Name);
            System.Console.WriteLine("Student marks"+student.Marks);
        }
    }
    public void StudentWithHighestMarks()
    {
        double n=-1;
        foreach (Student student in students )
        {
            if (student.Marks > n)
            {
                n=student.Marks;
            }
        }System.Console.WriteLine("Max marks is :"+n);
    }
    public void DisplayAboveAverage(Double MarksLimit)
    {
        foreach (Student student in students )
        {
            if (MarksLimit < student.Marks)
            {
            System.Console.WriteLine("Student Id:"+student.StudentId);
            System.Console.WriteLine("Student Name: "+student.Name);
            System.Console.WriteLine("Student marks"+student.Marks);
            }
        }
    }
    public void RemoveStudent(int n)
    {
        for(int i = 0; i < students.Count; i++)
        {
            if (n == students[i].StudentId)
            {
                students.RemoveAt(i);
                return;
            }
            
        }
        System.Console.WriteLine("Student Id does not exist: ");
    }
}
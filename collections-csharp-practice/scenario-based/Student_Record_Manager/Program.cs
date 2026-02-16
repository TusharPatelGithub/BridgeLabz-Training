class Program
{
    public static void Main()
    {
        StudentRecord record=new StudentRecord();
        Student student1=new Student(1,"Tushar",90);
        Student student2=new Student(2,"Asis",50);
        Student student3=new Student(3,"Alok",70);
        Student student4=new Student(4,"Anshu",80);
        Student student5=new Student(5,"Saurav",85);
        record.AddStudent(student1);
        record.AddStudent(student2);
        record.AddStudent(student3);
        record.AddStudent(student4);
        record.AddStudent(student5);
        record.DisplayStudent();
    }
}
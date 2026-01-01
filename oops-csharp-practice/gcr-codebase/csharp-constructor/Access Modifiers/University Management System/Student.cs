class Student1
{
    public int rollNumber;
    protected string name;
    private double CGPA;
    public Student1(int rollNumber, string name, double CGPA)
    {
        this.rollNumber=rollNumber;
        this.name=name;
        this.CGPA=CGPA;
    }
    public void get()
    {
        Console.WriteLine(CGPA);
        
    }
    public double set(double n)
    {
        CGPA=n;
        return CGPA;
    }

}
class Student
{
    public static void Main(string[] args)
    {
        Student1 student1=new Student1(1000,"tushar",9.8);
        Console.WriteLine(student1.set(7.8));
        
    }
}
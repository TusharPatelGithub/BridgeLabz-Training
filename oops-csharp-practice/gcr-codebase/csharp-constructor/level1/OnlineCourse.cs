using System.Net.WebSockets;

class OnlineCourse
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Enter the number of course: ");
        int n=Convert.ToInt16(Console.ReadLine());

        Course[] course=new Course[n];

        course[0]=new Course("c#",5,10000);
        course[1]=new Course("java",5,1000);
        course[2]=new Course("python",5,20000);
        course[3]=new Course("c++",5,25000);
        // for(int i = 0; i < n; i++)
        // {
        //    course[i].DisplayDetails();
        // }
        Console.WriteLine(Course.ChangeName("IIt "));
        
    }
}
class Course
{
    public string CourseName;
    public Double duration;
    public int fees;
    public static string InstituteName="Gla University";
    public Course(string CourseName,Double duration,int fees){
        this.CourseName=CourseName;
        this.duration=duration;
        this.fees=fees;
    }
    public void DisplayDetails()
    {
         Console.WriteLine($"Course Name: {CourseName}");
        Console.WriteLine($"Duration: {duration}");
        Console.WriteLine($"Fees: {fees}");
        Console.WriteLine();
    }
    public static string ChangeName(string name)
    {
        InstituteName=name;
        return InstituteName;
    }
}
using System;

class Course
{
    public string CourseName;
    public int Duration;

    public Course(string courseName, int duration)
    {
        CourseName = courseName;
        Duration = duration;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Course Name : " + CourseName);
        Console.WriteLine("Duration    : " + Duration + " weeks");
    }
}

class OnlineCourse : Course
{
    public string Platform;
    public bool IsRecorded;

    public OnlineCourse(string courseName, int duration, string platform, bool isRecorded)
        : base(courseName, duration)
    {
        Platform = platform;
        IsRecorded = isRecorded;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Platform    : " + Platform);
        Console.WriteLine("Recorded    : " + IsRecorded);
    }
}

class PaidOnlineCourse : OnlineCourse
{
    public double Fee;
    public double Discount;

    public PaidOnlineCourse(
        string courseName,
        int duration,
        string platform,
        bool isRecorded,
        double fee,
        double discount
    ) : base(courseName, duration, platform, isRecorded)
    {
        Fee = fee;
        Discount = discount;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Fee         : " + Fee);
        Console.WriteLine("Discount    : " + Discount + "%");
        Console.WriteLine("Final Fee   : " + (Fee - (Fee * Discount / 100)));
    }
}

class CourseSystem
{
    static void Main(string[] args)
    {
        PaidOnlineCourse course = new PaidOnlineCourse(
            "C# Full Stack",
            12,
            "Scaler",
            true,
            20000,
            10
        );

        course.DisplayDetails();
    }
}

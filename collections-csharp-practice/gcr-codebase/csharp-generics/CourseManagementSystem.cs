using System;
using System.Collections.Generic;
class CourseManagementSystem
{
    interface IReadOnlyCourse<out T>
    {
        T GetEvaluationType();
    }
    abstract class CourseType
    {
        public abstract void Evaluate();
    }
    class ExamCourse : CourseType
    {
        public override void Evaluate()
        {
            Console.WriteLine("Evaluation Method: Written Examination");
        }
    }
    class AssignmentCourse : CourseType
    {
        public override void Evaluate()
        {
            Console.WriteLine("Evaluation Method: Assignment Submission");
        }
    }
    class Course<T> : IReadOnlyCourse<T> where T : CourseType
    {
        public string courseCode;
        public string courseName;
        public T evaluationType;
        public Course(string code, string name, T evaluationType)
        {
            this.courseCode = code;
            this.courseName = name;
            this.evaluationType = evaluationType;
        }
        public void Display()
        {
            Console.WriteLine($"Course Code: {courseCode}, Course Name: {courseName}");
            evaluationType.Evaluate();
        }
        public T GetEvaluationType()
        {
            return evaluationType;
        }
    }
    static void Main()
    {
        List<Course<ExamCourse>> examCourses = new List<Course<ExamCourse>>();
        List<Course<AssignmentCourse>> assignmentCourses = new List<Course<AssignmentCourse>>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n University Course Management System");
            Console.WriteLine("1. Add Exam Course");
            Console.WriteLine("2. Add Assignment Course");
            Console.WriteLine("3. Display Exam Courses");
            Console.WriteLine("4. Display Assignment Courses");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Course Code: ");
                    string examCode = Console.ReadLine();
                    Console.Write("Enter Course Name: ");
                    string examName = Console.ReadLine();
                    examCourses.Add(
                        new Course<ExamCourse>(examCode, examName, new ExamCourse())
                    );
                    Console.WriteLine("Exam course added.");
                    break;
                case 2:
                    Console.Write("Enter Course Code: ");
                    string assignCode = Console.ReadLine();
                    Console.Write("Enter Course Name: ");
                    string assignName = Console.ReadLine();
                    assignmentCourses.Add(
                        new Course<AssignmentCourse>(assignCode, assignName, new AssignmentCourse())
                    );
                    Console.WriteLine("Assignment course added.");
                    break;
                case 3:
                    Console.WriteLine("\n--- Exam Courses ---");
                    foreach (var course in examCourses)
                        course.Display();
                    break;
                case 4:
                    Console.WriteLine("\n--- Assignment Courses ---");
                    foreach (var course in assignmentCourses)
                        course.Display();
                    break;
                case 5:
                    exit = true;
                    Console.WriteLine("Exiting system...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

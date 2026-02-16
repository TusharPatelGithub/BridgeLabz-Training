using System;
using System.Collections.Generic;
class ResumeScreeningSystem
{
    abstract class JobRole
    {
        public string candidateName;
        protected JobRole(string candidateName)
        {
            this.candidateName = candidateName;
        }
        public abstract void EvaluateSkills();
    }
    class SoftwareEngineer : JobRole
    {
        public SoftwareEngineer(string candidateName) : base(candidateName) { }
        public override void EvaluateSkills()
        {
            Console.WriteLine("Evaluating Coding, DSA, and System Design skills.");
        }
    }
    class DataScientist : JobRole
    {
        public DataScientist(string candidateName) : base(candidateName) { }
        public override void EvaluateSkills()
        {
            Console.WriteLine("Evaluating Statistics, ML, and Data Analysis skills.");
        }
    }
    class Resume<T> where T : JobRole
    {
        public T jobRole;
        public Resume(T jobRole)
        {
            this.jobRole = jobRole;
        }
        public void ScreenResume()
        {
            Console.WriteLine($"\nScreening resume for candidate: {jobRole.candidateName}");
            jobRole.EvaluateSkills();
            Console.WriteLine("Resume screening completed.");
        }
    }
    static void ProcessResume<T>(Resume<T> resume) where T : JobRole
    {
        Console.WriteLine("\nAI Screening Pipeline Started");
        resume.ScreenResume();
        Console.WriteLine("AI Screening Pipeline Finished");
    }
    public static void Main(string[] args)
    {
        List<Resume<SoftwareEngineer>> softwareEngineerResumes =
            new List<Resume<SoftwareEngineer>>();
        List<Resume<DataScientist>> dataScientistResumes =
            new List<Resume<DataScientist>>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nAI-Driven Resume Screening System");
            Console.WriteLine("1. Add Software Engineer Resume");
            Console.WriteLine("2. Add Data Scientist Resume");
            Console.WriteLine("3. Screen Software Engineer Resumes");
            Console.WriteLine("4. Screen Data Scientist Resumes");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Candidate Name: ");
                    string seName = Console.ReadLine();
                    softwareEngineerResumes.Add(
                        new Resume<SoftwareEngineer>(
                            new SoftwareEngineer(seName)
                        )
                    );
                    Console.WriteLine("Software Engineer resume added.");
                    break;
                case 2:
                    Console.Write("Enter Candidate Name: ");
                    string dsName = Console.ReadLine();
                    dataScientistResumes.Add(
                        new Resume<DataScientist>(
                            new DataScientist(dsName)
                        )
                    );
                    Console.WriteLine("Data Scientist resume added.");
                    break;
                case 3:
                    Console.WriteLine("\nScreening Software Engineer Resumes ---");
                    foreach (var resume in softwareEngineerResumes)
                        ProcessResume(resume);
                    break;
                case 4:
                    Console.WriteLine("\nScreening Data Scientist Resumes ---");
                    foreach (var resume in dataScientistResumes)
                        ProcessResume(resume);
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

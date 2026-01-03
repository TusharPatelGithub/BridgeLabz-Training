using System;

class Patient
{
    public static string HospitalName = "City Care Hospital";
    private static int totalPatients = 0;

    public string Name;
    public int Age;
    public string Ailment;
    public readonly int PatientID;

    public Patient(string name, int age, string ailment, int patientID)
    {
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        this.PatientID = patientID;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    public void DisplayPatientDetails()
    {
        Console.WriteLine("Patient ID : " + PatientID);
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Age        : " + Age);
        Console.WriteLine("Ailment    : " + Ailment);
    }
}

class HospitalManagement
{
    static void Main(string[] args)
    {
        Patient p1 = new Patient("Tushar", 22, "Fever", 301);
        Patient p2 = new Patient("Neha", 25, "Cold", 302);

        Console.WriteLine("Hospital Name: " + Patient.HospitalName);
        Patient.GetTotalPatients();
        Console.WriteLine();

        if (p1 is Patient)
        {
            p1.DisplayPatientDetails();
        }
    }
}

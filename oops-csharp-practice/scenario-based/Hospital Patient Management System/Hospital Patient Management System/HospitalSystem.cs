using Hospital_Patient_Management_System;

class HospitalSystem
{
    static void Main()
    {
        Doctor doctor = new Doctor
        {
            DoctorId = 1,
            DoctorName = "Dr. Sharma",
            Specialization = "Cardiology"
        };

        Patient p1 = new InPatient(101, "Tushar", 22, 5, 2000);
        Patient p2 = new OutPatient(102, "Amit", 30, 500);

        doctor.DisplayDoctorInfo();
        Console.WriteLine();

        p1.DisplayInfo();   // Polymorphism
        Console.WriteLine();

        p2.DisplayInfo();   // Polymorphism
    }
}
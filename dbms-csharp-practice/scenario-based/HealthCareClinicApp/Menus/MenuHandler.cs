using System;
using HealthCareClinicApp.Users;
namespace HealthCareClinicApp.Menus
{
    public class MenuHandler
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\nSelect Role:");
                Console.WriteLine("1. Patient");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("3. Receptionist");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        HandlePatientMenu();
                        break;
                    case 2: // Doctor
                    Doctor doctor = new Doctor();
                    while (true)
                    {
                    doctor.ShowMenu();
                    Console.Write("Choice: ");
                    int ch = int.Parse(Console.ReadLine());
                    if (ch == 1) doctor.SelectDoctor();
                    else if (ch == 2) doctor.ViewMyAppointments();
                    else if (ch == 3) doctor.AddPrescription();
                    else if (ch == 4) doctor.UpdateDiagnosis();
                    else if (ch == 5) doctor.ViewPrescriptions();
                    else if (ch == 0) break;
                    else Console.WriteLine("Invalid option");
                    }
                    break;
                    case 3: // Receptionist
                    Receptionist receptionist = new Receptionist();
                    while (true)
                    {
                        receptionist.ShowMenu();
                        Console.Write("Choice: ");
                        int ch = int.Parse(Console.ReadLine());
                        if (ch == 1) receptionist.ViewAllVisits();
                        else if (ch == 2) receptionist.GenerateBill();
                        else if (ch == 3) receptionist.ViewAllTransactions();
                        else if (ch == 0) break;
                        else Console.WriteLine("Invalid option");
                    }
                    break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
        private static void HandlePatientMenu()
        {
            Patient patient = new Patient();
            while (true)
            {
                patient.ShowMenu();
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        patient.ViewDoctors();
                        break;
                    case 2:
                        patient.BookAppointment();
                        break;
                    case 3:
                    patient.ViewMyPrescriptions();
                    break;
                    case 4:
                    patient.ViewMyBills();
                    break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
        private static void HandleDoctorMenu()
        {
            Doctor doctor = new Doctor();
            while (true)
            {
                doctor.ShowMenu();
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        doctor.AddPrescription();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
        private static void HandleReceptionistMenu()
        {
            Receptionist receptionist = new Receptionist();
            while (true)
            {
                receptionist.ShowMenu();
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        receptionist.GenerateBill();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}

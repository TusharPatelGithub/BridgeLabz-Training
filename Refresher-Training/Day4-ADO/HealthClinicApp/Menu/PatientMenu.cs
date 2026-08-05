using System;
using System.Data;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Menu
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void Show()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n===== Patient Menu =====");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. View All Patients (Connected)");
                Console.WriteLine("5. View All Patients (Disconnected)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddPatient(); break;
                    case "2": UpdatePatient(); break;
                    case "3": DeletePatient(); break;
                    case "4": ViewAllConnected(); break;
                    case "5": ViewAllDisconnected(); break;
                    case "0": back = true; break;
                    default: Console.WriteLine("Invalid option, try again."); break;
                }
            }
        }

        private void AddPatient()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            DateTime dob = ReadDate("Date of Birth (yyyy-MM-dd): ");

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Patient patient = new Patient(name, dob, gender, phone, address);
            _patientService.AddPatient(patient);
        }

        private void UpdatePatient()
        {
            int id = ReadInt("Enter Patient ID to update: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            DateTime dob = ReadDate("Date of Birth (yyyy-MM-dd): ");

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Patient patient = new Patient(id, name, dob, gender, phone, address);
            _patientService.UpdatePatient(patient);
        }

        private void DeletePatient()
        {
            int id = ReadInt("Enter Patient ID to delete: ");
            _patientService.DeletePatient(id);
        }

        private void ViewAllConnected()
        {
            var patients = _patientService.GetAllPatients_Connected();
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }
            foreach (var p in patients)
                Console.WriteLine(p);
        }

        private void ViewAllDisconnected()
        {
            DataTable table = _patientService.GetAllPatients_Disconnected();
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["PatientID"]} | {row["Name"]} | {Convert.ToDateTime(row["DateOfBirth"]):d} | {row["Gender"]} | {row["Phone"]} | {row["Address"]}");
            }
        }

        private int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }

        private DateTime ReadDate(string prompt)
        {
            Console.Write(prompt);
            DateTime.TryParse(Console.ReadLine(), out DateTime value);
            return value;
        }
    }
}
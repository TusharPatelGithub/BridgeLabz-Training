using System;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Menu
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void Show()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n===== Doctor Menu =====");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. View All Doctors");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddDoctor(); break;
                    case "2": UpdateDoctor(); break;
                    case "3": DeleteDoctor(); break;
                    case "4": ViewAllDoctors(); break;
                    case "0": back = true; break;
                    default: Console.WriteLine("Invalid option, try again."); break;
                }
            }
        }

        private void AddDoctor()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            int specializationId = ReadInt("Specialization ID: ");

            Doctor doctor = new Doctor(name, phone, email, specializationId);
            _doctorService.AddDoctor(doctor);
        }

        private void UpdateDoctor()
        {
            int id = ReadInt("Enter Doctor ID to update: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            int specializationId = ReadInt("Specialization ID: ");

            Doctor doctor = new Doctor(id, name, phone, email, specializationId);
            _doctorService.UpdateDoctor(doctor);
        }

        private void DeleteDoctor()
        {
            int id = ReadInt("Enter Doctor ID to delete: ");
            _doctorService.DeleteDoctor(id);
        }

        private void ViewAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
                return;
            }
            foreach (var d in doctors)
                Console.WriteLine(d);
        }

        private int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }
    }
}
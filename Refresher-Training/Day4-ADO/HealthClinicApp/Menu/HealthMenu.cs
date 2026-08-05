using System;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class HealthMenu
    {
        private readonly PatientMenu _patientMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly AppointmentMenu _appointmentMenu;

        public MainMenu()
        {
            // Wire up services -> menus.
            // Swap these for a DI container later if the project grows.
            IPatientService patientService = new PatientService();
            IDoctorService doctorService = new DoctorService();
            IAppointmentService appointmentService = new AppointmentService();

            _patientMenu = new PatientMenu(patientService);
            _doctorMenu = new DoctorMenu(doctorService);
            _appointmentMenu = new AppointmentMenu(appointmentService);
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== Health Clinic App =====");
                Console.WriteLine("1. Patient Menu");
                Console.WriteLine("2. Doctor Menu");
                Console.WriteLine("3. Appointment Menu");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": _patientMenu.Show(); break;
                    case "2": _doctorMenu.Show(); break;
                    case "3": _appointmentMenu.Show(); break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}
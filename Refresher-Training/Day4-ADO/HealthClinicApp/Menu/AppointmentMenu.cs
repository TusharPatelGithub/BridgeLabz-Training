using System;
using System.Data;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Menu
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentMenu(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void Show()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n===== Appointment Menu =====");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. Update Appointment");
                Console.WriteLine("3. Delete Appointment");
                Console.WriteLine("4. View All Appointments (Connected)");
                Console.WriteLine("5. View All Appointments (Disconnected)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddAppointment(); break;
                    case "2": UpdateAppointment(); break;
                    case "3": DeleteAppointment(); break;
                    case "4": ViewAllConnected(); break;
                    case "5": ViewAllDisconnected(); break;
                    case "0": back = true; break;
                    default: Console.WriteLine("Invalid option, try again."); break;
                }
            }
        }

        private void AddAppointment()
        {
            DateTime date = ReadDate("Appointment Date (yyyy-MM-dd): ");
            TimeSpan time = ReadTime("Appointment Time (HH:mm): ");

            Console.Write("Status: ");
            string status = Console.ReadLine();

            int patientId = ReadInt("Patient ID: ");
            int doctorId = ReadInt("Doctor ID: ");

            Appointment appointment = new Appointment(date, time, status, patientId, doctorId);
            _appointmentService.AddAppointment(appointment);
        }

        private void UpdateAppointment()
        {
            int id = ReadInt("Enter Appointment ID to update: ");

            DateTime date = ReadDate("Appointment Date (yyyy-MM-dd): ");
            TimeSpan time = ReadTime("Appointment Time (HH:mm): ");

            Console.Write("Status: ");
            string status = Console.ReadLine();

            int patientId = ReadInt("Patient ID: ");
            int doctorId = ReadInt("Doctor ID: ");

            Appointment appointment = new Appointment(id, date, time, status, patientId, doctorId);
            _appointmentService.UpdateAppointment(appointment);
        }

        private void DeleteAppointment()
        {
            int id = ReadInt("Enter Appointment ID to delete: ");
            _appointmentService.DeleteAppointment(id);
        }

        private void ViewAllConnected()
        {
            var appointments = _appointmentService.GetAllAppointments_Connected();
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }
            foreach (var a in appointments)
                Console.WriteLine(a);
        }

        private void ViewAllDisconnected()
        {
            DataTable table = _appointmentService.GetAllAppointments_Disconnected();
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["AppointmentID"]} | {Convert.ToDateTime(row["AppointmentDate"]):d} {row["AppointmentTime"]} | {row["Status"]} | PatientID:{row["PatientID"]} | DoctorID:{row["DoctorID"]}");
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

        private TimeSpan ReadTime(string prompt)
        {
            Console.Write(prompt);
            TimeSpan.TryParse(Console.ReadLine(), out TimeSpan value);
            return value;
        }
    }
}
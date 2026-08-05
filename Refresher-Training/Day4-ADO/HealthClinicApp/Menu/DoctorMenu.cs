using System;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

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

            int specializationId = ReadSpecializationId();

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

            int specializationId = ReadSpecializationId();

            Doctor doctor = new Doctor(id, name, phone, email, specializationId);
            _doctorService.UpdateDoctor(doctor);
        }

        private void DeleteDoctor()
        {
            int id = ReadInt("Enter Doctor ID to delete: ");

            int appointmentCount = GetAppointmentCountForDoctor(id);
            if (appointmentCount > 0)
            {
                Console.WriteLine($"Cannot delete this doctor: {appointmentCount} appointment(s) still reference them.");
                Console.WriteLine("Cancel or reassign those appointments first, then try again.");
                return;
            }

            _doctorService.DeleteDoctor(id);
        }

        // Checks the Appointment table so we can give a clear message
        // instead of letting the FK constraint fail with a raw SQL error.
        private int GetAppointmentCountForDoctor(int doctorId)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Appointment WHERE DoctorID = @DoctorID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Could not check existing appointments: {ex.Message}");
                    // If we can't verify, don't block the delete attempt —
                    // the FK constraint will still protect the data either way.
                    return 0;
                }
            }
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

        // Shows the valid Specialization IDs so the user isn't guessing,
        // then loops until a real numeric ID is entered.
        private int ReadSpecializationId()
        {
            ShowSpecializations();

            while (true)
            {
                Console.Write("Specialization ID: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int specializationId))
                {
                    return specializationId;
                }

                Console.WriteLine("That's not a valid number. Please enter one of the Specialization IDs listed above.");
            }
        }

        private void ShowSpecializations()
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SpecializationID, SpecializationName FROM Specialization ORDER BY SpecializationID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nAvailable Specializations:");
                        bool any = false;
                        while (reader.Read())
                        {
                            any = true;
                            Console.WriteLine($"  {reader["SpecializationID"]} - {reader["SpecializationName"]}");
                        }
                        if (!any)
                        {
                            Console.WriteLine("  (No specializations found — add rows to the Specialization table first.)");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Could not load specializations: {ex.Message}");
                }
            }
        }

        private int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Service
{
    public class AppointmentService : IAppointmentService
    {
        // ===================== CONNECTED =====================

        public void AddAppointment(Appointment appointment)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Appointment(AppointmentDate, AppointmentTime, Status, PatientID, DoctorID) VALUES(@AppointmentDate, @AppointmentTime, @Status, @PatientID, @DoctorID)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                        cmd.Parameters.AddWithValue("@Status", appointment.Status);
                        cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                        cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Appointment added successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Insert failed: {ex.Message}");
                }
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Appointment SET AppointmentDate=@AppointmentDate, AppointmentTime=@AppointmentTime, Status=@Status, PatientID=@PatientID, DoctorID=@DoctorID WHERE AppointmentID=@AppointmentID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                        cmd.Parameters.AddWithValue("@Status", appointment.Status);
                        cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                        cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Appointment updated successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Update failed: {ex.Message}");
                }
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Appointment WHERE AppointmentID=@AppointmentID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Appointment deleted successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Delete failed: {ex.Message}");
                }
            }
        }

        public List<Appointment> GetAllAppointments_Connected()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Appointment";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment(
                                (int)reader["AppointmentID"],
                                (DateTime)reader["AppointmentDate"],
                                (TimeSpan)reader["AppointmentTime"],
                                reader["Status"].ToString(),
                                (int)reader["PatientID"],
                                (int)reader["DoctorID"]
                            ));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Select failed: {ex.Message}");
                }
            }
            return appointments;
        }

        // ===================== DISCONNECTED =====================

        public DataTable GetAllAppointments_Disconnected()
        {
            DataTable appointmentTable = new DataTable();
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Appointment";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(appointmentTable);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Select failed: {ex.Message}");
                }
            }
            return appointmentTable;
        }
    }
}
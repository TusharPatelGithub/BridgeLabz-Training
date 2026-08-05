using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Service
{
    public class PatientService : IPatientService
    {
        // ===================== CONNECTED =====================

        public void AddPatient(Patient patient)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Patient(Name, DateOfBirth, Gender, Phone, Address) VALUES(@Name, @DateOfBirth, @Gender, @Phone, @Address)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", patient.Name);
                        cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", (object)patient.Gender ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", (object)patient.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Patient added successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Insert failed: {ex.Message}");
                }
            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Patient SET Name=@Name, DateOfBirth=@DateOfBirth, Gender=@Gender, Phone=@Phone, Address=@Address WHERE PatientID=@PatientID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                        cmd.Parameters.AddWithValue("@Name", patient.Name);
                        cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", (object)patient.Gender ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", (object)patient.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)patient.Address ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Patient updated successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Update failed: {ex.Message}");
                }
            }
        }

        public void DeletePatient(int patientId)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Patient WHERE PatientID=@PatientID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", patientId);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Patient deleted successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Delete failed: {ex.Message}");
                }
            }
        }

        public List<Patient> GetAllPatients_Connected()
        {
            List<Patient> patients = new List<Patient>();
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Patient";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient(
                                (int)reader["PatientID"],
                                reader["Name"].ToString(),
                                (DateTime)reader["DateOfBirth"],
                                reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                                reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                reader["Address"] == DBNull.Value ? null : reader["Address"].ToString()
                            ));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Select failed: {ex.Message}");
                }
            }
            return patients;
        }

        // ===================== DISCONNECTED =====================

        public DataTable GetAllPatients_Disconnected()
        {
            DataTable patientTable = new DataTable();
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Patient";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(patientTable);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Select failed: {ex.Message}");
                }
            }
            return patientTable;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Service
{
    public class DoctorService : IDoctorService
    {
        public void AddDoctor(Doctor doctor)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertDoctor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", doctor.Name);
                        cmd.Parameters.AddWithValue("@Phone", (object)doctor.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)doctor.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@SpecializationID", doctor.SpecializationID);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Doctor added successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Insert failed: {ex.Message}");
                }
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                        cmd.Parameters.AddWithValue("@Name", doctor.Name);
                        cmd.Parameters.AddWithValue("@Phone", (object)doctor.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)doctor.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@SpecializationID", doctor.SpecializationID);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Doctor updated successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Update failed: {ex.Message}");
                }
            }
        }

        public void DeleteDoctor(int doctorId)
        {
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Doctor deleted successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Delete failed: {ex.Message}");
                }
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (SqlConnection connection = DBConnectionUtillity.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllDoctors", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctors.Add(new Doctor(
                                    (int)reader["DoctorID"],
                                    reader["Name"].ToString(),
                                    reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                    reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                                    (int)reader["SpecializationID"]
                                ));
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Select failed: {ex.Message}");
                }
            }
            return doctors;
        }
    }
}
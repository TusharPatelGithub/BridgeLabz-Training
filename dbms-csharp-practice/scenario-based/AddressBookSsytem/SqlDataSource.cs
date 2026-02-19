using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace BridgeLabz.AddressBookSystem
{
    public class SqlDataSource : IDataSource
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=AddressBookSystem;Trusted_Connection=True;TrustServerCertificate=True;";
        // Saves address book and contacts to SQL Server
        public void Save(string addressBookName, List<AddressBookModel> contacts)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            int addressBookId;
            // Insert or get AddressBookId
            using (SqlCommand cmd = new SqlCommand(
                "IF NOT EXISTS (SELECT 1 FROM AddressBooks WHERE AddressBookName=@name) " +
                "INSERT INTO AddressBooks(AddressBookName) VALUES(@name);" +
                "SELECT AddressBookId FROM AddressBooks WHERE AddressBookName=@name", con))
            {
                cmd.Parameters.AddWithValue("@name", addressBookName);
                addressBookId = (int)cmd.ExecuteScalar();
            }
            // Insert contacts
            foreach (var c in contacts)
            {
                using SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Contacts 
                    (AddressBookId, FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email)
                    VALUES (@id,@fn,@ln,@addr,@city,@state,@zip,@phone,@email)", con);
                cmd.Parameters.AddWithValue("@id", addressBookId);
                cmd.Parameters.AddWithValue("@fn", c.FirstName);
                cmd.Parameters.AddWithValue("@ln", c.LastName);
                cmd.Parameters.AddWithValue("@addr", c.Address);
                cmd.Parameters.AddWithValue("@city", c.City);
                cmd.Parameters.AddWithValue("@state", c.State);
                cmd.Parameters.AddWithValue("@zip", c.Zip);
                cmd.Parameters.AddWithValue("@phone", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.ExecuteNonQuery();
            }
        }
        // Loads contacts from SQL Server
        public List<AddressBookModel> Load(string addressBookName)
        {
            List<AddressBookModel> contacts = new();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand cmd = new SqlCommand(
                @"SELECT c.* FROM Contacts c
                  JOIN AddressBooks a ON c.AddressBookId = a.AddressBookId
                  WHERE a.AddressBookName = @name", con);
            cmd.Parameters.AddWithValue("@name", addressBookName);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contacts.Add(new AddressBookModel
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    State = reader["State"].ToString(),
                    Zip = reader["Zip"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
            return contacts;
        }
    }
}

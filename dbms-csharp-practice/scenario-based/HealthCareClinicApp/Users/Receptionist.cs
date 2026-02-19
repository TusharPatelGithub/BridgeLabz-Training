using System;
using Microsoft.Data.SqlClient;
using HealthCareClinicApp.Data;
using HealthCareClinicApp.Interfaces;
namespace HealthCareClinicApp.Users
{
    public class Receptionist : IClinicOperations
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- Receptionist Menu ---");
            Console.WriteLine("1. View All Visits");
            Console.WriteLine("2. Generate Bill");
            Console.WriteLine("3. View All Payment Transactions");
            Console.WriteLine("0. Exit");
        }
        //View all visits
        public void ViewAllVisits()
        {
            using SqlConnection con = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT 
                    v.visit_id,
                    p.patient_name,
                    d.doctor_name,
                    v.visit_date,
                    v.diagnosis
                FROM visits v
                JOIN patients p ON v.patient_id = p.patient_id
                JOIN doctors d ON v.doctor_id = d.doctor_id
                ORDER BY v.visit_date DESC", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nVisits:");
            Console.WriteLine("VisitID | Patient | Doctor | Date | Diagnosis");
            Console.WriteLine("------------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["visit_id"]} | {reader["patient_name"]} | {reader["doctor_name"]} | " +
                    $"{Convert.ToDateTime(reader["visit_date"]).ToShortDateString()} | {reader["diagnosis"]}");
            }
        }
        //Generate bill for a visit
        public void GenerateBill()
{
    using SqlConnection con = DbConnection.GetConnection();
    SqlTransaction tx = con.BeginTransaction();
    try
    {
        //Show ONLY visits that do NOT have bills
        SqlCommand showVisits = new SqlCommand(
            @"SELECT 
                v.visit_id,
                p.patient_name,
                d.doctor_name,
                v.visit_date
            FROM visits v
            JOIN patients p ON v.patient_id = p.patient_id
            JOIN doctors d ON v.doctor_id = d.doctor_id
            WHERE NOT EXISTS (
                SELECT 1 FROM bills b WHERE b.visit_id = v.visit_id
            )
            ORDER BY v.visit_date DESC",
            con, tx);
        SqlDataReader reader = showVisits.ExecuteReader();
        Console.WriteLine("\nVisits Pending Billing:");
        Console.WriteLine("VisitID | Patient | Doctor | Visit Date");
        Console.WriteLine("-------------------------------------------");
        bool hasVisits = false;
        while (reader.Read())
        {
            hasVisits = true;
            Console.WriteLine(
                $"{reader["visit_id"]} | {reader["patient_name"]} | " +
                $"{reader["doctor_name"]} | " +
                $"{Convert.ToDateTime(reader["visit_date"]).ToShortDateString()}");
        }
        reader.Close();
        if (!hasVisits)
        {
            Console.WriteLine("No visits pending billing.");
            tx.Rollback();
            return;
        }
        Console.Write("\nEnter Visit ID to generate bill: ");
        int visitId = int.Parse(Console.ReadLine());
        //Generate bill
        SqlCommand generateBill = new SqlCommand(
            @"INSERT INTO bills
            (visit_id, patient_id, consultation_fee, additional_charges, total_amount, payment_status)
            SELECT 
                v.visit_id,
                v.patient_id,
                d.consultation_fee,
                0,
                d.consultation_fee,
                'UNPAID'
            FROM visits v
            JOIN doctors d ON v.doctor_id = d.doctor_id
            WHERE v.visit_id = @vid",
            con, tx);
        generateBill.Parameters.AddWithValue("@vid", visitId);
        generateBill.ExecuteNonQuery();
        tx.Commit();
        Console.WriteLine("Bill generated successfully!");
    }
    catch (Exception ex)
    {
        tx.Rollback();
        Console.WriteLine("Error: " + ex.Message);
    }
}
        //View all payment transactions
        public void ViewAllTransactions()
        {
            using SqlConnection con = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT 
                    t.transaction_id,
                    t.bill_id,
                    t.amount,
                    t.payment_mode,
                    t.transaction_date
                FROM payment_transactions t
                ORDER BY t.transaction_date DESC", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nPayment Transactions:");
            Console.WriteLine("TxnID | BillID | Amount | Mode | Date");
            Console.WriteLine("----------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["transaction_id"]} | {reader["bill_id"]} | " +
                    $"{reader["amount"]} | {reader["payment_mode"]} | " +
                    $"{Convert.ToDateTime(reader["transaction_date"]).ToShortDateString()}");
            }
        }
    }
}

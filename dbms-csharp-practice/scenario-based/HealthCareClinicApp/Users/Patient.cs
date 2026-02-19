using System;
using Microsoft.Data.SqlClient;
using HealthCareClinicApp.Data;
using HealthCareClinicApp.Interfaces;
namespace HealthCareClinicApp.Users
{
    public class Patient : IClinicOperations
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- Patient Menu ---");
            Console.WriteLine("1. View Available Doctors");
            Console.WriteLine("2. Book Appointment");
            Console.WriteLine("3. View My Prescriptions");
            Console.WriteLine("4. View My Bills & Payment Status");
            Console.WriteLine("0. Exit");
        }
        //View Doctors
        public void ViewDoctors()
        {
            using SqlConnection con = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT 
                d.doctor_id,
                d.doctor_name,
                s.specialty_name,
                d.consultation_fee
            FROM doctors d
            INNER JOIN specialties s
                ON d.specialty_id = s.specialty_id
            WHERE d.is_active = 1", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nAvailable Doctors:");
            Console.WriteLine("ID | Doctor Name | Specialty | Fee");
            Console.WriteLine("-------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["doctor_id"]} | {reader["doctor_name"]} | {reader["specialty_name"]} | {reader["consultation_fee"]}");
            }
        }
        //Book Appointment (REAL FLOW)
        public void BookAppointment()
        {
            using SqlConnection con = DbConnection.GetConnection();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                //Step 1: Show doctors
                ViewDoctors();
                Console.Write("\nEnter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());
                //Step 2: Validate doctor
                SqlCommand checkDoctor = new SqlCommand(
                    "SELECT COUNT(*) FROM doctors WHERE doctor_id = @did",
                    con, tx);
                checkDoctor.Parameters.AddWithValue("@did", doctorId);
                if ((int)checkDoctor.ExecuteScalar() == 0)
                {
                    Console.WriteLine("Invalid Doctor ID");
                    tx.Rollback();
                    return;
                }
                //Step 3: Collect patient details
                Console.Write("\nEnter Patient Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                Console.Write("Gender (M/F/O): ");
                string gender = Console.ReadLine();
                Console.Write("Blood Group (A+/O+ etc): ");
                string blood = Console.ReadLine();
                Console.Write("Contact Number: ");
                string contact = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Email (optional, press Enter to skip): ");
                string email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    email = null;
                }
                //Step 4: Insert patient (AUTO patient_id)
                int patientId;
                //Check if patient already exists (by contact number)
                SqlCommand checkPatient = new SqlCommand(
                    "SELECT patient_id FROM patients WHERE contact_number = @contact",
                    con, tx);
                checkPatient.Parameters.AddWithValue("@contact", contact);
                object existingPatientId = checkPatient.ExecuteScalar();
                if (existingPatientId != null)
                {
                    //Patient already exists
                    patientId = (int)existingPatientId;
                    Console.WriteLine($"Existing patient found. Patient ID: {patientId}");
                }
                else
                {
                    //Insert new patient
                    SqlCommand insertPatient = new SqlCommand(
                        @"INSERT INTO patients
            (patient_name, date_of_birth, gender, blood_group, contact_number, email, address)
            VALUES (@n, @dob, @g, @b, @c, @e, @a);
            SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        con, tx);
                    insertPatient.Parameters.AddWithValue("@n", name);
                    insertPatient.Parameters.AddWithValue("@dob", dob);
                    insertPatient.Parameters.AddWithValue("@g", gender);
                    insertPatient.Parameters.AddWithValue("@b", blood);
                    insertPatient.Parameters.AddWithValue("@c", contact);
                    insertPatient.Parameters.AddWithValue("@e", (object?)email ?? DBNull.Value);
                    insertPatient.Parameters.AddWithValue("@a", address);
                    patientId = (int)insertPatient.ExecuteScalar();
                    Console.WriteLine($" New patient registered. Patient ID: {patientId}");
                }
                //Step 5: Ask reason
                Console.Write("Reason for Visit: ");
                string reason = Console.ReadLine();
                //Step 6: Insert appointment (AUTO appointment_id)
                SqlCommand insertAppointment = new SqlCommand(
                    @"INSERT INTO appointments
                    (patient_id, doctor_id, appointment_date, appointment_time, reason)
                    VALUES
                    (@p, @d, CAST(GETDATE() AS DATE), '10:00', @r)",
                    con, tx);
                insertAppointment.Parameters.AddWithValue("@p", patientId);
                insertAppointment.Parameters.AddWithValue("@d", doctorId);
                insertAppointment.Parameters.AddWithValue("@r", reason);
                insertAppointment.ExecuteNonQuery();
                tx.Commit();
                Console.WriteLine("\n Appointment booked successfully!");
                Console.WriteLine($"Your Patient ID is: {patientId}");
                Console.WriteLine("Please save this ID for future reference.");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void ViewMyPrescriptions()
        {
            using SqlConnection con = DbConnection.GetConnection();
            try
            {
                Console.Write("\nEnter your Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());
                //Validate patient
                SqlCommand checkPatient = new SqlCommand(
                    "SELECT COUNT(*) FROM patients WHERE patient_id = @pid",
                    con);
                checkPatient.Parameters.AddWithValue("@pid", patientId);
                if ((int)checkPatient.ExecuteScalar() == 0)
                {
                    Console.WriteLine("Invalid Patient ID");
                    return;
                }
                //Show patient's appointments
                SqlCommand showAppointments = new SqlCommand(
                    @"SELECT 
                a.appointment_id,
                a.appointment_date,
                a.appointment_time,
                d.doctor_name,
                a.status
            FROM appointments a
            JOIN doctors d ON a.doctor_id = d.doctor_id
            WHERE a.patient_id = @pid",
                    con);
                showAppointments.Parameters.AddWithValue("@pid", patientId);
                SqlDataReader reader = showAppointments.ExecuteReader();
                Console.WriteLine("\nMy Appointments:");
                Console.WriteLine("ApptID | Doctor | Date | Time | Status");
                Console.WriteLine("----------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine(
                        $"{reader["appointment_id"]} | {reader["doctor_name"]} | " +
                        $"{Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()} | " +
                        $"{reader["appointment_time"]} | {reader["status"]}");
                }
                reader.Close();
                Console.Write("\nEnter Appointment ID to view prescriptions: ");
                int appointmentId = int.Parse(Console.ReadLine());
                //Get visit
                SqlCommand getVisit = new SqlCommand(
                    "SELECT visit_id FROM visits WHERE appointment_id = @aid",
                    con);
                getVisit.Parameters.AddWithValue("@aid", appointmentId);
                object visitResult = getVisit.ExecuteScalar();
                if (visitResult == null)
                {
                    Console.WriteLine("No visit/prescription available yet for this appointment.");
                    return;
                }
                int visitId = (int)visitResult;
                //Fetch prescriptions
                SqlCommand getPrescriptions = new SqlCommand(
                    @"SELECT 
                medicine_name,
                dosage,
                frequency,
                duration_days,
                instructions
            FROM prescriptions
            WHERE visit_id = @vid",
                    con);
                getPrescriptions.Parameters.AddWithValue("@vid", visitId);
                SqlDataReader pr = getPrescriptions.ExecuteReader();
                Console.WriteLine("\nMy Prescriptions:");
                Console.WriteLine("Medicine | Dosage | Frequency | Duration | Instructions");
                Console.WriteLine("---------------------------------------------------------");
                bool hasData = false;
                while (pr.Read())
                {
                    hasData = true;
                    Console.WriteLine(
                        $"{pr["medicine_name"]} | {pr["dosage"]} | {pr["frequency"]} | " +
                        $"{pr["duration_days"]} days | {pr["instructions"]}");
                }
                if (!hasData)
                {
                    Console.WriteLine("No prescriptions found for this visit.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void ViewMyBills()
        {
            using SqlConnection con = DbConnection.GetConnection();
            try
            {
                Console.Write("\nEnter your Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());
                //Validate patient
                SqlCommand checkPatient = new SqlCommand(
                    "SELECT COUNT(*) FROM patients WHERE patient_id = @pid",
                    con);
                checkPatient.Parameters.AddWithValue("@pid", patientId);
                if ((int)checkPatient.ExecuteScalar() == 0)
                {
                    Console.WriteLine("Invalid Patient ID");
                    return;
                }
                //Fetch bills for patient
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                b.bill_id,
                b.visit_id,
                d.doctor_name,
                b.total_amount,
                b.payment_status,
                b.payment_date
            FROM bills b
            JOIN visits v ON b.visit_id = v.visit_id
            JOIN doctors d ON v.doctor_id = d.doctor_id
            WHERE b.patient_id = @pid
            ORDER BY b.bill_date DESC",
                    con);
                cmd.Parameters.AddWithValue("@pid", patientId);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nMy Bills:");
                Console.WriteLine("BillID | VisitID | Doctor | Amount | Status | Payment Date");
                Console.WriteLine("------------------------------------------------------------");
                bool hasBills = false;
                while (reader.Read())
                {
                    hasBills = true;
                    string paymentDate =
                        reader["payment_date"] == DBNull.Value
                        ? "N/A"
                        : Convert.ToDateTime(reader["payment_date"]).ToShortDateString();
                    Console.WriteLine(
                        $"{reader["bill_id"]} | {reader["visit_id"]} | " +
                        $"{reader["doctor_name"]} | {reader["total_amount"]} | " +
                        $"{reader["payment_status"]} | {paymentDate}");
                }
                if (!hasBills)
                {
                    Console.WriteLine("No bills found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

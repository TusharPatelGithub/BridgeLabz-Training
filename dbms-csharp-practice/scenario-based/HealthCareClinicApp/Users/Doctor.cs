using System;
using Microsoft.Data.SqlClient;
using HealthCareClinicApp.Data;
using HealthCareClinicApp.Interfaces;
namespace HealthCareClinicApp.Users
{
    public class Doctor : IClinicOperations
    {
        private int doctorId;
        public void ShowMenu()
        {
            Console.WriteLine("\n--- Doctor Menu ---");
            Console.WriteLine("1. Select Doctor");
            Console.WriteLine("2. View My Appointments");
            Console.WriteLine("3. Add Prescription");
            Console.WriteLine("4. Update Diagnosis");
            Console.WriteLine("5. View Prescriptions (Per Patient)");
            Console.WriteLine("0. Exit");
        }
        // Select Doctor (who is using the system)
        public void SelectDoctor()
        {
            using SqlConnection con = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT d.doctor_id, d.doctor_name, s.specialty_name
                FROM doctors d
                JOIN specialties s ON d.specialty_id = s.specialty_id
                WHERE d.is_active = 1", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nAvailable Doctors:");
            Console.WriteLine("ID | Name | Specialty");
            Console.WriteLine("----------------------------");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["doctor_id"]}|{reader["doctor_name"]}|{reader["specialty_name"]}");
            }
            reader.Close();
            Console.Write("\nEnter your Doctor ID: ");
            doctorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Doctor selected successfully!");
        }
        // View Appointments for Selected Doctor
        public void ViewMyAppointments()
        {
            if (doctorId == 0)
            {
                Console.WriteLine("Please select a doctor first.");
                return;
            }
            using SqlConnection con = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT 
                    a.appointment_id,
                    p.patient_name,
                    a.appointment_date,
                    a.appointment_time,
                    a.reason,
                    a.status
                FROM appointments a
                JOIN patients p ON a.patient_id = p.patient_id
                WHERE a.doctor_id = @did
                ORDER BY a.appointment_date, a.appointment_time", con);
            cmd.Parameters.AddWithValue("@did", doctorId);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nMy Appointments:");
            Console.WriteLine("ApptID | Patient | Date | Time | Status | Reason");
            Console.WriteLine("---------------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["appointment_id"]}|{reader["patient_name"]}|"+
                    $"{Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()} | " +
                    $"{reader["appointment_time"]}|{reader["status"]}|{reader["reason"]}");
            }
        }
        //Add Prescription (Doctor never enters visit_id manually)
        public void AddPrescription()
        {
            if (doctorId == 0)
            {
                Console.WriteLine("Please select a doctor first.");
                return;
            }
            using SqlConnection con = DbConnection.GetConnection();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                // Show appointments
                ViewMyAppointments();
                Console.Write("\nEnter Appointment ID to prescribe: ");
                int appointmentId = int.Parse(Console.ReadLine());
                //Check or create visit
                SqlCommand getVisit = new SqlCommand(
                    @"SELECT visit_id FROM visits WHERE appointment_id = @aid",
                    con, tx);
                getVisit.Parameters.AddWithValue("@aid", appointmentId);
                object visitResult = getVisit.ExecuteScalar();
                int visitId;
                if (visitResult != null)
                {
                    visitId = (int)visitResult;
                }
                else
                {
                    // Create visit automatically
                    SqlCommand createVisit = new SqlCommand(
                        @"INSERT INTO visits
                        (appointment_id, patient_id, doctor_id, diagnosis, symptoms)
                        SELECT appointment_id, patient_id, doctor_id,
                                'Pending Diagnosis', 'Under Observation'
                        FROM appointments
                        WHERE appointment_id = @aid;
                        SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        con, tx);
                    createVisit.Parameters.AddWithValue("@aid", appointmentId);
                    visitId = (int)createVisit.ExecuteScalar();
                    // Mark appointment as COMPLETED
                    SqlCommand updateAppt = new SqlCommand(
                        @"UPDATE appointments
                        SET status = 'COMPLETED'
                        WHERE appointment_id = @aid",
                        con, tx);
                    updateAppt.Parameters.AddWithValue("@aid", appointmentId);
                    updateAppt.ExecuteNonQuery();
                }
                //Add prescription
                Console.Write("Medicine Name: ");
                string medicine = Console.ReadLine();
                Console.Write("Dosage: ");
                string dosage = Console.ReadLine();
                Console.Write("Frequency: ");
                string frequency = Console.ReadLine();
                Console.Write("Duration (days): ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Instructions: ");
                string instructions = Console.ReadLine();
                SqlCommand insertPrescription = new SqlCommand(
                    @"INSERT INTO prescriptions
                    (visit_id, medicine_name, dosage, frequency, duration_days, instructions)
                    VALUES
                    (@v, @m, @d, @f, @dur, @i)",
                    con, tx);
                insertPrescription.Parameters.AddWithValue("@v", visitId);
                insertPrescription.Parameters.AddWithValue("@m", medicine);
                insertPrescription.Parameters.AddWithValue("@d", dosage);
                insertPrescription.Parameters.AddWithValue("@f", frequency);
                insertPrescription.Parameters.AddWithValue("@dur", duration);
                insertPrescription.Parameters.AddWithValue("@i", instructions);
                insertPrescription.ExecuteNonQuery();
                tx.Commit();
                Console.WriteLine("Prescription added successfully!");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void UpdateDiagnosis()
{
    if (doctorId == 0)
    {
        Console.WriteLine("Please select a doctor first.");
        return;
    }
    using SqlConnection con = DbConnection.GetConnection();
    SqlTransaction tx = con.BeginTransaction();
    try
    {
        //show only this doctor's appointments
        SqlCommand showAppointments = new SqlCommand(
            @"SELECT 
                a.appointment_id,
                p.patient_name,
                a.appointment_date,
                a.appointment_time,
                a.status
            FROM appointments a
            JOIN patients p ON a.patient_id = p.patient_id
            WHERE a.doctor_id = @did",
            con, tx);
        showAppointments.Parameters.AddWithValue("@did", doctorId);
        SqlDataReader reader = showAppointments.ExecuteReader();
        Console.WriteLine("\nMy Appointments:");
        Console.WriteLine("ApptID | Patient | Date | Time | Status");
        Console.WriteLine("----------------------------------------");
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["appointment_id"]} | {reader["patient_name"]} | " +
                $"{Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()} | " +
                $"{reader["appointment_time"]} | {reader["status"]}");
        }
        reader.Close();
        Console.Write("\nEnter Appointment ID to update diagnosis: ");
        int appointmentId = int.Parse(Console.ReadLine());
        //Check if visit exists
        SqlCommand getVisit = new SqlCommand(
            "SELECT visit_id FROM visits WHERE appointment_id = @aid",
            con, tx);
        getVisit.Parameters.AddWithValue("@aid", appointmentId);
        object visitResult = getVisit.ExecuteScalar();
        int visitId;
        if (visitResult != null)
        {
            visitId = (int)visitResult;
        }
        else
        {
            //Create visit automatically
            SqlCommand createVisit = new SqlCommand(
                @"INSERT INTO visits
                (appointment_id, patient_id, doctor_id)
                SELECT appointment_id, patient_id, doctor_id
                FROM appointments
                WHERE appointment_id = @aid;
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                con, tx);
            createVisit.Parameters.AddWithValue("@aid", appointmentId);
            visitId = (int)createVisit.ExecuteScalar();
            // Mark appointment completed
            SqlCommand updateAppt = new SqlCommand(
                @"UPDATE appointments
                SET status = 'COMPLETED'
                WHERE appointment_id = @aid",
                con, tx);
            updateAppt.Parameters.AddWithValue("@aid", appointmentId);
            updateAppt.ExecuteNonQuery();
        }
        // Update diagnosis
        Console.Write("Enter Diagnosis: ");
        string diagnosis = Console.ReadLine();
        SqlCommand updateDiagnosis = new SqlCommand(
            @"UPDATE visits
            SET diagnosis = @diag
            WHERE visit_id = @vid",
            con, tx);
        updateDiagnosis.Parameters.AddWithValue("@diag", diagnosis);
        updateDiagnosis.Parameters.AddWithValue("@vid", visitId);
        updateDiagnosis.ExecuteNonQuery();
        tx.Commit();
        Console.WriteLine("Diagnosis updated successfully!");
    }
    catch (Exception ex)
    {
        tx.Rollback();
        Console.WriteLine("Error: " + ex.Message);
    }
}
    public void ViewPrescriptions()
{
    if (doctorId == 0)
    {
        Console.WriteLine("Please select a doctor first.");
        return;
    }
    using SqlConnection con = DbConnection.GetConnection();
    try
    {
        //Show doctor's appointments
        SqlCommand showAppointments = new SqlCommand(
            @"SELECT 
                a.appointment_id,
                p.patient_name,
                a.appointment_date,
                a.appointment_time
            FROM appointments a
            JOIN patients p ON a.patient_id = p.patient_id
            WHERE a.doctor_id = @did",
            con);
        showAppointments.Parameters.AddWithValue("@did", doctorId);
        SqlDataReader reader = showAppointments.ExecuteReader();
        Console.WriteLine("\nMy Appointments:");
        Console.WriteLine("ApptID | Patient | Date | Time");
        Console.WriteLine("--------------------------------");
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["appointment_id"]} | {reader["patient_name"]} | " +
                $"{Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()} | " +
                $"{reader["appointment_time"]}");
        }
        reader.Close();
        Console.Write("\nEnter Appointment ID to view prescriptions: ");
        int appointmentId = int.Parse(Console.ReadLine());
        //Get visit for appointment
        SqlCommand getVisit = new SqlCommand(
            "SELECT visit_id FROM visits WHERE appointment_id = @aid",
            con);
        getVisit.Parameters.AddWithValue("@aid", appointmentId);
        object visitResult = getVisit.ExecuteScalar();
        if (visitResult == null)
        {
            Console.WriteLine("No visit found for this appointment yet.");
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
        Console.WriteLine("\nPrescriptions:");
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
    }
}

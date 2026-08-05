using System;

namespace HealthClinicApp.Entity
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        // New appointment — no ID yet
        public Appointment(DateTime appointmentDate, TimeSpan appointmentTime, string status, int patientId, int doctorId)
        {
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Status = status;
            PatientID = patientId;
            DoctorID = doctorId;
        }

        // Existing appointment — read from DB, has ID
        public Appointment(int appointmentId, DateTime appointmentDate, TimeSpan appointmentTime, string status, int patientId, int doctorId)
        {
            AppointmentID = appointmentId;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Status = status;
            PatientID = patientId;
            DoctorID = doctorId;
        }

        public override string ToString()
        {
            return $"{AppointmentID} | {AppointmentDate:d} {AppointmentTime} | {Status} | PatientID:{PatientID} | DoctorID:{DoctorID}";
        }
    }
}
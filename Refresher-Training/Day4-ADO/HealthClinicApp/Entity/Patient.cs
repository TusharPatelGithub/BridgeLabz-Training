using System;

namespace HealthClinicApp.Entity
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // New patient — no ID yet
        public Patient(string name, DateTime dateOfBirth, string gender, string phone, string address)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Address = address;
        }

        // Existing patient — read from DB, has ID
        public Patient(int patientId, string name, DateTime dateOfBirth, string gender, string phone, string address)
        {
            PatientID = patientId;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return $"{PatientID} | {Name} | DOB: {DateOfBirth:d} | {Gender} | {Phone} | {Address}";
        }
    }
}
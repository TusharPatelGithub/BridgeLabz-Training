namespace HealthClinicApp.Entity
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SpecializationID { get; set; }

        // New doctor — no ID yet, DB will assign one on insert
        public Doctor(string name, string phone, string email, int specializationId)
        {
            Name = name;
            Phone = phone;
            Email = email;
            SpecializationID = specializationId;
        }

        // Existing doctor — read back from DB, already has an ID
        public Doctor(int doctorId, string name, string phone, string email, int specializationId)
        {
            DoctorID = doctorId;
            Name = name;
            Phone = phone;
            Email = email;
            SpecializationID = specializationId;
        }

        public override string ToString()
        {
            return $"{DoctorID} | {Name} | {Phone} | {Email} | SpecializationID: {SpecializationID}";
        }
    }
}
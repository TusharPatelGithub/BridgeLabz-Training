using System.Collections.Generic;
using System.Data;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IPatientService
    {
        // Connected
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
        List<Patient> GetAllPatients_Connected();

        // Disconnected
        DataTable GetAllPatients_Disconnected();
    }
}
using System.Collections.Generic;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int doctorId);
        List<Doctor> GetAllDoctors();
    }
}
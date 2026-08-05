using System.Collections.Generic;
using System.Data;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IAppointmentService
    {
        // Connected
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int appointmentId);
        List<Appointment> GetAllAppointments_Connected();

        // Disconnected
        DataTable GetAllAppointments_Disconnected();
    }
}
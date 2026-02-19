using System;
namespace HealthCareClinicApp.Exceptions
{
    public class ClinicException : Exception
    {
        public ClinicException(string message) : base(message) { }
    }
}

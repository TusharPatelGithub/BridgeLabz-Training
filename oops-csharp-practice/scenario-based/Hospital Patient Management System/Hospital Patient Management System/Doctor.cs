using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Patient_Management_System
{
    class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        public void DisplayDoctorInfo()
        {
            Console.WriteLine($"Doctor: {DoctorName}, Specialization: {Specialization}");
        }
    }
}

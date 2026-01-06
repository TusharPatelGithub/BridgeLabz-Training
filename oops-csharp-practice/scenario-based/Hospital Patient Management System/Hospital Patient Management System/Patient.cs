using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Patient_Management_System
{
    abstract class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Patient(int patientId, string name, int age)
        {
            PatientId = patientId;
            Name = name;
            Age = age;
        }

        public abstract void DisplayInfo();
    }
}

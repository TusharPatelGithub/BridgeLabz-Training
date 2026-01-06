using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Patient_Management_System
{
    class OutPatient : Patient, IPayable
    {
        public double ConsultationFee { get; set; }

        public OutPatient(int id, string name, int age, double fee)
            : base(id, name, age)
        {
            ConsultationFee = fee;
        }

        public double CalculateBill()
        {
            return ConsultationFee;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("---- OutPatient Details ----");
            Console.WriteLine($"ID: {PatientId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Consultation Fee: {CalculateBill()}");
        }
    }

}

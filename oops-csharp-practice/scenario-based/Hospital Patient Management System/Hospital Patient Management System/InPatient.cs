using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Patient_Management_System
{
    class InPatient : Patient, IPayable
    {
        public int NumberOfDays { get; set; }
        public double DailyCharge { get; set; }

        public InPatient(int id, string name, int age, int days, double charge)
            : base(id, name, age)
        {
            NumberOfDays = days;
            DailyCharge = charge;
        }

        public double CalculateBill()
        {
            return NumberOfDays * DailyCharge;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("---- InPatient Details ----");
            Console.WriteLine($"ID: {PatientId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Days Admitted: {NumberOfDays}");
            Console.WriteLine($"Total Bill: {CalculateBill()}");
        }
    }
}

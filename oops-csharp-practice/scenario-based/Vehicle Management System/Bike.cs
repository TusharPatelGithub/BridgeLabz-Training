using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Management_System
{
    class Bike : Vehicle, IRentable
    {
        public Bike(string vehicleNumber, string brand, double rentPerDay)
            : base(vehicleNumber, brand, rentPerDay) { }

        public double CalculateRent(int days)
        {
            return rentPerDay * days;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("---- Bike Details ----");
            base.DisplayInfo();
        }
    }
}

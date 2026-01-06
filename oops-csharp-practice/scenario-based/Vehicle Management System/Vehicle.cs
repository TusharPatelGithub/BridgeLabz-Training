using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Management_System
{
    class Vehicle
    {
        protected string vehicleNumber;
        protected string brand;
        protected double rentPerDay;

        public Vehicle(string vehicleNumber, string brand, double rentPerDay)
        {
            this.vehicleNumber = vehicleNumber;
            this.brand = brand;
            this.rentPerDay = rentPerDay;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle No: {vehicleNumber}");
            Console.WriteLine($"Brand: {brand}");
        }
    }
}

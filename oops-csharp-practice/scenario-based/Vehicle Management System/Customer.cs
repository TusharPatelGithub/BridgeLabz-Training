using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Management_System
{
    class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void RentVehicle(IRentable vehicle, int days)
        {
            Console.WriteLine($"Customer: {Name}");
            Console.WriteLine($"Rent for {days} days: ₹{vehicle.CalculateRent(days)}");
        }
    }
}

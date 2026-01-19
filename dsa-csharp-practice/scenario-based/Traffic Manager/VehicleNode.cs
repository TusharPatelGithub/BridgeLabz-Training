using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Manager
{
    class VehicleNode //represents single vehicle
    {
        public string VehicleNumber;
        public VehicleNode Next;
        public VehicleNode(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
            Next = null;
        }
    }
}

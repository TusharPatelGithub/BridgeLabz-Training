using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Manager
{
    class RoundAbout
    {
        private VehicleNode last;
        public RoundAbout()
        {
            last = null;
        }
        public void AddVehicle(string vehicleNumber) //add vehicle in roundabout
        {
            if (vehicleNumber == null)
                return;
            VehicleNode newNode = new VehicleNode(vehicleNumber);
            if (last == null)
            {
                last = newNode;
                last.Next = last;
            }
            else
            {
                newNode.Next = last.Next;
                last.Next = newNode;
                last = newNode;
            }
            Console.WriteLine($"Vehicle {vehicleNumber} entry in roundabout");
        }
        public void RemoveVehicle() //remove vehicle from roundabot 
        {
            if (last == null)
            {
                Console.WriteLine("roundabout is empty.");
                return;
            }
            if (last.Next == last)
            {
                Console.WriteLine($"Vehicle {last.VehicleNumber} exited the roundabout");
                last = null;
            }
            else
            {
                VehicleNode firstVehicle = last.Next;
                Console.WriteLine($"Vehicle {firstVehicle.VehicleNumber} exited roundabout");
                last.Next = firstVehicle.Next;
            }
        }
        public void Display()
        {  // dispaly roundabout
            if (last == null)
            {
                Console.WriteLine("Roundabout is empty");
                return;
            }
            Console.WriteLine("Roundabout state: ");
            VehicleNode temp = last.Next;
            do
            {
                Console.Write(temp.VehicleNumber + "=>");
                temp = temp.Next;
            } while (temp != last.Next);
            Console.WriteLine("Back to start.");
        }
    }
}

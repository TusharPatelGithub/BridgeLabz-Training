using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Manager
{
    class TrafficManager
    {
        public static void Main(String[] args)
        {
            RoundAbout roundabout = new RoundAbout();
            Console.Write("Enter maximum waiting queue size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            VehicleQueue waitingQueue = new VehicleQueue(size);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--------traffic Manager Menu--------");
                Console.WriteLine("1. Add vehicle to waiting queue");
                Console.WriteLine("2. Move vehicle from queue to roundabout");
                Console.WriteLine("3. Remove vehicle from roundabout");
                Console.WriteLine("4. View roundabout state");
                Console.WriteLine("5. View waiting queue");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter vehicle number: ");
                        string vehicle = Console.ReadLine();
                        waitingQueue.Enqueue(vehicle);
                        break;
                    case 2:
                        string nextVehicle = waitingQueue.Dequeue();
                        roundabout.AddVehicle(nextVehicle);
                        break;
                    case 3:
                        roundabout.RemoveVehicle();
                        break;
                    case 4:
                        roundabout.Display();
                        break;
                    case 5:
                        waitingQueue.PrintQueue();
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Traffic Manager closed.");
                        break;
                    default:
                        Console.WriteLine("Try again.");
                        break;
                }
            }
        }
    }
}

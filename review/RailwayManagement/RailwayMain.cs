using System;
class RailwayMain
{
    public static void Main(String[] args)
    {
        RailwaySystem system = new RailwaySystem(15);
        string choice;
        do
        {
            Console.WriteLine("RailwayManagement");
            Console.WriteLine("1. Register Passenger.");
            Console.WriteLine("2. Display Passenger");
            Console.WriteLine("3. Sort Passenger");
            Console.WriteLine("4. Search Passenger by Pnr");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("Enter choice: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                system.RegisterPassenger();
                break;
                case "2":
                system.DisplayPassenger();
                break;
                case "3":
                system.SortByPnr();
                break;
                case "4":
                Console.Write("Enter pnr number: ");
                int pnr = int.Parse(Console.ReadLine());
                system.SearchByPnr(pnr);
                break;
                default:
                Console.WriteLine("Invalid Choice.");
                break;
            }
        }while(choice!="5");
    }
}
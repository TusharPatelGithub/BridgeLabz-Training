using System;
class AmbulanceRouteMain{
    static void Main(string[] args){
        CircularRoute route = new CircularRoute();
        int choice;
        do{
            Console.WriteLine("\nAmbulance Route System");
            Console.WriteLine("1. Add Hospital Unit");
            Console.WriteLine("2. Route Patient");
            Console.WriteLine("3. Remove Unit (Maintenance)");
            Console.WriteLine("4. Display Units");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice){
                case 1:
                    Console.Write("Enter unit name: ");
                    string name = Console.ReadLine();
                    Console.Write("Is unit available? (yes/no): ");
                    string input = Console.ReadLine().ToLower();
                    bool available = input == "yes";
                    route.AddUnit(name, available);
                    Console.WriteLine("Hospital unit added successfully.");
                    break;
                case 2:
                    route.RoutePatient();
                    break;
                case 3:
                    Console.Write("enter unit name to remove: ");
                    string removeName = Console.ReadLine();
                    route.RemoveUnit(removeName);
                    break;
                case 4:
                    route.DisplayUnits();
                    break;
                case 5:
                    Console.WriteLine("exiting Ambulance Route System...");
                    break;
                default:
                    Console.WriteLine("invalid choice. Please try again.");
                    break;
            }
        }while(choice != 5);
        Console.ReadLine();
    }
}
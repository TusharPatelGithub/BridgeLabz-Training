using System;
using HealthCareClinicApp.Menus;
namespace HealthCareClinicApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to HealthCare Clinic System");
            MenuHandler.Start();
            Console.WriteLine("\nThank you for using the system!");
        }
    }
}

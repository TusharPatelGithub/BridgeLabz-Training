using System;

class Program
{
    static void Main()
    {
        Appliance[] appliances =
        {
            new Light("Living Room"),
            new Fan("Bedroom"),
            new AC("Office")
        };

        foreach (Appliance appliance in appliances)
        {
            appliance.TurnOn();   // Polymorphism
            appliance.TurnOff();
            Console.WriteLine();
        }
    }
}

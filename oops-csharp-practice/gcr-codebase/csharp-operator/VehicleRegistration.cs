using System;

class Vehicle
{
    public static double RegistrationFee = 5000;

    public string OwnerName;
    public string VehicleType;
    public readonly string RegistrationNumber;

    public Vehicle(string ownerName, string vehicleType, string registrationNumber)
    {
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = registrationNumber;
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name          : " + OwnerName);
        Console.WriteLine("Vehicle Type        : " + VehicleType);
        Console.WriteLine("Registration Number : " + RegistrationNumber);
        Console.WriteLine("Registration Fee    : " + RegistrationFee);
    }
}

class VehicleRegistration
{
    static void Main(string[] args)
    {
        Vehicle vehicle1 = new Vehicle("Tushar", "Car", "MH12AB1234");

        Vehicle.UpdateRegistrationFee(6500);

        if (vehicle1 is Vehicle)
        {
            vehicle1.DisplayVehicleDetails();
        }
        else
        {
            Console.WriteLine("Invalid vehicle object");
        }
    }
}

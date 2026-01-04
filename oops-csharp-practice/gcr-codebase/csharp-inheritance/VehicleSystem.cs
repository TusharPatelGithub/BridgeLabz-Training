using System;

interface Refuelable
{
    void Refuel();
}

class Vehicle
{
    public string Model;
    public int MaxSpeed;

    public Vehicle(string model, int maxSpeed)
    {
        Model = model;
        MaxSpeed = maxSpeed;
    }
}

class ElectricVehicle : Vehicle
{
    public int BatteryCapacity;

    public ElectricVehicle(string model, int maxSpeed, int batteryCapacity)
        : base(model, maxSpeed)
    {
        BatteryCapacity = batteryCapacity;
    }

    public void Charge()
    {
        Console.WriteLine("Vehicle Type : Electric");
        Console.WriteLine("Model        : " + Model);
        Console.WriteLine("Max Speed    : " + MaxSpeed);
        Console.WriteLine("Battery      : " + BatteryCapacity + " kWh");
        Console.WriteLine("Status       : Charging");
    }
}

class PetrolVehicle : Vehicle, Refuelable
{
    public int FuelCapacity;

    public PetrolVehicle(string model, int maxSpeed, int fuelCapacity)
        : base(model, maxSpeed)
    {
        FuelCapacity = fuelCapacity;
    }

    public void Refuel()
    {
        Console.WriteLine("Vehicle Type : Petrol");
        Console.WriteLine("Model        : " + Model);
        Console.WriteLine("Max Speed    : " + MaxSpeed);
        Console.WriteLine("Fuel Tank    : " + FuelCapacity + " litres");
        Console.WriteLine("Status       : Refueling");
    }
}

class VehicleSystem
{
    static void Main(string[] args)
    {
        ElectricVehicle ev = new ElectricVehicle("Tesla Model 3", 200, 75);
        PetrolVehicle pv = new PetrolVehicle("Honda City", 180, 40);

        ev.Charge();
        Console.WriteLine();

        pv.Refuel();
    }
}

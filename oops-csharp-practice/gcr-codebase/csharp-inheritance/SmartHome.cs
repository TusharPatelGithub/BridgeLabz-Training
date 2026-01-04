using System;

class Device
{
    public int DeviceId;
    public string Status;

    public Device(int deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine("Device ID : " + DeviceId);
        Console.WriteLine("Status    : " + Status);
    }
}

class Thermostat : Device
{
    public int TemperatureSetting;

    public Thermostat(int deviceId, string status, int temperature)
        : base(deviceId, status)
    {
        TemperatureSetting = temperature;
    }

    public override void DisplayStatus()
    {
        Console.WriteLine("Device ID           : " + DeviceId);
        Console.WriteLine("Status              : " + Status);
        Console.WriteLine("Temperature Setting : " + TemperatureSetting + "°C");
    }
}

class SmartHome
{
    static void Main(string[] args)
    {
        Thermostat thermostat = new Thermostat(101, "ON", 24);
        thermostat.DisplayStatus();
    }
}

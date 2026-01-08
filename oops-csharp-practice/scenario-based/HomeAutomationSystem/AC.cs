public class AC : Appliance
{
    public AC(string name) : base(name) { }

    public override void TurnOn()
    {
        System.Console.WriteLine($"{Name} AC is cooling the room to 22°C.");
    }

    public override void TurnOff()
    {
        System.Console.WriteLine($"{Name} AC is turned OFF and compressor stopped.");
    }
}

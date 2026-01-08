public class Fan : Appliance
{
    public Fan(string name) : base(name) { }

    public override void TurnOn()
    {
        System.Console.WriteLine($"{Name} fan is spinning at medium speed.");
    }
}

public class Light : Appliance
{
    public Light(string name) : base(name) { }

    public override void TurnOn()
    {
        System.Console.WriteLine($"{Name} light is glowing softly.");
    }
}

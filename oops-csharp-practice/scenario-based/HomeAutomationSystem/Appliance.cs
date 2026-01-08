public abstract class Appliance : IControllable
{
    public string Name { get; set; }

    protected Appliance(string name)
    {
        Name = name;
    }

    public abstract void TurnOn();

    public virtual void TurnOff()
    {
        System.Console.WriteLine($"{Name} is turned OFF.");
    }
}

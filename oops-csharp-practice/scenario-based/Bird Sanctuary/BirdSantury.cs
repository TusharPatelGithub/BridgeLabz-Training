using Bird_Sanctuary;

class BirdSanctuary
{
    static void Main()
    {
        Bird[] birds = new Bird[]
        {
            new Eagle("Eagle", "Brown"),
            new Sparrow("Sparrow", "Grey"),
            new Duck("Duck", "White"),
            new Penguin("Penguin", "Black"),
        };

        foreach (Bird bird in birds)
        {
            bird.DisplayInfo();
            if (bird is IFlyable)
            {
                ((IFlyable)bird).Fly();
            }

            if (bird is ISwimmable)
            {
                ((ISwimmable)bird).Swim();
            }

            Console.WriteLine();
        }
    }
}
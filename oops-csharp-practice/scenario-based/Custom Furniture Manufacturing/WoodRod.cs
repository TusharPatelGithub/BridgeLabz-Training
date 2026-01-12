class WoodRod : WoodRodBase
{
    public WoodRod(int length)
    {
        Length = length;
    }

    public override int GetLength()
    {
        return Length;
    }
}

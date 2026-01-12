class Rod : RodBase
{
    public Rod(int length)
    {
        Length = length;
    }

    public override int GetLength()
    {
        return Length;
    }
}

class Handshakes
{
    static int shakes(int n)
    {
        return  (n * (n - 1)) / 2;
    }
    static void Main(String[] args)
    {
        Console.WriteLine("Enter the Value: ");
        int a=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine(shakes(a));
    }
}
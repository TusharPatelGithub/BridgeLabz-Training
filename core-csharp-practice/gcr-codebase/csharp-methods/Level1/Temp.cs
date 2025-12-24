class Temp
{
     static void output(double a, double b)
    {
        double windChill = 35.74 + 0.6215 *a + (0.4275*a - 35.75) * b*0.16 ;
        Console.WriteLine("windchill = " +windChill);

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Temperature Value: ");
        double a=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the wind speed : ");
        double b=Convert.ToDouble(Console.ReadLine());
        output(a,b);
    }
}
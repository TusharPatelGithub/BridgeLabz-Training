class SimpleInt

{
    static Double SimpleI(Double a, Double b, Double c)
    {
        return (a*b*c)/100;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the principal amount: ");
        Double a=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the Rate: ");
        Double b=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the time in year: ");
        Double c=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(SimpleI(a,b,c));
    }
}
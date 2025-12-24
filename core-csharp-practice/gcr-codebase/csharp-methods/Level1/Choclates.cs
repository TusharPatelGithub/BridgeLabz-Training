class Choclates
{
     static void output(double a, double b)
    {
        Console.WriteLine("Number of choclates distrubuted each of student: "+a/b);
        Console.WriteLine("Remaining choclates: "+a%b);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Choclate Value: ");
        double a=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Number of student : ");
        double b=Convert.ToDouble(Console.ReadLine());
        output(a,b);
    }
}
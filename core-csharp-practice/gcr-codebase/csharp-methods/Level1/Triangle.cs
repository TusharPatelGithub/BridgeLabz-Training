class Triangle

{
    static int sides(int a)
    {
        int p=a+a+a;
        int run=5000/p;
        return run;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the sides: ");
        int a=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Numbers of round is: "+sides(a));
    }
}
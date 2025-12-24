class CheckNum
{
    static void check(int a)
    {
        if (a > 0)
        {
            Console.WriteLine(a+" is a positive number: ");
        } else if (a < 0)
        {
            Console.WriteLine(a+" is a negative number: ");
        }
        else
        {
            Console.WriteLine(a+" is a zero: ");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int a=Convert.ToInt16(Console.ReadLine());
        // Console.WriteLine
        check(a);
    }
}
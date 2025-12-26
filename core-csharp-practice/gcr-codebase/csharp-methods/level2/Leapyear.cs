class Leapyear
{
    static bool output(int a)
    {
        return (a%4==0);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number:");
        int a=Convert.ToInt16(Console.ReadLine()); 
         Console.WriteLine(output(a));
    }
}
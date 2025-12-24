class SmallLarge
{
    static void val(int a, int b, int c)
    {
        if (a > b && a > c)
        {
            Console.WriteLine(a+" is the largest number: ");
        }else if (b > c && b > a)
        {
             Console.WriteLine(b+" is the largest number: ");
        }
        else
        {
             Console.WriteLine(c+" is the largest number: ");
        }
        if (a < b && a < c)
        {
            Console.WriteLine(a+" is the smallest number: ");
        }else if (b < c && b < a)
        {
             Console.WriteLine(b+" is the smallest number: ");
        }
        else
        {
             Console.WriteLine(c+" is the smallest number: ");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first Value: ");
        int a=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter second Value: ");
        int b=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter the third Value: ");
        int c=Convert.ToInt16(Console.ReadLine());
        val(a,b,c);
        
    }
}
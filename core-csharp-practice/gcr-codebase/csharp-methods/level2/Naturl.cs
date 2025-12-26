class Naturl
{
    static int num(int a)
    {
        if (a < 1)
        {
            return 0;
        }
        return a+num(a-1);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number: ");
        int a= Convert.ToInt16(Console.ReadLine());
        int sum=(a*(a+1))/2;
        Console.WriteLine(num(a)==sum);
    }
}
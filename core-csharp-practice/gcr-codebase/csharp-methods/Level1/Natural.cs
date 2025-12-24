class Natural
{
    static int sum(int a)
    {
        int sum=0;
        for(int i = 1; i <= a; i++)
        {
            sum=sum+i;
        }
        return sum;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Value: ");
        int a=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine(sum(a));
    }
}
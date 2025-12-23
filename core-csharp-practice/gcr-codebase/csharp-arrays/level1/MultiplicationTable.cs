class MultiplicationTable
{
    static void Main(String[] args)
    {
        int a=Convert.ToInt16(Console.ReadLine());
        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine(a+" * "+i+" = "+a*i);
        }
    }
}
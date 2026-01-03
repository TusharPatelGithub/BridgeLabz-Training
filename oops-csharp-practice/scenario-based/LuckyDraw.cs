
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

class Draw
{
    protected int n;
    public void value()
    {
        Console.WriteLine($"Enter the number of visitors: ");
        n=Convert.ToInt16(Console.ReadLine());
    }
}
class Mela : Draw
{

    public void Print()
    {
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter any number ");
            int number=Convert.ToInt16(Console.ReadLine());
            if (number % 3 == 0 || number % 5 == 0)
            {
                Console.WriteLine($"Congrats visitor {i+1} you won a gift. ");

            }
            else
            {
                Console.WriteLine($"visitor {i+1} better luck next time. ");
            }
        }
    }
   
}
class LuckyDraw
{
    public static void Main(string[] args)
    {
        Mela mela=new Mela();
        mela.value();
        mela.Print();
    }
}

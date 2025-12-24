class SpringSea
{
    static bool check(int month, int day)
    {
        if (month >= 3 || month <= 6)
        {
            if (month == 3 && day >= 20)
            {
                return true;
            }
            else if (month == 6 && day <= 20)
            {
                return true;
            }
        }
        return false;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the month: ");
        
        int month=Convert.ToInt16(Console.ReadLine());

        if (month <=3&&month>=6)
        {
            Console.WriteLine("Enter valid month and not a spring season: ");
        }
        Console.WriteLine("Enter the date: ");
        int day=Convert.ToInt16(Console.ReadLine());
        if (day > 31&&day<1)
        {
            Console.WriteLine("Enter valid date: ");
        }
        Console.WriteLine(check(month,day));
    }
}
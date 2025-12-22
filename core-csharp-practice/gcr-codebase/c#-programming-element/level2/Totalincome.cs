using System;

class TotalIncome
{
    public static void Main(string[] args)
    {
        Console.Write("Enter salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter bonus: ");
        double bonus = Convert.ToDouble(Console.ReadLine());

        double totalIncome = salary + bonus;

        Console.WriteLine("Total Income = " + totalIncome);
    }
}

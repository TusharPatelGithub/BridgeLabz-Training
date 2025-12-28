using System;

class DateComparison
{
    static void Main()
    {
        Console.Write("Enter first date (yyyy-mm-dd): ");
        string input1 = Console.ReadLine() ?? "";
        Console.Write("Enter second date (yyyy-mm-dd): ");
        string input2 = Console.ReadLine()?? "";
        if (DateTime.TryParse(input1, out DateTime date1) &&
            DateTime.TryParse(input2, out DateTime date2))
        {
            int result = DateTime.Compare(date1, date2);

            if (result < 0)
                Console.WriteLine("First date is BEFORE the second date.");
            else if (result > 0)
                Console.WriteLine("First date is AFTER the second date.");
            else
                Console.WriteLine("Both dates are the SAME.");
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }
}

using System;

class CompanyBonus
{
    static void Main()
    {
        int count = 10;
        double[] pay = new double[count];
        double[] experience = new double[count];
        double[] incentive = new double[count];
        double[] updatedPay = new double[count];
        double sumOldPay = 0;
        double sumIncentive = 0;
        double sumNewPay = 0;
        for (int idx = 0; idx < count; idx++)
        {
            Console.WriteLine("Enter details for Employee " + (idx + 1));

            Console.Write("Enter Salary: ");
            pay[idx] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Years of Service: ");
            experience[idx] = Convert.ToDouble(Console.ReadLine());

            if (pay[idx] <= 0 || experience[idx] < 0)
            {
                Console.WriteLine("Invalid input! Please enter again.");
                idx--;
            }
        }
        for (int idx = 0; idx < count; idx++)
        {
            if (experience[idx] > 5)
                incentive[idx] = pay[idx] * 0.05;
            else
                incentive[idx] = pay[idx] * 0.02;
            updatedPay[idx] = pay[idx] + incentive[idx];
            sumOldPay += pay[idx];
            sumIncentive += incentive[idx];
            sumNewPay += updatedPay[idx];
        }
        Console.WriteLine("\nTotal Old Salary: " + sumOldPay);
        Console.WriteLine("Total Bonus Paid: " + sumIncentive);
        Console.WriteLine("Total New Salary: " + sumNewPay);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage_Computation
{
    class EmployeeUtilityImpl : IEmployee
    {
        private Employee _employee;
        private const int Wage_Per_Hour = 20;
        private const int Full_Day_Hour = 8;
        private const int Part_Time_Hour = 8;
        private const int Working_Days = 20;
        private const int Max_Working_Days = 20;
        private const int Max_Working_Hours = 100;
        public Employee addEmployee()
        {
            Console.WriteLine("Enter Employee Details: ");

            Console.Write("Employee ID: ");
            long id = Convert.ToInt64(Console.ReadLine());

            Console.Write("Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Employee Email: ");
            string email = Console.ReadLine();

            _employee = new Employee(id, name, email);

            Console.WriteLine("\nEmployee Details Saved Successfully\n");
            Console.WriteLine(_employee.ToString());

            return _employee;
        }

        public bool CheckAttendance(long e)
        {
            Random random = new Random();
            int attendance = random.Next(0, 2);

            if (attendance == 1)
            {
                Console.WriteLine("Employee Present");
                return true;
            }
            else
            {
                Console.WriteLine("Employee Absent");
                return false;
            }

        }

        public void CalculateDailyWage(long e)
        {
            bool isPresent = CheckAttendance(e);
            if (isPresent)
            {
                int dailyWage = Wage_Per_Hour * Full_Day_Hour;
                Console.WriteLine("Daily Employee Wage: " + dailyWage);
            }
            else
            {
                Console.WriteLine("Daily Employee Wage: 0");
            }
        }

        public void CalculatePartTimeWage()
        {
            int wage = Part_Time_Hour * Wage_Per_Hour;
            Console.WriteLine("Part Time Daily Wage: " + wage);
        }

        public void CalculateMonthlyWage(long e)
        {
            int totalWage = 0;

            for (int day = 1; day <= Working_Days; day++)
            {
                Console.WriteLine("\nDay " + day);

                if (CheckAttendance(e))
                {
                    totalWage += Full_Day_Hour * Wage_Per_Hour;
                }
            }

            Console.WriteLine("\nTotal Monthly Wage: " + totalWage);
        }

        public void CalculateWageTillCondition(long e)
        {
            int totalWorkingDays = 0;
            int totalWorkingHours = 0;
            int totalWage = 0;

            while (totalWorkingDays < Max_Working_Days && totalWorkingHours < Max_Working_Hours)
            {
                totalWorkingDays++;

                Console.WriteLine("\nDay " + totalWorkingDays);

                bool isPresent = CheckAttendance(e);

                if (isPresent)
                {
                    totalWorkingHours += Full_Day_Hour;
                    totalWage += Full_Day_Hour * Wage_Per_Hour;
                    Console.WriteLine("Employee Present");
                }
                else
                {
                    Console.WriteLine("Employee Absent");
                }
            }

            Console.WriteLine("\nFinal Result:");
            Console.WriteLine("Total Working Days: " + totalWorkingDays);
            Console.WriteLine("Total Working Hours: " + totalWorkingHours);
            Console.WriteLine("Total Wage: " + totalWage);
        }
    }
}
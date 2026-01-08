using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage_Computation
{
    sealed class EmployeeMenu
    {
        private IEmployee employee;

        public void employeeMenu()
        {
            employee = new EmployeeUtilityImpl();
            Employee e1 = null;

            while (true)
            {
                Console.WriteLine("\nWelcome to the Employee Wage Computation System");
                Console.WriteLine("1. Full Time Employee");
                Console.WriteLine("2. Part Time Employee");
                Console.WriteLine("3. Exit");

                int mainChoice = Convert.ToInt32(Console.ReadLine());

                switch (mainChoice)
                {
                    // Full Time Employee Menu
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("\nFull Time Employee Menu");
                            Console.WriteLine("1. Add Employee");
                            Console.WriteLine("2. Check Employee Attendance");
                            Console.WriteLine("3. Calculate Daily Wage");
                            Console.WriteLine("4. Calculate Monthly Wage");
                            Console.WriteLine("5. Calculate Wage Till Condition");
                            Console.WriteLine("6. Back");

                            int ftChoice = Convert.ToInt32(Console.ReadLine());

                            switch (ftChoice)
                            {
                                case 1:
                                    e1 = employee.addEmployee();
                                    break;

                                case 2:
                                    employee.CheckAttendance(e1.GetId());
                                    break;

                                case 3:
                                    employee.CalculateDailyWage(e1.GetId());
                                    break;

                                case 4:
                                    employee.CalculateMonthlyWage(e1.GetId());
                                    break;

                                case 5:
                                    employee.CalculateWageTillCondition(e1.GetId());
                                    break;

                                case 6:
                                    return;


                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                        }

                    // Part Time Employee Menu
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("\nPart Time Employee Menu");
                            Console.WriteLine("1. Add Employee");
                            Console.WriteLine("2. Calculate Part Time Wage");
                            Console.WriteLine("3. Back");

                            int ptChoice = Convert.ToInt32(Console.ReadLine());

                            switch (ptChoice)
                            {
                                case 1:
                                    e1 = employee.addEmployee();
                                    break;

                                case 2:
                                    employee.CalculatePartTimeWage();
                                    break;

                                case 3:
                                    break;

                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                        }

                    // Exit
                    case 3:
                        Console.WriteLine("Exiting the System");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
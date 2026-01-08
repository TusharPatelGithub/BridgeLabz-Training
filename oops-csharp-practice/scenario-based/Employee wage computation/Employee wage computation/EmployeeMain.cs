using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employee_Wage_Computation
{
    internal class EmployeeMain
    {
        public static void Main(string[] args)
        {

            EmployeeMenu employeeMenu = new EmployeeMenu();
            employeeMenu.employeeMenu();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage_Computation
{
    internal interface IEmployee
    {
        Employee addEmployee();
        public bool CheckAttendance(long e);
        public void CalculateDailyWage(long e);
        void CalculatePartTimeWage();
        void CalculateMonthlyWage(long e);
        void CalculateWageTillCondition(long e);
    }

}
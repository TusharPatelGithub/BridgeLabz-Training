using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage_Computation
{
    internal class Employee
    {
        private long employeeId { get; set; }

        private string employeeName { get; set; }

        private string employeeEmail { get; set; }

        public Employee(long employeeId, string employeeName, string employeeEmail)
        {
            this.employeeName = employeeName;
            this.employeeEmail = employeeEmail;
            this.employeeId = employeeId;
        }

        public long GetId()
        {
            return employeeId;
        }
        public override string ToString()
        {
            return "Employee Name: " + employeeName + "Employee ID: " + employeeId + "Employee Email" + employeeEmail;
        }
    }
}
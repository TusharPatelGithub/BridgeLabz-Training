using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace PayrollService
{
    //interface for Employee Payroll Service
    public interface IEmployeePayrollService
    {
        void AddEmployee(Employee employee);//uc1&uc2
        void AddEmployeesWithThreads(List<Employee> employees);  //uc2,uc3,uc4
        void AddEmployeeWithDetails(Employee employee); //uc5
        void UpdateEmployeeSalary(Employee employee); //uc6
    }
}
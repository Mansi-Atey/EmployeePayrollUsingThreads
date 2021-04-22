using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingThreading
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeDetails> employeePayrollDetailsList = new List<EmployeeDetails>();
        public void addEmployeeToPayRoll(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.addEmployeeToPayroll(employeeData);
                Console.WriteLine("Employee added: " +employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailsList.ToString());
        }

        public void addEmployeeToPayroll(EmployeeDetails emp)
        {
            employeePayrollDetailsList.Add(emp);
        }
        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                        this.addEmployeeToPayroll(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.EmployeeName);

                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailsList.Count);
        }
    }
}

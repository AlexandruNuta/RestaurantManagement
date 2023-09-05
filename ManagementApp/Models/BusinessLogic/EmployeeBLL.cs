using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Models.BusinessLogic
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDAL;

        public EmployeeBLL()
        {
            employeeDAL = new EmployeeDAL();
        }

        public List<Employee> GetEmployees()
        {
            return employeeDAL.GetEmployees();
        }

        public Employee GetEmployee(int employeeId)
        {
            return employeeDAL.GetEmployee(employeeId);
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return employeeDAL.GetEmployeeByUsername(username);
        }

        public bool UpdateEmployeeName(int employeeId, string newName)
        {
            // You can add business logic/validation here if needed
            return employeeDAL.UpdateEmployeeName(employeeId, newName);
        }

        public bool CreateEmployee(int id,string name,string position)
        {
            // You can add business logic/validation here if needed
            return employeeDAL.CreateEmployee(id,name,position);
        }

        public bool DeleteEmployee(int employeeId)
        {
            // You can add business logic/validation here if needed
            return employeeDAL.DeleteEmployee(employeeId);
        }
    }
}

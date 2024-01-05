using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.BusinessLogic
{
    public class EmployeeBLL
    {
        public IEmployeeDA employeeDAL;
        public EmployeeBLL(IEmployeeFactory employeeDAL)
        {
            this.employeeDAL = employeeDAL.Create();
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
  
            return employeeDAL.UpdateEmployeeName(employeeId, newName);
        }

        public bool CreateEmployee(int id,string name,string position)
        {
 
            return employeeDAL.CreateEmployee(id,name,position);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return employeeDAL.DeleteEmployee(employeeId);
        }
    }
}

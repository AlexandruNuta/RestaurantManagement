
using ManagementApp.Commands;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.ViewModels
{
    public class EmployeeViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public EmployeeBLL _employeeBLL;


        private int _employeeId;
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                OnPropertyChanged(nameof(EmployeeId));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        public EmployeeViewModel()
        {
            IEmployeeFactory employeeDA = new EmployeeDAFactory();
            _employeeBLL = new EmployeeBLL(employeeDA);
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee);
            LoadEmployees();
   
        }


        private void AddEmployee()
        {
            
            bool success = _employeeBLL.CreateEmployee(_employeeId,_name,_position);

            if (success)
            {
                MessageBox.Show("Employee created successfully");
                Employees.Clear();
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Error occurred while creating the employee");
            }

            Name = string.Empty;
            Position = string.Empty;
        }

        private void EditEmployee()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Select an employee to edit.");
                return;
            }

            SelectedEmployee.Name = Name;

            bool success = _employeeBLL.UpdateEmployeeName(SelectedEmployee.Id, SelectedEmployee.Name);

            if (success)
            {
                MessageBox.Show("Employee name updated successfully");
                Employees.Clear();
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Error occurred while updating the employee name");
            }
        }

        private void DeleteEmployee()
        {
            if(SelectedEmployee == null)
    {
                MessageBox.Show("Select an employee to delete.");
                return;
            }

            bool success = _employeeBLL.DeleteEmployee(SelectedEmployee.Id);

            if (success)
            {
                MessageBox.Show("Employee deleted successfully");
                Employees.Clear();
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Error occurred while deleting the employee");
            }
        }
        private void LoadEmployees()
        {
            List<Employee> employees = _employeeBLL.GetEmployees();

            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }

    }
}

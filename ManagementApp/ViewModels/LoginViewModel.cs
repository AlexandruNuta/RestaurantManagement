using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ManagementApp.Commands;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using ManagementApp.Views;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }


        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            EmployeeBLL employeeBLL;
            IEmployeeFactory employeeDA = new EmployeeDAFactory();
            employeeBLL = new EmployeeBLL(employeeDA);
            Employee employee = employeeBLL.GetEmployeeByUsername(Username);

            if (employee != null)
            {
                // Successful login
                if (employee.Position == "Administrator")
                {
                    NavigateToAdminPage();
                }
                else
                {
                    NavigateToEmployeePage();
                }
            }
            else
            {
                Console.WriteLine("Login failed!");
            }
        }
        private void NavigateToAdminPage()
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
        }

        private void NavigateToEmployeePage()
        {
            EmployeePage employeePage = new EmployeePage();
            employeePage.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ManagementApp.Commands;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.Entity;
using ManagementApp.Views;

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
            EmployeeBLL employeeBLL = new EmployeeBLL();
            Employee employee = employeeBLL.GetEmployeeByUsername(Username);

            if (employee != null)
            {
                // Successful login
                if (employee.Position == "Administrator")
                {
                    NavigateToAdminPage(); // Navigate to the admin page
                }
                else
                {
                    NavigateToEmployeePage(); // Navigate to the employee page
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
            // Close the current login window if needed
            // this.Close();
        }

        private void NavigateToEmployeePage()
        {
            EmployeePage employeePage = new EmployeePage();
            employeePage.Show();
            // Close the current login window if needed
            // this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using ManagementApp.Commands;
using ManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ManagementApp.ViewModels
{
    public class AdminViewModel
    {

        public ICommand NavigateToEmployeesCommand { get; }
        public ICommand NavigateToProductsCommand { get; }
        public ICommand NavigateToTablesCommand { get; }
        public ICommand NavigateToOrderCommand { get; }

        public AdminViewModel()
        {
         
            NavigateToEmployeesCommand = new RelayCommand(NavigateToEmployees);
            NavigateToProductsCommand = new RelayCommand(NavigateToProducts);
            NavigateToTablesCommand = new RelayCommand(NavigateToTables);
            NavigateToOrderCommand = new RelayCommand(NavigateToOrder);
        }

        private void NavigateToEmployees()
        {
            EmployeeView employeesView = new EmployeeView();
            employeesView.Show();

        }

        private void NavigateToProducts()
        {
            ProductView productsView = new ProductView();
            productsView.Show();
        }

        private void NavigateToTables()
        {
            TableView tablesView = new TableView();
            tablesView.Show();
        }

        private void NavigateToOrder()
        {
            OrderPage orderPage = new OrderPage();
            orderPage.Show();
        }
    }
}

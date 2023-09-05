using ManagementApp.Commands;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ManagementApp.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public Order SelectedOrder { get; set; }

        public void SelectOrder(Order order)
        {
            SelectedOrder = order;
            OnPropertyChanged(nameof(SelectedOrder));
        }

        public OrderBLL _orderBLL = new OrderBLL();
        public ProductBLL _productBLL = new ProductBLL();

        

        private decimal _newOrderTotalAmount;
        public decimal NewOrderTotalAmount
        {
            get { return _newOrderTotalAmount; }
            set
            {
                _newOrderTotalAmount = value;
                OnPropertyChanged(nameof(NewOrderTotalAmount));
            }
        }
        private DateTime _newOrderDate = DateTime.Now;
        public DateTime NewOrderDate
        {
            get { return _newOrderDate; }
            set
            {
                _newOrderDate = value;
                OnPropertyChanged(nameof(NewOrderDate));
            }
        }

        private string _newOrderStatus;
        public string NewOrderStatus
        {
            get { return _newOrderStatus; }
            set
            {
                _newOrderStatus = value;
                OnPropertyChanged(nameof(NewOrderStatus));
            }
        }

        private int _newOrderTableId;
        public int NewOrderTableId
        {
            get { return _newOrderTableId; }
            set
            {
                _newOrderTableId = value;
                OnPropertyChanged(nameof(NewOrderTableId));
            }
        }
        private int _newOrderId;
        public int NewOrderId
        {
            get { return _newOrderTableId; }
            set
            {
                _newOrderId = value;
                OnPropertyChanged(nameof(NewOrderId));
            }
        }
        private decimal _intermediateTotal;
        public decimal IntermediateTotal
        {
            get { return _intermediateTotal; }
            set
            {
                _intermediateTotal = value;
                OnPropertyChanged(nameof(IntermediateTotal));
            }
        }

        public ObservableCollection<Product> AvailableProducts { get; set; } = new ObservableCollection<Product>();
        public Product SelectedProduct { get; set; }
        public int SelectedProductQuantity { get; set; }

        public ICommand AddProductToOrderCommand { get; }
        public ICommand CreateOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        public OrderViewModel()
        {
            AddProductToOrderCommand = new RelayCommand(AddProductToOrder);
            CreateOrderCommand = new RelayCommand(CreateOrder);
            DeleteOrderCommand = new RelayCommand(DeleteOrder);
            LoadAvailableProducts();
            LoadOrders();
            _intermediateTotal = 0;
        }

        private void CreateOrder()
        {


            bool success = _orderBLL.CreateOrder(_newOrderId, _newOrderTotalAmount, _newOrderDate, _newOrderStatus, _newOrderTableId);

            if (success)
            {
                MessageBox.Show("Order created successfully");
                Orders.Clear();
                LoadOrders(); // Refresh the list of orders
            }
            else
            {
                MessageBox.Show("Error occurred while creating the order");
            }

            // Clear the text boxes after adding
            NewOrderId = 0;
            NewOrderTotalAmount = 0;
            NewOrderDate = DateTime.Now;
            NewOrderStatus = string.Empty;
            NewOrderTableId = 0;
        }

        private void AddProductToOrder()
        {
            if (SelectedOrder == null || SelectedProduct == null || SelectedProductQuantity <= 0)
            {
                MessageBox.Show("Please select a valid order, product, and quantity.");
                return;
            }

            bool success = _orderBLL.AddProductToOrder(SelectedOrder.Id, SelectedProduct.Id, SelectedProductQuantity);

            if (!success)
            {
                MessageBox.Show("Error occurred while adding the product to the order.");
            }
            IntermediateTotal += (SelectedProduct.Price * SelectedProductQuantity);

            // Reset selected product and quantity (if needed)
            SelectedProduct = null;
            SelectedProductQuantity = 0;
        }

        private void DeleteOrder()
        {
            if (SelectedOrder == null)
            {
                MessageBox.Show("Please select an order to delete.");
                return;
            }

            bool success = _orderBLL.DeleteOrder(SelectedOrder.Id);

            if (success)
            {
                MessageBox.Show("Order deleted successfully");
                Orders.Remove(SelectedOrder);
            }
            else
            {
                MessageBox.Show("Error occurred while deleting the order");
            }
        }

        private void LoadAvailableProducts()
        {
            List<Product> products = _productBLL.GetAllProducts();

            foreach (var product in products)
            {
                AvailableProducts.Add(product);
            }
        }

        private void LoadOrders()
        {
            List<Order> orders = _orderBLL.GetAllOrders();

            foreach (var temp in orders)
            {
                Orders.Add(temp);
            }
        }
    }

}

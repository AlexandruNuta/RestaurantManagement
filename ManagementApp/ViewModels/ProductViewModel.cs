using ManagementApp.Commands;
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

using ManagementApp.Models.BusinessLogic;

namespace ManagementApp.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public Product SelectedProduct { get; set; }

        public void SelectProduct(Product product)
        {
            SelectedProduct = product;
            OnPropertyChanged(nameof(SelectedProduct));
        }

        public ProductBLL _productBLL = new ProductBLL();

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        // Commands
        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductViewModel()
        {
            // Initialize commands
            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            LoadProducts();
        }

        // Command methods
        private void AddProduct()
        {
           

            bool success = _productBLL.CreateProduct(_productId,_productName,_price);

            if (success)
            {
                MessageBox.Show("Product created successfully");
                Products.Clear();
                LoadProducts(); // Refresh the list of products
            }
            else
            {
                MessageBox.Show("Error occurred while creating the product");
            }


            // Clear the text boxes after adding[

            ProductId = 0;
            ProductName = string.Empty;
            Price = 0;
            // Set default value
                       // Clear other properties here
        }

        private void EditProduct()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

           

            bool success = _productBLL.UpdateProduct(_productName,_price);

            if (success)
            {
                MessageBox.Show("Product edited successfully");
                LoadProducts(); // Refresh the list of products
            }
            else
            {
                MessageBox.Show("Error occurred while editing the product");
            }
        }

        private void DeleteProduct()
        {
            if(SelectedProduct == null)
    {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            bool success = _productBLL.DeleteProduct(SelectedProduct.Id);

            if (success)
            {
                MessageBox.Show("Product deleted successfully");
                Products.Clear();
                Products.Remove(SelectedProduct);
            }
            else
            {
                MessageBox.Show("Error occurred while deleting the product");
            }
        }

        private void LoadProducts()
        {
            // Implement the code to fetch products from your data access layer
            List<Product> products = _productBLL.GetAllProducts();

            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}

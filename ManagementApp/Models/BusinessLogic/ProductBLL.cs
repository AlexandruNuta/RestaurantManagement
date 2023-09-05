using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;

namespace ManagementApp.Models.BusinessLogic
{
    public class ProductBLL
    {
        public ProductDA productDA = new ProductDA();

        public ProductBLL()
        {
            productDA = new ProductDA();
        }

        public List<Product> GetAllProducts()
        {
            return productDA.GetProducts();
        }

        public Product GetProductById(string name)
        {
            return productDA.GetProductByName(name);
        }

        public bool UpdateProduct(string name, decimal price)
        {
            // You can add business logic/validation here if needed
            return productDA.UpdateProductByName(name, price);
        }

        public bool CreateProduct(int id,string name, decimal price)
        {
            // You can add business logic/validation here if needed
            return productDA.CreateProduct(id,name, price);
        }

        public bool DeleteProduct(int id)
        {
            // You can add business logic/validation here if needed
            return productDA.DeleteProduct(id);
        }

    }
}

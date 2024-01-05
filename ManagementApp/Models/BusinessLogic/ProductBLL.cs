using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.BusinessLogic
{
    public class ProductBLL
    {

        public IProductDA _productDA;

        public ProductBLL(IProductDAFactory productDAFactory)
        {
            _productDA = productDAFactory.Create();

        }

        public List<Product> GetAllProducts()
        {
            return _productDA.GetProducts();
        }

        public Product GetProductByName(string name)
        {
            return _productDA.GetProductByName(name);
        }

        public bool UpdateProduct(string name, decimal price)
        {

            return _productDA.UpdateProductByName(name, price);
        }

        public bool CreateProduct(int id,string name, decimal price)
        {

            return _productDA.CreateProduct(id,name, price);
        }

        public bool DeleteProduct(int id)
        {
            return _productDA.DeleteProduct(id);
        }

    }
}

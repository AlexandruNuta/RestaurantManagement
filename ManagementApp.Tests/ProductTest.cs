using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Tests
{
    [TestClass]
    public class ProductBLLTests
    {
        private Mock<IProductDAFactory> _mockProductDAFactory;
        private ProductBLL _productBLL;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockProductDA = new Mock<IProductDA>();
            _mockProductDAFactory = new Mock<IProductDAFactory>();
            _mockProductDAFactory.Setup(f => f.Create()).Returns(mockProductDA.Object);
            _productBLL = new ProductBLL(_mockProductDAFactory.Object);
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {

            var expectedProducts = new List<Product> { new Product(), new Product() };
            _mockProductDAFactory.Setup(f => f.Create().GetProducts()).Returns(expectedProducts);

            var result = _productBLL.GetAllProducts();

            Assert.AreEqual(expectedProducts, result);
        }


    }
}

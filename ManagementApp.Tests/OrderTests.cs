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
    public class OrderBLLTests
    {
        private Mock<IOrderDAFactory> _mockOrderDAFactory;
        private OrderBLL _orderBLL;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockOrderDA = new Mock<IOrderDA>();
            _mockOrderDAFactory = new Mock<IOrderDAFactory>();
            _mockOrderDAFactory.Setup(p => p.Create()).Returns(mockOrderDA.Object);
            _orderBLL = new OrderBLL(_mockOrderDAFactory.Object);
        }

        [TestMethod]
        public void GetAllOrders_ReturnsAllOrders()
        {
            var expectedOrders = new List<Order> { new Order(), new Order() };
            _mockOrderDAFactory.Setup(p => p.Create().GetAllOrders()).Returns(expectedOrders);

            var result = _orderBLL.GetAllOrders();

            Assert.AreEqual(expectedOrders, result);
        }

    }
}

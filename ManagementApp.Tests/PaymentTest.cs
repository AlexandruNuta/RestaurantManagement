using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.Entity.FactoriInterfaces;
using static ManagementApp.Models.DataAccess.OrderDAFactory;
using Moq;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;

namespace ManagementApp.Tests
{
    [TestClass]
    public class PaymentTest
    {
        private Mock<IPaymentDAFactory> _mockPaymentDAFactory;
        private PaymentBLL _paymentBLL;

        [TestInitialize]

        public void TestInitialize()
        {
            var mockPaymentDA = new Mock<IPaymentDA>();
            _mockPaymentDAFactory = new Mock<IPaymentDAFactory>();
            _mockPaymentDAFactory.Setup(p => p.Create()).Returns(mockPaymentDA.Object);
            _paymentBLL = new PaymentBLL(_mockPaymentDAFactory.Object);
        }

        [TestMethod]
        public void GetAllPayments_ReturnsAllPayments()
        {
            var expectedPayment = new Payment();
            _mockPaymentDAFactory.Setup(p => p.Create().ReadPayment(It.IsAny<int>())).Returns(expectedPayment);

            var result = _paymentBLL.GetPaymentById(1);

            Assert.AreEqual(expectedPayment, result);
        }
    }
}

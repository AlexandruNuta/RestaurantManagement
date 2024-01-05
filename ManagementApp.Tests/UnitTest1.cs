using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagementApp.Models.Entity;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.BusinessLogic;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void Order_SetAndGetProperties_ShouldWorkCorrectly()
        {

            var order = new Order();

            order.Id = 1;
            order.TotalAmount = 50.0m;
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.TableId = 3;

            Assert.AreEqual(1, order.Id);
            Assert.AreEqual(50.0m, order.TotalAmount);
            Assert.AreEqual("Pending", order.Status);
            Assert.AreEqual(3, order.TableId);
        }
        [TestMethod]
        public void Product_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var product = new Product();

            product.Id = 1;
            product.Name = "mere";
            product.Price = 10;
           

            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("mere", product.Name);
            Assert.AreEqual(10, product.Price);
           
        }

        [TestMethod]
        public void Payment_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var payment = new Payment();

            payment.PaymentId = 1;
            payment.OrderId = 5;
            payment.Amount = 30.0m;
            payment.PaymentDate = DateTime.Now;

            Assert.AreEqual(1, payment.PaymentId);
            Assert.AreEqual(5, payment.OrderId);
            Assert.AreEqual(30.0m, payment.Amount);
        }

        [TestMethod]
        public void Table_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var table = new Table();

            table.Id = 1;
            table.Number = 10;
            table.AvailableSeats = 8;
            table.OccupiedSeats = 2;
            table.WaiterId = 7;

            Assert.AreEqual(1, table.Id);
            Assert.AreEqual(10, table.Number);
            Assert.AreEqual(8, table.AvailableSeats);
            Assert.AreEqual(2, table.OccupiedSeats);
            Assert.AreEqual(7, table.WaiterId);
        }
        [TestMethod]
        public void Employee_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var employee = new Employee();

            employee.Id = 1;
            employee.Name = "Ion";
            employee.Position = "Administrator";

            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Ion", employee.Name);
            Assert.AreEqual("Administrator", employee.Position);
        }
        [TestMethod]
        public void OrderProduct_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var orderProduct = new OrderProduct();

            orderProduct.Id = 1;
            orderProduct.ProductId = 2;
            orderProduct.Quantity = 3;

            Assert.AreEqual(1, orderProduct.Id);
            Assert.AreEqual(2, orderProduct.ProductId);
            Assert.AreEqual(3, orderProduct.Quantity);
        }

        [TestMethod]
        public void Order_SetInvalidTotalAmount_ShouldThrowException()
        {
            var order = new Order();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => order.TotalAmount = -50.0m);
        }

        [TestMethod]
        public void Payment_SetInvalidAmount_ShouldThrowException()
        {

            var payment = new Payment();


            Assert.ThrowsException<ArgumentOutOfRangeException>(() => payment.Amount = -30.0m);
        }
    }
}

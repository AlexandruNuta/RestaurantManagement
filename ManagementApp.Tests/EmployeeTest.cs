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
using static ManagementApp.Models.DataAccess.EmployeeDAFactory;

namespace ManagementApp.Tests
{
    [TestClass]
    public class EmployeeBLLTests
    {
        private Mock<IEmployeeFactory> _mockEmployeeDAFactory;
        private EmployeeBLL _employeeBLL;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockEmployeeDA = new Mock<IEmployeeDA>();
            _mockEmployeeDAFactory = new Mock<IEmployeeFactory>();
            _mockEmployeeDAFactory.Setup(p => p.Create()).Returns(mockEmployeeDA.Object);
            _employeeBLL = new EmployeeBLL(_mockEmployeeDAFactory.Object);
        }

        [TestMethod]
        public void GetAllOrders_ReturnsAllOrders()
        {
            var expectedEmployees = new List<Employee> { new Employee(), new Employee() };
            _mockEmployeeDAFactory.Setup(p => p.Create().GetEmployees()).Returns(expectedEmployees);

            var result = _employeeBLL.GetEmployees();

            Assert.AreEqual(expectedEmployees, result);
        }
    }
}

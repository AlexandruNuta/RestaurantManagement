using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.DataAccess.TableDAFactory;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Tests
{

    [TestClass]
    public class TableBLLTests
    {
        private Mock<ITableDAFactory> _mockTableDAFactory;
        private TableBLL _tableBLL;

        [TestInitialize]
        public void TestInitialize()
        {
            var _mockTableDA = new Mock<ITableDA>();
            _mockTableDAFactory = new Mock<ITableDAFactory>();
            _mockTableDAFactory.Setup(p => p.Create()).Returns(_mockTableDA.Object);
            _tableBLL = new TableBLL(_mockTableDAFactory.Object);
        }

        [TestMethod]
        public void GetAllTables_ReturnsAllTables()
        {
            var expectedTables = new List<Table> { new Table(), new Table() };
            _mockTableDAFactory.Setup(p => p.Create().GetAllTables()).Returns(expectedTables);

            var result = _tableBLL.GetAllTables();

            Assert.AreEqual(expectedTables, result);
        }

    }


}

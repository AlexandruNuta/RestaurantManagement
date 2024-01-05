using ManagementApp.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.DataAccess.TableDAFactory;

namespace ManagementApp.Models.Entity
{
    public class FactoriInterfaces
    {
        public interface IOrderDAFactory
        {
            IOrderDA Create();
        }

        public interface IEmployeeFactory
        {
            IEmployeeDA Create();
        }

        public interface IProductDAFactory
        {
            IProductDA Create();
        }
        public interface ITableDAFactory
        {
            ITableDA Create();
        }
        public interface IPaymentDAFactory
        {
            IPaymentDA Create();
        }

    }
    
}

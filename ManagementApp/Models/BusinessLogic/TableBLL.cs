using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.Models.Entity;
using ManagementApp.Models.DataAccess;
using static ManagementApp.Models.Entity.FactoriInterfaces;
using static ManagementApp.Models.DataAccess.TableDAFactory;

namespace ManagementApp.Models.BusinessLogic
{
    public class TableBLL
    {
 
        private ITableDA _tableDA;

        public TableBLL(ITableDAFactory tableDAFactory)
        {
            _tableDA = tableDAFactory.Create();
        }

        public List<Table> GetAllTables()
        {
            return _tableDA.GetAllTables();
        }

        public Table GetTableByNumber(int number)
        {
            return _tableDA.GetTable(number);
        }

        public bool UpdateTable(int id, int number, int availableSeats, int occupiedSeats,int waiterId)
        {
            
              return _tableDA.UpdateTable(id, number, availableSeats, occupiedSeats,waiterId);
        }

        public bool CreateTable(int id, int number, int availableSeats, int occupiedSeats,int waiterId)
        {

            return _tableDA.CreateTable(id, number, availableSeats, occupiedSeats, waiterId);
        }

        public bool DeleteTable(int id)
        {

            return _tableDA.DeleteTable(id);
        }

        public bool UpdateTableById(int id,int waiterId)
        {
            return _tableDA.UpdateTableById(id, waiterId);
        }

    }
}

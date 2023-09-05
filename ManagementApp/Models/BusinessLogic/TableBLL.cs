using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApp.Models.Entity;
using ManagementApp.Models.DataAccess;

namespace ManagementApp.Models.BusinessLogic
{
    public class TableBLL
    {
        TableDA tableDA = new TableDA();

        public TableBLL()
        {
            tableDA = new TableDA();
        }

        public List<Table> GetAllTables()
        {
            return tableDA.GetAllTables();
        }

        public Table GetTableByNumber(int number)
        {
            return tableDA.GetTable(number);
        }

        public bool UpdateTable(int id, int number, int availableSeats, int occupiedSeats,int waiterId)
        {
            
              return tableDA.UpdateTable(id, number, availableSeats, occupiedSeats,waiterId);
        }

        public bool CreateTable(int id, int number, int availableSeats, int occupiedSeats,int waiterId)
        {
            // You can add business logic/validation here if needed
            return tableDA.CreateTable(id, number, availableSeats, occupiedSeats, waiterId);
        }

        public bool DeleteTable(int id)
        {
            // You can add business logic/validation here if needed
            return tableDA.DeleteTable(id);
        }

        public bool UpdateTableById(int id,int waiterId)
        {
            return tableDA.UpdateTableById(id, waiterId);
        }

    }
}

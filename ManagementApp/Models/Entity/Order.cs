using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;

namespace ManagementApp.Models.Entity
{
    public class Order : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private decimal totalAmount;
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (totalAmount != value)
                {
                    totalAmount = value;
                    OnPropertyChanged("TotalAmount");
                }
            }
        }

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                if (orderDate != value)
                {
                    orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        private int tableId;
        public int TableId
        {
            get { return tableId; }
            set
            {
                if (tableId != value)
                {
                    tableId = value;
                    OnPropertyChanged("TableId");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class OrderWithProducts : Order
    {
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}


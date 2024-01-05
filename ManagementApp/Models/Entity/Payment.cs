using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Models.Entity
{
    public class Payment : INotifyPropertyChanged
    {
        private int paymentId;
        public int PaymentId
        {
            get { return paymentId; }
            set
            {
                if (paymentId != value)
                {
                    paymentId = value;
                    OnPropertyChanged("PaymentId");
                }
            }
        }

        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set
            {
                if (orderId != value)
                {
                    orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount cannot be negative.");
                }

                amount = value;
            }
        }

        private DateTime paymentDate;
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set
            {
                if (paymentDate != value)
                {
                    paymentDate = value;
                    OnPropertyChanged("PaymentDate");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

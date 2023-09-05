using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ManagementApp.Models.Entity
{
    public class Table : INotifyPropertyChanged
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

        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        private int availableSeats;
        public int AvailableSeats
        {
            get { return availableSeats; }
            set
            {
                if (availableSeats != value)
                {
                    availableSeats = value;
                    OnPropertyChanged("AvailableSeats");
                }
            }
        }

        private int occupiedSeats;
        public int OccupiedSeats
        {
            get { return occupiedSeats; }
            set
            {
                if (occupiedSeats != value)
                {
                    occupiedSeats = value;
                    OnPropertyChanged("OccupiedSeats");
                }
            }
        }

        private int waiterId;
        public int WaiterId
        {
            get { return waiterId; }
            set
            {
                if (waiterId != value)
                {
                    waiterId = value;
                    OnPropertyChanged("WaiterId");
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


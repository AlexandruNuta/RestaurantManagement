using ManagementApp.Commands;
using ManagementApp.Models.BusinessLogic;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ManagementApp.ViewModels
{
    internal class TableViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Table> Tables { get; set; } = new ObservableCollection<Table>();
        public Table SelectedTable { get; set; }

        public void SelectTable(Table table)
        {
            SelectedTable = table;
            OnPropertyChanged(nameof(SelectedTable));
        }

        public TableBLL _tableBLL = new TableBLL();

        private int _tableId;
        public int TableId
        {
            get { return _tableId; }
            set
            {
                _tableId = value;
                OnPropertyChanged(nameof(TableId));
            }
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private int _availableSeats;
        public int AvailableSeats
        {
            get { return _availableSeats; }
            set
            {
                _availableSeats = value;
                OnPropertyChanged(nameof(AvailableSeats));
            }
        }

        private int _occupiedSeats;
        public int OccupiedSeats
        {
            get { return _occupiedSeats; }
            set
            {
                _occupiedSeats = value;
                OnPropertyChanged(nameof(OccupiedSeats));
            }
        }

        private int _waiterId;
        public int WaiterId
        {
            get { return _waiterId; }
            set
            {
                _waiterId = value;
                OnPropertyChanged(nameof(WaiterId));
            }
        }

        // Commands
        public ICommand AddTableCommand { get; }
        public ICommand EditTableCommand { get; }
        public ICommand DeleteTableCommand { get; }

        public ICommand LinkWaiterTableCommand { get; }

        public TableViewModel()
        {
            // Initialize commands
            AddTableCommand = new RelayCommand(AddTable);
            EditTableCommand = new RelayCommand(EditTable);
            DeleteTableCommand = new RelayCommand(DeleteTable);
            LinkWaiterTableCommand = new RelayCommand(LinkTableCommand);
            LoadTables();
        }

        // Command methods
        private void AddTable()
        {
            bool success = _tableBLL.CreateTable(_tableId, _number, _availableSeats, _occupiedSeats, _waiterId);

            if (success)
            {
                MessageBox.Show("Table created successfully");
                Tables.Clear();
                LoadTables(); // Refresh the list of tables
            }
            else
            {
                MessageBox.Show("Error occurred while creating the table");
            }

            // Clear the text boxes after adding
            TableId = 0;
            Number = 0;
            AvailableSeats = 0;
            OccupiedSeats = 0;
            WaiterId = 0;
        }

        private void EditTable()
        {
            if (SelectedTable == null)
            {
                MessageBox.Show("Please select a table to edit.");
                return;
            }

            bool success = _tableBLL.UpdateTable(_tableId,_number, _availableSeats, _occupiedSeats, _waiterId);

            if (success)
            {
                MessageBox.Show("Table edited successfully");
                Tables.Clear();
                LoadTables(); // Refresh the list of tables
            }
            else
            {
                MessageBox.Show("Error occurred while editing the table");
            }
        }

        private void DeleteTable()
        {
            if (SelectedTable == null)
            {
                MessageBox.Show("Please select a table to delete.");
                return;
            }

            bool success = _tableBLL.DeleteTable(SelectedTable.Id);

            if (success)
            {
                MessageBox.Show("Table deleted successfully");
                Tables.Remove(SelectedTable);
                Tables.Clear();
                LoadTables();
            }
            else
            {
                MessageBox.Show("Error occurred while deleting the table");
            }
        }
        private void LinkTableCommand()
        {
            if (SelectedTable == null)
            {
                MessageBox.Show("Please select a table to delete.");
                return;
            }

            bool success = _tableBLL.UpdateTableById(SelectedTable.Id,_waiterId);

            if (success)
            {
                MessageBox.Show("Table linked successfully");
                Tables.Remove(SelectedTable);
                Tables.Clear();
                LoadTables();
            }
            else
            {
                MessageBox.Show("Error occurred while deleting the table");
            }
        }
        private void LoadTables()
        {
            // Implement the code to fetch tables from your data access layer
            List<Table> tables = _tableBLL.GetAllTables();

            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
    }
}

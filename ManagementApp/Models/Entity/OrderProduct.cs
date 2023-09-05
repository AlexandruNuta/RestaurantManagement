using ManagementApp.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApp.Models.Entity
{
    public class OrderProduct : INotifyPropertyChanged
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

        private int productId;
        public int ProductId
        {
            get { return productId; }
            set
            {
                if (productId != value)
                {
                    productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        public List<OrderProduct> GetProductsForOrder(int orderId)
        {
            List<OrderProduct> orderProducts = new List<OrderProduct>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetProductsForOrder]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderProduct orderProduct = new OrderProduct
                            {
                                ProductId = (int)reader["ProductId"],
                                Quantity = (int)reader["Quantity"]
                            };

                            orderProducts.Add(orderProduct);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return orderProducts;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

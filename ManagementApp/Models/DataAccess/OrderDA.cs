using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementApp.Models.Entity;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.DataAccess
{
    public class OrderDAFactory: IOrderDAFactory
    {
        public IOrderDA Create()
        {
            return new OrderDA();
        }
    }
    public interface IOrderDA
    {
        bool CreateOrder(int id, decimal totalAmount, DateTime orderDate, string status, int tableId);
        OrderWithProducts GetOrder(int id);
        List<Order> GetAllOrders();
        bool DeleteOrder(int orderid);
        bool AddProductToOrder(int orderId, int productId, int quantity);
        List<OrderProduct> GetProductsForOrder(int orderId);
        decimal GetProductPrice(int productId);

    }
    public class OrderDA:IOrderDA
    {
        public bool CreateOrder(int id, decimal totalAmount, DateTime orderDate, string status, int tableId)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[CreateOrder]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = totalAmount;
                cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderDate;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status;
                cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = tableId;

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public OrderWithProducts GetOrder(int orderId)
        {
            OrderWithProducts order = null;

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetOrderById]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new OrderWithProducts
                            {
                                Id = (int)reader["Id"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                OrderDate = (DateTime)reader["OrderDate"],
                                Status = (string)reader["Status"],
                                TableId = (int)reader["TableId"]
                            };
                        }
                    }

                    if (order != null)
                    {

                        cmd = new SqlCommand("[dbo].[GetProductsForOrder]", connection);
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
                                order.OrderProducts.Add(orderProduct);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }

                return order;
            }
        }
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllOrders]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = (int)reader["OrderId"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                OrderDate = (DateTime)reader["OrderDate"],
                                Status = (string)reader["Status"],
                                TableId = (int)reader["TableId"]
                            };

                            orders.Add(order);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return orders;
        }
        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    SqlCommand deleteOrderProductsCmd = new SqlCommand("[dbo].[DeleteOrderProductsByOrderId]", connection, transaction);
                    deleteOrderProductsCmd.CommandType = CommandType.StoredProcedure;
                    deleteOrderProductsCmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

                    int rowsAffected = deleteOrderProductsCmd.ExecuteNonQuery();

                    SqlCommand deleteOrderCmd = new SqlCommand("[dbo].[DeleteOrder]", connection, transaction);
                    deleteOrderCmd.CommandType = CommandType.StoredProcedure;
                    deleteOrderCmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;

                    rowsAffected += deleteOrderCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }
        public bool AddProductToOrder(int orderId, int productId, int quantity)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("[dbo].[AddProductToOrder]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
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
        public decimal GetProductPrice(int productId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Price FROM Products WHERE ProductId = @ProductId", connection);
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (decimal)result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return 0;
        }

    }
}

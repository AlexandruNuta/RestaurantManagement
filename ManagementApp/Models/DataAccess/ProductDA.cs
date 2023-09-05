using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApp.Models.DataAccess
{
    public  class ProductDA
    {
        public Product GetProductByName(string productName)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;
            SqlDataReader reader = null;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[GetProductByName]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@productName", SqlDbType.NVarChar).Value = productName;

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Product foundProduct = new Product
                    {
                        Id = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["ProductName"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                        // Add other properties as needed
                    };
                    return foundProduct;
                }
                else
                {
                    return null; // Product not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return null;
            }
            finally
            {
                reader?.Close();
                sqlConnection.Close();
            }
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;
            SqlDataReader reader = null;
            List<Product> products = new List<Product>();

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[GetProducts]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                        // Add other properties as needed
                    };
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return null;
            }
            finally
            {
                reader?.Close();
                sqlConnection.Close();
            }
        }
        public bool DeleteProduct(int productId)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[DeleteProduct]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

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
        public bool UpdateProductByName(string productName, decimal newPrice)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[UpdateProductByName]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@productName", SqlDbType.NVarChar).Value = productName;
                cmd.Parameters.Add("@newPrice", SqlDbType.Decimal).Value = newPrice;

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
        public bool CreateProduct(int id,string name,decimal price)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[CreateProduct]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                // Add other parameters as needed

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

    }
}

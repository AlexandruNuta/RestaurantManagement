using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementApp.Models.Entity;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.DataAccess
{
    public class TableDAFactory : ITableDAFactory
    {
        public ITableDA Create()
        {
            return new TableDA();
        }
        public interface ITableDA
        {
            List<Table> GetAllTables();
            Table GetTable(int number);
            bool DeleteTable(int tableId);
            bool CreateTable(int id, int number, int availableSeats, int occupiedSeats, int waiterId);
            bool UpdateTable(int id, int number, int availableSeats, int occupiedSeats, int waiterId);
            bool UpdateTableById(int id, int waiterId);
        }
        public class TableDA : ITableDA
        {
            public List<Table> GetAllTables()
            {
                List<Table> tables = new List<Table>();

                SqlConnection sqlConnection = DatabaseManager.Connection;
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllTables]", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Table table = new Table
                        {
                            Id = Convert.ToInt32(reader["TableId"]),
                            Number = Convert.ToInt32(reader["Number"]),
                            AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]),
                            OccupiedSeats = Convert.ToInt32(reader["OccupiedSeats"]),
                            WaiterId = Convert.ToInt32(reader["WaiterId"])
                        };

                        tables.Add(table);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                finally
                {
                    reader?.Close();
                    sqlConnection.Close();
                }

                return tables;
            }

            public Table GetTable(int number)
            {
                Table table = null;

                SqlConnection sqlConnection = DatabaseManager.Connection;
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetTableByNumber]", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Number", SqlDbType.Int).Value = number;

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        table = new Table
                        {
                            Id = Convert.ToInt32(reader["TableId"]),
                            Number = Convert.ToInt32(reader["TableNumber"]),
                            AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]),
                            OccupiedSeats = Convert.ToInt32(reader["OccupiedSeats"]),
                            WaiterId = Convert.ToInt32(reader["WaiterId"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                finally
                {
                    reader?.Close();
                    sqlConnection.Close();
                }

                return table;
            }
            public bool DeleteTable(int tableId)
            {
                SqlConnection sqlConnection = DatabaseManager.Connection;

                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteRestTable]", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
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
            public bool CreateTable(int id, int number, int availableSeats, int occupiedSeats, int waiterId)
            {
                SqlConnection sqlConnection = DatabaseManager.Connection;

                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[CreateRestTable]", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Number", SqlDbType.Int).Value = number;
                    cmd.Parameters.Add("@AvailableSeats", SqlDbType.Int).Value = availableSeats;
                    cmd.Parameters.Add("@OccupiedSeats", SqlDbType.Int).Value = occupiedSeats;
                    cmd.Parameters.Add("@WaiterId", SqlDbType.Int).Value = waiterId;

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

            public bool UpdateTable(int tableId, int number, int availableSeats, int occupiedSeats, int waiterId)
            {
                SqlConnection sqlConnection = DatabaseManager.Connection;

                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateTable]", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = tableId;
                    cmd.Parameters.Add("@Number", SqlDbType.Int).Value = number;
                    cmd.Parameters.Add("@AvailableSeats", SqlDbType.Int).Value = availableSeats;
                    cmd.Parameters.Add("@OccupiedSeats", SqlDbType.Int).Value = occupiedSeats;
                    cmd.Parameters.Add("@WaiterId", SqlDbType.Int).Value = waiterId;

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
            public bool UpdateTableById(int tableId, int waiterId)
            {
                using (SqlConnection connection = DatabaseManager.Connection)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("[dbo].[UpdateTableWaiterById]", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = tableId;
                        cmd.Parameters.Add("@WaiterId", SqlDbType.Int).Value = waiterId;

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

        }
    }
}

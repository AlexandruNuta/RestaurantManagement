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
    public class PaymentDAFactory: IPaymentDAFactory
    {
        public IPaymentDA Create()
        {
            return new PaymentDA();
        }
    }
    public interface IPaymentDA
    {
        bool CreatePayment(int orderId, decimal amount, DateTime paymentDate);
        Payment ReadPayment(int paymentId);
        bool UpdatePayment(int paymentId, int orderId, decimal amount, DateTime paymentDate);
        bool DeletePayment(int paymentId);
    }
    public class PaymentDA:IPaymentDA
    {
        public bool CreatePayment(int orderId, decimal amount, DateTime paymentDate)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[CreatePayments]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                cmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = paymentDate;

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


        public Payment ReadPayment(int paymentId)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[ReadPayment]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = paymentId;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Payment
                        {
                            PaymentId = Convert.ToInt32(reader["PaymentId"]),
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"])
                        };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UpdatePayment(int paymentId, int orderId, decimal amount, DateTime paymentDate)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[UpdatePayment]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = paymentId;
                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderId;
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                cmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = paymentDate;

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

        public bool DeletePayment(int paymentId)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[DeletePayment]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = paymentId;

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

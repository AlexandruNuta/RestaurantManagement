using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.DataAccess
{
    public class EmployeeDAFactory: IEmployeeFactory
    {
        public IEmployeeDA Create()
        {
            return new EmployeeDAL();
        }
    }
    public interface IEmployeeDA
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeByUsername(string username);
        Employee GetEmployee(int employeeId);
        bool CreateEmployee(int id, string name, string position);
        bool DeleteEmployee(int employeeId);
        bool UpdateEmployeeName(int employeeId, string newName);
    }
    public class EmployeeDAL:IEmployeeDA
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllEmployees]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Id = Convert.ToInt32(reader["EmployeeId"]),
                                Name = reader["Name"].ToString(),
                                Position = reader["Position"].ToString()
                            };
                            employees.Add(employee);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return employees;
        }
        public Employee GetEmployeeByUsername(string username)
        {
            SqlConnection sqlConnection = DatabaseManager.Connection;
            SqlDataReader reader = null;

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[GetEmployeeByUsername]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Employee foundEmployee = new Employee
                    {
                        Id = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Position = reader["Position"].ToString()
                    };
                    return foundEmployee;
                }
                else
                {
                    return null;
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



        public Employee GetEmployee(int employeeId)
        {
            Employee employee = null;

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employee
                            {
                                Id = (int)reader["EmployeeId"],
                                Name = (string)reader["Name"],
                                Position = (string)reader["Position"]
                            };
                        }
                    }
                }
            }

            return employee;
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteEmployee]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;

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
        public bool UpdateEmployeeName(int employeeId, string newName)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateEmployeeName]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = newName;

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
                    connection.Close();
                }
            }
        }

        public bool CreateEmployee(int id,string name,string position)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("[dbo].[CreateEmployee]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.NVarChar).Value = id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = position;

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
                    connection.Close();
                }
            }
        }


    }
}


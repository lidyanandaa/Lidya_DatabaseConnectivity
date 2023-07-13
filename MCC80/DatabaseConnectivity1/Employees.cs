using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity1
{
    public class Employees
    {
        private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";

        //penamaan private harus ada _ nya didepannya
        private static SqlConnection _connection;

        //------------------------------------EMPLOYEES----------------------------------------------
        //GET ALL EMPLOYEES
        public static void GetEmployees()
        {
            var _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM EMPLOYEES";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("First Name: " + reader.GetString(1));
                        Console.WriteLine("Last Name: " + reader.GetString(2));
                        Console.WriteLine("Email: " + reader.GetString(3));
                        Console.WriteLine("Phone Number: " + reader.GetString(4));
                        Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                        Console.WriteLine("Salary: " + reader.GetInt32(6));
                        Console.WriteLine("Commission PCT: " + reader.GetDecimal(7));
                        Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                        Console.WriteLine("Job Id: " + reader.GetString(9));
                        Console.WriteLine("Department Id: " + reader.GetInt32(10));
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error connecting to the database. " + x.Message);
            }
        }

        // INSERT EMPLOYEES
        public static void InsertEmployees(int id, string first_name, string last_name, string email, string phone_number, DateTime hire_date, int salary, decimal commission_pct, int manager_id, string job_id, int department_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO employees(id, first_name, last_name, email, phone_number, hire_date, salary, " +
           "commission_pct, manager_id, job_id, department_id)" +
           "VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, " +
           "@job_id, @department_id)";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@first_name", first_name);
            sqlCommand.Parameters.AddWithValue("@last_name", last_name);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone_number", phone_number);
            sqlCommand.Parameters.AddWithValue("@hire_date", hire_date);
            sqlCommand.Parameters.AddWithValue("@salary", salary);
            sqlCommand.Parameters.AddWithValue("@commission_pct", commission_pct);
            sqlCommand.Parameters.AddWithValue("@manager_id", manager_id);
            sqlCommand.Parameters.AddWithValue("@job_id", job_id);
            sqlCommand.Parameters.AddWithValue("@department_id", department_id);

            try
            {
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert succes");
                }
                else
                {
                    Console.WriteLine("Insert failed");
                }
                transaction.Commit();
                _connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error! " + ex.Message);
            }
        }

        //UPDATE EMPLOYEES
        public static void UpdateEmployees(int id, string first_name, string last_name, string email, string phone_number, DateTime hire_date, int salary, decimal commission_pct, int manager_id, string job_id, int department_id)
        {
            var _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "update employees set first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE id = @id";

            //Set paramaeter value
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@first_name", first_name);
            sqlCommand.Parameters.AddWithValue("@last_name", last_name);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@phone_number", phone_number);
            sqlCommand.Parameters.AddWithValue("@hire_date", hire_date);
            sqlCommand.Parameters.AddWithValue("@salary", salary);
            sqlCommand.Parameters.AddWithValue("@commission_pct", commission_pct);
            sqlCommand.Parameters.AddWithValue("@manager_id", manager_id);
            sqlCommand.Parameters.AddWithValue("@job_id", job_id);
            sqlCommand.Parameters.AddWithValue("@department_id", department_id);
            try
            {
                _connection.Open();
                int rowAffected = sqlCommand.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    Console.WriteLine("Employees updated succesfully.");
                }
                else
                {
                    Console.WriteLine("No employees found or no change made.");
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error connecting to the database. " + x.Message);
            }
        }


        //DELETE EMPLOYEES
        public static void DeleteEmployees(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM EMPLOYEES WHERE ID = @id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                // Declare parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete success.");
                }
                else
                {
                    Console.WriteLine("Delete failed.");
                }

                transaction.Commit();
                _connection.Close();
            }
            catch (Exception x)
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to the database. " + x.Message);
            }
        }

        //GET BY ID EMPLOYEES
        public static void GetEmployeesById(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM EMPLOYEES WHERE ID = @id";

            try
            {
                _connection.Open();

                // Declare parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("First Name: " + reader.GetString(1));
                        Console.WriteLine("Last Name: " + reader.GetString(2));
                        Console.WriteLine("Email: " + reader.GetString(3));
                        Console.WriteLine("Phone Number: " + reader.GetString(4));
                        Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                        Console.WriteLine("Salary: " + reader.GetInt32(6));
                        Console.WriteLine("Comission PCT: " + reader.GetDecimal(7));
                        Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                        Console.WriteLine("Job Id: " + reader.GetString(9));
                        Console.WriteLine("Department Id: " + reader.GetInt32(10));
                    }
                }
                else
                {
                    Console.WriteLine("No employees found with the given ID.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to the database.");
            }
        }
    }
}

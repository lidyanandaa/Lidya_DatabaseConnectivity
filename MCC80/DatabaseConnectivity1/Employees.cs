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
            sqlCommand.CommandText = "INSERT INTO EMPLOYEES (ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, SALARY, COMMISSION_PCT, MANAGER_ID, JOB_ID, DEPARTMENT_ID) VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

            _connection.Open();
            using SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                //mendeklarasikan parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFirstName = new SqlParameter();
                pFirstName.ParameterName = "@first_name";
                pFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
                pFirstName.Value = first_name;
                sqlCommand.Parameters.Add(pFirstName);

                SqlParameter pLastName = new SqlParameter();
                pLastName.ParameterName = "@last_name";
                pLastName.SqlDbType = System.Data.SqlDbType.Int;
                pLastName.Value = last_name;
                sqlCommand.Parameters.Add(pLastName);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Value = email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhoneNumber = new SqlParameter();
                pPhoneNumber.ParameterName = "@phone_number";
                pPhoneNumber.SqlDbType = System.Data.SqlDbType.VarChar;
                pPhoneNumber.Value = phone_number;
                sqlCommand.Parameters.Add(pPhoneNumber);

                SqlParameter pHireDate = new SqlParameter();
                pHireDate.ParameterName = "@hire_date";
                pHireDate.SqlDbType = System.Data.SqlDbType.Int;
                pHireDate.Value = hire_date;
                sqlCommand.Parameters.Add(pHireDate);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = System.Data.SqlDbType.VarChar;
                pSalary.Value = salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCommissionPct = new SqlParameter();
                pCommissionPct.ParameterName = "@commission_pct";
                pCommissionPct.SqlDbType = System.Data.SqlDbType.Int;
                pCommissionPct.Value = commission_pct;
                sqlCommand.Parameters.Add(pCommissionPct);

                SqlParameter pManagerId = new SqlParameter();
                pManagerId.ParameterName = "@manager_id";
                pManagerId.SqlDbType = SqlDbType.VarChar;
                pManagerId.Value = manager_id;
                sqlCommand.Parameters.Add(pManagerId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@job_id";
                pJobId.SqlDbType = System.Data.SqlDbType.VarChar;
                pJobId.Value = job_id;
                sqlCommand.Parameters.Add(pJobId);

                SqlParameter pDepartmentId = new SqlParameter();
                pDepartmentId.ParameterName = "@department_id";
                pDepartmentId.SqlDbType = System.Data.SqlDbType.Int;
                pDepartmentId.Value = department_id;
                sqlCommand.Parameters.Add(pDepartmentId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert success.");
                }
                else
                {
                    Console.WriteLine("Insert failed.");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DatabaseConnectivity1
{
    public class Histories
    {
        private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";

        //penamaan private harus ada _ nya didepannya
        private static SqlConnection _connection;

        //------------------------------------HISTORIES----------------------------------------------
        //GET ALL HISTORIES
        public static void GetHistories()
        {
            var _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM HISTORIES";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                        Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                        Console.WriteLine("End Date: " + reader.GetDateTime(2));
                        Console.WriteLine("Department Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job Id: " + reader.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("No histories found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database. " + ex.Message);
            }
        }

        // INSERT HISTORIES
        public static void InsertHistories(DateTime start_date, int employee_id, DateTime end_date, int departement_id, string job_id)
        {
            _connection = new SqlConnection(_connectionString);

            using SqlConnection connection = new SqlConnection(_connectionString);
            string query = "insert into histories (start_date, employee_id, end_date, departement_id, job_id) values (@StartDate, @EmployeeId, @EndDate, @DepartmentId, @JobId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", start_date);
                command.Parameters.AddWithValue("@EmployeeId", employee_id);
                command.Parameters.AddWithValue("@EndDate", end_date);
                command.Parameters.AddWithValue("@DepartmentId", departement_id);
                command.Parameters.AddWithValue("@JobId", job_id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Insert success.");
                    }
                    else
                    {
                        Console.WriteLine("Insert failed.");
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error: " + x.Message);
                }
            }

            //UPDATE HISTORIES
            //public static void UpdateHistories(DateTime start_date, int employee_id, DateTime end_date, int departement_id, string job_id)
            {
                var _connection = new SqlConnection(_connectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _connection;
                sqlCommand.CommandText = "update histories set start_date = @start_date, end_date = @end_date, departement_id = @departement_id, job_id = @job_id WHERE employee_id = @employee_id";

                //Set paramaeter value
                sqlCommand.Parameters.AddWithValue("@start_date", start_date);
                sqlCommand.Parameters.AddWithValue("@employee_id", employee_id);
                sqlCommand.Parameters.AddWithValue("@end_date", end_date);
                sqlCommand.Parameters.AddWithValue("@departement_id", departement_id);
                sqlCommand.Parameters.AddWithValue("@job_id", job_id);
                try
                {
                    _connection.Open();
                    int rowAffected = sqlCommand.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("Histories updated succesfully.");
                    }
                    else
                    {
                        Console.WriteLine("No hitories found or no change made.");
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error connecting to the database. " + x.Message);
                }
            }


            //DELETE HISTORIES
            //public static void DeleteHistories(DateTime start_date)
            {
                _connection = new SqlConnection(_connectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _connection;
                sqlCommand.CommandText = "DELETE FROM histories WHERE start_date = @start_date";

                _connection.Open();
                SqlTransaction transaction = _connection.BeginTransaction();
                sqlCommand.Transaction = transaction;

                try
                {
                    // Declare parameter
                    SqlParameter pStartDate = new SqlParameter();
                    pStartDate.ParameterName = "@start_date";
                    pStartDate.SqlDbType = System.Data.SqlDbType.DateTime;
                    pStartDate.Value = start_date;
                    sqlCommand.Parameters.Add(pStartDate);

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
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Error connecting to the database.");
                }
            }

            //GET BY ID HISTORIES
            //public static void GetHistoriesById(DateTime start_date)
            {
                _connection = new SqlConnection(_connectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _connection;
                sqlCommand.CommandText = "SELECT * FROM histories WHERE start_date = @start_date";
                sqlCommand.Parameters.AddWithValue("@start_date", start_date);

                try
                {
                    _connection.Open();
                    using SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                            Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                            Console.WriteLine("End Date: " + reader.GetDateTime(2));
                            Console.WriteLine("Department Id: " + reader.GetInt32(3));
                            Console.WriteLine("Job Id: " + reader.GetString(4));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No histories found with the given ID.");
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
}

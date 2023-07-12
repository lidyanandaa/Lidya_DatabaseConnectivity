using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity1
{
    public class Jobs
    {
        private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";

        //penamaan private harus ada _ nya didepannya
        private static SqlConnection _connection;
        //------------------------------------JOB-------------------------------------------------
        //GET ALL JOB
        public static void GetJobs()
        {
            var _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM JOBS";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Title: " + reader.GetString(1));
                        Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                        Console.WriteLine("Max Salary: " + reader.GetInt32(3));
                    }
                }
                else
                {
                    Console.WriteLine("No jobs found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database.");
            }
        }

        // INSERT JOB
        public static void InsertJobs(string id, string title, int min_salary, int max_salary)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO jobs (Id, Title, Min_Salary, Max_Salary) VALUES (@id, @title, @min, @max)";

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

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
                pTitle.Value = title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min";
                pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMinSalary.Value = min_salary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max";
                pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMaxSalary.Value = max_salary;
                sqlCommand.Parameters.Add(pMaxSalary);

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
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database.");
            }
        }

        //UPDATE JOBS
        public static void UpdateJobs(string id, string title, int min_salary, int max_salary)
        {
            var _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "update jobs set title = @title, min_salary = @min_salary, max_salary = @max_salary" +
                " WHERE id = @id";

            //Set paramaeter value
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@min_salary", min_salary);
            sqlCommand.Parameters.AddWithValue("@max_salary", max_salary);
            try
            {
                _connection.Open();
                int rowAffected = sqlCommand.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    Console.WriteLine("Job updated succesfully.");
                }
                else
                {
                    Console.WriteLine("No job found or no change made.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database. " + ex.Message);
            }
        }

        //DELETE JOBS
        public static void DeleteJobs(string id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM JOBS WHERE ID = @id";

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
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to the database.");
            }
        }

        //GET BY ID JOBS
        public static void GetJobsById(string id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM JOBS WHERE ID = @id";

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
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Title: " + reader.GetString(1));
                        Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                        Console.WriteLine("Max Salary: " + reader.GetInt32(3));
                    }
                }
                else
                {
                    Console.WriteLine("No jobs found with the given ID.");
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

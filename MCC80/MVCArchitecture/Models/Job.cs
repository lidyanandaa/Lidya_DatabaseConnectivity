using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Views;
using System.Net.Http.Headers;

namespace MVCArchitecture.Models
{
    public class Job
    {
        public string id { get; set; }
        public string title { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }

        //GET ALL JOB
        public List<Job> GetAll()
        {
            var connection = Connection.Get();

            var jobs = new List<Job>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM JOBS";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Job job = new Job();
                        job.id = reader.GetString(0);
                        job.title = reader.GetString(1);
                        job.min_salary = reader.GetInt32(2);
                        job.max_salary = reader.GetInt32(3);

                        jobs.Add(job);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return jobs;
            }
            catch
            {
                return new List<Job>();
            }
        }

        // INSERT JOB
        public int Insert(Job job)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO jobs (Id, Title, Min_Salary, Max_Salary) VALUES (@id, @title, @min, @max)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                //mendeklarasikan parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = job.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
                pTitle.Value = job.title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min";
                pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMinSalary.Value = job.min_salary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max";
                pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMaxSalary.Value = job.max_salary;
                sqlCommand.Parameters.Add(pMaxSalary);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result; // 0 gagal, >= 1 berhasil
            }
            catch
            {
                transaction.Rollback();
                return -1; // Kesalahan terjadi pada database
            }
        }

        //UPDATE JOBS
        public int Update(Job job)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "update jobs set title = @title, min_salary = @min_salary, max_salary = @max_salary WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = job.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
                pTitle.Value = job.title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min";
                pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMinSalary.Value = job.min_salary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max";
                pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
                pMaxSalary.Value = job.max_salary;
                sqlCommand.Parameters.Add(pMaxSalary);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result;

            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        //DELETE JOBS
        public int Delete(string id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM JOBS WHERE ID = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                // Declare parameter
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

                transaction.Commit();
                connection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        //GET BY ID JOBS
        public Job GetById(string id)
        {
            var job = new Job();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM JOBS WHERE ID = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    job.id = reader.GetString(0);
                    job.title = reader.GetString(1);
                    job.min_salary = reader.GetInt32(2);
                    job.max_salary = reader.GetInt32(3);
                }
                reader.Close();
                connection.Close();

                return new Job();
            }
            catch
            {
                return new Job();
            }
        }
    }
}

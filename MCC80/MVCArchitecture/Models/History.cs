using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    public class History
    {
        public DateTime start_date { get; set; }
        public int employee_id { get; set; }
        public DateTime end_date { get; set; }
        public int department_id { get; set; }
        public string job_id { get; set; }
        //GET ALL HISTORIES
        public List<History> GetAll()
        {
            var connection = Connection.Get();

            var histories = new List<History>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM HISTORIES";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        History history = new History();
                        history.start_date = reader.GetDateTime(0);
                        history.employee_id = reader.GetInt32(1);
                        history.end_date = reader.GetDateTime(2);
                        history.department_id = reader.GetInt32(3);
                        history.job_id = reader.GetString(4);

                        histories.Add(history);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return histories;
            }
            catch
            {
                return new List<History>();
            }
        }

        // INSERT HISTORIES
        public int Insert(History history)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO histories (start_date, employee_id, end_date, department_id, job_id) VALUES (@StartDate, @EmployeeID, @EndDate, @DepartmentID, @JobID)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pStartDate = new SqlParameter();
                pStartDate.ParameterName = "@StartDate";
                pStartDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pStartDate.Value = history.start_date;
                sqlCommand.Parameters.Add(pStartDate);

                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@EmployeeID";
                pEmployeeId.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmployeeId.Value = history.employee_id;
                sqlCommand.Parameters.Add(pEmployeeId);

                SqlParameter pEndDate = new SqlParameter();
                pEndDate.ParameterName = "@EndDate";
                pEndDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pEndDate.Value = history.end_date;
                sqlCommand.Parameters.Add(pEndDate);

                SqlParameter pDepartmentID = new SqlParameter();
                pDepartmentID.ParameterName = "@DepartmentID";
                pDepartmentID.SqlDbType = System.Data.SqlDbType.VarChar;
                pDepartmentID.Value = history.department_id;
                sqlCommand.Parameters.Add(pDepartmentID);

                SqlParameter pJobID = new SqlParameter();
                pJobID.ParameterName = "@JobID";
                pJobID.SqlDbType = System.Data.SqlDbType.VarChar;
                pJobID.Value = history.job_id;
                sqlCommand.Parameters.Add(pJobID);

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

        //UPDATE HISTORIES
        public int Update(History history)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "update histories set start_date = @start_date, job_id = @job_id, department_id = @department_id WHERE employee_id = @employee_id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pStartDate = new SqlParameter();
                pStartDate.ParameterName = "@StartDate";
                pStartDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pStartDate.Value = history.start_date;
                sqlCommand.Parameters.Add(pStartDate);

                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@EmployeeID";
                pEmployeeId.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmployeeId.Value = history.employee_id;
                sqlCommand.Parameters.Add(pEmployeeId);

                SqlParameter pEndDate = new SqlParameter();
                pEndDate.ParameterName = "@EndDate";
                pEndDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pEndDate.Value = history.end_date;
                sqlCommand.Parameters.Add(pEndDate);

                SqlParameter pDepartmentID = new SqlParameter();
                pDepartmentID.ParameterName = "@DepartmentID";
                pDepartmentID.SqlDbType = System.Data.SqlDbType.VarChar;
                pDepartmentID.Value = history.department_id;
                sqlCommand.Parameters.Add(pDepartmentID);

                SqlParameter pJobID = new SqlParameter();
                pJobID.ParameterName = "@JobID";
                pJobID.SqlDbType = System.Data.SqlDbType.VarChar;
                pJobID.Value = history.job_id;
                sqlCommand.Parameters.Add(pJobID);

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

        //DELETE HISTORIES
        public int Delete(int employee_id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "Delete from histories where employee_id = (@Id)";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                // Declare parameter
                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@EmployeeID";
                pEmployeeId.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmployeeId.Value = employee_id;
                sqlCommand.Parameters.Add(pEmployeeId);

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


        //GET BY ID HISTORIES
        public History GetById(int id)
        {
            var history = new History();
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM histories WHERE employee_id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.Parameters.AddWithValue("@region_id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        history.start_date = reader.GetDateTime(0);
                        history.employee_id = reader.GetInt32(1);
                        history.end_date = reader.GetDateTime(2);
                        history.department_id = reader.GetInt32(3);
                        history.job_id = reader.GetString(4);
                    }
                }

                reader.Close();
                connection.Close();

                return new History();
            }
            catch
            {
                return new History();
            }
        }
    }
}
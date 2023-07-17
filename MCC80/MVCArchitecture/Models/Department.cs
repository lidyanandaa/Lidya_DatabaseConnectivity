using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Views;

namespace MVCArchitecture.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }

        //GET ALL DEPARTMENTS
        public List<Department> GetAll()
        {
            var connection = Connection.Get();

            var departments = new List<Department>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM DEPARTMENTS";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.id = reader.GetInt32(0);
                        department.name = reader.GetString(1);
                        department.location_id = reader.GetInt32(2);
                        department.manager_id = reader.GetInt32(3);

                        departments.Add(department);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return departments;
            }
            catch
            {
                return new List<Department>();
            }
        }

        // INSERT DEPARTMENS
        public int Insert(Department department)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO DEPARTMENTS (id, name, location_id, manager_id) VALUES (@id, @name, @location_id, @manager_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                //mendeklarasikan parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = department.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = department.name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationId = new SqlParameter();
                pLocationId.ParameterName = "@location_id";
                pLocationId.SqlDbType = System.Data.SqlDbType.Int;
                pLocationId.Value = department.location_id;
                sqlCommand.Parameters.Add(pLocationId);

                SqlParameter pManagerId = new SqlParameter();
                pManagerId.ParameterName = "@manager_id";
                pManagerId.SqlDbType = System.Data.SqlDbType.Int;
                pManagerId.Value = department.manager_id;
                sqlCommand.Parameters.Add(pManagerId);
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

        //UPDATE DEPARTMENS
        public int Update(Department department)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "update departments set name = @name, location_id = @location_id, manager_id = @manager_id WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = department.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = department.name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationId = new SqlParameter();
                pLocationId.ParameterName = "@location_id";
                pLocationId.SqlDbType = System.Data.SqlDbType.Int;
                pLocationId.Value = department.location_id;
                sqlCommand.Parameters.Add(pLocationId);

                SqlParameter pManagerId = new SqlParameter();
                pManagerId.ParameterName = "@manager_id";
                pManagerId.SqlDbType = System.Data.SqlDbType.Int;
                pManagerId.Value = department.manager_id;
                sqlCommand.Parameters.Add(pManagerId);

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

        //DELETE DEPARTMENS
        public int Delete(int id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM DEPARTMENTS WHERE ID = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
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

        //GET BY ID DEPARTMENS
        public Department GetById(int id)
        {
            var department = new Department();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM DEPARTMENTS WHERE ID = @id";

            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    department.id = reader.GetInt32(0);
                    department.name = reader.GetString(1);
                    department.location_id = reader.GetInt32(2);
                    department.manager_id = reader.GetInt32(3);
                }

                reader.Close();
                connection.Close();

                return department;
            }
            catch
            {
                return new Department();
            }
        }
    }
}

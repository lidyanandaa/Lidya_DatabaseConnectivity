using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Models
{
    public class Country
    {  
            public int id { get; set; }
            public string name { get; set; }
            public int region_id { get; set; }

            //GET ALL COUNTRIES
            public List<Country> GetAll()
            {
                var connection = Connection.Get();

                var countries = new List<Country>();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM COUNTRIES";

                try
                {
                    connection.Open();
                    using SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Country country = new Country();
                            country.id = reader.GetInt32(0);
                            country.name = reader.GetString(1);
                            country.region_id = reader.GetInt32(2);

                            countries.Add(country);
                        }
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();
                    }

                    return countries;
                }
                catch
                {
                    return new List<Country>();
                }
            }

            // INSERT COUNTRIES
            public int Insert(Country country)
            {
                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO COUNTRIES (ID, NAME, REGION_ID) VALUES (@id, @name, @region_id)";

                connection.Open();
                using SqlTransaction transaction = connection.BeginTransaction();
                sqlCommand.Transaction = transaction;

                try
                {
                    //mendeklarasikan parameter
                    SqlParameter pId = new SqlParameter();
                    pId.ParameterName = "@id";
                    pId.SqlDbType = SqlDbType.VarChar;
                    pId.Value = country.id;
                    sqlCommand.Parameters.Add(pId);

                    SqlParameter pName = new SqlParameter();
                    pName.ParameterName = "@name";
                    pName.SqlDbType = System.Data.SqlDbType.VarChar;
                    pName.Value = country.name;
                    sqlCommand.Parameters.Add(pName);

                    SqlParameter pRegionId = new SqlParameter();
                    pRegionId.ParameterName = "@region_id";
                    pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                    pRegionId.Value = country.region_id;
                    sqlCommand.Parameters.Add(pRegionId);

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

            //UPDATE COUNTRIES
            public int Update(Country country)
            {
                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "update countries set name = @name, region_id = @region_id WHERE id = @id";

                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                sqlCommand.Transaction = transaction;
                try
                {
                    SqlParameter pId = new SqlParameter();
                    pId.ParameterName = "@id";
                    pId.SqlDbType = SqlDbType.VarChar;
                    pId.Value = country.id;
                    sqlCommand.Parameters.Add(pId);

                    SqlParameter pName = new SqlParameter();
                    pName.ParameterName = "@name";
                    pName.SqlDbType = System.Data.SqlDbType.VarChar;
                    pName.Value = country.name;
                    sqlCommand.Parameters.Add(pName);

                    SqlParameter pRegionId = new SqlParameter();
                    pRegionId.ParameterName = "@region_id";
                    pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                    pRegionId.Value = country.region_id;
                    sqlCommand.Parameters.Add(pRegionId);

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

            //DELETE COUNTRIES
            public int Delete(int id)
            {
                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM COUNTRIES WHERE ID = @id";

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

            //GET BY ID COUNTRIES
            public Country GetById(int id)
            {
                var country = new Country();

                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM COUNTRIES WHERE ID = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            try
                {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    country.id = reader.GetInt32(0);
                    country.name = reader.GetString(1);
                    country.region_id = reader.GetInt32(2);
                }

                reader.Close();
                connection.Close();

                return country;
            }
            catch
            {
                return new Country();
            }
        }
        }
    }

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
    public class Location
    {
        public int id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public int country_id { get; set; }

        //GET ALL LOCATIONS
        public List<Location> GetAll()
        {
            var connection = Connection.Get();

            var locations = new List<Location>();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM LOCATIONS";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Location location = new Location();
                        location.id = reader.GetInt32(0);
                        location.street_address = reader.GetString(1);
                        location.postal_code = reader.GetString(2);
                        location.city = reader.GetString(3);
                        location.state_province = reader.GetString (4);
                        location.country_id = reader.GetInt32(5);

                        locations.Add(location);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return locations;
            }
            catch  
            {
                return new List<Location>();
            }
        }

        // INSERT LOCATIONS
        public int Insert(Location location)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO LOCATIONS (ID, STREET_ADDRESS, POSTAL_CODE, CITY, STATE_PROVINCE, COUNTRY_ID) VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                //mendeklarasikan parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = location.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pStreetAddress = new SqlParameter();
                pStreetAddress.ParameterName = "@street_address";
                pStreetAddress.SqlDbType = System.Data.SqlDbType.VarChar;
                pStreetAddress.Value = location.street_address;
                sqlCommand.Parameters.Add(pStreetAddress);

                SqlParameter pPostalCode = new SqlParameter();
                pPostalCode.ParameterName = "@postal_code";
                pPostalCode.SqlDbType = System.Data.SqlDbType.VarChar;
                pPostalCode.Value = location.postal_code;
                sqlCommand.Parameters.Add(pPostalCode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = System.Data.SqlDbType.VarChar;
                pCity.Value = location.city;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pStateProvince = new SqlParameter();
                pStateProvince.ParameterName = "@state_province";
                pStateProvince.SqlDbType = System.Data.SqlDbType.VarChar;
                pStateProvince.Value = location.state_province;
                sqlCommand.Parameters.Add(pStateProvince);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.SqlDbType = System.Data.SqlDbType.Int;
                pCountryId.Value = location.country_id;
                sqlCommand.Parameters.Add(pCountryId);

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

        //UPDATE LOCATIONS
        public int Update(Location location)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "update locations set street_address = @street_address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = location.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pStreetAddress = new SqlParameter();
                pStreetAddress.ParameterName = "@street_address";
                pStreetAddress.SqlDbType = System.Data.SqlDbType.VarChar;
                pStreetAddress.Value = location.street_address;
                sqlCommand.Parameters.Add(pStreetAddress);

                SqlParameter pPostalCode = new SqlParameter();
                pPostalCode.ParameterName = "@postal_code";
                pPostalCode.SqlDbType = System.Data.SqlDbType.VarChar;
                pPostalCode.Value = location.postal_code;
                sqlCommand.Parameters.Add(pPostalCode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = System.Data.SqlDbType.VarChar;
                pCity.Value = location.city;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pStateProvince = new SqlParameter();
                pStateProvince.ParameterName = "@state_province";
                pStateProvince.SqlDbType = System.Data.SqlDbType.VarChar;
                pStateProvince.Value = location.state_province;
                sqlCommand.Parameters.Add(pStateProvince);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.SqlDbType = System.Data.SqlDbType.Int;
                pCountryId.Value = location.country_id;
                sqlCommand.Parameters.Add(pCountryId);

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

        //DELETE LOCATIONS
        public int Delete(int id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM LOCATIONS WHERE ID = @id";

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

        //GET BY ID LOCATIONS
        public Location GetById(int id)
        {
            var location = new Location();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM LOCATIONS WHERE ID = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    location.id = reader.GetInt32(0);
                    location.street_address = reader.GetString(1);
                    location.postal_code = reader.GetString(2);
                    location.city = reader.GetString(3);
                    location.state_province = reader.GetString(4);
                    location.country_id = reader.GetInt32(5);
                }
                reader.Close();
                connection.Close();

                return new Location();
            }
            catch
            {
                return new Location();
            }
        }
    }
}

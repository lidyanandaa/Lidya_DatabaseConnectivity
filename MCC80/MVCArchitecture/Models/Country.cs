﻿using System;
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
        public class Countries
        {
            public int id { get; set; }
            public string name { get; set; }
            public int region_id { get; set; }

            //GET ALL COUNTRIES
            public List<Country> GetCountries()
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
                            //country.id = reader.GetInt32(0);
                            //country.name = reader.GetString(1);
                            //country.region_id = reader.GetInt32(2);

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
            public static void InsertCountries(int id, string name, int region_id)
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
                    pId.Value = id;
                    sqlCommand.Parameters.Add(pId);

                    SqlParameter pName = new SqlParameter();
                    pName.ParameterName = "@name";
                    pName.SqlDbType = System.Data.SqlDbType.VarChar;
                    pName.Value = name;
                    sqlCommand.Parameters.Add(pName);

                    SqlParameter pRegionId = new SqlParameter();
                    pRegionId.ParameterName = "@region_id";
                    pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                    pRegionId.Value = region_id;
                    sqlCommand.Parameters.Add(pRegionId);

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
                    connection.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error connecting to the database. " + ex.Message);
                }
            }

            //UPDATE COUNTRIES
            public static void UpdateCountries(int id, string name, int region_id)
            {
                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "update countries set name = @name, region_id = @region_id WHERE id = @id";

                //Set paramaeter value
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@region_id", region_id);
                try
                {
                    connection.Open();
                    int rowAffected = sqlCommand.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("Countries updated succesfully.");
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

            //DELETE COUNTRIES
            public static void DeleteCountries(int id)
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
                    if (result > 0)
                    {
                        Console.WriteLine("Delete success.");
                    }
                    else
                    {
                        Console.WriteLine("Delete failed.");
                    }

                    transaction.Commit();
                    connection.Close();
                }
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Error connecting to the database.");
                }
            }

            //GET BY ID COUNTRIES
            public static void GetCountriesById(int id)
            {
                var connection = Connection.Get();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM COUNTRIES WHERE ID = @id";

                try
                {
                    connection.Open();

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
                            Console.WriteLine("Name: " + reader.GetString(1));
                            Console.WriteLine("Region Id: " + reader.GetInt32(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No jobs found with the given ID.");
                    }

                    reader.Close();
                    connection.Close();
                }
                catch
                {
                    Console.WriteLine("Error connecting to the database.");
                }
            }
        }
    }
}
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity;

class Program
{
    private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";
    
    //penamaan private harus ada _ nya didepannya
    private static SqlConnection _connection;
    public static void Main()
    {
        //GetRegions();
        //InsertRegions("Jawa Barat");
        //UpdateRegions(14, "Jawa Timur");
        //DeleteRegions(1015);
        //GetRegionById(id: 14);

        //GetJobs();
        //UpdateJobs("1", "GM", 3000, 5000);
        //InsertJobs("31", "Admin", 5000, 8000); 
        //DeleteJobs("31");

    }

    //------------------------------------REGION-------------------------------------------------
    //GET ALL REGION
    public static void GetRegions()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM REGIONS";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT REGION
    public static void InsertRegions(string name)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO REGIONS VALUES (@name)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            //mendeklarasikan parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

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

    //UPDATE REGION
    static void UpdateRegions(int id, string newName)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE REGIONS SET NAME = @newName WHERE ID = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            // Declare parameters
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pNewName = new SqlParameter();
            pNewName.ParameterName = "@newName";
            pNewName.SqlDbType = SqlDbType.VarChar;
            pNewName.Value = newName;
            sqlCommand.Parameters.Add(pNewName);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
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

    //DELETE REGION
    static void DeleteRegions(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM REGIONS WHERE ID = @id";

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

    //GET BY ID REGION
    static void GetRegionById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM REGIONS WHERE ID = @id";

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
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No region found with the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to the database.");
        }
    }

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
    static void UpdateJobs(string id, string newTitle, int newMinSalary, int newMaxSalary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE jobs SET title = @newTitle, min_salary = @newMinSalary, max_salary = @newMaxSalary WHERE job_id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            // Declare parameters
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@newTitle";
            pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
            pTitle.Value = newTitle;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@newMinSalary";
            pMinSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMinSalary.Value = newMinSalary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@newMaxSalary";
            pMaxSalary.SqlDbType = System.Data.SqlDbType.Int;
            pMaxSalary.Value = newMaxSalary;
            sqlCommand.Parameters.Add(pMaxSalary);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
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

    //DELETE JOBS
    static void DeleteJobs(string id)
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
    static void GetJobsById(int id)
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

 //------------------------------------COUNTRIES-------------------------------------------------
    //GET ALL COUNTRIES
    public static void GetCountries()
    {
        var _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM COUNTRIES";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Region Id: " + reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No countries found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT COUNTRIES
    public static void InsertCountries(string id, string name, int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO COUNTRIES (ID, NAME, REGION_ID) VALUES (@id, @name, @region_id)";

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
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }

    //DELETE COUNTRIES
    static void DeleteCountries(string id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM COUNTRIES WHERE ID = @id";

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

    //GET BY ID COUNTRIES
    static void GetCountriesById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM COUNTRIES WHERE ID = @id";

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
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Region Id: " + reader.GetInt32(2));
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

    //------------------------------------LOCATIONS-------------------------------------------------
    //GET ALL LOCATIONS
    public static void GetLocations()
    {
        var _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM LOCATIONS";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Street Address: " + reader.GetString(1));
                    Console.WriteLine("Postal Code: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("State Province: " + reader.GetString(4));
                    Console.WriteLine("Country Id: " + reader.GetString(5));
                }
            }
            else
            {
                Console.WriteLine("No locations found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT LOCATIONS
    public static void InsertLocations(string id, string street_address, int postal_code, string city, string state_province, string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO LOCATIONS (ID, STREET_ADDRESS, POSTAL_CODE, CITY, STATE_PROVINCE, COUNTRY_ID) VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

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

            SqlParameter pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = System.Data.SqlDbType.VarChar;
            pStreetAddress.Value = street_address;
            sqlCommand.Parameters.Add(pStreetAddress);

            SqlParameter pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = System.Data.SqlDbType.Int;
            pPostalCode.Value = postal_code;
            sqlCommand.Parameters.Add(pPostalCode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = city;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = System.Data.SqlDbType.VarChar;
            pStateProvince.Value = state_province;
            sqlCommand.Parameters.Add(pStateProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = System.Data.SqlDbType.Int;
            pCountryId.Value = country_id;
            sqlCommand.Parameters.Add(pCountryId);

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

    //DELETE LOCATIONS
    static void DeleteLocations(string id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM LOCATIONS WHERE ID = @id";

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

    //GET BY ID LOCATIONS
    static void GetLocationsById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM LOCATIONS WHERE ID = @id";

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
                    Console.WriteLine("Street Address: " + reader.GetString(1));
                    Console.WriteLine("Postal Code: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("State Province: " + reader.GetString(4));
                    Console.WriteLine("Country Id: " + reader.GetString(5));
                }
            }
            else
            {
                Console.WriteLine("No locations found with the given ID.");
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
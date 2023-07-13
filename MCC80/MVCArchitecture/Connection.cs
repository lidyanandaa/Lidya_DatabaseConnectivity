using MVCArchitecture;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture;

public class Connection
{
    private static string _connectionString = "Data Source=DESKTOP-227DCJU; Database = db_mcc1; Integrated Security=True;Connect Timeout=30;";

    //penamaan private harus ada _ nya didepannya
    private static SqlConnection _connection;
    public static SqlConnection Get()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            return _connection;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
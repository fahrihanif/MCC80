using System.Data.SqlClient;

namespace MVCArchitecture;

public class Connection
{
    private static readonly string _ConnectionString = @"
            Data Source=CAMOUFLY;
            Initial Catalog=db_mcc_79;
            Integrated Security=True";

    private static SqlConnection _connection;

    public static SqlConnection Get()
    {
        try
        {
            _connection = new SqlConnection(_ConnectionString);
            return _connection;
        }
        catch
        {
            Console.WriteLine("");
            throw;
        }
    }
}

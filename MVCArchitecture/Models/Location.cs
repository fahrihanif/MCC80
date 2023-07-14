using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Location
{
    public int Id { get; set; }

    public string Street_Address { get; set; }

    public string Postal_Code { get; set; }

    public string City { get; set; }

    public string State_Province { get; set; }

    public string Country_Id { get; set; }

    public List<Location> GetAll()
    {
        var connection = Connection.Get();

        var locations = new List<Location>();

        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM locations";

        try
        {
            connection.Open();
            using var reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.Street_Address = reader.GetString(1);
                    location.Postal_Code = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.State_Province = reader.GetString(4);
                    location.Country_Id = reader.GetString(5);

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


    public int Insert(Location location)
    {
        var _connection = Connection.Get();


        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText =
            "INSERT INTO countries VALUES (@street_address), (@postal_code), (@city), (@state_province)";

        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;


        try
        {
            var pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = location.Street_Address;
            sqlCommand.Parameters.Add(pStreetAddress);

            var pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = location.Postal_Code;
            sqlCommand.Parameters.Add(pPostalCode);

            var pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            var pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = location.State_Province;
            sqlCommand.Parameters.Add(pStateProvince);

            var result = sqlCommand.ExecuteNonQuery();


            transaction.Commit();
            _connection.Close();
            return result;
        }
        catch
        {
            transaction.Rollback();
            return -1;
        }
    }


    public int Update(Location location)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText =
            "UPDATE countries SET street_address = @street_Address, postal_code = @postal_code, city = @city, state_province = @state_province WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = location.Street_Address;
            sqlCommand.Parameters.Add(pStreetAddress);

            var pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = location.Postal_Code;
            sqlCommand.Parameters.Add(pPostalCode);

            var pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            var pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = location.State_Province;
            sqlCommand.Parameters.Add(pStateProvince);

            var result = sqlCommand.ExecuteNonQuery();

            transaction.Commit();
            _connection.Close();


            return result;
        }
        catch
        {
            transaction.Rollback();
            return -1;
        }
    }


    public int Delete(int id)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM locations WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@id";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = id;
            sqlCommand.Parameters.Add(pLocationId);

            var result = sqlCommand.ExecuteNonQuery();


            transaction.Commit();
            _connection.Close();

            return result;
        }
        catch
        {
            transaction.Rollback();
            return -1;
        }
    }


    public Location GetById(int id)
    {
        var location = new Location();

        using (var connection = Connection.Get())
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM locations WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        location.Id = reader.GetInt32(0);
                        location.Street_Address = reader.GetString(1);
                        location.Postal_Code = reader.GetString(2);
                        location.City = reader.GetString(3);
                        location.State_Province = reader.GetString(4);
                        location.Country_Id = reader.GetString(5);
                    }
                }
            }
            catch
            {
                return new Location();
            }
        }

        return location;
    }
}

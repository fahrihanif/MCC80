using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Country
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Region_Id { get; set; }

    public List<Country> GetAll()
    {
        var connection = Connection.Get();

        var countries = new List<Country>();

        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM countries";

        try
        {
            connection.Open();
            using var reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var country = new Country();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.Region_Id = reader.GetInt32(2);

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


    public int Insert(Country country)
    {
        var _connection = Connection.Get();


        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Regions VALUES (@name)";

        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;


        try
        {
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = country.Name;
            sqlCommand.Parameters.Add(pName);

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


    public int Update(Country country)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE countries SET name = @name WHERE country_id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = country.Name;
            sqlCommand.Parameters.Add(pName);

            var pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@id";
            pCountryId.SqlDbType = SqlDbType.Char;
            pCountryId.Value = country.Id;
            sqlCommand.Parameters.Add(pCountryId);

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


    public int Delete(string id)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM countries WHERE country_id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@id";
            pCountryId.SqlDbType = SqlDbType.Char;
            pCountryId.Value = id;
            sqlCommand.Parameters.Add(pCountryId);

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


    public Country GetById(string id)
    {
        var country = new Country();

        using (var connection = Connection.Get())
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM countries WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.Region_Id = reader.GetInt32(2);
                    }
                }
            }
            catch
            {
                return new Country();
            }
        }

        return country;
    }
}

using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Region
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Region> GetAll()
    {
        var connection = Connection.Get();

        var regions = new List<Region>();

        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM Regions";

        try
        {
            connection.Open();
            using var reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);

                    regions.Add(region);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return regions;
        }
        catch
        {
            return new List<Region>();
        }
    }


    public int Insert(Region region)
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
            pName.Value = region.Name;
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


    public int Update(Region region)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE regions SET name = @name WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = region.Name;
            sqlCommand.Parameters.Add(pName);

            var pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@id";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = region.Id;
            sqlCommand.Parameters.Add(pRegionId);

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
        sqlCommand.CommandText = "DELETE FROM regions WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@id";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = id;
            sqlCommand.Parameters.Add(pRegionId);

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


    public Region GetById(int id)
    {
        var region = new Region();

        using (var connection = Connection.Get())
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM regions WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
                    }
                }
            }
            catch
            {
                return new Region();
            }
        }

        return region;
    }
}

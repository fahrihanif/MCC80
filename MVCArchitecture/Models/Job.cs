using System.Data;
using System.Data.SqlClient;

namespace MVCArchitecture.Models;

public class Job
{
    public string Id { get; set; }

    public string Title { get; set; }

    public int Min_Salary { get; set; }

    public int Max_Salary { get; set; }

    public List<Job> GetAll()
    {
        var connection = Connection.Get();

        var jobs = new List<Job>();

        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM jobs";

        try
        {
            connection.Open();
            using var reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var job = new Job();

                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.Min_Salary = reader.GetInt32(2);
                    job.Max_Salary = reader.GetInt32(3);

                    jobs.Add(job);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return jobs;
        }
        catch
        {
            return new List<Job>();
        }
    }


    public int Insert(Job job)
    {
        var _connection = Connection.Get();


        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO jobs VALUES (@title), (@min_salary), (@max_salary)";

        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;


        try
        {
            var pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = SqlDbType.VarChar;
            pTitle.Value = job.Title;
            sqlCommand.Parameters.Add(pTitle);

            var pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@min_salary";
            pMinSalary.SqlDbType = SqlDbType.Int;
            pMinSalary.Value = job.Min_Salary;
            sqlCommand.Parameters.Add(pMinSalary);

            var pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@max_salary";
            pMaxSalary.SqlDbType = SqlDbType.Int;
            pMaxSalary.Value = job.Max_Salary;
            sqlCommand.Parameters.Add(pMaxSalary);

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


    public int Update(Job job)
    {
        var _connection = Connection.Get();

        var sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText =
            "UPDATE jobs SET title = @title, min_salary = @min_salary, max_salary = @max_salary WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pJobId = new SqlParameter();
            pJobId.ParameterName = "@id";
            pJobId.SqlDbType = SqlDbType.Char;
            pJobId.Value = job.Id;
            sqlCommand.Parameters.Add(Id);

            var pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = SqlDbType.VarChar;
            pTitle.Value = job.Title;
            sqlCommand.Parameters.Add(pTitle);

            var pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@min_salary";
            pMinSalary.SqlDbType = SqlDbType.Int;
            pMinSalary.Value = job.Min_Salary;
            sqlCommand.Parameters.Add(pMinSalary);

            var pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@max_salary";
            pMaxSalary.SqlDbType = SqlDbType.Int;
            pMaxSalary.Value = job.Max_Salary;
            sqlCommand.Parameters.Add(pMaxSalary);

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
        sqlCommand.CommandText = "DELETE FROM jobs WHERE id = @id";

        _connection.Open();
        var transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            var pJobId = new SqlParameter();
            pJobId.ParameterName = "@id";
            pJobId.SqlDbType = SqlDbType.Char;
            pJobId.Value = id;
            sqlCommand.Parameters.Add(pJobId);

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


    public Job GetById(string id)
    {
        var job = new Job();

        using (var connection = Connection.Get())
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM jobs WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.Min_Salary = reader.GetInt32(2);
                        job.Max_Salary = reader.GetInt32(3);
                    }
                }
            }
            catch
            {
                return new Job();
            }
        }

        return job;
    }
}

using Dapper;
using MetricsAgent.Models;
using Microsoft.Extensions.Options;
using System.Data.SQLite;

namespace MetricsAgent.Services.Impl
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        public RamMetricsRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "INSERT INTO rammetrics(value, time) VALUES(@value, @time)";
            //cmd.Parameters.AddWithValue("@value", item.Value);
            //cmd.Parameters.AddWithValue("@time", item.Time);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                new
                {
                    id = id
                });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "DELETE FROM rammetrics WHERE id=@id";
            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics").ToList();

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM rammetrics";
            //var returnList = new List<RamMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        returnList.Add(new RamMetric
            //        {
            //            Id = reader.GetInt32(0),
            //            Value = reader.GetInt32(1),
            //            Time = reader.GetInt32(2)
            //        });
            //    }
            //}
            //return returnList;
        }

        public RamMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.QuerySingle<RamMetric>("SELECT * FROM rammetrics WHERE id=@id", new { id = id });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM rammetrics WHERE id=@id";
            //var returnList = new List<RamMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    if (reader.Read())
            //    {
            //        return new RamMetric
            //        {
            //            Id = reader.GetInt32(0),
            //            Time = reader.GetInt32(1),
            //            Value = reader.GetInt32(2)
            //        };
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }

        public IList<RamMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time >= @timeFrom and time <= @timeTo",
                new
                {
                    timeFrom = timeFrom.TotalSeconds,
                    timeTo = timeTo.TotalSeconds
                }).ToList();

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM rammetrics WHERE time >= @timeFrom and time <= @timeTo";
            //cmd.Parameters.AddWithValue("@timeFrom", timeFrom);
            //cmd.Parameters.AddWithValue("@timeTo", timeTo);

            //var returnList = new List<RamMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        returnList.Add(new RamMetric
            //        {
            //            Id = reader.GetInt32(0),
            //            Value = reader.GetInt32(1),
            //            Time = reader.GetInt32(2)
            //        });
            //    }
            //}
            //return returnList;
        }

        public void Update(RamMetric item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("UPDATE rammetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });

            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "UPDATE rammetrics SET value = @value, time = @time WHERE id = @id";
            //cmd.Parameters.AddWithValue("@id", item.Id);
            //cmd.Parameters.AddWithValue("@value", item.Value);
            //cmd.Parameters.AddWithValue("@time", item.Time);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }
    }
}

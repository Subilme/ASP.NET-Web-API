using Dapper;
using MetricsAgent.Models;
using Microsoft.Extensions.Options;
using System.Data.SQLite;

namespace MetricsAgent.Services.Impl
{
    public class HddMetricsRepository : IHddMetricsRepository
    {

        private readonly IOptions<DatabaseOptions> _databaseOptions;

        public HddMetricsRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        public void Create(HddMetric item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "INSERT INTO hddmetrics(value, time) VALUES(@value, @time)";
            //cmd.Parameters.AddWithValue("@value", item.Value);
            //cmd.Parameters.AddWithValue("@time", item.Time);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                new
                {
                    id = id
                });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "DELETE FROM hddmetrics WHERE id=@id";
            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }

        public IList<HddMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.Query<HddMetric>("SELECT Id, Time, Value FROM hddmetrics").ToList();

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM hddmetrics";
            //var returnList = new List<HddMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        returnList.Add(new HddMetric
            //        {
            //            Id = reader.GetInt32(0),
            //            Value = reader.GetInt32(1),
            //            Time = reader.GetInt32(2)
            //        });
            //    }
            //}
            //return returnList;
        }

        public HddMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.QuerySingle<HddMetric>("SELECT * FROM hddmetrics WHERE id=@id", new { id = id });

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM hddmetrics WHERE id=@id";
            //var returnList = new List<HddMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    if (reader.Read())
            //    {
            //        return new HddMetric
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

        public IList<HddMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            return connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE time >= @timeFrom and time <= @timeTo",
                new
                {
                    timeFrom = timeFrom.TotalSeconds,
                    timeTo = timeTo.TotalSeconds
                }).ToList();

            //connection.Open();
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "SELECT * FROM hddmetrics WHERE time >= @timeFrom and time <= @timeTo";
            //cmd.Parameters.AddWithValue("@timeFrom", timeFrom);
            //cmd.Parameters.AddWithValue("@timeTo", timeTo);
            //var returnList = new List<HddMetric>();
            //using (SQLiteDataReader reader = cmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        returnList.Add(new HddMetric
            //        {
            //            Id = reader.GetInt32(0),
            //            Value = reader.GetInt32(1),
            //            Time = reader.GetInt32(2)
            //        });
            //    }
            //}
            //return returnList;
        }

        public void Update(HddMetric item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);

            connection.Execute("UPDATE hddmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });

            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "UPDATE hddmetrics SET value = @value, time = @time WHERE id = @id";
            //cmd.Parameters.AddWithValue("@id", item.Id);
            //cmd.Parameters.AddWithValue("@value", item.Value);
            //cmd.Parameters.AddWithValue("@time", item.Time);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }
    }
}

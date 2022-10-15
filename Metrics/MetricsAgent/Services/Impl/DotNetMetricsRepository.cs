﻿using MetricsAgent.Models;
using System.Data.SQLite;

namespace MetricsAgent.Services.Impl
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private const string connectionString = "Data Source = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public void Create(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "DELETE FROM dotnetmetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<DotNetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM dotnetmetrics";

            var returnList = new List<DotNetMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new DotNetMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }

            return returnList;
        }

        public DotNetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM dotnetmetrics WHERE id=@id";

            var returnList = new List<CPUMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new DotNetMetric
                    {
                        Id = reader.GetInt32(0),
                        Time = reader.GetInt32(1),
                        Value = reader.GetInt32(2)
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public IList<DotNetMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo)
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM dotnetmetrics WHERE time >= @timeFrom and time <= @timeTo";
            cmd.Parameters.AddWithValue("@timeFrom", timeFrom);
            cmd.Parameters.AddWithValue("@timeTo", timeTo);

            var returnList = new List<DotNetMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new DotNetMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }

            return returnList;
        }

        public void Update(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(connectionString);
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "UPDATE dotnetmetrics SET value = @value, time = @time WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}

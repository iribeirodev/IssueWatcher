using System;
using System.Collections.Generic;
using System.Data.SQLite;
using IssueWatcher.Model;

namespace IssueWatcher.Services
{
    public class AppParameterService
    {
        private readonly string _databaseFile;

        public AppParameterService(string databaseFile)
        {
            _databaseFile = databaseFile;
        }

        public bool Insert(AppParameter param)
        {
            string sql = "INSERT INTO app_parameters (key, value, description) VALUES (@key, @value, @description);";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@key", param.Key);
                    cmd.Parameters.AddWithValue("@value", param.Value);
                    cmd.Parameters.AddWithValue("@description", param.Description);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(AppParameter param)
        {
            string sql = "UPDATE app_parameters SET value = @value, description = @description WHERE key = @key;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@key", param.Key);
                    cmd.Parameters.AddWithValue("@value", param.Value);
                    cmd.Parameters.AddWithValue("@description", param.Description);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string key)
        {
            string sql = "DELETE FROM app_parameters WHERE key = @key;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@key", key);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public AppParameter GetByKey(string key)
        {
            string sql = "SELECT * FROM app_parameters WHERE key = @key LIMIT 1;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@key", key);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AppParameter
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Key = reader["key"].ToString(),
                                Value = reader["value"]?.ToString(),
                                Description = reader["description"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<AppParameter> GetAll()
        {
            var list = new List<AppParameter>();
            string sql = "SELECT * FROM app_parameters ORDER BY key;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AppParameter
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Key = reader["key"].ToString(),
                            Value = reader["value"]?.ToString(),
                            Description = reader["description"]?.ToString()
                        });
                    }
                }
            }

            return list;
        }
    }

}

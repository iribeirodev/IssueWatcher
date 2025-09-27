using IssueWatcher.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueWatcher.Services
{
    public class IncidentService
    {
        private readonly string _databaseFile;

        public IncidentService(string databaseFile)
        {
            _databaseFile = databaseFile;
        }

        public static bool RecreateDatabase(string databasePath)
        {
            if (File.Exists(databasePath)) 
                File.Delete(databasePath);

            SQLiteConnection.CreateFile(databasePath);
            ConfigReader reader = new ConfigReader();

            string script = reader.ReadCreateScript();
            using (var conn = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(script, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            return true;
        }

        public List<Incident> GetAll(string numberCriteria)
        {
            var incidents = new List<Incident>();

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                string limitClause = "";
                if (!string.IsNullOrWhiteSpace(numberCriteria) && numberCriteria != "all")
                {
                    // Remove qualquer texto indesejado e usa LIMIT do SQLite
                    if (int.TryParse(numberCriteria.Replace("incidents", ""), out int limit))
                        limitClause = $"LIMIT {limit}";
                }

                string sql = $"SELECT * FROM incidents {limitClause};";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var incident = new Incident
                        {
                            AssignmentGroup = reader["assignment_group"]?.ToString(),
                            Number = reader["number"]?.ToString(),
                            State = reader["state"]?.ToString(),
                            Caller = reader["caller"]?.ToString(),
                            AssignedTo = reader["assigned_to"]?.ToString(),
                            Priority = reader["priority"]?.ToString(),
                            Created = reader["created"]?.ToString(),
                            Updated = reader["updated"]?.ToString(),
                            ShortDescription = reader["short_description"]?.ToString(),
                            SlaDue = reader["sla_due"]?.ToString(),
                            ConfigurationItem = reader["configuration_item"]?.ToString(),
                            Resolved = reader["resolved"]?.ToString(),
                            Email = reader["email"]?.ToString()
                        };

                        incidents.Add(incident);
                    }
                } 
            } 

            return incidents;
        }

        public bool Update(string number, string newAssignedTo)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Incident number cannot be empty.", nameof(number));

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                string sql = "UPDATE incidents SET assigned_to = @assigned_to WHERE number = @number;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@assigned_to", newAssignedTo ?? "");
                    cmd.Parameters.AddWithValue("@number", number);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            return true;
        }

        public List<string> GetNotes(string incidentNumber)
        {
            var notes = new List<string>();

            if (string.IsNullOrWhiteSpace(incidentNumber))
                return notes;

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                string sql = "SELECT description FROM notes WHERE number = @number;";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@number", incidentNumber);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notes.Add(reader["description"]?.ToString() ?? "");
                        }
                    }
                }

                conn.Close();
            }

            return notes;
        }

        public void ReplaceNotes(string incidentNumber, List<string> notes)
        {
            if (string.IsNullOrWhiteSpace(incidentNumber))
                throw new ArgumentException("Incident number cannot be empty.", nameof(incidentNumber));

            if (notes == null)
                notes = new List<string>();

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    // 1. Deleta as notas existentes
                    using (var deleteCmd = new SQLiteCommand("DELETE FROM notes WHERE number = @number;", conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@number", incidentNumber);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // 2. Insere as novas notas
                    using (var insertCmd = new SQLiteCommand("INSERT INTO notes (number, description) VALUES (@number, @description);", conn))
                    {
                        insertCmd.Parameters.AddWithValue("@number", incidentNumber);
                        var descriptionParam = insertCmd.Parameters.Add("@description", System.Data.DbType.String);

                        foreach (var note in notes)
                        {
                            descriptionParam.Value = note ?? "";
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

                conn.Close();
            }
        }
    }
}

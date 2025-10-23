﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using IssueWatcher.Model;

namespace IssueWatcher.Services
{
    /// <summary>
    /// Fornece serviços para interagir com dados de incidentes, como leitura, consulta e atualização
    /// no banco de dados SQLite.
    /// </summary>
    public class IncidentService
    {
        private readonly string _databaseFile;
        private readonly IncidentStat _incidentStat;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IncidentService"/>.
        /// </summary>
        /// <param name="databaseFile">O caminho completo para o arquivo de banco de dados SQLite.</param>
        public IncidentService(string databaseFile)
        {
            _databaseFile = databaseFile;
            _incidentStat = new IncidentStat();
        }

        #region Read

        /// <summary>
        /// Obtém uma lista de todos os incidentes (ou um número limitado de incidentes) do banco de dados.
        /// </summary>
        /// <param name="numberCriteria">Um critério para limitar o número de incidentes retornados. 
        /// Pode ser uma string vazia/nula, "all" ou o número de incidentes desejado (ex: "100incidents").</param>
        /// <returns>Uma <see cref="List{T}"/> de objetos <see cref="Incident"/>.</returns>
        public List<Incident> GetAll(string numberCriteria)
        {
            var incidents = new List<Incident>();

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                string limitClause = "";
                if (!string.IsNullOrWhiteSpace(numberCriteria) && numberCriteria != "all")
                {
                    if (int.TryParse(numberCriteria.Replace("incidents", ""), out int limit))
                        limitClause = $"LIMIT {limit}";
                }

                string sql = $@"
                    SELECT i.* FROM incidents i
                    {limitClause};";

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
                            LocalPriority = reader["local_priority"] != DBNull.Value ? reader["local_priority"].ToString() : "5",
                            Created = reader["created"]?.ToString(),
                            Updated = reader["updated"]?.ToString(),
                            ShortDescription = reader["short_description"]?.ToString(),
                            SlaDue = reader["sla_due"]?.ToString(),
                            ConfigurationItem = reader["configuration_item"]?.ToString(),
                            Resolved = reader["resolved"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            LocalStatus = reader["local_status"]?.ToString(),
                            CurrentIncident = reader["current_incident"]?.ToString(),
                        };

                        incidents.Add(incident);
                    }
                }
            }

            return incidents;
        }

        /// <summary>
        /// Obtém todas as anotações (notes) associadas a um número de incidente específico.
        /// </summary>
        /// <param name="incidentNumber">O número do incidente para o qual as notas serão consultadas.</param>
        /// <returns>Uma <see cref="List{T}"/> de strings contendo as descrições das notas. 
        /// Retorna uma lista vazia se o número do incidente for nulo ou vazio.</returns>
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

        /// <summary>
        /// Obtém uma lista de todos os valores distintos e não vazios de "assigned_to" (atribuído a) 
        /// da tabela de incidentes, ordenados alfabeticamente.
        /// </summary>
        /// <returns>Uma <see cref="List{T}"/> de strings com os nomes dos responsáveis.</returns>
        public List<string> GetAllAssignedTo()
        {
            var assignedToList = new List<string>();

            string sql = @"
            SELECT DISTINCT assigned_to
            FROM incidents
            WHERE assigned_to IS NOT NULL AND assigned_to != ''
            ORDER BY assigned_to;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string assignedTo = reader["assigned_to"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(assignedTo))
                        {
                            assignedToList.Add(assignedTo);
                        }
                    }
                }
            }

            return assignedToList;
        }

        /// <summary>
        /// Obtém uma lista de todos os valores distintos e não vazios de "state" (estado) 
        /// da tabela de incidentes, ordenados alfabeticamente.
        /// </summary>
        /// <returns>Uma <see cref="List{T}"/> de strings com os estados distintos.</returns>
        public List<string> GetAllStates()
        {
            var statesList = new List<string>();

            string sql = @"
            SELECT DISTINCT state
            FROM incidents
            WHERE state IS NOT NULL AND state != ''
            ORDER BY state;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string state = reader["state"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(state))
                        {
                            statesList.Add(state);
                        }
                    }
                }
            }

            return statesList;
        }

        /// <summary>
        /// Obtém uma lista de todos os valores distintos e não vazios de "local_status" (status local) 
        /// da tabela de incidentes, ordenados alfabeticamente.
        /// </summary>
        /// <returns>Uma <see cref="List{T}"/> de strings com os status locais distintos.</returns>
        public List<string> GetAllLocalStatuses()
        {
            var localStatusList = new List<string>();

            // Altera a coluna de 'state' para 'local_status'
            string sql = @"
            SELECT DISTINCT local_status
            FROM incidents
            WHERE local_status IS NOT NULL AND local_status != ''
            ORDER BY local_status;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string localStatus = reader["local_status"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(localStatus))
                        {
                            localStatusList.Add(localStatus);
                        }
                    }
                }
            }

            return localStatusList;
        }

        /// <summary>
        /// Obtém o número do incidente que está marcado na coluna 'current_incident' do banco de dados.
        /// </summary>
        /// <returns>O número do incidente atual como string, ou <c>null</c> se não houver um definido (ou marcado).</returns>
        public string GetCurrentIncident()
        {
            string sql = "SELECT number FROM incidents WHERE current_incident = 'Y' LIMIT 1;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }


        /// <summary>
        /// Obtém um único objeto <see cref="Incident"/> com base no seu número.
        /// </summary>
        /// <param name="numberCriteria">O número de identificação do incidente (ex: "INC123456").</param>
        /// <returns>O objeto <see cref="Incident"/> correspondente, ou <c>null</c> se não for encontrado ou se o critério for inválido.</returns>
        public Incident GetIncidentByNumber(string numberCriteria)
        {
            if (string.IsNullOrWhiteSpace(numberCriteria))
            {
                return null;
            }

            Incident incident = null;

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                string sql = @"
                SELECT * FROM incidents 
                WHERE number = @Number;";

                // 4. Executa a query
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Number", numberCriteria);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            incident = new Incident
                            {
                                AssignmentGroup = reader["assignment_group"]?.ToString(),
                                Number = reader["number"]?.ToString(),
                                State = reader["state"]?.ToString(),
                                Caller = reader["caller"]?.ToString(),
                                AssignedTo = reader["assigned_to"]?.ToString(),
                                Priority = reader["priority"]?.ToString(),
                                LocalPriority = reader["local_priority"] != DBNull.Value ? reader["local_priority"].ToString() : "5",
                                Created = reader["created"]?.ToString(),
                                Updated = reader["updated"]?.ToString(),
                                ShortDescription = reader["short_description"]?.ToString(),
                                SlaDue = reader["sla_due"]?.ToString(),
                                ConfigurationItem = reader["configuration_item"]?.ToString(),
                                Resolved = reader["resolved"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                LocalStatus = reader["local_status"]?.ToString(),
                                CurrentIncident = reader["current_incident"]?.ToString(),
                            };
                        }
                    }
                }
            }

            return incident;
        }

        /// <summary>
        /// Obtém os números dos incidentes que contêm anotações (notes) registradas no banco de dados.
        /// </summary>
        /// <returns>Um <see cref="HashSet{T}"/> de strings contendo os números de incidentes com notas.</returns>
        public HashSet<string> GetIncidentNumbersWithNotes()
        {
            var result = new HashSet<string>();

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                string sql = "SELECT DISTINCT number FROM notes";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader["number"].ToString());
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Calcula e retorna as estatísticas agregadas de incidentes para um mês específico,
        /// incluindo contagem por estado e por status local.
        /// </summary>
        /// <param name="mesAno">O mês e ano no formato "yyyy-MM" (ex: "2025-10") para o qual as estatísticas devem ser calculadas.</param>
        /// <returns>Um objeto <see cref="IncidentStat"/> preenchido com as contagens de incidentes correspondentes ao mês informado.</returns>
        public IncidentStat GetStatistics(string mesAno)
        {
            var stat = new IncidentStat { MesAno = mesAno };

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                // Contagem por estado no mês especificado
                string stateQuery = @"
                    SELECT state, COUNT(*) as count
                    FROM (
                        SELECT state,
                               STRFTIME('%Y-%m',
                                   SUBSTR(updated, 7, 4) || '-' || SUBSTR(updated, 4, 2) || '-' || SUBSTR(updated, 1, 2)
                               ) AS mes_ano
                        FROM incidents
                    )
                    WHERE mes_ano = @mesAno
                    GROUP BY state";

                using (var cmd = new SQLiteCommand(stateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@mesAno", mesAno);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string state = reader.GetString(0);
                            int count = reader.GetInt32(1);

                            switch (state.ToLower())
                            {
                                case "canceled":
                                    stat.CountCancelled = count;
                                    break;
                                case "closed":
                                    stat.CountClosed = count;
                                    break;
                                case "in progress":
                                    stat.CountInProgress = count;
                                    break;
                                case "resolved":
                                    stat.CountResolved = count;
                                    break;
                                case "new":
                                    stat.CountNew = count;
                                    break;
                            }
                        }
                    }
                }

                // Contagem por status local no mês especificado
                string localStatusQuery = @"
                    SELECT state, local_status
                    FROM (
                        SELECT state, local_status,
                               STRFTIME('%Y-%m',
                                   SUBSTR(updated, 7, 4) || '-' || SUBSTR(updated, 4, 2) || '-' || SUBSTR(updated, 1, 2)
                               ) AS mes_ano
                        FROM incidents
                    )
                    WHERE mes_ano = @mesAno";

                using (var cmd = new SQLiteCommand(localStatusQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@mesAno", mesAno);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var localStatusCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                        while (reader.Read())
                        {
                            string state = reader.IsDBNull(0) ? null : reader.GetString(0);
                            string localStatus = reader.IsDBNull(1) ? null : reader.GetString(1);

                            string key;
                            if (localStatus == null && string.Equals(state, "New", StringComparison.OrdinalIgnoreCase))
                                key = "n/a";
                            else if (localStatus != null)
                                key = localStatus.ToLower();
                            else
                                continue;

                            if (!localStatusCounts.ContainsKey(key))
                                localStatusCounts[key] = 0;

                            localStatusCounts[key]++;
                        }

                        foreach (var kvp in localStatusCounts)
                        {
                            switch (kvp.Key)
                            {
                                case "aguardando homologação":
                                    stat.CountAguardandoHomologacao = kvp.Value;
                                    break;
                                case "aguardando publicação":
                                    stat.CountAguardandoPublicacao = kvp.Value;
                                    break;
                                case "aguardando testes":
                                    stat.CountAguardandoTestes = kvp.Value;
                                    break;
                                case "em atendimento":
                                    stat.CountEmAtendimento = kvp.Value;
                                    break;
                                case "finalizado":
                                    stat.CountFinalizado = kvp.Value;
                                    break;
                                case "n/a":
                                    stat.CountNaoAtuado = kvp.Value;
                                    break;
                            }
                        }
                    }
                }
            }

            return stat;
        }

        #endregion

        #region Save
        /// <summary>
        /// Define a coluna 'current_incident' como 'Y' (ou valor similar) para o incidente especificado
        /// e como 'N' (ou valor similar) para todos os outros, na tabela incidents.
        /// </summary>
        /// <param name="incidentNumber">O número do incidente a ser marcado como o atual.</param>
        /// <returns><c>true</c> se a operação foi bem-sucedida (alguma linha foi afetada), caso contrário, <c>false</c>.</returns>
        public bool UpdateCurrentIncident(string incidentNumber)
        {
            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    int rowsAffected = 0;

                    // 1. Limpa a flag de todos os outros incidentes
                    string clearSql = "UPDATE incidents SET current_incident = 'N' WHERE number != @incidentNumber;";
                    using (var clearCmd = new SQLiteCommand(clearSql, conn))
                    {
                        clearCmd.Parameters.AddWithValue("@incidentNumber", incidentNumber);
                        clearCmd.ExecuteNonQuery();
                    }

                    // 2. Define a flag para o incidente atual
                    string setSql = "UPDATE incidents SET current_incident = 'Y' WHERE number = @incidentNumber;";
                    using (var setCmd = new SQLiteCommand(setSql, conn))
                    {
                        setCmd.Parameters.AddWithValue("@incidentNumber", incidentNumber);
                        rowsAffected = setCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Deleta o registro do incidente atual, o que significa limpar a flag 'current_incident'
        /// para o incidente especificado.
        /// </summary>
        /// <param name="incidentNumber">O número do incidente a ter a seleção atual deletada/limpa.</param>
        /// <returns><c>true</c> se o registro foi deletado/limpo (alguma linha foi afetada), caso contrário, <c>false</c>.</returns>
        public bool DeleteCurrentIncident(string incidentNumber)
        {
            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                // Limpa a flag de current_incident para o número especificado
                string sql = "UPDATE incidents SET current_incident = NULL WHERE number = @incidentNumber;";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@incidentNumber", incidentNumber);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Atualiza a prioridade local de um incidente existente na tabela <c>incidents</c>.
        /// </summary>
        /// <param name="number">O número do incidente a ser atualizado.</param>
        /// <param name="newPriority">O novo valor da prioridade local.</param>
        /// <returns><c>true</c> se a operação for concluída com sucesso (sem verificar se alguma linha foi afetada).</returns>
        /// <exception cref="ArgumentException">Lançada se o número do incidente for nulo ou vazio.</exception>
        public bool UpdateIncidentPriority(string number, string newPriority)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Incident number cannot be empty.", nameof(number));

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                // Atualiza a coluna 'local_priority' na tabela 'incidents'
                string sql = "UPDATE incidents SET local_priority = @local_priority WHERE number = @number;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@local_priority", newPriority ?? "");
                    cmd.Parameters.AddWithValue("@number", number);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            return true;
        }

        /// <summary>
        /// Atualiza o campo 'assigned_to' (atribuído a) para um incidente específico no banco de dados.
        /// </summary>
        /// <param name="number">O número único do incidente a ser atualizado.</param>
        /// <param name="newAssignedTo">O novo valor a ser atribuído ao campo 'assigned_to'. Pode ser <c>null</c> para limpar o campo.</param>
        /// <returns><c>true</c> se a operação for concluída com sucesso (a query foi executada).</returns>
        /// <exception cref="ArgumentException">Lançada se o <paramref name="number"/> do incidente for nulo ou vazio.</exception>
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

        /// <summary>
        /// Atualiza múltiplos campos de um incidente (state, assigned_to, priority, local_status, local_priority) no banco de dados.
        /// </summary>
        /// <param name="number">O número do incidente a ser atualizado.</param>
        /// <param name="state">O novo estado do incidente.</param>
        /// <param name="assignedTo">O novo responsável pelo incidente.</param>
        /// <param name="localStatus">O novo status local do incidente.</param>
        /// <param name="localPriority">A nova prioridade local do incidente.</param>
        /// <returns><c>true</c> se pelo menos uma linha foi afetada (incidente encontrado e atualizado); caso contrário, <c>false</c>.</returns>
        public bool UpdateIncident(
            string number,
            string state,
            string assignedTo,
            string localStatus,
            string localPriority)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return false;
            }

            string sql = @"
                UPDATE incidents SET
                    state = @State,
                    assigned_to = @AssignedTo,
                    local_status = @LocalStatus,
                    local_priority = @LocalPriority
                WHERE 
                    number = @Number;";

            using (var conn = new SQLiteConnection($"Data Source={_databaseFile};Version=3;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@State", state ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedTo", assignedTo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LocalStatus", localStatus ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LocalPriority", localPriority ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@Number", number);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Remove todas as notas existentes para um incidente e insere uma nova lista de notas.
        /// A operação é realizada dentro de uma transação para garantir atomicidade (todas ou nenhuma são salvas).
        /// </summary>
        /// <param name="incidentNumber">O número único do incidente ao qual as notas estão associadas.</param>
        /// <param name="notes">Uma lista de strings representando as novas notas a serem inseridas. Se a lista for <c>null</c> ou vazia, todas as notas existentes serão apenas removidas.</param>
        /// <exception cref="ArgumentException">Lançada se o <paramref name="incidentNumber"/> for nulo ou vazio.</exception>
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

        #endregion
    }
}
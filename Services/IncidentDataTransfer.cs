using ClosedXML.Excel;
using IssueWatcher.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace IssueWatcher.Services
{
    /// <summary>
    /// Responsável por executar a transferência de dados relacionados a incidentes,
    /// como exportação e importação de planilhas.
    /// </summary>
    public class IncidentDataTransfer
    {
        private readonly ConfigReader _configReader;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IncidentDataTransfer"/>.
        /// </summary>
        /// <param name="configReader">O objeto leitor de configuração que será usado para acessar as configurações.</param>
        public IncidentDataTransfer(ConfigReader configReader)
        {
            _configReader = configReader;
        }

        /// <summary>
        /// Importa dados de incidentes de uma planilha, atualizando o registro se o incidente já existir (pelo número), 
        /// ou inserindo um novo se não existir.
        /// </summary>
        /// <param name="spreadsheetFile">O caminho completo para o arquivo de planilha (Excel/ClosedXML).</param>
        /// <returns><c>true</c> se a importação for concluída com sucesso.</returns>
        /// <exception cref="InvalidDataException">Lançada se a estrutura da planilha for inválida.</exception>
        public bool ImportIncidents(string spreadsheetFile)
        {
            string expectedHeaders = _configReader.GetValue("spreadsheet");

            using (var workbook = new XLWorkbook(spreadsheetFile))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed();

                if (!ValidateSpreadsheetColumns(worksheet, expectedHeaders, out string error))
                    throw new InvalidDataException(Properties.Resources.INVALID_SPREADSHEET);

                string databaseFile = _configReader.GetDatabaseName();

                using (var conn = new SQLiteConnection($"Data Source={databaseFile};Version=3;"))
                {
                    conn.Open();

                    string checkSql = "SELECT assigned_to FROM incidents WHERE number = @number;";

                    string updateSql =
                        @"UPDATE incidents SET
                            assignment_group = @assignment_group, state = @state, caller = @caller, 
                            assigned_to = @assigned_to, priority = @priority, created = @created, 
                            updated = @updated, short_description = @short_description, sla_due = @sla_due, 
                            configuration_item = @configuration_item, resolved = @resolved, email = @email
                         WHERE number = @number;";

                    string insertSql =
                        @"INSERT INTO incidents (
                            assignment_group, number, state, caller, assigned_to,
                            priority, created, updated, short_description,
                            sla_due, configuration_item, resolved, email
                        ) VALUES (
                            @assignment_group, @number, @state, @caller, @assigned_to,
                            @priority, @created, @updated, @short_description,
                            @sla_due, @configuration_item, @resolved, @email
                        );";

                    foreach (var row in rows.Skip(1))
                    {
                        string number = row.Cell(2).GetValue<string>();

                        using (var checkCmd = new SQLiteCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@number", number);
                            object existingAssignedTo = checkCmd.ExecuteScalar();

                            bool exists = existingAssignedTo != null;

                            string sqlToExecute = exists ? updateSql : insertSql;

                            using (var cmd = new SQLiteCommand(sqlToExecute, conn))
                            {
                                cmd.Parameters.AddWithValue("@assignment_group", row.Cell(1).GetValue<string>());
                                cmd.Parameters.AddWithValue("@number", number);
                                cmd.Parameters.AddWithValue("@state", row.Cell(3).GetValue<string>());
                                cmd.Parameters.AddWithValue("@caller", row.Cell(4).GetValue<string>());

                                // Se já existe e assigned_to não está vazio, mantém o valor atual
                                string newAssignedTo = row.Cell(5).GetValue<string>();
                                if (exists && !string.IsNullOrEmpty(existingAssignedTo?.ToString()))
                                    cmd.Parameters.AddWithValue("@assigned_to", existingAssignedTo.ToString());
                                else
                                    cmd.Parameters.AddWithValue("@assigned_to", newAssignedTo);

                                cmd.Parameters.AddWithValue("@priority", row.Cell(6).GetValue<string>());
                                cmd.Parameters.AddWithValue("@created", row.Cell(7).GetValue<string>());
                                cmd.Parameters.AddWithValue("@updated", row.Cell(8).GetValue<string>());
                                cmd.Parameters.AddWithValue("@short_description", row.Cell(9).GetValue<string>());
                                cmd.Parameters.AddWithValue("@sla_due", row.Cell(10).GetValue<string>());
                                cmd.Parameters.AddWithValue("@configuration_item", row.Cell(11).GetValue<string>());
                                cmd.Parameters.AddWithValue("@resolved", row.Cell(12).GetValue<string>());
                                cmd.Parameters.AddWithValue("@email", row.Cell(13).GetValue<string>());

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Atualiza ou insere o registro de última importação na tabela last_imported.
        /// </summary>
        /// <param name="successful">Indica se a importação foi bem-sucedida (1 para sucesso, 0 para falha).</param>
        public void UpsertLastImported(int successful)
        {
            string databaseFile = _configReader.GetDatabaseName();
            using (var conn = new SQLiteConnection($"Data Source={databaseFile};Version=3;"))
            {
                conn.Open();

                string checkSql = "SELECT COUNT(*) FROM last_imported;";
                string updateSql = "UPDATE last_imported SET successful = @successful, date_imported = @date_imported;";
                string insertSql = "INSERT INTO last_imported (successful, date_imported) VALUES (@successful, @date_imported);";

                using (var checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    long count = (long)checkCmd.ExecuteScalar();
                    string sqlToExecute = count > 0 ? updateSql : insertSql;

                    using (var cmd = new SQLiteCommand(sqlToExecute, conn))
                    {
                        cmd.Parameters.AddWithValue("@successful", successful);
                        cmd.Parameters.AddWithValue("@date_imported", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Recupera o registro mais recente da tabela last_imported.
        /// </summary>
        /// <returns>Instância de <see cref="LastImportedModel"/> contendo os dados da última importação, ou null se não houver registro.</returns>
        public LastImportedModel GetLastImported()
        {
            string databaseFile = _configReader.GetDatabaseName();
            using (var conn = new SQLiteConnection($"Data Source={databaseFile};Version=3;"))
            {
                conn.Open();

                string query = "SELECT successful, date_imported FROM last_imported LIMIT 1;";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LastImportedModel
                        {
                            Successful = reader.GetInt32(0),
                            DateImported = reader.GetString(1)
                        };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Valida se os cabeçalhos da primeira linha da planilha correspondem aos cabeçalhos esperados.
        /// A validação compara o número de colunas e o nome de cada coluna, ignorando a caixa.
        /// </summary>
        /// <param name="worksheet">A planilha a ser validada.</param>
        /// <param name="expectedHeaderCsv">Uma string CSV contendo os nomes dos cabeçalhos esperados.</param>
        /// <param name="errorMessage">
        /// Quando este método retorna <c>false</c>, contém a mensagem de erro detalhada sobre a falha.
        /// Quando este método retorna <c>true</c>, contém <see cref="string.Empty"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> se todos os cabeçalhos estiverem corretos em número e nome;
        /// <c>false</c> se houver uma incompatibilidade no número de colunas ou no nome de alguma coluna.
        /// </returns>
        private bool ValidateSpreadsheetColumns(IXLWorksheet worksheet, string expectedHeaderCsv, out string errorMessage)
        {
            var expectedHeaders = expectedHeaderCsv.Split(',')
                                                    .Select(h => h.Trim())
                                                    .ToList();

            var actualHeaders = worksheet.FirstRowUsed()
                                         .Cells()
                                         .Select(c => c.GetValue<string>().Trim())
                                         .ToList();

            if (actualHeaders.Count != expectedHeaders.Count)
            {
                errorMessage = $"Esperado {expectedHeaders.Count} colunas, mas encontrado {actualHeaders.Count}.";
                return false;
            }

            for (int i = 0; i < expectedHeaders.Count; i++)
            {
                if (!string.Equals(actualHeaders[i], expectedHeaders[i], StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = $"Coluna {i + 1} incorreta: esperado '{expectedHeaders[i]}', encontrado '{actualHeaders[i]}'.";
                    return false;
                }
            }

            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Exporta todos os incidentes armazenados no banco de dados, incluindo suas notas associadas, para um arquivo Excel.
        /// Os incidentes são ordenados pela prioridade.
        /// </summary>
        /// <param name="filePath">O caminho completo, incluindo o nome do arquivo (.xlsx), onde o arquivo será salvo.</param>
        public void ExportIncidentsWithNotes(string filePath)
        {
            IncidentService service = new IncidentService(_configReader.GetDatabaseName());

            var incidents = service.GetAll("all");

            // ordenação por prioridade
            incidents = incidents
                                .OrderBy(i => int.TryParse(i.Priority, out int p) ? p : int.MaxValue)
                                .ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Incidents");

                // Cabeçalhos
                var headers = new List<string>
                {
                    "Priority", "Number", "Status", "AssignmentGroup", "State", "Caller", "AssignedTo",
                    "Created", "Updated", "ShortDescription",
                    "SlaDue", "ConfigurationItem", "Resolved", "Email", "Issue Type", "Observações"
                };

                for (int col = 0; col < headers.Count; col++)
                    worksheet.Cell(1, col + 1).Value = headers[col];

                // Dados
                for (int row = 0; row < incidents.Count; row++)
                {
                    var inc = incidents[row];
                    worksheet.Cell(row + 2, 1).Value = inc.LocalPriority;
                    worksheet.Cell(row + 2, 2).Value = inc.Number;
                    worksheet.Cell(row + 2, 3).Value = inc.LocalStatus;
                    worksheet.Cell(row + 2, 4).Value = inc.AssignmentGroup;
                    worksheet.Cell(row + 2, 5).Value = inc.State;
                    worksheet.Cell(row + 2, 6).Value = inc.Caller;
                    worksheet.Cell(row + 2, 7).Value = inc.AssignedTo;
                    worksheet.Cell(row + 2, 8).Value = inc.Created;
                    worksheet.Cell(row + 2, 9).Value = inc.Updated;
                    worksheet.Cell(row + 2, 10).Value = inc.ShortDescription;
                    worksheet.Cell(row + 2, 11).Value = inc.SlaDue;
                    worksheet.Cell(row + 2, 12).Value = inc.ConfigurationItem;
                    worksheet.Cell(row + 2, 13).Value = inc.Resolved;
                    worksheet.Cell(row + 2, 14).Value = inc.Email;
                    worksheet.Cell(row + 2, 15).Value = inc.IssueType;

                    // Notas
                    var notes = service.GetNotes(inc.Number);
                    worksheet.Cell(row + 2, 16).Value = string.Join(Environment.NewLine, notes);
                    worksheet.Cell(row + 2, 16).Style.Alignment.WrapText = true; // Permite quebras de linha
                }

                worksheet.Columns().AdjustToContents(); // Ajusta largura automaticamente
                workbook.SaveAs(filePath);
            }
        }

    }
}

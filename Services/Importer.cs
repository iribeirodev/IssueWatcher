using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueWatcher.Services
{
    public class Importer
    {
        public static bool ImportIncidents(string databaseFile, string spreadsheetFile)
        {
            var config = new ConfigReader();
            string expectedHeaders = config.GetValue("spreadsheet");

            // Abre o Excel com ClosedXML
            using (var workbook = new XLWorkbook(spreadsheetFile))
            {
                var worksheet = workbook.Worksheet(1); // primeira aba
                var rows = worksheet.RangeUsed().RowsUsed();

                if (!ValidateSpreadsheetColumns(worksheet, expectedHeaders, out string error))
                {
                    throw new InvalidDataException("Spreadsheet contains invalid columns or whole invalid header.");
                }

                // Conecta ao SQLite
                using (var conn = new SQLiteConnection($"Data Source={databaseFile};Version=3;"))
                {
                    conn.Open();

                    // Apaga todos os registros existentes
                    using (var cmdClear = new SQLiteCommand("DELETE FROM incidents;", conn))
                    {
                        cmdClear.ExecuteNonQuery();
                    }

                    foreach (var row in rows.Skip(1)) // pula cabeçalho
                    {
                        string sql = @"INSERT INTO incidents (
                                assignment_group, number, state, caller, assigned_to,
                                priority, created, updated, short_description,
                                sla_due, configuration_item, resolved, email
                            ) VALUES (
                                @assignment_group, @number, @state, @caller, @assigned_to,
                                @priority, @created, @updated, @short_description,
                                @sla_due, @configuration_item, @resolved, @email
                            );";

                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@assignment_group", row.Cell(1).GetValue<string>());
                            cmd.Parameters.AddWithValue("@number", row.Cell(2).GetValue<string>());
                            cmd.Parameters.AddWithValue("@state", row.Cell(3).GetValue<string>());
                            cmd.Parameters.AddWithValue("@caller", row.Cell(4).GetValue<string>());
                            cmd.Parameters.AddWithValue("@assigned_to", row.Cell(5).GetValue<string>());
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

            return true;
        }

        private static bool ValidateSpreadsheetColumns(IXLWorksheet worksheet, string expectedHeaderCsv, out string errorMessage)
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

        public static void ExportIncidentsWithNotes(string filePath)
        {
            ConfigReader reader = new ConfigReader();
            IncidentService service = new IncidentService(reader.GetValue("database"));

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
                    "Priority", "Number", "AssignmentGroup", "State", "Caller", "AssignedTo",
                    "Created", "Updated", "ShortDescription",
                    "SlaDue", "ConfigurationItem", "Resolved", "Email", "Notas"
                };

                for (int col = 0; col < headers.Count; col++)
                    worksheet.Cell(1, col + 1).Value = headers[col];

                // Dados
                for (int row = 0; row < incidents.Count; row++)
                {
                    var inc = incidents[row];
                    worksheet.Cell(row + 2, 1).Value = inc.Priority;
                    worksheet.Cell(row + 2, 2).Value = inc.Number;
                    worksheet.Cell(row + 2, 3).Value = inc.AssignmentGroup;
                    worksheet.Cell(row + 2, 4).Value = inc.State;
                    worksheet.Cell(row + 2, 5).Value = inc.Caller;
                    worksheet.Cell(row + 2, 6).Value = inc.AssignedTo;
                    worksheet.Cell(row + 2, 7).Value = inc.Created;
                    worksheet.Cell(row + 2, 8).Value = inc.Updated;
                    worksheet.Cell(row + 2, 9).Value = inc.ShortDescription;
                    worksheet.Cell(row + 2, 10).Value = inc.SlaDue;
                    worksheet.Cell(row + 2, 11).Value = inc.ConfigurationItem;
                    worksheet.Cell(row + 2, 12).Value = inc.Resolved;
                    worksheet.Cell(row + 2, 13).Value = inc.Email;

                    // Notas
                    var notes = service.GetNotes(inc.Number);
                    worksheet.Cell(row + 2, 14).Value = string.Join(Environment.NewLine, notes);
                    worksheet.Cell(row + 2, 14).Style.Alignment.WrapText = true; // Permite quebras de linha
                }

                worksheet.Columns().AdjustToContents(); // Ajusta largura automaticamente
                workbook.SaveAs(filePath);
            }
        }

    }
}

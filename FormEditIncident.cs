using IssueWatcher.Model;
using IssueWatcher.Services;
using IssueWatcher.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace IssueWatcher
{
    public partial class FormEditIncident : Form
    {
        private SortableBindingList<Incident> listIncidents;
        private HashSet<string> _incidentNumbersWithNotes;
        private Color _corTag = Color.YellowGreen;

        public FormEditIncident()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            var configReader = new ConfigReader();
            var service = new IncidentService(configReader.GetValue("database"));

            dgvIncidents.AutoGenerateColumns = false;

            var numberCriteria = cboRecordsToLoad.Text;

            List<Incident> incidents = service.GetAll(numberCriteria);
            listIncidents = new SortableBindingList<Incident>(incidents);

            btnExport.Enabled = false;
            btnStat.Enabled = false;

            btnGoTo.Enabled = false;

            if (incidents.Count == 0)
            {
                MessageBox.Show("Nenhum incidente encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
                _incidentNumbersWithNotes = service.GetIncidentNumbersWithNotes();
                btnExport.Enabled = true;
                btnStat.Enabled = true;
            }

            dgvIncidents.DataSource = listIncidents;

            MarcarIncidenteAtual();

        }

        private void MarcarIncidenteAtual()
        {
            var configReader = new ConfigReader();
            var service = new IncidentService(configReader.GetValue("database"));

            // Marcar a célula "Tag" do incidente atual
            string currentIncidentNumber = service.GetCurrentIncident();
            if (!string.IsNullOrEmpty(currentIncidentNumber))
            {
                foreach (DataGridViewRow row in dgvIncidents.Rows)
                {
                    if (row.Cells["number"].Value?.ToString() == currentIncidentNumber)
                    {
                        row.Cells["Tag"].Style.BackColor = _corTag;
                    }
                    else
                    {
                        row.Cells["Tag"].Style.BackColor = dgvIncidents.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

        private void FormEditIncident_Load(object sender, EventArgs e)
        {
            cboRecordsToLoad.SelectedIndex = cboRecordsToLoad.Items.Count - 1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e tecla backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // cancela o caractere
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            string filterValue = txtNumber.Text.Trim();

            if (listIncidents == null) return;

            if (string.IsNullOrEmpty(filterValue))
            {
                // mostra todos
                dgvIncidents.DataSource = listIncidents;
            }
            else
            {
                // filtra apenas números que contêm o valor digitado no campo Number
                var filtered = new SortableBindingList<Incident>(
                    listIncidents.Where(i => i.Number != null && i.Number.Contains(filterValue)).ToList()
                );

                dgvIncidents.DataSource = filtered;
            }
        }

        private void dgvIncidents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvIncidents.Columns["Action"].Index && e.RowIndex >= 0)
            {
                var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value.ToString();

                FormIncidentNotes formIncidentNotes = new FormIncidentNotes();
                formIncidentNotes.IncidentNumber = number;
                formIncidentNotes.Text = $"Edit notes for incident {number}";
                formIncidentNotes.ShowDialog();

            }

            btnGoTo.Enabled = false;
            if (e.RowIndex > -1)
            {
                var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value.ToString();
                toolTip1.SetToolTip(btnGoTo, $"Ir para o chamado {number} no MyServices.");
                btnGoTo.Enabled = true;
                
            }
        }

        private void dgvIncidents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIncidents.Columns[e.ColumnIndex].Name == "assigned_to")
            {
                var linha = dgvIncidents.Rows[e.RowIndex];
                var valorEditado = linha.Cells[e.ColumnIndex].Value?.ToString();
                var numero = linha.Cells["number"].Value?.ToString();

                if (MessageBox.Show(
                     $"Deseja realmente atualizar o valor para '{valorEditado}'?",
                    "Confirmação",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    dgvIncidents.CancelEdit();
                    return;
                }

                try
                {
                    ConfigReader reader = new ConfigReader();

                    IncidentService service = new IncidentService(reader.GetValue("database"));
                    if (service.Update(numero, valorEditado))
                    {
                        MessageBox.Show("Value updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Error updating value: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(dgvIncidents.Columns[e.ColumnIndex].Name == "Priority")
            {
                var linha = dgvIncidents.Rows[e.RowIndex];
                var valorEditado = linha.Cells[e.ColumnIndex].Value?.ToString();
                var numero = linha.Cells["number"].Value?.ToString();

                if (MessageBox.Show(
                    $"Deseja realmente alterar a prioridade do incidente {numero} para {valorEditado}?",
                        "Confirmação",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    dgvIncidents.CancelEdit();
                    return;
                }

                try
                {
                    ConfigReader reader = new ConfigReader();

                    IncidentService service = new IncidentService(reader.GetValue("database"));
                    if (service.UpdateIncidentPriority(numero, valorEditado))
                    {
                        MessageBox.Show("Priority updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Error updating priority: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if ((listIncidents == null) || (listIncidents.Count == 0))
            {
                MessageBox.Show("Nada a exportar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "Incidents.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Importer.ExportIncidentsWithNotes(sfd.FileName);
                        MessageBox.Show("Data successfully exported", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvIncidents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignora células fora do conteúdo (como cabeçalhos)
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvIncidents.Columns[e.ColumnIndex].Name != "Action")
                return;

            // A partir daqui é seguro acessar a linha
            string incidentNumber = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value?.ToString();

            bool hasNote = !string.IsNullOrEmpty(incidentNumber)
                && _incidentNumbersWithNotes != null
                && _incidentNumbersWithNotes.Contains(incidentNumber);

            e.PaintBackground(e.CellBounds, true);

            using (Brush brush = new SolidBrush(hasNote ? ColorTranslator.FromHtml("#c2ccf2") : SystemColors.Control))
            {
                Rectangle rect = e.CellBounds;
                rect.Inflate(-2, -2);
                e.Graphics.FillRectangle(brush, rect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                "...",
                dgvIncidents.Font,
                e.CellBounds,
                hasNote ? Color.White : SystemColors.ControlText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigReader reader = new ConfigReader();

                IncidentService service = new IncidentService(reader.GetValue("database"));
                var stats = service.GetStatistics();

                FormStatistics statsForm = new FormStatistics();
                statsForm.Stats = stats;
                statsForm.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error retrieving statistics: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGoTo_Click(object sender, EventArgs e)
        {
            if (dgvIncidents.CurrentRow != null)
            {
                var number = dgvIncidents.CurrentRow.Cells["number"].Value.ToString();
                string url = $"https://myservices.abb.com/cs_gr?id=search&spa=1&q={number}";

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        private void dgvIncidents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvIncidents.Columns[e.ColumnIndex].Name == "Tag")
            {
                var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value?.ToString();
                var cell = dgvIncidents.Rows[e.RowIndex].Cells["Tag"];
                var defaultColor = dgvIncidents.DefaultCellStyle.BackColor;

                try
                {
                    var configReader = new ConfigReader();
                    var service = new IncidentService(configReader.GetValue("database"));

                    // Verifica se a célula está marcada
                    if (cell.Style.BackColor == _corTag)
                    {
                        // Desmarca visualmente
                        cell.Style.BackColor = defaultColor;

                        // Remove da tabela
                        bool deleted = service.DeleteCurrentIncident(number);
                        if (deleted)
                        {
                            MessageBox.Show($"Incidente {number} desmarcado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Falha ao remover incidente atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Aplica a cor padrão em todas as células da coluna "Tag"
                        foreach (DataGridViewRow row in dgvIncidents.Rows)
                        {
                            row.Cells["Tag"].Style.BackColor = defaultColor;
                        }

                        // Marca visualmente
                        cell.Style.BackColor = _corTag;

                        // Atualiza na tabela
                        bool updated = service.UpdateCurrentIncident(number);
                        if (updated)
                        {
                            MessageBox.Show($"Incidente {number} marcado como atual.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Erro ao processar incidente: {exc.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvIncidents_Sorted(object sender, EventArgs e)
        {
            MarcarIncidenteAtual();
        }
    }
}

using IssueWatcher.Model;
using IssueWatcher.Services;
using IssueWatcher.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueWatcher
{
    public partial class FormEditIncident : Form
    {
        private SortableBindingList<Incident> listIncidents;

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

            if (incidents.Count == 0)
            {
                MessageBox.Show("Nenhum incidente encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dgvIncidents.DataSource = listIncidents;
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
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormIncidentNotes : Form
    {
        public string IncidentNumber { get; set; }

        public bool Changed { get; set; } = false;

        public FormIncidentNotes()
        {
            InitializeComponent();
        }

        private void dgvNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (dgvNotes.CurrentCell == null || dgvNotes.CurrentRow == null)
                return;

            var row = dgvNotes.CurrentRow;

            if (dgvNotes.CurrentCell.Value != null &&
                MessageBox.Show(
                    Properties.Resources.REMOVE_LINE_CONFIRMATION,
                    "Confirmation", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            bool shouldRemoveRow = !row.IsNewRow && dgvNotes.Rows.Count > 1;

            Action clearCells = () =>
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = null;
                }
            };

            Action actionToExecute = shouldRemoveRow
                ? (Action)(() => dgvNotes.Rows.Remove(row))
                : clearCells;

            actionToExecute();
        }

        private void FormIncidentNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((Changed)
             && (MessageBox.Show("Confirma as alterações?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                List<string> notes = new List<string>();
                foreach (DataGridViewRow row in dgvNotes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var valor = row.Cells["Note"].Value?.ToString();
                        if (!string.IsNullOrEmpty(valor))
                            notes.Add(valor);
                    }
                }

                ConfigReader reader = new ConfigReader();
                IncidentService service = new IncidentService(reader.GetValue("database"));

                service.ReplaceNotes(IncidentNumber, notes);
            }
        }

        private void FormIncidentNotes_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IncidentNumber))
                return;

            ConfigReader reader = new ConfigReader();
            IncidentService service = new IncidentService(reader.GetValue("database"));

            List<string> notes = service.GetNotes(IncidentNumber);

            dgvNotes.Rows.Clear();
            foreach (var note in notes)
            {
                dgvNotes.Rows.Add(note);
            }

            Changed = false;
        }

        private void dgvNotes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Changed = true;
        }

        private void dgvNotes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) => Changed = true;

        private void dgvNotes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) => Changed = true;
    }
}

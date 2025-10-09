using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormIncidentNotes : Form
    {
        public string IncidentNumber { get; set; }

        private readonly IncidentService _incidentService;
        private readonly ConfigReader _configReader;


        public bool Changed { get; set; } = false;

        public FormIncidentNotes()
        {
            InitializeComponent();

            _configReader = new ConfigReader();
            _incidentService = new IncidentService(_configReader.GetDatabaseName());
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
             && (MessageBox.Show(
                 Properties.Resources.APPLY_ISSUE_CHANGES.Replace("{number}", IncidentNumber), 
                 "Confirm", 
                 MessageBoxButtons.YesNo, 
                 MessageBoxIcon.Question) == DialogResult.No))
            {
                return;
            }
            
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

            _incidentService.ReplaceNotes(IncidentNumber, notes);
        }

        private void FormIncidentNotes_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IncidentNumber))
                return;

            List<string> notes = _incidentService.GetNotes(IncidentNumber);

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

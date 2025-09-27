using IssueWatcher.Services;
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
    public partial class FormIncidentNotes : Form
    {
        public string IncidentNumber { get; set; }

        public bool Alterou { get; set; } = false;

        public FormIncidentNotes()
        {
            InitializeComponent();
        }

        private void dgvNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                if ((dgvNotes.CurrentCell.Value != null)
                    && (MessageBox.Show("Excluir a coluna?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                {
                    return;
                }

                if (e.KeyCode == Keys.Delete && dgvNotes.CurrentRow != null)
                {
                    var row = dgvNotes.CurrentRow;

                    if (!row.IsNewRow && dgvNotes.Rows.Count > 1)
                    {
                        dgvNotes.Rows.Remove(row);
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Value = null;
                        }
                    }
                }
            }
        }

        private void FormIncidentNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((Alterou)
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

            Alterou = false;
        }

        private void dgvNotes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Alterou = true;
        }

        private void dgvNotes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Alterou = true;
        }

        private void dgvNotes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Alterou = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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

        private void FormIncidentNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((Changed)
             && (MessageBox.Show(
                 Properties.Resources.APPLY_ISSUE_CHANGES.Replace("{number}", IncidentNumber), 
                 "Confirm", 
                 MessageBoxButtons.YesNo, 
                 MessageBoxIcon.Question) == DialogResult.No))
                return;

            _incidentService.ReplaceNote(IncidentNumber, txtNote.Text);
        }

        private void FormIncidentNotes_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IncidentNumber))
                return;

            List<string> notes = _incidentService.GetNotes(IncidentNumber);
            if (notes.Any())
            {
                txtNote.Text = notes.LastOrDefault() ?? "";
                txtNote.SelectionStart = txtNote.Text.Length;
                txtNote.SelectionLength = 0;                 
            }


            Changed = false;
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
        }
    }
}

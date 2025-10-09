using System;
using System.Windows.Forms;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetDatabaseLocation();
        }

        public void SetDatabaseLocation()
        {
            ConfigReader configReader = new ConfigReader();
            statusLabel.Text = $"Current database: {configReader.GetDatabaseName()}";
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport formImport = new FormImport();
            formImport.ShowDialog();
        }

        private void editIncidentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIncidents formEditIncident = new FormIncidents();
            formEditIncident.MdiParent = this;
            formEditIncident.Show();
        }

    }
}

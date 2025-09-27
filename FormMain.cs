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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();

            SetDatabaseLocation();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetDatabaseLocation();
        }

        public void SetDatabaseLocation()
        {
            ConfigReader configReader = new ConfigReader();
            statusLabel.Text = $"Current database: {configReader.GetValue("database")}";
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport formImport = new FormImport();
            formImport.ShowDialog();
        }

        private void editIncidentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditIncident formEditIncident = new FormEditIncident();
            formEditIncident.MdiParent = this;
            formEditIncident.Show();
        }

    }
}

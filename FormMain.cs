using IssueWatcher.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace IssueWatcher
{
    public partial class FormMain : Form
    {

        private readonly string _backgroundColor = "#DBE9F4"; // Cor de fundo do espaço MDI
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
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient client)
                {   
                    client.BackColor = ColorTranslator.FromHtml(_backgroundColor);
                    break;
                }
            }
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

        private void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTemplates formTemplates = new FormTemplates();
            formTemplates.MdiParent = this;
            formTemplates.Show();
        }
    }
}

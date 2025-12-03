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
    public partial class FormReplaceStatus : Form
    {
        private readonly IncidentService _incidentService;
        private readonly ConfigReader _configReader;
        private readonly int _pnlStateTop;
        private readonly int _pnlStatusTop;

        public FormReplaceStatus()
        {
            InitializeComponent();

            _pnlStateTop = pnlState.Top;
            _pnlStatusTop = pnlStatus.Top;

            _configReader = new ConfigReader();
            _incidentService = new IncidentService(_configReader.GetDatabaseName());
        }

        private void LoadLocalStatus()
        {
            cboStatus.DataSource = null;
            cboStatus.DataSource = _incidentService.GetAllLocalStatuses();
        }

        private void LoadStates()
        {
            cboState.DataSource = null;
            cboState.DataSource = _incidentService.GetAllStates();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            pnlState.Top = _pnlStatusTop;
            pnlStatus.Top = _pnlStateTop;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            pnlState.Top = _pnlStateTop;
            pnlStatus.Top = _pnlStatusTop;
        }

        private void FormReplaceStatus_Load(object sender, EventArgs e)
        {
            LoadLocalStatus();
            LoadStates();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string message;

            if (pnlState.Top < pnlStatus.Top)
            {
                message =
                    "You are about to perform a bulk update.\n\n" +
                    $"All incidents currently classified with State '{cboState.Text}'\n" +
                    $"will be changed so that their Local Status becomes '{cboStatus.Text}'.\n\n" +
                    "Do you want to proceed with this modification?";

                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                int updated = _incidentService.BulkUpdate(cboState.Text, cboStatus.Text, true);
                MessageBox.Show($"{updated} incidents were updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                message =
                    "You are about to perform a bulk update.\n\n" +
                    $"All incidents currently classified with Local Status '{cboStatus.Text}'\n" +
                    $"will be changed so that their State becomes '{cboState.Text}'.\n\n" +
                    "Do you want to proceed with this modification?";

                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                int updated = _incidentService.BulkUpdate(cboStatus.Text, cboState.Text, false);
                MessageBox.Show($"{updated} incidents were updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

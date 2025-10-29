using System;
using System.Windows.Forms;
using IssueWatcher.Model;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormEditIncident : Form
    {
        public string Number { get; set; }

        public string AssignedToUpdated { get; set; }
        public string PriorityUpdated { get; set; }
        public string StateUpdated { get; set; }
        public string LocalStatusUpdated { get; set; }
        public string IssueType { get; set; }
        public bool Changed { get; set; } = false;

        private IncidentService _incidentService;
        private bool _isLoading = false;

        public FormEditIncident()
        {
            InitializeComponent();

            ConfigReader configReader = new ConfigReader();
            _incidentService = new IncidentService(configReader.GetDatabaseName());
        }

        private void CarregarListas()
        {
            cboAssignedTo.Items.Clear();
            var listAssignedTo = _incidentService.GetAllAssignedTo();
            foreach (var item in listAssignedTo)
            {
                cboAssignedTo.Items.Add(item);
            }

            cboState.Items.Clear();
            var listStates = _incidentService.GetAllStates();
            foreach (var state in listStates)
            {
                cboState.Items.Add(state);
            }

            cboLocalStatus.Items.Clear();
            var listStatus = _incidentService.GetAllLocalStatuses();
            foreach (var status in listStatus)
            {
                cboLocalStatus.Items.Add(status);
            }

            cboIssueType.Items.Clear();
            var listIssueType = _incidentService.GetAllIssueTypes();
            foreach (var issueType in listIssueType)
            {
                cboIssueType.Items.Add(issueType);
            }
        }

        private void FormEditIncident_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            CarregarListas();


            if (!string.IsNullOrEmpty(Number)) 
            {
                var incidentToEdit = _incidentService.GetIncidentByNumber(Number);

                txtAssignmentGroup.Text = incidentToEdit.AssignmentGroup;
                txtNumber.Text = incidentToEdit.Number;
                cboState.Text = incidentToEdit.State;
                txtCaller.Text = incidentToEdit.Caller;
                cboAssignedTo.Text = incidentToEdit.AssignedTo;
                cboPriority.Text = incidentToEdit.LocalPriority;
                txtCreated.Text = incidentToEdit.Created;
                txtUpdated.Text = incidentToEdit.Updated;
                txtConfigurationItem.Text = incidentToEdit.ConfigurationItem;
                txtSlaDue.Text = incidentToEdit.SlaDue;
                txtEmail.Text = incidentToEdit.Email;
                txtShortDescription.Text = incidentToEdit.ShortDescription;
                cboLocalStatus.Text = incidentToEdit.LocalStatus;
                cboIssueType.Text = incidentToEdit.IssueType;
            }

            _isLoading = false;
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            if (!_isLoading)
                Changed = true;
        }

        private void FormEditIncident_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Changed) return;

            string message = Properties.Resources.APPLY_ISSUE_CHANGES.Replace("{number}", Number);

            if (MessageBox.Show(message,
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_incidentService.UpdateIncident(
                number: Number, 
                state: cboState.Text, 
                assignedTo: cboAssignedTo.Text,
                localStatus: cboLocalStatus.Text, 
                localPriority: cboPriority.Text,
                issueType: cboIssueType.Text))
            {
                AssignedToUpdated = cboAssignedTo.Text;
                PriorityUpdated = cboPriority.Text;
                StateUpdated = cboState.Text;
                LocalStatusUpdated = cboLocalStatus.Text;
                IssueType = cboIssueType.Text;
            }
        }
    }
}

using System;
using System.Windows.Forms;
using IssueWatcher.Model;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormParameters : Form
    {
        private readonly AppParameterService _appParameterService;
        private bool _isEdit = false;
        private bool _isLoading = false;

        public FormParameters()
        {
            InitializeComponent();

            ConfigReader config = new ConfigReader();

            _appParameterService = new AppParameterService(config.GetDatabaseName());
        }


        private void SetNewParameter()
        {
            txtKey.Enabled = true;
            txtKey.Text = "";
            txtValue.Text = "";
            txtDescription.Text = "";

            btnCopyToClipboard.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            _isLoading = true;
            lstParameters.ClearSelected();
            _isLoading = false;

            _isEdit = false;
        }

        private void ApplyChanges()
        {
            if (!ValidateChanges())
            {
                MessageBox.Show(Properties.Resources.INVALID_PARAMETERS_DATA, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                bool saved = false;

                if (!_isEdit)
                {
                    var existing = _appParameterService.GetByKey(txtKey.Text);
                    if (existing != null)
                    {
                        MessageBox.Show(Properties.Resources.INVALID_PARAMETER_KEY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AppParameter appParameterToInsert = new AppParameter
                    {
                        Key = txtKey.Text,
                        Value = txtValue.Text,
                        Description = txtDescription.Text,
                    };

                    saved = _appParameterService.Insert(appParameterToInsert);
                }
                else
                {
                    AppParameter appParameterToUpdate = new AppParameter
                    {
                        Id = Int32.Parse(lstParameters.SelectedValue.ToString()),
                        Key = txtKey.Text,
                        Value = txtValue.Text,
                        Description = txtDescription.Text,
                    };

                    saved = _appParameterService.Update(appParameterToUpdate);
                }

                if (saved)
                {
                    MessageBox.Show(Properties.Resources.SUCCESSFULL_APPLIED, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadParametersList();
                    SetNewParameter();
                    return;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(Properties.Resources.ERROR_APPLYING_CHANGES.Replace("{error}", exc.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void DeleteParameter()
        {
            if (MessageBox.Show(Properties.Resources.PARAMETER_DELETE_CONFIRMATION, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
            {
                return;
            }

            try
            {
                if (lstParameters.SelectedItem != null)
                {
                    bool deleted = false;

                    deleted = _appParameterService.Delete(((AppParameter)lstParameters.SelectedItem).Key);
                    if (deleted)
                    {
                        MessageBox.Show(Properties.Resources.SUCCESSFULL_DELETED, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadParametersList();
                        SetNewParameter();
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(Properties.Resources.ERROR_APPLYING_CHANGES.Replace("{error}", exc.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidateChanges()
        {
            return (!string.IsNullOrEmpty(txtKey.Text) && !string.IsNullOrEmpty(txtValue.Text));
        }

        private void FormParameters_Load(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnCopyToClipboard.Enabled = false;

            LoadParametersList();

        }

        private void LoadParametersList()
        {
            _isLoading = true;

            lstParameters.ValueMember = "id";
            lstParameters.DisplayMember = "key";
            lstParameters.DataSource = _appParameterService.GetAll();

            lstParameters.ClearSelected();

            _isLoading = false;
        }

        private void lstParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (lstParameters.SelectedItem != null)
            {
                var appParameter = _appParameterService.GetByKey(((AppParameter)lstParameters.SelectedItem).Key);
                if (appParameter != null)
                {
                    txtKey.Text = appParameter.Key;
                    txtValue.Text = appParameter.Value;
                    txtDescription.Text = appParameter.Description;
                }

                btnDelete.Enabled = true;
                btnCopyToClipboard.Enabled = true;

                txtKey.Enabled = false;


                _isEdit = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNewParameter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteParameter();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                MessageBox.Show(Properties.Resources.NOTHING_TO_COPY, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Clipboard.SetText(txtValue.Text);
            MessageBox.Show(Properties.Resources.SUCCESSFULL_COPIED_TO_CLIPBOARD, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormParameters_Shown(object sender, EventArgs e)
        {
            txtKey.Focus();
        }
    }
}

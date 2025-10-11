using System;
using System.IO;
using System.Windows.Forms;
using IssueWatcher.Services;

namespace IssueWatcher
{
    public partial class FormImport : Form
    {
        private string _fileName;
        private readonly IncidentService _incidentService;
        private readonly IncidentDataTransfer _incidentDataTransfer;
        private readonly ConfigReader _configReader;

        public FormImport()
        {
            InitializeComponent();

            _configReader = new ConfigReader();
            _incidentService = new IncidentService(_configReader.GetDatabaseName());
            _incidentDataTransfer = new IncidentDataTransfer(_configReader);
        }

        private void ImportIssues()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _incidentDataTransfer.ImportIncidents(_fileName);

                Cursor = Cursors.Default;
                MessageBox.Show(Properties.Resources.SUCCESSFULL_IMPORTING,
                                    "Sucess", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);

                Close();
            }
            catch (InvalidDataException iex)
            {
                MessageBox.Show(Properties.Resources.ERROR_IMPORTING.Replace("{error}", iex.Message) , 
                                    "Error", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Resources.ERROR_IMPORTING.Replace("{error}", ex.Message),
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void txtSpreadsheetLocation_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Pick up an Excel file (.xlsx or .xls)";
            openFileDialog.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";

            openFileDialog.FilterIndex = 1;
            openFileDialog.CheckFileExists = true;

            btnImport.Enabled = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSpreadsheetLocation.Text = openFileDialog.FileName;
                _fileName = openFileDialog.FileName;

                btnImport.Enabled = true;
            }
        }

        private void btnImport_Click(object sender, EventArgs e) => ImportIssues();
    }
}

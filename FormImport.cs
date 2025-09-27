using IssueWatcher.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueWatcher
{
    public partial class FormImport : Form
    {
        private string _fileName;
        private string _databaseFile;

        public FormImport()
        {
            InitializeComponent();
        }

        private void ImportarIncidentes()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Importer.ImportIncidents(_databaseFile, _fileName);

                this.Cursor = Cursors.Default;
                MessageBox.Show("Data successfully imported.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (InvalidDataException iex)
            {
                MessageBox.Show("Error importing issues:\n" + iex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing issues:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void txtSpreadsheetLocation_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Pick up Spreadsheet File (.xlsx or .xls)";
            openFileDialog.Filter = "Database File (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";

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

        private void FormImport_Load(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ConfigReader reader = new ConfigReader();
            _databaseFile = reader.GetValue("database");

            ImportarIncidentes();
        }
    }
}

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
    public partial class FormSettings : Form
    {
        private readonly ConfigReader configReader;

        public FormSettings()
        {
            InitializeComponent();
            configReader = new ConfigReader();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            txtDatabaseLocation.Text = configReader.GetValue("database");
            var columns = configReader.GetValue("spreadsheet");

            if ((!string.IsNullOrEmpty(columns)) && (columns.Contains(",")))
            {
                var columnsList = columns.Split(',').ToList();
                lstColumns.Items.Clear();
                columnsList.ForEach(c =>
                {
                    lstColumns.Items.Add(c);
                });
            }
        }

        private void txtDatabaseLocation_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Pick up Database File (.db or .sqlite)";
            openFileDialog.Filter = "Database File (*.db;*.sqlite)|*.db;*.sqlite|All Files (*.*)|*.*";

            openFileDialog.FilterIndex = 1;
            openFileDialog.CheckFileExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDatabaseLocation.Text = openFileDialog.FileName;
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string newDatabasePath = txtDatabaseLocation.Text;
                configReader.SetValue("database", newDatabasePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível salvar a configuração! Detalhes: {ex.Message}",
                                "Erro ao Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void txtCreateDatabase_DoubleClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Database File (chamados.db)";
            saveFileDialog.Filter = "Database File (*.db)|*.db";
            saveFileDialog.FileName = "chamados.db";

            btnCreate.Enabled = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCreateDatabase.Text = saveFileDialog.FileName;
                btnCreate.Enabled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
                "Tem certeza? Essa ação irá excluir todos os chamados existentes e criará uma nova base de dados.",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                if (IncidentService.RecreateDatabase(txtCreateDatabase.Text))
                {
                    configReader.SetValue("database", txtCreateDatabase.Text);

                    MessageBox.Show($"Database successfully created.  Application will be close and using {txtCreateDatabase.Text} from now on.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

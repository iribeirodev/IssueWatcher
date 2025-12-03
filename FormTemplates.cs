using IssueWatcher.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueWatcher
{
    public partial class FormTemplates : Form
    {
        private readonly TemplateService _templateService;
        private readonly AppParameterService _appParameterService;
        private bool _loading = false;
        private bool _isEdit = true;

        private bool _changed = false;

        public FormTemplates()
        {
            InitializeComponent();

            _templateService = new TemplateService();
            ConfigReader config = new ConfigReader();
            _appParameterService = new AppParameterService(config.GetDatabaseName());
        }

        private void LoadTemplatesList()
        {
            _loading = true;

            btnUndo.Enabled = false;

            cboTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemplates.Items.Clear();

            var templates = _templateService.ReadAllTemplates();
            foreach (var item in templates)
            {
                cboTemplates.Items.Add(item);
            }

            if (templates.Count > 0)
                cboTemplates.SelectedIndex = 0;

            _loading = false;
            _isEdit = true;
        }

        private void SetNewTemplate()
        {
            btnUndo.Enabled = true;

            _isEdit = false;

            cboTemplates.DropDownStyle = ComboBoxStyle.DropDown;
            cboTemplates.Text = "";

            rtfContent.Clear();

            cboTemplates.Focus();
        }

        private void ApplyChanges()
        {
            if (!ValidateChanges())
            {
                MessageBox.Show(
                    Properties.Resources.TEMPLATE_INVALID_INFO,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!IsValidFileName(cboTemplates.Text))
            {
                MessageBox.Show(
                    Properties.Resources.INVALID_FILE_NAME,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                if (_templateService.SaveTemplate($"{cboTemplates.Text.Trim()}.rtf", rtfContent.Rtf))
                {
                    MessageBox.Show(
                        Properties.Resources.SUCCESSFULL_APPLIED,
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    rtfContent.Clear();

                    LoadTemplatesList(); 
                } else
                {
                    MessageBox.Show(
                        Properties.Resources.ERROR_APPLYING_CHANGES.Replace("{error}", ""),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    Properties.Resources.ERROR_APPLYING_CHANGES.Replace("{error}", exc.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            
        }

        private bool IsValidFileName(string fileName)
        {
            // Verifica se a string é nula ou vazia
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            // Obtém a lista de caracteres inválidos para nomes de arquivo no Windows
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Itera pela string para verificar se algum caractere inválido está presente
            foreach (char c in fileName)
            {
                if (Array.IndexOf(invalidChars, c) >= 0)
                {
                    return false;
                }
            }

            // Verifica o comprimento máximo do caminho (MAX_PATH)
            if (fileName.Length > 256)
            {
                return false;
            }

            return true;
        }

        private bool ValidateChanges()
        {
            return (!string.IsNullOrEmpty(cboTemplates.Text) && !string.IsNullOrEmpty(rtfContent.Text));
        }

        private void UndoNewTemplate()
        {
            LoadTemplatesList();
        }

        private void ChangeText()
        {
            string texto = rtfContent.Text;
            string[] tokens = texto.Split(' ');

            var macroWords = tokens.Where(t => t.StartsWith("!") && t != "!").ToList();

            foreach (var macroWord in macroWords)
            {
                var parameter = _appParameterService.GetByKey(macroWord);
                if (parameter != null)
                {
                    // Substitui no texto original o token pelo valor do parâmetro
                    texto = texto.Replace(macroWord, parameter.Value);
                }
            }

            rtfContent.Text = texto;
            MessageBox.Show("Ready.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormTemplates_Load(object sender, EventArgs e)
        {
            LoadTemplatesList();
        }

        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string template = cboTemplates.Text;

            var content = _templateService.GetTextContent(template);

            rtfContent.Rtf = content;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNewTemplate();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UndoNewTemplate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void rtfContent_TextChanged(object sender, EventArgs e)
        {
            if (!_loading)
                _changed = true;
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            ChangeText();
        }
    }
}

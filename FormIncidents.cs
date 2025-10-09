using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IssueWatcher.Enums;
using IssueWatcher.Model;
using IssueWatcher.Services;
using IssueWatcher.Utils;

namespace IssueWatcher
{
    public partial class FormIncidents : Form
    {
        private readonly IncidentService _incidentService;
        private readonly IncidentDataTransfer _incidentDataTransfer;
        private readonly ConfigReader _configReader;

        private const string INCIDENT_URL_SEARCH = "https://myservices.abb.com/cs_gr?id=search&spa=1&q={number}";

        private readonly Color TAG_COLOR = ColorTranslator.FromHtml(Properties.Resources.TAG_COLOR);
        private readonly Color NOTES_COLOR = ColorTranslator.FromHtml(Properties.Resources.NOTES_COLOR);
        

        private SortableBindingList<Incident> listIncidents;
        private HashSet<string> _incidentNumbersWithNotes;  // Incidentes com anotações

        private FormEditIncident formEditIncident;          // Tela de edição de dados de incidentes
        private FormIncidentNotes formIncidentNotes;        // Tela de anotações sobre incidentes
        private FormStatistics formStatistics;              // Tela de apresentação de estatísticas


        public FormIncidents()
        {
            InitializeComponent();

            _configReader = new ConfigReader();
            _incidentService = new IncidentService(_configReader.GetDatabaseName());
            _incidentDataTransfer = new IncidentDataTransfer(_configReader);
        }

        /// <summary>
        /// Configura estado dos botões e controles da tela
        /// </summary>
        public void SetControlState(EnumControlState state)
        {
            switch (state)
            {
                case EnumControlState.Initial:
                    txtSearchNumber.Enabled = false;
                    cboSearchState.Enabled = false;

                    btnLoad.Enabled = true;
                    btnEdit.Enabled = false;
                    btnStat.Enabled = false;
                    btnGoTo.Enabled = false;
                    btnExport.Enabled = false;

                    cboRecordsToLoad.SelectedIndex = cboRecordsToLoad.Items.Count - 1;

                    break;
                case EnumControlState.Loaded:
                    txtSearchNumber.Enabled = true;
                    txtSearchNumber.Text = "";

                    cboSearchState.Enabled = true;
                    cboSearchState.SelectedIndex = -1;

                    btnLoad.Enabled = true;
                    btnEdit.Enabled = false;
                    btnStat.Enabled = true;
                    btnGoTo.Enabled = false;
                    btnExport.Enabled = true;
                    break;
                case EnumControlState.Selected:
                    txtSearchNumber.Enabled = true;
                    cboSearchState.Enabled = true;

                    btnLoad.Enabled = true;
                    btnEdit.Enabled = true;
                    btnStat.Enabled = true;
                    btnGoTo.Enabled = true;
                    btnExport.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Carrega os dados de incidentes para a grid
        /// </summary>
        public void LoadData()
        {
            dgvIncidents.AutoGenerateColumns = false;

            var numberCriteria = cboRecordsToLoad.Text;

            List<Incident> incidents = _incidentService.GetAll(numberCriteria);
            listIncidents = new SortableBindingList<Incident>(incidents);

            if (incidents.Count == 0)
            {
                MessageBox.Show("Nenhum incidente encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Carrega números de incidentes com anotações
            _incidentNumbersWithNotes = _incidentService.GetIncidentNumbersWithNotes();

            dgvIncidents.DataSource = listIncidents;

            SetControlState(EnumControlState.Loaded);
            SetIncidentAsCurrent();
        }

        /// <summary>
        /// Marca o incidente como atual.
        /// </summary>
        private void SetIncidentAsCurrent()
        {
            string currentIncidentNumber = _incidentService.GetCurrentIncident();
            if (string.IsNullOrEmpty(currentIncidentNumber))
            {
                return;
            }

            foreach (DataGridViewRow row in dgvIncidents.Rows)
            {
                if (row.Cells["number"].Value?.ToString() == currentIncidentNumber)
                {
                    row.Cells["Tag"].Style.BackColor = TAG_COLOR;
                    break;
                }

                row.Cells["Tag"].Style.BackColor = dgvIncidents.DefaultCellStyle.BackColor;
            }
        }

        /// <summary>
        /// Ordena a lista pelas colunas created ou updated
        /// </summary>
        private void SortListByDateFields(string columnName)
        {
            // Só processa colunas de data ===
            if (columnName != "created" && columnName != "updated")
                return;

            // Alternância da Direção de Ordenação

            // Obtém a direção atual (se for 'asc' ou nulo/diferente, será 'asc' por padrão).
            bool isAscending = dgvIncidents.Tag != null && dgvIncidents.Tag.ToString() == "asc";
            bool ascending = !isAscending;

            // Atualiza o Tag do DataGridView para a próxima chamada.
            dgvIncidents.Tag = ascending ? "asc" : "desc";


            // Verifica se há um filtro de estado ativo.
            bool hasStateFilter = !string.IsNullOrEmpty(cboSearchState.Text);
            string criteria = cboSearchState.Text;

            // Cria a lista de incidentes a ser ordenada:
            SortableBindingList<Incident> listToSort = hasStateFilter
                // Se houver filtro, filtra a lista original.
                ? new SortableBindingList<Incident>(
                    listIncidents.Where(i => i.State != null && i.State == criteria).ToList()
                )
                // Se não houver filtro, usa a lista completa.
                : listIncidents;

            // Função helper para parse seguro da data (para usar no LINQ).
            Func<Incident, DateTime> dateSelector = i =>
                System.DateTime.TryParse(columnName == "created" ? i.Created : i.Updated, out var dt)
                ? dt : System.DateTime.MinValue;

            // Seleciona a ordenação (Ascendente ou Descendente)
            var sortedList = ascending
                ? listToSort.OrderBy(dateSelector).ToList()
                : listToSort.OrderByDescending(dateSelector).ToList();

            dgvIncidents.DataSource = new SortableBindingList<Incident>(sortedList);

        }

        /// <summary>
        /// Exportação dos incidentes com todas as informações inclusive anotações para o Excel.
        /// </summary>
        private void ExportIncidentsToExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "Incidents.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;

                    _incidentDataTransfer.ExportIncidentsWithNotes(sfd.FileName);

                    Cursor = Cursors.Default;
                    MessageBox.Show(Properties.Resources.ISSUES_EXPORTED_TO_EXCEL, 
                            "Success", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(Properties.Resources.ERROR_EXPORTING.Replace("{error}", ex.Message), 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Marca incidente como atual na grid 
        /// </summary>
        private void TagIncident(DataGridViewCell cell, string number, Color defaultColor)
        {
            // Limpa tags anteriores em todas as linhas.
            foreach (DataGridViewRow row in dgvIncidents.Rows)
            {
                row.Cells["Tag"].Style.BackColor = defaultColor;
            }

            cell.Style.BackColor = TAG_COLOR;
            bool updated = _incidentService.UpdateCurrentIncident(number);

            string message = updated
                ? Properties.Resources.ISSUE_TAGGED_AS_DEFAULT.Replace("{number}", number)
                : Properties.Resources.ERROR_TAGGING_AS_DEFAULT;

            MessageBoxIcon icon = updated ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, updated ? "Information" : "Error", MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Desmarca incidente atual na grid
        /// </summary>
        private void UntagIncident(DataGridViewCell cell, string number, Color defaultColor)
        {
            cell.Style.BackColor = defaultColor;
            bool deleted = _incidentService.DeleteCurrentIncident(number);

            string message = deleted
                ? Properties.Resources.ISSUE_UNTAGGED.Replace("{number}", number)
                : Properties.Resources.ERROR_UNTAGGING_ISSUE;

            MessageBoxIcon icon = deleted ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, deleted ? "Information" : "Error", MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Abre a página de incidentes para consulta por número
        /// </summary>
        private void GoToIncidentPage()
        {
            if (dgvIncidents.CurrentRow != null)
            {
                var number = dgvIncidents.CurrentRow.Cells["number"].Value.ToString();

                Process.Start(new ProcessStartInfo
                {
                    FileName = INCIDENT_URL_SEARCH.Replace("{number}", number),
                    UseShellExecute = true
                });
            }
        }

        private void FormEditIncident_Load(object sender, EventArgs e)
        {
            SetControlState(EnumControlState.Initial);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvIncidents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clique na célula de anotações de um incidente
            if (e.ColumnIndex == dgvIncidents.Columns["Action"].Index && e.RowIndex >= 0)
            {
                var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value.ToString();

                formIncidentNotes = new FormIncidentNotes();
                formIncidentNotes.IncidentNumber = number;
                formIncidentNotes.Text = $"Edit notes for incident {number}";
                formIncidentNotes.ShowDialog();
            }

            // Tem célula selecionada, eu seto o tooltip do botão e habilito os outros de acordo
            if (e.RowIndex > -1)
            {
                var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value.ToString();
                toolTip1.SetToolTip(btnGoTo, 
                    Properties.Resources.GOTO_ISSUE_NUMBER.Replace("{number}", number));

                SetControlState(EnumControlState.Selected);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if ((listIncidents == null) || (listIncidents.Count == 0))
            {
                MessageBox.Show(Properties.Resources.NOTHING_TO_EXPORT,
                    "Warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            ExportIncidentsToExcel();
        }

        private void dgvIncidents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignora cabeçalhos e células inválidas e aplica a lógica APENAS na coluna "Action".
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvIncidents.Columns[e.ColumnIndex].Name != "Action")
                return;

            // Obtém o número do incidente da coluna "number" e verifica se o incidente possui anotações de acordo com o número
            string incidentNumber = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value?.ToString();
            bool hasNote = !string.IsNullOrEmpty(incidentNumber)
                && _incidentNumbersWithNotes != null
                && _incidentNumbersWithNotes.Contains(incidentNumber);

            // Desenha o fundo padrão da célula.
            e.PaintBackground(e.CellBounds, true);

            // Cria um pincel com cor condicional.
            using (Brush brush = new SolidBrush(
                // Cor azul (#c2ccf2) se tiver nota, ou cor de controle padrão.
                hasNote ?  NOTES_COLOR : SystemColors.Control))
            {
                Rectangle rect = e.CellBounds;
                // Diminui o retângulo para criar um efeito de margem/botão.
                rect.Inflate(-2, -2);
                // Preenche o retângulo interno.
                e.Graphics.FillRectangle(brush, rect);
            }

            // Desenha o texto "..." centralizado.
            TextRenderer.DrawText(
                e.Graphics,
                "...",
                dgvIncidents.Font,
                e.CellBounds,
                // Cor do texto branca se tiver nota, ou cor de texto padrão.
                hasNote ? Color.White : SystemColors.ControlText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            try
            {
                var stats = _incidentService.GetStatistics();

                formStatistics = new FormStatistics();
                formStatistics.Stats = stats;
                formStatistics.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Resources.ERROR_STATISTICS.Replace("{error}", ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            GoToIncidentPage();
        }

        // Aciona marcação de incidente como default na grid
        private void dgvIncidents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (dgvIncidents.Columns[e.ColumnIndex].Name != "Tag"))
                return;

            var number = dgvIncidents.Rows[e.RowIndex].Cells["number"].Value?.ToString();
            var cell = dgvIncidents.Rows[e.RowIndex].Cells["Tag"];
            var defaultColor = dgvIncidents.DefaultCellStyle.BackColor;

            // Verifica número do incidente válido
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show(
                    Properties.Resources.INVALID_ISSUE_NUMBER,
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Verifica o estado atual da célula.
                bool isTagged = cell.Style.BackColor == TAG_COLOR;

                // Define a ação (função) a ser executada usando o operador ternário.
                Action actionToExecute = isTagged
                    ? (Action)(() => UntagIncident(cell, number, defaultColor)) // Converte explicitamente a primeira lambda
                    : () => TagIncident(cell, number, defaultColor);

                actionToExecute();
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    Properties.Resources.ERROR_PROCESSING_ISSUE.Replace("{error}", exc.Message),
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        // Ao reordenar manter o incidente marcado como default
        private void dgvIncidents_Sorted(object sender, EventArgs e)
        {
            SetIncidentAsCurrent();
        }

        // Pesquisa por estado
        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listIncidents == null) return;

            string criteria = cboSearchState.Text;
            criteria = (criteria == "Cancelled") ? "Canceled" : criteria;

            // Pesquisa por estado tem prioridade
            txtSearchNumber.Text = string.Empty;

            // Sem filtro
            bool showAll = string.IsNullOrEmpty(criteria) || criteria.Equals("all", StringComparison.OrdinalIgnoreCase);

            // usa a lista completa ou filtrada
            var filteredList =
                showAll ? listIncidents 
                        : new SortableBindingList<Incident>(
                                listIncidents.Where(i => i.State != null 
                                                            && i.State.Equals(criteria, StringComparison.OrdinalIgnoreCase))
                                             .ToList());  

            dgvIncidents.DataSource = filteredList;
        }

        // Ao clicar no header reordena por data
        private void dgvIncidents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortListByDateFields(dgvIncidents.Columns[e.ColumnIndex].Name);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            formEditIncident = new FormEditIncident();
            var number = dgvIncidents.CurrentRow.Cells["number"].Value.ToString();
            formEditIncident.Number = number;
            formEditIncident.ShowDialog();
            if (formEditIncident.Changed)
            {
                dgvIncidents.CurrentRow.Cells["Priority"].Value = formEditIncident.PriorityUpdated;
                dgvIncidents.CurrentRow.Cells["assigned_to"].Value = formEditIncident.AssignedToUpdated;
                dgvIncidents.CurrentRow.Cells["state"].Value = formEditIncident.StateUpdated;
                dgvIncidents.CurrentRow.Cells["LocalStatus"].Value = formEditIncident.LocalStatusUpdated;
            }
        }

        // Permite apenas dígitos e tecla backspace
        private void txtSearchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        /// <summary>
        /// Busca pelo incidente digitando o número como critério
        /// </summary>
        private void txtSearchNumber_TextChanged(object sender, EventArgs e)
        {
            if (listIncidents == null) return;

            string filterValue = txtSearchNumber.Text.Trim();
            // Mostra todos
            if (string.IsNullOrEmpty(filterValue))
            {
                dgvIncidents.DataSource = listIncidents;
                return;
            }

            // Filtra apenas números que contêm o valor digitado no campo Number
            cboSearchState.SelectedIndex = 0;
            var filtered = new SortableBindingList<Incident>(
                listIncidents.Where(i => i.Number != null && i.Number.Contains(filterValue)).ToList()
            );

            dgvIncidents.DataSource = filtered;
        }
    }
}

using IssueWatcher.Model;
using IssueWatcher.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IssueWatcher
{
    public partial class FormStatistics : Form
    {
        public IncidentStat Stats { get; set; }

        private readonly IncidentService _incidentService;
        private readonly Font _chartFont;
        private readonly Font _chartFontMin;

        public FormStatistics()
        {
            InitializeComponent();

            ConfigReader configReader = new ConfigReader();
            _incidentService = new IncidentService(configReader.GetDatabaseName());

            _chartFont = new Font("Segoe UI", 9, FontStyle.Regular);
            _chartFontMin = new Font("Segoe UI", 8, FontStyle.Regular);

            SetCurrentDateParameters();
        }

        private void SetCurrentDateParameters()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            for (int i = 0; i < cboMonth.Items.Count; i++)
            {
                var currentItem = cboMonth.Items[i].ToString();
                var numItem = int.Parse(currentItem.Split('-')[0]); // pega o número antes do '-'

                if (numItem == currentMonth)
                {
                    cboMonth.SelectedIndex = i;
                    break;
                }
            }

            nupYear.Value = decimal.Parse(currentYear.ToString());
        }

        private void FilterData()
        {
            string mesAno = $"{nupYear.Value}-{cboMonth.SelectedItem.ToString().Split('-')[0].Trim()}";

            Stats = _incidentService.GetStatistics(mesAno);

            GenerateCallerChart(chartCaller);
            GenerateConfigurationItemChart(chartConfigurationItem);
            GenerateStateChart(chartStates);
            GenerateLocalStatusChart(chartLocalStatus);
            GenerateSummary();
        }

        private void GenerateCallerChart(Chart chartCaller)
        {
            var series = chartCaller.Series["Callers"];
            series.Points.Clear();

            chartCaller.Titles.Clear();
            chartCaller.Titles.Add("Top Callers");
            chartCaller.Titles[0].Font = _chartFont;

            chartCaller.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartCaller.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;

            // Adiciona os TopCallers dinamicamente
            foreach (var callerStat in Stats.TopCallers)
            {
                if (callerStat.Total > 0)
                    series.Points.AddXY(callerStat.Caller, callerStat.Total);
            }
        }

        private void GenerateConfigurationItemChart(Chart chartCI)
        {
            var series = chartCI.Series["Apps"];
            series.Points.Clear();

            chartCI.Titles.Clear();
            chartCI.Titles.Add("Top Apps");
            chartCI.Titles[0].Font = _chartFont;

            chartCI.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartCI.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;

            // Adiciona os TopApps dinamicamente
            foreach (var appStat in Stats.TopApps)
            {
                if (appStat.Total > 0)
                    series.Points.AddXY(appStat.App, appStat.Total);
            }
        }

        private void GenerateLocalStatusChart(Chart chartPrioridades)
        {
            var series = chartPrioridades.Series[Properties.Resources.LOCAL_STATUS_SERIES_TITLE];
            series.Points.Clear();

            chartPrioridades.Titles.Clear();
            chartPrioridades.Titles.Add(Properties.Resources.DISTRIB_BY_LOCAL_STATUS);
            chartPrioridades.Titles[0].Font = _chartFont;

            chartPrioridades.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartPrioridades.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;

            if (Stats.CountAguardandoHomologacao > 0)
                series.Points.AddXY("Aguardando homologação", Stats.CountAguardandoHomologacao);

            if (Stats.CountAguardandoPublicacao > 0)
                series.Points.AddXY("Aguardando publicação", Stats.CountAguardandoPublicacao);

            if (Stats.CountAguardandoTestes > 0)
                series.Points.AddXY("Aguardando testes", Stats.CountAguardandoTestes);

            if (Stats.CountFinalizado > 0)
                series.Points.AddXY("Finalizado", Stats.CountFinalizado);

            if (Stats.CountNaoAtuado > 0)
                series.Points.AddXY("Não atuado", Stats.CountNaoAtuado);
        }

        private void GenerateStateChart(Chart chartEstados)
        {
            // Usa a série já definida no Designer
            var series = chartEstados.Series[Properties.Resources.STATE_SERIES_TITLE];
            series.Points.Clear(); // limpa os dados, mas mantém estilo e cor da série

            chartEstados.Titles.Clear();
            chartEstados.Titles.Add(Properties.Resources.DISTRIB_BY_STATE_CHART_TITLE);
            chartEstados.Titles[0].Font = _chartFont;

            chartEstados.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartEstados.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;

            // Adiciona os dados com cores específicas por ponto
            if (Stats.CountNew > 0)
                series.Points.AddXY("New", Stats.CountNew);

            if (Stats.CountInProgress > 0)
                series.Points.AddXY("In Progress", Stats.CountInProgress);

            if (Stats.CountResolved > 0)
                series.Points.AddXY("Resolved", Stats.CountResolved);

            if (Stats.CountClosed > 0)
                series.Points.AddXY("Closed", Stats.CountClosed);

            if (Stats.CountCancelled > 0)
                series.Points.AddXY("Cancelled", Stats.CountCancelled);
        }

        private void GenerateSummary()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"📅 Resumo de {Stats.MesAno}");
            sb.AppendLine($"Total de incidentes: {Stats.TotalIncidents}");
            sb.AppendLine();

            // Por estado
            sb.AppendLine("📊 Distribuição por estado:");
            AppendWithPercentage(sb, "New", Stats.CountNew, Stats.TotalIncidents);
            AppendWithPercentage(sb, "In progress", Stats.CountInProgress, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Resolved", Stats.CountResolved, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Cancelled", Stats.CountCancelled, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Closed", Stats.CountClosed, Stats.TotalIncidents);
            sb.AppendLine();

            // Por status local
            sb.AppendLine("📌 Distribuição por status local:");
            AppendWithPercentage(sb, "Aguardando homologação", Stats.CountAguardandoHomologacao, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Aguardando publicação", Stats.CountAguardandoPublicacao, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Aguardando testes", Stats.CountAguardandoTestes, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Em atendimento", Stats.CountEmAtendimento, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Finalizado", Stats.CountFinalizado, Stats.TotalIncidents);
            AppendWithPercentage(sb, "Não atuado", Stats.CountNaoAtuado, Stats.TotalIncidents);
            sb.AppendLine();

            // Top callers
            sb.AppendLine("👤 Top 5 Callers:");
            foreach (var caller in Stats.TopCallers.OrderByDescending(c => c.Total))
            {
                double perc = (caller.Total * 100.0) / Stats.TotalIncidents;
                sb.AppendLine($"{caller.Caller}: {caller.Total} ({perc:F1}%)");
            }
            sb.AppendLine();

            // Top apps
            sb.AppendLine("🖥️ Top 5 Aplicações:");
            foreach (var app in Stats.TopApps.OrderByDescending(a => a.Total))
            {
                double perc = (app.Total * 100.0) / Stats.TotalIncidents;
                sb.AppendLine($"{app.App}: {app.Total} ({perc:F1}%)");
            }

            txtResumo.Text = sb.ToString();
            this.ActiveControl = null;
        }

        private void AppendWithPercentage(StringBuilder sb, string label, int count, int total)
        {
            if (count > 0 && total > 0)
            {
                double perc = (count * 100.0) / total;
                sb.AppendLine($"{label}: {count} ({perc:F1}%)");
            }
            else
            {
                sb.AppendLine($"{label}: {count}");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {

        }

        private void nupYear_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = true;

        private void nupYear_KeyDown(object sender, KeyEventArgs e)
        {
            // Bloqueia teclas de edição (Backspace, Delete, etc.)
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtResumo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

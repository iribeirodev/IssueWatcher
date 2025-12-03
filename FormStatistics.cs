using IssueWatcher.Model;
using IssueWatcher.Services;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

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
            GenerateTopOpenCallersChart(chartOpenCallers);
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

            // Eixo Y (quantidade de chamados) sempre inteiro
            chartCaller.ChartAreas[0].AxisY.Interval = 1;
            chartCaller.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

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

        private void GenerateTopOpenCallersChart(Chart chartOpenCallers)
        {
            chartOpenCallers.Series.Clear();
            var series = chartOpenCallers.Series.Add("Número de chamados");
            series.ChartType = SeriesChartType.Bar; // barras horizontais para melhor aproveitamento

            chartOpenCallers.Legends[0].Enabled = false;

            chartOpenCallers.Titles.Clear();
            chartOpenCallers.Titles.Add("Open tickets by user");
            chartOpenCallers.Titles[0].Font = _chartFont;

            // Ajuste de fontes
            chartOpenCallers.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartOpenCallers.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;

            // Eixo Y (quantidade de chamados) sempre inteiro
            chartOpenCallers.ChartAreas[0].AxisY.Interval = 1;
            chartOpenCallers.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            // Eixo X (usuários) – garante todos os rótulos
            chartOpenCallers.ChartAreas[0].AxisX.Interval = 1;
            chartOpenCallers.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;
            //chartOpenCallers.ChartAreas[0].AxisX.LabelStyle.Angle = -15;
            chartOpenCallers.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            chartOpenCallers.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            chartOpenCallers.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;

            // Expande área útil do gráfico
            chartOpenCallers.ChartAreas[0].Position = new ElementPosition(5, 5, 90, 85);
            chartOpenCallers.ChartAreas[0].InnerPlotPosition = new ElementPosition(25, 10, 70, 80);

            // Ativa rolagem se houver muitos usuários
            chartOpenCallers.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartOpenCallers.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartOpenCallers.ChartAreas[0].AxisX.ScrollBar.Size = 12;
            chartOpenCallers.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // Exibe valores nas barras
            series.IsValueShownAsLabel = false;
            series.LabelFormat = "N0";

            // Adiciona os dados
            foreach (var caller in Stats.TopOpenCallers)
            {
                series.Points.AddXY(caller.Caller, caller.Total);
            }
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

        private void SetNextMonthYear()
        {
            int mes = cboMonth.SelectedIndex + 1;
            int ano = (int)nupYear.Value;

            if (mes == 12)
            {
                mes = 1;
                ano++;
            }
            else
            {
                mes++;
            }

            UpdateMonthYear(mes, ano);
        }

        private void SetPrevMonthYear()
        {
            int mes = cboMonth.SelectedIndex + 1;
            int ano = (int)nupYear.Value;

            if (mes == 1)
            {
                mes = 12;
                ano--;
            }
            else
            {
                mes--;
            }

            UpdateMonthYear(mes, ano);
        }

        private void UpdateMonthYear(int mes, int ano)
        {
            for (int i = 0; i < cboMonth.Items.Count; i++)
            {
                var item = cboMonth.Items[i].ToString();
                var numItem = int.Parse(item.Split('-')[0]);

                if (numItem == mes)
                {
                    cboMonth.SelectedIndex = i;
                    break;
                }
            }

            nupYear.Value = ano;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SetPrevMonthYear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SetNextMonthYear();
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

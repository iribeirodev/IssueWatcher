using IssueWatcher.Model;
using IssueWatcher.Services;
using System;
using System.Drawing;
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
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {

        }

        private void FilterData()
        {
            string mesAno = dtpMes.Value.ToString("yyyy-MM");

            Stats = _incidentService.GetStatistics(mesAno);

            GenerateStateChart(chartStates);
            GenerateLocalStatusChart(chartLocalStatus);
            GenerateSummary();
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
            {
                int index = series.Points.AddXY("Aguardando homologação", Stats.CountAguardandoHomologacao);
                series.Points[index].Color = Color.MediumPurple;
            }

            if (Stats.CountAguardandoPublicacao > 0)
            {
                int index = series.Points.AddXY("Aguardando publicação", Stats.CountAguardandoPublicacao);
                series.Points[index].Color = Color.Coral;
            }

            if (Stats.CountAguardandoTestes > 0)
            {
                int index = series.Points.AddXY("Aguardando testes", Stats.CountAguardandoTestes);
                series.Points[index].Color = Color.Orange;
            }

            if (Stats.CountFinalizado > 0)
            {
                int index = series.Points.AddXY("Finalizado", Stats.CountFinalizado);
                series.Points[index].Color = Color.ForestGreen;
            }

            if (Stats.CountNaoAtuado > 0)
            {
                int index = series.Points.AddXY("Não atuado", Stats.CountNaoAtuado);
                series.Points[index].Color = Color.Gray;
            }
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
            {
                int index = series.Points.AddXY("New", Stats.CountNew);
                series.Points[index].Color = Color.DodgerBlue;
            }

            if (Stats.CountInProgress > 0)
            {
                int index = series.Points.AddXY("In Progress", Stats.CountInProgress);
                series.Points[index].Color = Color.Goldenrod;
            }

            if (Stats.CountResolved > 0)
            {
                int index = series.Points.AddXY("Resolved", Stats.CountResolved);
                series.Points[index].Color = Color.ForestGreen;
            }

            if (Stats.CountClosed > 0)
            {
                int index = series.Points.AddXY("Closed", Stats.CountClosed);
                series.Points[index].Color = Color.Gray;
            }

            if (Stats.CountCancelled > 0)
            {
                int index = series.Points.AddXY("Cancelled", Stats.CountCancelled);
                series.Points[index].Color = Color.IndianRed;
            }
        }


        private void GenerateSummary()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"New: {Stats.CountNew}");
            sb.AppendLine($"In progress: {Stats.CountInProgress}");
            sb.AppendLine($"Resolved: {Stats.CountResolved}");
            sb.AppendLine($"Cancelled: {Stats.CountCancelled}");
            sb.AppendLine($"Closed: {Stats.CountClosed}");
            sb.AppendLine();
            sb.AppendLine($"Aguardando homologação: {Stats.CountAguardandoHomologacao}");
            sb.AppendLine($"Aguardando publicação: {Stats.CountAguardandoPublicacao}");
            sb.AppendLine($"Aguardando Homologação:  {Stats.CountAguardandoTestes}");
            sb.AppendLine($"Finalizados: {Stats.CountFinalizado}");
            sb.AppendLine($"Não atuados: {Stats.CountNaoAtuado}");

            txtResumo.Text = sb.ToString();
            this.ActiveControl = null;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData();
        }
    }
}

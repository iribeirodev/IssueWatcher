using IssueWatcher.Model;
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

        private readonly Font _chartFont;
        private readonly Font _chartFontMin;

        public FormStatistics()
        {
            InitializeComponent();

            _chartFont = new Font("Segoe UI", 10, FontStyle.Regular);
            _chartFontMin = new Font("Segoe UI", 8, FontStyle.Regular);
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            PreencherGraficoEstados(chartStates);
            PreencherGraficoLocalStatus(chartLocalStatus);
            PreencherResumo();
        }


        public void PreencherGraficoLocalStatus(Chart chartPrioridades)
        {
            chartPrioridades.Series.Clear();
            chartPrioridades.Titles.Clear();

            chartPrioridades.Titles.Add(Properties.Resources.DISTRIB_BY_LOCAL_STATUS);
            chartPrioridades.Titles[0].Font = _chartFont;

            var series = new Series(Properties.Resources.LOCAL_STATUS_SERIES_TITLE)
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Font = _chartFont
            };

            chartPrioridades.Series.Add(series);

            chartPrioridades.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartPrioridades.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;


            if (Stats.CountAguardandoHomologacao > 0) series.Points.AddXY("Aguardando homologação", Stats.CountAguardandoHomologacao);
            if (Stats.CountAguardandoPublicacao > 0) series.Points.AddXY("Aguardando publicação", Stats.CountAguardandoPublicacao);
            if (Stats.CountAguardandoTestes > 0) series.Points.AddXY("Aguardando testes", Stats.CountAguardandoTestes);
            if (Stats.CountFinalizado > 0) series.Points.AddXY("Finalizado", Stats.CountFinalizado);
            if (Stats.CountNaoAtuado> 0) series.Points.AddXY("Não atuado", Stats.CountNaoAtuado);
        }


        public void PreencherGraficoEstados(Chart chartEstados)
        {
            chartEstados.Series.Clear();
            chartEstados.Titles.Clear();

            chartEstados.Titles.Add(Properties.Resources.DISTRIB_BY_STATE_CHART_TITLE);
            chartEstados.Titles[0].Font = _chartFont;

            var series = new Series(Properties.Resources.STATE_SERIES_TITLE)
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Font = _chartFontMin
            };

            chartEstados.Series.Add(series);


            chartEstados.ChartAreas[0].AxisX.LabelStyle.Font = _chartFontMin;
            chartEstados.ChartAreas[0].AxisY.LabelStyle.Font = _chartFontMin;


            if (Stats.CountNew > 0) series.Points.AddXY("New", Stats.CountNew);
            if (Stats.CountInProgress > 0) series.Points.AddXY("In Progress", Stats.CountInProgress);
            if (Stats.CountResolved > 0) series.Points.AddXY("Resolved", Stats.CountResolved);
            if (Stats.CountClosed > 0) series.Points.AddXY("Closed", Stats.CountClosed);
            if (Stats.CountCancelled > 0) series.Points.AddXY("Cancelled", Stats.CountCancelled);
        }


        public void PreencherResumo()
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
    }
}

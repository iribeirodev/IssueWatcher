using IssueWatcher.Model;
using System;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IssueWatcher
{
    public partial class FormStatistics : Form
    {
        public IncidentStat Stats { get; set; }

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            PreencherGraficoEstados(chartEstados);
            PreencherGraficoPrioridades(chartPrioridades);
            PreencherResumo();
        }


        public void PreencherGraficoPrioridades(Chart chartPrioridades)
        {
            chartPrioridades.Series.Clear();
            chartPrioridades.Titles.Clear();

            chartPrioridades.Titles.Add("Distribuição por Prioridade");

            var series = new Series("Prioridades")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            chartPrioridades.Series.Add(series);

            if (Stats.CountPriority1 > 0) series.Points.AddXY("Prioridade 01", Stats.CountPriority1);
            if (Stats.CountPriority2 > 0) series.Points.AddXY("Prioridade 02", Stats.CountPriority2);
            if (Stats.CountPriority3 > 0) series.Points.AddXY("Prioridade 03", Stats.CountPriority3);
            if (Stats.CountPriority4 > 0) series.Points.AddXY("Prioridade 04", Stats.CountPriority4);
            if (Stats.CountPriority5 > 0) series.Points.AddXY("Prioridade 05", Stats.CountPriority5);
        }


        public void PreencherGraficoEstados(Chart chartEstados)
        {
            chartEstados.Series.Clear();
            chartEstados.Titles.Clear();

            chartEstados.Titles.Add("Distribuição por Estado");

            var series = new Series("Estados")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            chartEstados.Series.Add(series);

            if (Stats.CountNew > 0) series.Points.AddXY("New", Stats.CountNew);
            if (Stats.CountInProgress > 0) series.Points.AddXY("In Progress", Stats.CountInProgress);
            if (Stats.CountClosed > 0) series.Points.AddXY("Closed", Stats.CountClosed);
            if (Stats.CountCancelled > 0) series.Points.AddXY("Cancelled", Stats.CountCancelled);
        }


        public void PreencherResumo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cancelados: {Stats.CountCancelled}");
            sb.AppendLine($"Fechados: {Stats.CountClosed}");
            sb.AppendLine($"Em progresso: {Stats.CountInProgress}");
            sb.AppendLine($"Novos: {Stats.CountNew}");
            sb.AppendLine();
            sb.AppendLine($"Prioridade 01: {Stats.CountPriority1}");
            sb.AppendLine($"Prioridade 02: {Stats.CountPriority2}");
            sb.AppendLine($"Prioridade 03: {Stats.CountPriority3}");
            sb.AppendLine($"Prioridade 04: {Stats.CountPriority4}");
            sb.AppendLine($"Prioridade 05: {Stats.CountPriority5}");

            txtResumo.Text = sb.ToString();
            this.ActiveControl = null;
        }
    }
}

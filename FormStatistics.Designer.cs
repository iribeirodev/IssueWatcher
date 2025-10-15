namespace IssueWatcher
{
    partial class FormStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.chartStates = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLocalStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLocalStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResumo
            // 
            this.txtResumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResumo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtResumo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResumo.ForeColor = System.Drawing.Color.Black;
            this.txtResumo.Location = new System.Drawing.Point(12, 280);
            this.txtResumo.Multiline = true;
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumo.Size = new System.Drawing.Size(989, 190);
            this.txtResumo.TabIndex = 0;
            this.txtResumo.TabStop = false;
            // 
            // chartStates
            // 
            this.chartStates.BackColor = System.Drawing.Color.PapayaWhip;
            chartArea1.Name = "ChartArea1";
            this.chartStates.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStates.Legends.Add(legend1);
            this.chartStates.Location = new System.Drawing.Point(12, 12);
            this.chartStates.Name = "chartStates";
            this.chartStates.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStates.Series.Add(series1);
            this.chartStates.Size = new System.Drawing.Size(489, 261);
            this.chartStates.TabIndex = 1;
            this.chartStates.Text = "chart1";
            // 
            // chartLocalStatus
            // 
            this.chartLocalStatus.BackColor = System.Drawing.Color.PapayaWhip;
            this.chartLocalStatus.BorderlineColor = System.Drawing.Color.PapayaWhip;
            chartArea2.Name = "ChartArea1";
            this.chartLocalStatus.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartLocalStatus.Legends.Add(legend2);
            this.chartLocalStatus.Location = new System.Drawing.Point(506, 12);
            this.chartLocalStatus.Name = "chartLocalStatus";
            this.chartLocalStatus.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartLocalStatus.Series.Add(series2);
            this.chartLocalStatus.Size = new System.Drawing.Size(489, 261);
            this.chartLocalStatus.TabIndex = 2;
            this.chartLocalStatus.Text = "chart2";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 476);
            this.Controls.Add(this.chartLocalStatus);
            this.Controls.Add(this.chartStates);
            this.Controls.Add(this.txtResumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLocalStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResumo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStates;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLocalStatus;
    }
}
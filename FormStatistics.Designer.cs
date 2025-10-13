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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.txtResumo.Location = new System.Drawing.Point(18, 430);
            this.txtResumo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResumo.Multiline = true;
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumo.Size = new System.Drawing.Size(1465, 290);
            this.txtResumo.TabIndex = 0;
            this.txtResumo.TabStop = false;
            // 
            // chartStates
            // 
            this.chartStates.BackColor = System.Drawing.Color.PapayaWhip;
            chartArea13.Name = "ChartArea1";
            this.chartStates.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chartStates.Legends.Add(legend13);
            this.chartStates.Location = new System.Drawing.Point(18, 18);
            this.chartStates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartStates.Name = "chartStates";
            this.chartStates.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chartStates.Series.Add(series13);
            this.chartStates.Size = new System.Drawing.Size(733, 402);
            this.chartStates.TabIndex = 1;
            this.chartStates.Text = "chart1";
            // 
            // chartLocalStatus
            // 
            this.chartLocalStatus.BackColor = System.Drawing.Color.PapayaWhip;
            this.chartLocalStatus.BorderlineColor = System.Drawing.Color.PapayaWhip;
            chartArea14.Name = "ChartArea1";
            this.chartLocalStatus.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chartLocalStatus.Legends.Add(legend14);
            this.chartLocalStatus.Location = new System.Drawing.Point(759, 18);
            this.chartLocalStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartLocalStatus.Name = "chartLocalStatus";
            this.chartLocalStatus.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chartLocalStatus.Series.Add(series14);
            this.chartLocalStatus.Size = new System.Drawing.Size(733, 402);
            this.chartLocalStatus.TabIndex = 2;
            this.chartLocalStatus.Text = "chart2";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 733);
            this.Controls.Add(this.chartLocalStatus);
            this.Controls.Add(this.chartStates);
            this.Controls.Add(this.txtResumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
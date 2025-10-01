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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.chartEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPrioridades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrioridades)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResumo
            // 
            this.txtResumo.BackColor = System.Drawing.Color.Lavender;
            this.txtResumo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResumo.ForeColor = System.Drawing.Color.Black;
            this.txtResumo.Location = new System.Drawing.Point(12, 283);
            this.txtResumo.Multiline = true;
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.Size = new System.Drawing.Size(840, 182);
            this.txtResumo.TabIndex = 0;
            this.txtResumo.TabStop = false;
            // 
            // chartEstados
            // 
            chartArea5.Name = "ChartArea1";
            this.chartEstados.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartEstados.Legends.Add(legend5);
            this.chartEstados.Location = new System.Drawing.Point(12, 12);
            this.chartEstados.Name = "chartEstados";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartEstados.Series.Add(series5);
            this.chartEstados.Size = new System.Drawing.Size(417, 265);
            this.chartEstados.TabIndex = 1;
            this.chartEstados.Text = "chart1";
            // 
            // chartPrioridades
            // 
            chartArea6.Name = "ChartArea1";
            this.chartPrioridades.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartPrioridades.Legends.Add(legend6);
            this.chartPrioridades.Location = new System.Drawing.Point(435, 12);
            this.chartPrioridades.Name = "chartPrioridades";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartPrioridades.Series.Add(series6);
            this.chartPrioridades.Size = new System.Drawing.Size(417, 265);
            this.chartPrioridades.TabIndex = 2;
            this.chartPrioridades.Text = "chart2";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 475);
            this.Controls.Add(this.chartPrioridades);
            this.Controls.Add(this.chartEstados);
            this.Controls.Add(this.txtResumo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrioridades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResumo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrioridades;
    }
}
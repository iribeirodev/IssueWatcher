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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.chartStates = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLocalStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLocalStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResumo
            // 
            this.txtResumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResumo.BackColor = System.Drawing.Color.White;
            this.txtResumo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResumo.ForeColor = System.Drawing.Color.Black;
            this.txtResumo.Location = new System.Drawing.Point(12, 387);
            this.txtResumo.Multiline = true;
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumo.Size = new System.Drawing.Size(990, 181);
            this.txtResumo.TabIndex = 0;
            this.txtResumo.TabStop = false;
            // 
            // chartStates
            // 
            chartArea9.Name = "ChartArea1";
            this.chartStates.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chartStates.Legends.Add(legend9);
            this.chartStates.Location = new System.Drawing.Point(12, 89);
            this.chartStates.Name = "chartStates";
            this.chartStates.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.SteelBlue;
            series9.Legend = "Legend1";
            series9.Name = "States";
            this.chartStates.Series.Add(series9);
            this.chartStates.Size = new System.Drawing.Size(489, 261);
            this.chartStates.TabIndex = 1;
            this.chartStates.Text = "chart1";
            // 
            // chartLocalStatus
            // 
            this.chartLocalStatus.BorderlineColor = System.Drawing.Color.PapayaWhip;
            chartArea10.Name = "ChartArea1";
            this.chartLocalStatus.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartLocalStatus.Legends.Add(legend10);
            this.chartLocalStatus.Location = new System.Drawing.Point(506, 89);
            this.chartLocalStatus.Name = "chartLocalStatus";
            this.chartLocalStatus.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.MediumSeaGreen;
            series10.Legend = "Legend1";
            series10.Name = "Local Status";
            this.chartLocalStatus.Series.Add(series10);
            this.chartLocalStatus.Size = new System.Drawing.Size(489, 261);
            this.chartLocalStatus.TabIndex = 2;
            this.chartLocalStatus.Text = "chart2";
            // 
            // dtpMes
            // 
            this.dtpMes.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpMes.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpMes.CalendarTitleBackColor = System.Drawing.Color.PowderBlue;
            this.dtpMes.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpMes.CalendarTrailingForeColor = System.Drawing.Color.LightSteelBlue;
            this.dtpMes.CustomFormat = "MM yyyy";
            this.dtpMes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(12, 31);
            this.dtpMes.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpMes.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.Size = new System.Drawing.Size(115, 25);
            this.dtpMes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Specific Month";
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(133, 32);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(42, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Summary";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1009, 574);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpMes);
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
        private System.Windows.Forms.DateTimePicker dtpMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
    }
}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.chartStates = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLocalStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.nupYear = new System.Windows.Forms.NumericUpDown();
            this.chartCaller = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartConfigurationItem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLocalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCaller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConfigurationItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResumo
            // 
            this.txtResumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResumo.BackColor = System.Drawing.Color.White;
            this.txtResumo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResumo.ForeColor = System.Drawing.Color.Black;
            this.txtResumo.Location = new System.Drawing.Point(12, 83);
            this.txtResumo.Multiline = true;
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.ReadOnly = true;
            this.txtResumo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumo.Size = new System.Drawing.Size(275, 474);
            this.txtResumo.TabIndex = 0;
            this.txtResumo.TabStop = false;
            this.txtResumo.TextChanged += new System.EventHandler(this.txtResumo_TextChanged);
            // 
            // chartStates
            // 
            this.chartStates.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.Name = "ChartArea1";
            this.chartStates.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Gainsboro;
            legend1.Name = "Legend1";
            this.chartStates.Legends.Add(legend1);
            this.chartStates.Location = new System.Drawing.Point(293, 323);
            this.chartStates.Name = "chartStates";
            this.chartStates.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.SteelBlue;
            series1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "States";
            this.chartStates.Series.Add(series1);
            this.chartStates.Size = new System.Drawing.Size(436, 234);
            this.chartStates.TabIndex = 1;
            this.chartStates.Text = "chart1";
            // 
            // chartLocalStatus
            // 
            this.chartLocalStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.chartLocalStatus.BorderlineColor = System.Drawing.Color.PapayaWhip;
            chartArea2.BackColor = System.Drawing.Color.AliceBlue;
            chartArea2.Name = "ChartArea1";
            this.chartLocalStatus.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Gainsboro;
            legend2.Name = "Legend1";
            this.chartLocalStatus.Legends.Add(legend2);
            this.chartLocalStatus.Location = new System.Drawing.Point(753, 323);
            this.chartLocalStatus.Name = "chartLocalStatus";
            this.chartLocalStatus.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Color = System.Drawing.Color.MediumSeaGreen;
            series2.Legend = "Legend1";
            series2.Name = "Local Status";
            this.chartLocalStatus.Series.Add(series2);
            this.chartLocalStatus.Size = new System.Drawing.Size(436, 234);
            this.chartLocalStatus.TabIndex = 2;
            this.chartLocalStatus.Text = "chart2";
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
            this.btnFilter.Location = new System.Drawing.Point(268, 37);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(42, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboMonth
            // 
            this.cboMonth.BackColor = System.Drawing.Color.White;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.ForeColor = System.Drawing.Color.Black;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "01 - January",
            "02 - February",
            "03 - March",
            "04 - April",
            "05 - May",
            "06 - June",
            "07 - July",
            "08 - August",
            "09 - September",
            "10 - October",
            "11 - November",
            "12 - December"});
            this.cboMonth.Location = new System.Drawing.Point(15, 35);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(169, 25);
            this.cboMonth.TabIndex = 7;
            // 
            // nupYear
            // 
            this.nupYear.BackColor = System.Drawing.Color.White;
            this.nupYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupYear.ForeColor = System.Drawing.Color.Black;
            this.nupYear.Location = new System.Drawing.Point(190, 35);
            this.nupYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.nupYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nupYear.Name = "nupYear";
            this.nupYear.Size = new System.Drawing.Size(72, 25);
            this.nupYear.TabIndex = 8;
            this.nupYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nupYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nupYear_KeyDown);
            this.nupYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupYear_KeyPress);
            // 
            // chartCaller
            // 
            this.chartCaller.BackColor = System.Drawing.Color.AliceBlue;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartCaller.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.Gainsboro;
            legend3.Name = "Legend1";
            this.chartCaller.Legends.Add(legend3);
            this.chartCaller.Location = new System.Drawing.Point(293, 83);
            this.chartCaller.Name = "chartCaller";
            this.chartCaller.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series3.Color = System.Drawing.Color.CornflowerBlue;
            series3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.Name = "Callers";
            this.chartCaller.Series.Add(series3);
            this.chartCaller.Size = new System.Drawing.Size(436, 234);
            this.chartCaller.TabIndex = 9;
            this.chartCaller.Text = "chart1";
            // 
            // chartConfigurationItem
            // 
            this.chartConfigurationItem.BackColor = System.Drawing.Color.AliceBlue;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.Name = "ChartArea1";
            this.chartConfigurationItem.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.Gainsboro;
            legend4.Name = "Legend1";
            this.chartConfigurationItem.Legends.Add(legend4);
            this.chartConfigurationItem.Location = new System.Drawing.Point(753, 83);
            this.chartConfigurationItem.Name = "chartConfigurationItem";
            this.chartConfigurationItem.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.MediumOrchid;
            series4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Legend = "Legend1";
            series4.Name = "Apps";
            this.chartConfigurationItem.Series.Add(series4);
            this.chartConfigurationItem.Size = new System.Drawing.Size(436, 234);
            this.chartConfigurationItem.TabIndex = 10;
            this.chartConfigurationItem.Text = "chart1";
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1205, 569);
            this.Controls.Add(this.chartConfigurationItem);
            this.Controls.Add(this.chartCaller);
            this.Controls.Add(this.nupYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCaller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConfigurationItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResumo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStates;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLocalStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.NumericUpDown nupYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCaller;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConfigurationItem;
    }
}
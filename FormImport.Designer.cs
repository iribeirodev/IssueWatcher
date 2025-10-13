namespace IssueWatcher
{
    partial class FormImport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImport));
            this.txtSpreadsheetLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSpreadsheetLocation
            // 
            this.txtSpreadsheetLocation.BackColor = System.Drawing.Color.White;
            this.txtSpreadsheetLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpreadsheetLocation.ForeColor = System.Drawing.Color.Black;
            this.txtSpreadsheetLocation.Location = new System.Drawing.Point(75, 105);
            this.txtSpreadsheetLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSpreadsheetLocation.Name = "txtSpreadsheetLocation";
            this.txtSpreadsheetLocation.ReadOnly = true;
            this.txtSpreadsheetLocation.Size = new System.Drawing.Size(988, 25);
            this.txtSpreadsheetLocation.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtSpreadsheetLocation, "Double-click to select a Spreadsheet file");
            this.txtSpreadsheetLocation.DoubleClick += new System.EventHandler(this.txtSpreadsheetLocation_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spreadsheet Location";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Location = new System.Drawing.Point(1088, 100);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(52, 46);
            this.btnImport.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnImport, "Start importing");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1200, 237);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtSpreadsheetLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import from Spreadsheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSpreadsheetLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnImport;
    }
}
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
            this.txtSpreadsheetLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpreadsheetLocation.ForeColor = System.Drawing.Color.Black;
            this.txtSpreadsheetLocation.Location = new System.Drawing.Point(67, 84);
            this.txtSpreadsheetLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSpreadsheetLocation.Name = "txtSpreadsheetLocation";
            this.txtSpreadsheetLocation.ReadOnly = true;
            this.txtSpreadsheetLocation.Size = new System.Drawing.Size(879, 22);
            this.txtSpreadsheetLocation.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtSpreadsheetLocation, "Double-click to Pick up a database file");
            this.txtSpreadsheetLocation.DoubleClick += new System.EventHandler(this.txtSpreadsheetLocation_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spreadsheet Location";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(67, 118);
            this.btnImport.Margin = new System.Windows.Forms.Padding(20, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnImport.Size = new System.Drawing.Size(216, 48);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Start";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 220);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtSpreadsheetLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
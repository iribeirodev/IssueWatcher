namespace IssueWatcher
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabaseLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblCreateDatabase = new System.Windows.Forms.Label();
            this.txtCreateDatabase = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Location";
            // 
            // txtDatabaseLocation
            // 
            this.txtDatabaseLocation.BackColor = System.Drawing.Color.White;
            this.txtDatabaseLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseLocation.ForeColor = System.Drawing.Color.Black;
            this.txtDatabaseLocation.Location = new System.Drawing.Point(72, 55);
            this.txtDatabaseLocation.Name = "txtDatabaseLocation";
            this.txtDatabaseLocation.ReadOnly = true;
            this.txtDatabaseLocation.Size = new System.Drawing.Size(660, 22);
            this.txtDatabaseLocation.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtDatabaseLocation, "Double-click to Pick up a database file");
            this.txtDatabaseLocation.DoubleClick += new System.EventHandler(this.txtDatabaseLocation_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Spreadsheet Columns";
            // 
            // lstColumns
            // 
            this.lstColumns.BackColor = System.Drawing.Color.White;
            this.lstColumns.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColumns.ForeColor = System.Drawing.Color.Gray;
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.ItemHeight = 17;
            this.lstColumns.Location = new System.Drawing.Point(72, 253);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.ScrollAlwaysVisible = true;
            this.lstColumns.Size = new System.Drawing.Size(660, 259);
            this.lstColumns.TabIndex = 3;
            // 
            // lblCreateDatabase
            // 
            this.lblCreateDatabase.AutoSize = true;
            this.lblCreateDatabase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDatabase.Location = new System.Drawing.Point(69, 128);
            this.lblCreateDatabase.Name = "lblCreateDatabase";
            this.lblCreateDatabase.Size = new System.Drawing.Size(106, 13);
            this.lblCreateDatabase.TabIndex = 4;
            this.lblCreateDatabase.Text = "Create Database As";
            // 
            // txtCreateDatabase
            // 
            this.txtCreateDatabase.BackColor = System.Drawing.Color.White;
            this.txtCreateDatabase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateDatabase.ForeColor = System.Drawing.Color.Black;
            this.txtCreateDatabase.Location = new System.Drawing.Point(201, 125);
            this.txtCreateDatabase.Name = "txtCreateDatabase";
            this.txtCreateDatabase.ReadOnly = true;
            this.txtCreateDatabase.Size = new System.Drawing.Size(531, 22);
            this.txtCreateDatabase.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCreateDatabase, "Double-click to Pick up a database file");
            this.txtCreateDatabase.DoubleClick += new System.EventHandler(this.txtCreateDatabase_DoubleClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.Location = new System.Drawing.Point(201, 152);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(62, 48);
            this.btnCreate.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnCreate, "Re-Create Database");
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtCreateDatabase);
            this.Controls.Add(this.lblCreateDatabase);
            this.Controls.Add(this.lstColumns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDatabaseLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatabaseLocation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Label lblCreateDatabase;
        private System.Windows.Forms.TextBox txtCreateDatabase;
        private System.Windows.Forms.Button btnCreate;
    }
}
namespace IssueWatcher
{
    partial class FormEditIncident
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLocalStatus = new System.Windows.Forms.ComboBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboAssignedTo = new System.Windows.Forms.ComboBox();
            this.txtShortDescription = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSlaDue = new System.Windows.Forms.TextBox();
            this.txtConfigurationItem = new System.Windows.Forms.TextBox();
            this.txtUpdated = new System.Windows.Forms.TextBox();
            this.txtCreated = new System.Windows.Forms.TextBox();
            this.txtCaller = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtAssignmentGroup = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cboState);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboLocalStatus);
            this.panel1.Controls.Add(this.cboPriority);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboAssignedTo);
            this.panel1.Controls.Add(this.txtShortDescription);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtSlaDue);
            this.panel1.Controls.Add(this.txtConfigurationItem);
            this.panel1.Controls.Add(this.txtUpdated);
            this.panel1.Controls.Add(this.txtCreated);
            this.panel1.Controls.Add(this.txtCaller);
            this.panel1.Controls.Add(this.txtNumber);
            this.panel1.Controls.Add(this.txtAssignmentGroup);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 542);
            this.panel1.TabIndex = 27;
            // 
            // cboState
            // 
            this.cboState.BackColor = System.Drawing.Color.White;
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboState.ForeColor = System.Drawing.Color.Black;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(498, 481);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(292, 31);
            this.cboState.TabIndex = 53;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
            this.cboState.TextChanged += new System.EventHandler(this.Value_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "State";
            // 
            // cboLocalStatus
            // 
            this.cboLocalStatus.BackColor = System.Drawing.Color.White;
            this.cboLocalStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalStatus.ForeColor = System.Drawing.Color.Black;
            this.cboLocalStatus.FormattingEnabled = true;
            this.cboLocalStatus.Location = new System.Drawing.Point(826, 481);
            this.cboLocalStatus.Name = "cboLocalStatus";
            this.cboLocalStatus.Size = new System.Drawing.Size(292, 31);
            this.cboLocalStatus.TabIndex = 11;
            this.cboLocalStatus.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
            this.cboLocalStatus.TextChanged += new System.EventHandler(this.Value_Changed);
            // 
            // cboPriority
            // 
            this.cboPriority.BackColor = System.Drawing.Color.White;
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPriority.ForeColor = System.Drawing.Color.Black;
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            ""});
            this.cboPriority.Location = new System.Drawing.Point(379, 481);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(61, 31);
            this.cboPriority.TabIndex = 8;
            this.cboPriority.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
            this.cboPriority.TextChanged += new System.EventHandler(this.Value_Changed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(822, 458);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 49;
            this.label13.Text = "Local Status";
            // 
            // cboAssignedTo
            // 
            this.cboAssignedTo.BackColor = System.Drawing.Color.White;
            this.cboAssignedTo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssignedTo.ForeColor = System.Drawing.Color.Black;
            this.cboAssignedTo.FormattingEnabled = true;
            this.cboAssignedTo.Location = new System.Drawing.Point(32, 481);
            this.cboAssignedTo.Name = "cboAssignedTo";
            this.cboAssignedTo.Size = new System.Drawing.Size(292, 31);
            this.cboAssignedTo.TabIndex = 2;
            this.cboAssignedTo.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
            this.cboAssignedTo.TextChanged += new System.EventHandler(this.Value_Changed);
            // 
            // txtShortDescription
            // 
            this.txtShortDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtShortDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDescription.ForeColor = System.Drawing.Color.SlateGray;
            this.txtShortDescription.Location = new System.Drawing.Point(32, 348);
            this.txtShortDescription.MaxLength = 500;
            this.txtShortDescription.Multiline = true;
            this.txtShortDescription.Name = "txtShortDescription";
            this.txtShortDescription.ReadOnly = true;
            this.txtShortDescription.Size = new System.Drawing.Size(899, 79);
            this.txtShortDescription.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.SlateGray;
            this.txtEmail.Location = new System.Drawing.Point(33, 189);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(365, 30);
            this.txtEmail.TabIndex = 5;
            // 
            // txtSlaDue
            // 
            this.txtSlaDue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSlaDue.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlaDue.ForeColor = System.Drawing.Color.SlateGray;
            this.txtSlaDue.Location = new System.Drawing.Point(639, 189);
            this.txtSlaDue.Name = "txtSlaDue";
            this.txtSlaDue.ReadOnly = true;
            this.txtSlaDue.Size = new System.Drawing.Size(292, 30);
            this.txtSlaDue.TabIndex = 10;
            // 
            // txtConfigurationItem
            // 
            this.txtConfigurationItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConfigurationItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigurationItem.ForeColor = System.Drawing.Color.SlateGray;
            this.txtConfigurationItem.Location = new System.Drawing.Point(639, 117);
            this.txtConfigurationItem.Name = "txtConfigurationItem";
            this.txtConfigurationItem.ReadOnly = true;
            this.txtConfigurationItem.Size = new System.Drawing.Size(365, 30);
            this.txtConfigurationItem.TabIndex = 4;
            // 
            // txtUpdated
            // 
            this.txtUpdated.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdated.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdated.ForeColor = System.Drawing.Color.SlateGray;
            this.txtUpdated.Location = new System.Drawing.Point(639, 261);
            this.txtUpdated.Name = "txtUpdated";
            this.txtUpdated.ReadOnly = true;
            this.txtUpdated.Size = new System.Drawing.Size(292, 30);
            this.txtUpdated.TabIndex = 9;
            // 
            // txtCreated
            // 
            this.txtCreated.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCreated.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreated.ForeColor = System.Drawing.Color.SlateGray;
            this.txtCreated.Location = new System.Drawing.Point(33, 261);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.ReadOnly = true;
            this.txtCreated.Size = new System.Drawing.Size(365, 30);
            this.txtCreated.TabIndex = 3;
            // 
            // txtCaller
            // 
            this.txtCaller.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCaller.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaller.ForeColor = System.Drawing.Color.SlateGray;
            this.txtCaller.Location = new System.Drawing.Point(33, 117);
            this.txtCaller.Name = "txtCaller";
            this.txtCaller.ReadOnly = true;
            this.txtCaller.Size = new System.Drawing.Size(292, 30);
            this.txtCaller.TabIndex = 7;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.ForeColor = System.Drawing.Color.SlateGray;
            this.txtNumber.Location = new System.Drawing.Point(639, 44);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(151, 30);
            this.txtNumber.TabIndex = 6;
            // 
            // txtAssignmentGroup
            // 
            this.txtAssignmentGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAssignmentGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignmentGroup.ForeColor = System.Drawing.Color.SlateGray;
            this.txtAssignmentGroup.Location = new System.Drawing.Point(32, 44);
            this.txtAssignmentGroup.Name = "txtAssignmentGroup";
            this.txtAssignmentGroup.ReadOnly = true;
            this.txtAssignmentGroup.Size = new System.Drawing.Size(365, 30);
            this.txtAssignmentGroup.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "E-mail";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(635, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "SLA Due";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(635, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 35;
            this.label12.Text = "Updated";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(375, 458);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Priority";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Caller";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(635, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(635, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Configuration Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Short Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Created";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Assigned To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Assignment Group";
            // 
            // FormEditIncident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 593);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditIncident";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Incident Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditIncident_FormClosing);
            this.Load += new System.EventHandler(this.FormEditIncident_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLocalStatus;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboAssignedTo;
        private System.Windows.Forms.TextBox txtShortDescription;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSlaDue;
        private System.Windows.Forms.TextBox txtConfigurationItem;
        private System.Windows.Forms.TextBox txtUpdated;
        private System.Windows.Forms.TextBox txtCreated;
        private System.Windows.Forms.TextBox txtCaller;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtAssignmentGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboState;
    }
}
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditIncident));
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Priority = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigned_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configuration_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignment_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnStat = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblFilterby = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cboRecordsToLoad = new System.Windows.Forms.ComboBox();
            this.lblRecordsToLoad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.AllowUserToAddRows = false;
            this.dgvIncidents.AllowUserToDeleteRows = false;
            this.dgvIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncidents.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Priority,
            this.number,
            this.State,
            this.caller,
            this.assigned_to,
            this.configuration_item,
            this.short_description,
            this.email,
            this.created,
            this.updated,
            this.assignment_group});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncidents.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvIncidents.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvIncidents.Location = new System.Drawing.Point(0, 86);
            this.dgvIncidents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.RowHeadersWidth = 51;
            this.dgvIncidents.RowTemplate.Height = 24;
            this.dgvIncidents.Size = new System.Drawing.Size(1313, 605);
            this.dgvIncidents.TabIndex = 0;
            this.dgvIncidents.TabStop = false;
            this.dgvIncidents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellClick);
            this.dgvIncidents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellEndEdit);
            this.dgvIncidents.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvIncidents_CellPainting);
            // 
            // Action
            // 
            this.Action.HeaderText = "Edit Notes";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action.Text = "...";
            this.Action.UseColumnTextForButtonValue = true;
            this.Action.Width = 70;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "Priority";
            this.Priority.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.Priority.Name = "Priority";
            this.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.number.DefaultCellStyle = dataGridViewCellStyle1;
            this.number.HeaderText = "Number";
            this.number.MinimumWidth = 6;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 120;
            // 
            // State
            // 
            this.State.DataPropertyName = "state";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightSlateGray;
            this.State.DefaultCellStyle = dataGridViewCellStyle2;
            this.State.HeaderText = "State";
            this.State.MaxInputLength = 100;
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 180;
            // 
            // caller
            // 
            this.caller.DataPropertyName = "caller";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightSlateGray;
            this.caller.DefaultCellStyle = dataGridViewCellStyle3;
            this.caller.HeaderText = "Caller";
            this.caller.MaxInputLength = 100;
            this.caller.MinimumWidth = 6;
            this.caller.Name = "caller";
            this.caller.ReadOnly = true;
            this.caller.Width = 200;
            // 
            // assigned_to
            // 
            this.assigned_to.DataPropertyName = "AssignedTo";
            this.assigned_to.HeaderText = "Assigned To";
            this.assigned_to.MaxInputLength = 100;
            this.assigned_to.MinimumWidth = 6;
            this.assigned_to.Name = "assigned_to";
            this.assigned_to.Width = 200;
            // 
            // configuration_item
            // 
            this.configuration_item.DataPropertyName = "ConfigurationItem";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightSlateGray;
            this.configuration_item.DefaultCellStyle = dataGridViewCellStyle4;
            this.configuration_item.HeaderText = "Configuration Item";
            this.configuration_item.MaxInputLength = 100;
            this.configuration_item.MinimumWidth = 6;
            this.configuration_item.Name = "configuration_item";
            this.configuration_item.ReadOnly = true;
            this.configuration_item.Width = 180;
            // 
            // short_description
            // 
            this.short_description.DataPropertyName = "ShortDescription";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.LightSlateGray;
            this.short_description.DefaultCellStyle = dataGridViewCellStyle5;
            this.short_description.HeaderText = "Short Description";
            this.short_description.MaxInputLength = 500;
            this.short_description.MinimumWidth = 6;
            this.short_description.Name = "short_description";
            this.short_description.ReadOnly = true;
            this.short_description.Width = 280;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.LightSlateGray;
            this.email.DefaultCellStyle = dataGridViewCellStyle6;
            this.email.HeaderText = "Email";
            this.email.MaxInputLength = 100;
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 280;
            // 
            // created
            // 
            this.created.DataPropertyName = "created";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.LightSlateGray;
            this.created.DefaultCellStyle = dataGridViewCellStyle7;
            this.created.HeaderText = "Created";
            this.created.MinimumWidth = 6;
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.Width = 130;
            // 
            // updated
            // 
            this.updated.DataPropertyName = "Updated";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.LightSlateGray;
            this.updated.DefaultCellStyle = dataGridViewCellStyle8;
            this.updated.HeaderText = "Updated";
            this.updated.MinimumWidth = 6;
            this.updated.Name = "updated";
            this.updated.ReadOnly = true;
            this.updated.Width = 130;
            // 
            // assignment_group
            // 
            this.assignment_group.DataPropertyName = "AssignmentGroup";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.LightSlateGray;
            this.assignment_group.DefaultCellStyle = dataGridViewCellStyle9;
            this.assignment_group.HeaderText = "Assignment Group";
            this.assignment_group.MinimumWidth = 6;
            this.assignment_group.Name = "assignment_group";
            this.assignment_group.ReadOnly = true;
            this.assignment_group.Width = 200;
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.Controls.Add(this.btnStat);
            this.pnlControl.Controls.Add(this.btnExport);
            this.pnlControl.Controls.Add(this.lblNumber);
            this.pnlControl.Controls.Add(this.lblFilterby);
            this.pnlControl.Controls.Add(this.txtNumber);
            this.pnlControl.Controls.Add(this.btnLoad);
            this.pnlControl.Controls.Add(this.cboRecordsToLoad);
            this.pnlControl.Controls.Add(this.lblRecordsToLoad);
            this.pnlControl.Location = new System.Drawing.Point(0, 1);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(1313, 81);
            this.pnlControl.TabIndex = 4;
            // 
            // btnStat
            // 
            this.btnStat.Enabled = false;
            this.btnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnStat.Image")));
            this.btnStat.Location = new System.Drawing.Point(881, 15);
            this.btnStat.Margin = new System.Windows.Forms.Padding(2);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(62, 48);
            this.btnStat.TabIndex = 9;
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(1230, 15);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 48);
            this.btnExport.TabIndex = 3;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(342, 45);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(102, 17);
            this.lblNumber.TabIndex = 8;
            this.lblNumber.Text = "Incident number";
            // 
            // lblFilterby
            // 
            this.lblFilterby.AutoSize = true;
            this.lblFilterby.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterby.Location = new System.Drawing.Point(342, 15);
            this.lblFilterby.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterby.Name = "lblFilterby";
            this.lblFilterby.Size = new System.Drawing.Size(54, 17);
            this.lblFilterby.TabIndex = 7;
            this.lblFilterby.Text = "Filter by";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(496, 43);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumber.MaxLength = 5;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(76, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(806, 15);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(62, 48);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cboRecordsToLoad
            // 
            this.cboRecordsToLoad.BackColor = System.Drawing.Color.White;
            this.cboRecordsToLoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecordsToLoad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRecordsToLoad.ForeColor = System.Drawing.Color.Black;
            this.cboRecordsToLoad.FormattingEnabled = true;
            this.cboRecordsToLoad.Items.AddRange(new object[] {
            "10 incidents",
            "20 incidents",
            "50 incidents",
            "100 incidents",
            "150 incidents",
            "all"});
            this.cboRecordsToLoad.Location = new System.Drawing.Point(17, 43);
            this.cboRecordsToLoad.Margin = new System.Windows.Forms.Padding(2);
            this.cboRecordsToLoad.Name = "cboRecordsToLoad";
            this.cboRecordsToLoad.Size = new System.Drawing.Size(181, 25);
            this.cboRecordsToLoad.TabIndex = 0;
            // 
            // lblRecordsToLoad
            // 
            this.lblRecordsToLoad.AutoSize = true;
            this.lblRecordsToLoad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsToLoad.Location = new System.Drawing.Point(15, 15);
            this.lblRecordsToLoad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsToLoad.Name = "lblRecordsToLoad";
            this.lblRecordsToLoad.Size = new System.Drawing.Size(63, 17);
            this.lblRecordsToLoad.TabIndex = 3;
            this.lblRecordsToLoad.Text = "Load first";
            // 
            // FormEditIncident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 691);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.dgvIncidents);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormEditIncident";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incidents";
            this.Load += new System.EventHandler(this.FormEditIncident_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidents;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cboRecordsToLoad;
        private System.Windows.Forms.Label lblRecordsToLoad;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblFilterby;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewComboBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn caller;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigned_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn configuration_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignment_group;
        private System.Windows.Forms.Button btnStat;
    }
}
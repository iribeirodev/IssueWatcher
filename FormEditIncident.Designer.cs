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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditIncident));
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnGoTo = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboRecordsToLoad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.Tag,
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
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncidents.DefaultCellStyle = dataGridViewCellStyle50;
            this.dgvIncidents.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvIncidents.Location = new System.Drawing.Point(0, 123);
            this.dgvIncidents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.RowHeadersWidth = 51;
            this.dgvIncidents.RowTemplate.Height = 24;
            this.dgvIncidents.Size = new System.Drawing.Size(1313, 568);
            this.dgvIncidents.TabIndex = 0;
            this.dgvIncidents.TabStop = false;
            this.dgvIncidents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellClick);
            this.dgvIncidents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellDoubleClick);
            this.dgvIncidents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellEndEdit);
            this.dgvIncidents.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvIncidents_CellPainting);
            this.dgvIncidents.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIncidents_ColumnHeaderMouseClick);
            this.dgvIncidents.Sorted += new System.EventHandler(this.dgvIncidents_Sorted);
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
            // Tag
            // 
            this.Tag.DataPropertyName = "tag";
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tag.Width = 50;
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
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.LightSlateGray;
            this.number.DefaultCellStyle = dataGridViewCellStyle41;
            this.number.HeaderText = "Number";
            this.number.MinimumWidth = 6;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 120;
            // 
            // State
            // 
            this.State.DataPropertyName = "state";
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.LightSlateGray;
            this.State.DefaultCellStyle = dataGridViewCellStyle42;
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
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.LightSlateGray;
            this.caller.DefaultCellStyle = dataGridViewCellStyle43;
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
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.LightSlateGray;
            this.configuration_item.DefaultCellStyle = dataGridViewCellStyle44;
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
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle45.ForeColor = System.Drawing.Color.LightSlateGray;
            this.short_description.DefaultCellStyle = dataGridViewCellStyle45;
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
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle46.ForeColor = System.Drawing.Color.LightSlateGray;
            this.email.DefaultCellStyle = dataGridViewCellStyle46;
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
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.LightSlateGray;
            this.created.DefaultCellStyle = dataGridViewCellStyle47;
            this.created.HeaderText = "Created";
            this.created.MinimumWidth = 6;
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.Width = 130;
            // 
            // updated
            // 
            this.updated.DataPropertyName = "Updated";
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.LightSlateGray;
            this.updated.DefaultCellStyle = dataGridViewCellStyle48;
            this.updated.HeaderText = "Updated";
            this.updated.MinimumWidth = 6;
            this.updated.Name = "updated";
            this.updated.ReadOnly = true;
            this.updated.Width = 130;
            // 
            // assignment_group
            // 
            this.assignment_group.DataPropertyName = "AssignmentGroup";
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.LightSlateGray;
            this.assignment_group.DefaultCellStyle = dataGridViewCellStyle49;
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
            this.pnlControl.Controls.Add(this.groupBox2);
            this.pnlControl.Controls.Add(this.groupBox1);
            this.pnlControl.Controls.Add(this.btnGoTo);
            this.pnlControl.Controls.Add(this.btnStat);
            this.pnlControl.Controls.Add(this.btnExport);
            this.pnlControl.Controls.Add(this.btnLoad);
            this.pnlControl.Location = new System.Drawing.Point(0, 1);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(1313, 118);
            this.pnlControl.TabIndex = 4;
            // 
            // btnGoTo
            // 
            this.btnGoTo.Enabled = false;
            this.btnGoTo.Image = ((System.Drawing.Image)(resources.GetObject("btnGoTo.Image")));
            this.btnGoTo.Location = new System.Drawing.Point(958, 43);
            this.btnGoTo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(62, 48);
            this.btnGoTo.TabIndex = 2;
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // btnStat
            // 
            this.btnStat.Enabled = false;
            this.btnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnStat.Image")));
            this.btnStat.Location = new System.Drawing.Point(866, 43);
            this.btnStat.Margin = new System.Windows.Forms.Padding(2);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(62, 48);
            this.btnStat.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnStat, "Statistics");
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(1050, 43);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 48);
            this.btnExport.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnExport, "Export to Excel");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(774, 43);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(62, 48);
            this.btnLoad.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnLoad, "Refresh Data");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Location = new System.Drawing.Point(268, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // cboState
            // 
            this.cboState.BackColor = System.Drawing.Color.White;
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.Enabled = false;
            this.cboState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboState.ForeColor = System.Drawing.Color.Black;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "",
            "Cancelled",
            "Closed",
            "In Progress",
            "New",
            "all"});
            this.cboState.Location = new System.Drawing.Point(138, 47);
            this.cboState.Margin = new System.Windows.Forms.Padding(2);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(181, 25);
            this.cboState.TabIndex = 1;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "State";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(20, 28);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(92, 13);
            this.lblNumber.TabIndex = 15;
            this.lblNumber.Text = "Incident number";
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(23, 47);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumber.MaxLength = 6;
            this.txtNumber.Multiline = true;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(99, 25);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboRecordsToLoad);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "# of records loaded";
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
            this.cboRecordsToLoad.Location = new System.Drawing.Point(10, 47);
            this.cboRecordsToLoad.Margin = new System.Windows.Forms.Padding(2);
            this.cboRecordsToLoad.Name = "cboRecordsToLoad";
            this.cboRecordsToLoad.Size = new System.Drawing.Size(181, 25);
            this.cboRecordsToLoad.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cboRecordsToLoad, "Select an Item and Click on Refresh Data");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Load first";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidents;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecordsToLoad;
    }
}
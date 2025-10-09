namespace IssueWatcher
{
    partial class FormIncidents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIncidents));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecordsToLoad = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSearchState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtSearchNumber = new System.Windows.Forms.TextBox();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigned_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configuration_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignment_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.Tag,
            this.number,
            this.State,
            this.LocalStatus,
            this.caller,
            this.assigned_to,
            this.configuration_item,
            this.short_description,
            this.email,
            this.created,
            this.updated,
            this.assignment_group});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncidents.DefaultCellStyle = dataGridViewCellStyle12;
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
            this.dgvIncidents.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvIncidents_CellPainting);
            this.dgvIncidents.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIncidents_ColumnHeaderMouseClick);
            this.dgvIncidents.Sorted += new System.EventHandler(this.dgvIncidents_Sorted);
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.Controls.Add(this.btnEdit);
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
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(904, 39);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(62, 48);
            this.btnEdit.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnEdit, "Edit Incident Info");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSearchState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.txtSearchNumber);
            this.groupBox1.Location = new System.Drawing.Point(268, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // cboSearchState
            // 
            this.cboSearchState.BackColor = System.Drawing.Color.White;
            this.cboSearchState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchState.Enabled = false;
            this.cboSearchState.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchState.ForeColor = System.Drawing.Color.Black;
            this.cboSearchState.FormattingEnabled = true;
            this.cboSearchState.Items.AddRange(new object[] {
            "",
            "Cancelled",
            "Closed",
            "In Progress",
            "New",
            "all"});
            this.cboSearchState.Location = new System.Drawing.Point(138, 47);
            this.cboSearchState.Margin = new System.Windows.Forms.Padding(2);
            this.cboSearchState.Name = "cboSearchState";
            this.cboSearchState.Size = new System.Drawing.Size(181, 25);
            this.cboSearchState.TabIndex = 1;
            this.cboSearchState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
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
            // txtSearchNumber
            // 
            this.txtSearchNumber.Enabled = false;
            this.txtSearchNumber.Location = new System.Drawing.Point(23, 47);
            this.txtSearchNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchNumber.MaxLength = 6;
            this.txtSearchNumber.Multiline = true;
            this.txtSearchNumber.Name = "txtSearchNumber";
            this.txtSearchNumber.Size = new System.Drawing.Size(99, 25);
            this.txtSearchNumber.TabIndex = 0;
            this.txtSearchNumber.TextChanged += new System.EventHandler(this.txtSearchNumber_TextChanged);
            this.txtSearchNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchNumber_KeyPress);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Enabled = false;
            this.btnGoTo.Image = ((System.Drawing.Image)(resources.GetObject("btnGoTo.Image")));
            this.btnGoTo.Location = new System.Drawing.Point(1054, 39);
            this.btnGoTo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(62, 48);
            this.btnGoTo.TabIndex = 3;
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // btnStat
            // 
            this.btnStat.Enabled = false;
            this.btnStat.Image = ((System.Drawing.Image)(resources.GetObject("btnStat.Image")));
            this.btnStat.Location = new System.Drawing.Point(979, 39);
            this.btnStat.Margin = new System.Windows.Forms.Padding(2);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(62, 48);
            this.btnStat.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnStat, "Statistics");
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(1132, 39);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 48);
            this.btnExport.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnExport, "Export to Excel");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(826, 39);
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
            this.Priority.DataPropertyName = "LocalPriority";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
            this.Priority.DefaultCellStyle = dataGridViewCellStyle1;
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 50;
            // 
            // Tag
            // 
            this.Tag.DataPropertyName = "tag";
            this.Tag.HeaderText = "Current";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tag.Width = 50;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.number.DefaultCellStyle = dataGridViewCellStyle2;
            this.number.HeaderText = "Number";
            this.number.MinimumWidth = 6;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 120;
            // 
            // State
            // 
            this.State.DataPropertyName = "state";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.State.DefaultCellStyle = dataGridViewCellStyle3;
            this.State.HeaderText = "State";
            this.State.MaxInputLength = 100;
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 180;
            // 
            // LocalStatus
            // 
            this.LocalStatus.DataPropertyName = "LocalStatus";
            this.LocalStatus.HeaderText = "Local Status";
            this.LocalStatus.Name = "LocalStatus";
            this.LocalStatus.Width = 175;
            // 
            // caller
            // 
            this.caller.DataPropertyName = "caller";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.caller.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.assigned_to.DefaultCellStyle = dataGridViewCellStyle5;
            this.assigned_to.HeaderText = "Assigned To";
            this.assigned_to.MaxInputLength = 100;
            this.assigned_to.MinimumWidth = 6;
            this.assigned_to.Name = "assigned_to";
            this.assigned_to.ReadOnly = true;
            this.assigned_to.Width = 200;
            // 
            // configuration_item
            // 
            this.configuration_item.DataPropertyName = "ConfigurationItem";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.configuration_item.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.short_description.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.email.DefaultCellStyle = dataGridViewCellStyle8;
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
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.created.DefaultCellStyle = dataGridViewCellStyle9;
            this.created.HeaderText = "Created";
            this.created.MinimumWidth = 6;
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.Width = 130;
            // 
            // updated
            // 
            this.updated.DataPropertyName = "Updated";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.updated.DefaultCellStyle = dataGridViewCellStyle10;
            this.updated.HeaderText = "Updated";
            this.updated.MinimumWidth = 6;
            this.updated.Name = "updated";
            this.updated.ReadOnly = true;
            this.updated.Width = 130;
            // 
            // assignment_group
            // 
            this.assignment_group.DataPropertyName = "AssignmentGroup";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.assignment_group.DefaultCellStyle = dataGridViewCellStyle11;
            this.assignment_group.HeaderText = "Assignment Group";
            this.assignment_group.MinimumWidth = 6;
            this.assignment_group.Name = "assignment_group";
            this.assignment_group.ReadOnly = true;
            this.assignment_group.Width = 200;
            // 
            // FormIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 691);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.dgvIncidents);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormIncidents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incidents";
            this.Load += new System.EventHandler(this.FormEditIncident_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSearchState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtSearchNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecordsToLoad;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn caller;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigned_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn configuration_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignment_group;
    }
}
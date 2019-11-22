namespace OperatorGateway
{
    partial class OperatorGateway
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorGateway));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabMonitorService = new System.Windows.Forms.TabPage();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.grbService = new System.Windows.Forms.GroupBox();
            this.cbbStartType = new System.Windows.Forms.ComboBox();
            this.lblStartType = new System.Windows.Forms.Label();
            this.btnViewLogService = new System.Windows.Forms.Button();
            this.txtServiceDisplay = new System.Windows.Forms.TextBox();
            this.lblServiceDisplay = new System.Windows.Forms.Label();
            this.txtServiceStatus = new System.Windows.Forms.TextBox();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.btnServiceStart = new System.Windows.Forms.Button();
            this.btnServiceStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPhoneChangeTelco = new System.Windows.Forms.TabPage();
            this.grbMonitorPhoneChangeTelco = new System.Windows.Forms.GroupBox();
            this.rtbMonitor = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRedis = new System.Windows.Forms.CheckBox();
            this.chkEdu = new System.Windows.Forms.CheckBox();
            this.chkGateway = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUrlData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTS017dff08 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewLogPhoneChangeTelco = new System.Windows.Forms.Button();
            this.txtTS0165a601 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJSESSIONID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartPhoneChangeTelco = new System.Windows.Forms.Button();
            this.btnStopPhoneChangeTelco = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabMonitorService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.grbService.SuspendLayout();
            this.tabPhoneChangeTelco.SuspendLayout();
            this.grbMonitorPhoneChangeTelco.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabHome);
            this.tabControlMain.Controls.Add(this.tabMonitorService);
            this.tabControlMain.Controls.Add(this.tabPhoneChangeTelco);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1184, 661);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // tabHome
            // 
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1176, 635);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // tabMonitorService
            // 
            this.tabMonitorService.Controls.Add(this.pbLoading);
            this.tabMonitorService.Controls.Add(this.dgvService);
            this.tabMonitorService.Controls.Add(this.grbService);
            this.tabMonitorService.Location = new System.Drawing.Point(4, 22);
            this.tabMonitorService.Name = "tabMonitorService";
            this.tabMonitorService.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonitorService.Size = new System.Drawing.Size(1176, 635);
            this.tabMonitorService.TabIndex = 1;
            this.tabMonitorService.Text = "Monitor Service";
            this.tabMonitorService.UseVisualStyleBackColor = true;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoading.BackColor = System.Drawing.Color.White;
            this.pbLoading.Image = global::OperatorGateway.Properties.Resources.loader;
            this.pbLoading.Location = new System.Drawing.Point(555, 289);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(72, 62);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 7;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // dgvService
            // 
            this.dgvService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvService.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Location = new System.Drawing.Point(8, 96);
            this.dgvService.Name = "dgvService";
            this.dgvService.Size = new System.Drawing.Size(1162, 531);
            this.dgvService.TabIndex = 6;
            this.dgvService.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvService_CellClick);
            // 
            // grbService
            // 
            this.grbService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbService.Controls.Add(this.cbbStartType);
            this.grbService.Controls.Add(this.lblStartType);
            this.grbService.Controls.Add(this.btnViewLogService);
            this.grbService.Controls.Add(this.txtServiceDisplay);
            this.grbService.Controls.Add(this.lblServiceDisplay);
            this.grbService.Controls.Add(this.txtServiceStatus);
            this.grbService.Controls.Add(this.lblServiceStatus);
            this.grbService.Controls.Add(this.txtServiceName);
            this.grbService.Controls.Add(this.lblServiceName);
            this.grbService.Controls.Add(this.btnServiceStart);
            this.grbService.Controls.Add(this.btnServiceStop);
            this.grbService.Controls.Add(this.btnRefresh);
            this.grbService.Location = new System.Drawing.Point(8, 6);
            this.grbService.Name = "grbService";
            this.grbService.Size = new System.Drawing.Size(1162, 84);
            this.grbService.TabIndex = 5;
            this.grbService.TabStop = false;
            // 
            // cbbStartType
            // 
            this.cbbStartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbStartType.Enabled = false;
            this.cbbStartType.FormattingEnabled = true;
            this.cbbStartType.Items.AddRange(new object[] {
            "Manual",
            "Automatic",
            "Disabled"});
            this.cbbStartType.Location = new System.Drawing.Point(807, 51);
            this.cbbStartType.Name = "cbbStartType";
            this.cbbStartType.Size = new System.Drawing.Size(187, 21);
            this.cbbStartType.TabIndex = 12;
            this.cbbStartType.SelectedIndexChanged += new System.EventHandler(this.CbbStartType_SelectedIndexChanged);
            // 
            // lblStartType
            // 
            this.lblStartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartType.AutoSize = true;
            this.lblStartType.Location = new System.Drawing.Point(745, 54);
            this.lblStartType.Name = "lblStartType";
            this.lblStartType.Size = new System.Drawing.Size(56, 13);
            this.lblStartType.TabIndex = 11;
            this.lblStartType.Text = "Start Type";
            // 
            // btnViewLogService
            // 
            this.btnViewLogService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewLogService.Enabled = false;
            this.btnViewLogService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLogService.Location = new System.Drawing.Point(1000, 19);
            this.btnViewLogService.Name = "btnViewLogService";
            this.btnViewLogService.Size = new System.Drawing.Size(75, 23);
            this.btnViewLogService.TabIndex = 10;
            this.btnViewLogService.Text = "View log";
            this.btnViewLogService.UseVisualStyleBackColor = false;
            this.btnViewLogService.Click += new System.EventHandler(this.BtnViewLogService_Click);
            // 
            // txtServiceDisplay
            // 
            this.txtServiceDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceDisplay.Enabled = false;
            this.txtServiceDisplay.Location = new System.Drawing.Point(86, 51);
            this.txtServiceDisplay.Name = "txtServiceDisplay";
            this.txtServiceDisplay.Size = new System.Drawing.Size(653, 20);
            this.txtServiceDisplay.TabIndex = 9;
            // 
            // lblServiceDisplay
            // 
            this.lblServiceDisplay.AutoSize = true;
            this.lblServiceDisplay.Location = new System.Drawing.Point(6, 54);
            this.lblServiceDisplay.Name = "lblServiceDisplay";
            this.lblServiceDisplay.Size = new System.Drawing.Size(80, 13);
            this.lblServiceDisplay.TabIndex = 8;
            this.lblServiceDisplay.Text = "Service Display";
            // 
            // txtServiceStatus
            // 
            this.txtServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceStatus.Enabled = false;
            this.txtServiceStatus.Location = new System.Drawing.Point(807, 21);
            this.txtServiceStatus.Name = "txtServiceStatus";
            this.txtServiceStatus.Size = new System.Drawing.Size(187, 20);
            this.txtServiceStatus.TabIndex = 7;
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(745, 24);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(37, 13);
            this.lblServiceStatus.TabIndex = 6;
            this.lblServiceStatus.Text = "Status";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceName.Enabled = false;
            this.txtServiceName.Location = new System.Drawing.Point(86, 21);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(653, 20);
            this.txtServiceName.TabIndex = 5;
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(6, 24);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(74, 13);
            this.lblServiceName.TabIndex = 4;
            this.lblServiceName.Text = "Service Name";
            // 
            // btnServiceStart
            // 
            this.btnServiceStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnServiceStart.Enabled = false;
            this.btnServiceStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceStart.Location = new System.Drawing.Point(1000, 49);
            this.btnServiceStart.Name = "btnServiceStart";
            this.btnServiceStart.Size = new System.Drawing.Size(75, 23);
            this.btnServiceStart.TabIndex = 3;
            this.btnServiceStart.Text = "Start";
            this.btnServiceStart.UseVisualStyleBackColor = false;
            this.btnServiceStart.Click += new System.EventHandler(this.BtnServiceStart_Click);
            // 
            // btnServiceStop
            // 
            this.btnServiceStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceStop.BackColor = System.Drawing.Color.Tomato;
            this.btnServiceStop.Enabled = false;
            this.btnServiceStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceStop.Location = new System.Drawing.Point(1081, 49);
            this.btnServiceStop.Name = "btnServiceStop";
            this.btnServiceStop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnServiceStop.Size = new System.Drawing.Size(75, 23);
            this.btnServiceStop.TabIndex = 2;
            this.btnServiceStop.Text = "Stop";
            this.btnServiceStop.UseVisualStyleBackColor = false;
            this.btnServiceStop.Click += new System.EventHandler(this.BtnServiceStop_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1081, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // tabPhoneChangeTelco
            // 
            this.tabPhoneChangeTelco.Controls.Add(this.grbMonitorPhoneChangeTelco);
            this.tabPhoneChangeTelco.Controls.Add(this.groupBox1);
            this.tabPhoneChangeTelco.Location = new System.Drawing.Point(4, 22);
            this.tabPhoneChangeTelco.Name = "tabPhoneChangeTelco";
            this.tabPhoneChangeTelco.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhoneChangeTelco.Size = new System.Drawing.Size(1176, 635);
            this.tabPhoneChangeTelco.TabIndex = 2;
            this.tabPhoneChangeTelco.Text = "Phone Change Telco";
            this.tabPhoneChangeTelco.UseVisualStyleBackColor = true;
            // 
            // grbMonitorPhoneChangeTelco
            // 
            this.grbMonitorPhoneChangeTelco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMonitorPhoneChangeTelco.Controls.Add(this.rtbMonitor);
            this.grbMonitorPhoneChangeTelco.Location = new System.Drawing.Point(8, 173);
            this.grbMonitorPhoneChangeTelco.Name = "grbMonitorPhoneChangeTelco";
            this.grbMonitorPhoneChangeTelco.Size = new System.Drawing.Size(1160, 456);
            this.grbMonitorPhoneChangeTelco.TabIndex = 7;
            this.grbMonitorPhoneChangeTelco.TabStop = false;
            this.grbMonitorPhoneChangeTelco.Text = "Monitor";
            // 
            // rtbMonitor
            // 
            this.rtbMonitor.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMonitor.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbMonitor.Location = new System.Drawing.Point(3, 16);
            this.rtbMonitor.Name = "rtbMonitor";
            this.rtbMonitor.ReadOnly = true;
            this.rtbMonitor.Size = new System.Drawing.Size(1154, 437);
            this.rtbMonitor.TabIndex = 1;
            this.rtbMonitor.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtRange);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtInterval);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkRedis);
            this.groupBox1.Controls.Add(this.chkEdu);
            this.groupBox1.Controls.Add(this.chkGateway);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUrlData);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEndFile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStartFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTS017dff08);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnViewLogPhoneChangeTelco);
            this.groupBox1.Controls.Add(this.txtTS0165a601);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtJSESSIONID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnStartPhoneChangeTelco);
            this.groupBox1.Controls.Add(this.btnStopPhoneChangeTelco);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1157, 161);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtRange
            // 
            this.txtRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRange.Location = new System.Drawing.Point(815, 99);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(75, 20);
            this.txtRange.TabIndex = 26;
            this.txtRange.Text = "200";
            this.txtRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRange_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(770, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Range";
            // 
            // txtInterval
            // 
            this.txtInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterval.Location = new System.Drawing.Point(689, 99);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(75, 20);
            this.txtInterval.TabIndex = 24;
            this.txtInterval.Text = "1500000";
            this.txtInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterval_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Interval";
            // 
            // chkRedis
            // 
            this.chkRedis.AutoSize = true;
            this.chkRedis.Checked = true;
            this.chkRedis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRedis.Location = new System.Drawing.Point(160, 133);
            this.chkRedis.Name = "chkRedis";
            this.chkRedis.Size = new System.Drawing.Size(53, 17);
            this.chkRedis.TabIndex = 22;
            this.chkRedis.Text = "Redis";
            this.chkRedis.UseVisualStyleBackColor = true;
            // 
            // chkEdu
            // 
            this.chkEdu.AutoSize = true;
            this.chkEdu.Checked = true;
            this.chkEdu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEdu.Location = new System.Drawing.Point(219, 133);
            this.chkEdu.Name = "chkEdu";
            this.chkEdu.Size = new System.Drawing.Size(45, 17);
            this.chkEdu.TabIndex = 21;
            this.chkEdu.Text = "Edu";
            this.chkEdu.UseVisualStyleBackColor = true;
            // 
            // chkGateway
            // 
            this.chkGateway.AutoSize = true;
            this.chkGateway.Checked = true;
            this.chkGateway.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGateway.Location = new System.Drawing.Point(86, 133);
            this.chkGateway.Name = "chkGateway";
            this.chkGateway.Size = new System.Drawing.Size(68, 17);
            this.chkGateway.TabIndex = 20;
            this.chkGateway.Text = "Gateway";
            this.chkGateway.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Persistent";
            // 
            // txtUrlData
            // 
            this.txtUrlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlData.Location = new System.Drawing.Point(86, 99);
            this.txtUrlData.Name = "txtUrlData";
            this.txtUrlData.Size = new System.Drawing.Size(546, 20);
            this.txtUrlData.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Url data";
            // 
            // txtEndFile
            // 
            this.txtEndFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndFile.Location = new System.Drawing.Point(1076, 99);
            this.txtEndFile.Name = "txtEndFile";
            this.txtEndFile.Size = new System.Drawing.Size(75, 20);
            this.txtEndFile.TabIndex = 16;
            this.txtEndFile.Text = "20000";
            this.txtEndFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndFile_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1028, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "End file";
            // 
            // txtStartFile
            // 
            this.txtStartFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartFile.Location = new System.Drawing.Point(947, 99);
            this.txtStartFile.Name = "txtStartFile";
            this.txtStartFile.Size = new System.Drawing.Size(75, 20);
            this.txtStartFile.TabIndex = 14;
            this.txtStartFile.Text = "0";
            this.txtStartFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartFile_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Start file";
            // 
            // txtTS017dff08
            // 
            this.txtTS017dff08.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTS017dff08.Location = new System.Drawing.Point(86, 73);
            this.txtTS017dff08.Name = "txtTS017dff08";
            this.txtTS017dff08.Size = new System.Drawing.Size(1065, 20);
            this.txtTS017dff08.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "TS017dff08";
            // 
            // btnViewLogPhoneChangeTelco
            // 
            this.btnViewLogPhoneChangeTelco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogPhoneChangeTelco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewLogPhoneChangeTelco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLogPhoneChangeTelco.Location = new System.Drawing.Point(914, 129);
            this.btnViewLogPhoneChangeTelco.Name = "btnViewLogPhoneChangeTelco";
            this.btnViewLogPhoneChangeTelco.Size = new System.Drawing.Size(75, 23);
            this.btnViewLogPhoneChangeTelco.TabIndex = 10;
            this.btnViewLogPhoneChangeTelco.Text = "View log";
            this.btnViewLogPhoneChangeTelco.UseVisualStyleBackColor = false;
            this.btnViewLogPhoneChangeTelco.Click += new System.EventHandler(this.BtnViewLogPhoneChangeTelco_Click);
            // 
            // txtTS0165a601
            // 
            this.txtTS0165a601.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTS0165a601.Location = new System.Drawing.Point(86, 47);
            this.txtTS0165a601.Name = "txtTS0165a601";
            this.txtTS0165a601.Size = new System.Drawing.Size(1065, 20);
            this.txtTS0165a601.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "TS0165a601";
            // 
            // txtJSESSIONID
            // 
            this.txtJSESSIONID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJSESSIONID.Location = new System.Drawing.Point(86, 21);
            this.txtJSESSIONID.Name = "txtJSESSIONID";
            this.txtJSESSIONID.Size = new System.Drawing.Size(1065, 20);
            this.txtJSESSIONID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "JSESSIONID";
            // 
            // btnStartPhoneChangeTelco
            // 
            this.btnStartPhoneChangeTelco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPhoneChangeTelco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStartPhoneChangeTelco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPhoneChangeTelco.Location = new System.Drawing.Point(995, 129);
            this.btnStartPhoneChangeTelco.Name = "btnStartPhoneChangeTelco";
            this.btnStartPhoneChangeTelco.Size = new System.Drawing.Size(75, 23);
            this.btnStartPhoneChangeTelco.TabIndex = 3;
            this.btnStartPhoneChangeTelco.Text = "Start";
            this.btnStartPhoneChangeTelco.UseVisualStyleBackColor = false;
            this.btnStartPhoneChangeTelco.Click += new System.EventHandler(this.BtnStartPhoneChangeTelco_Click);
            // 
            // btnStopPhoneChangeTelco
            // 
            this.btnStopPhoneChangeTelco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopPhoneChangeTelco.BackColor = System.Drawing.Color.Tomato;
            this.btnStopPhoneChangeTelco.Enabled = false;
            this.btnStopPhoneChangeTelco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopPhoneChangeTelco.Location = new System.Drawing.Point(1076, 129);
            this.btnStopPhoneChangeTelco.Name = "btnStopPhoneChangeTelco";
            this.btnStopPhoneChangeTelco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnStopPhoneChangeTelco.Size = new System.Drawing.Size(75, 23);
            this.btnStopPhoneChangeTelco.TabIndex = 2;
            this.btnStopPhoneChangeTelco.Text = "Stop";
            this.btnStopPhoneChangeTelco.UseVisualStyleBackColor = false;
            this.btnStopPhoneChangeTelco.Click += new System.EventHandler(this.BtnStopPhoneChangeTelco_Click);
            // 
            // OperatorGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "OperatorGateway";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operator Gateway - v1.0";
            this.Load += new System.EventHandler(this.OperatorGateway_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabMonitorService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.grbService.ResumeLayout(false);
            this.grbService.PerformLayout();
            this.tabPhoneChangeTelco.ResumeLayout(false);
            this.grbMonitorPhoneChangeTelco.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabMonitorService;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.GroupBox grbService;
        private System.Windows.Forms.Button btnViewLogService;
        private System.Windows.Forms.TextBox txtServiceDisplay;
        private System.Windows.Forms.Label lblServiceDisplay;
        private System.Windows.Forms.TextBox txtServiceStatus;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnServiceStart;
        private System.Windows.Forms.Button btnServiceStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabPhoneChangeTelco;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTS017dff08;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewLogPhoneChangeTelco;
        private System.Windows.Forms.TextBox txtTS0165a601;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJSESSIONID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartPhoneChangeTelco;
        private System.Windows.Forms.Button btnStopPhoneChangeTelco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUrlData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRedis;
        private System.Windows.Forms.CheckBox chkEdu;
        private System.Windows.Forms.CheckBox chkGateway;
        private System.Windows.Forms.GroupBox grbMonitorPhoneChangeTelco;
        private System.Windows.Forms.RichTextBox rtbMonitor;
        private System.Windows.Forms.ComboBox cbbStartType;
        private System.Windows.Forms.Label lblStartType;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Label label9;
    }
}


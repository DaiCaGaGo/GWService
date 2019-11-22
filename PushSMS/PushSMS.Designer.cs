namespace PushSMS
{
    partial class PushSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PushSMS));
            this.tabPagePushSMS = new System.Windows.Forms.TabPage();
            this.grbFooter = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grbMonitor = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grbAppConfig = new System.Windows.Forms.GroupBox();
            this.chkLogError = new System.Windows.Forms.CheckBox();
            this.chkLogInfo = new System.Windows.Forms.CheckBox();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnCleanLog = new System.Windows.Forms.Button();
            this.chkFormatJson = new System.Windows.Forms.CheckBox();
            this.txtLimitLog = new System.Windows.Forms.TextBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.grbQueue = new System.Windows.Forms.GroupBox();
            this.cbbCountSMS = new System.Windows.Forms.ComboBox();
            this.cbbInterval = new System.Windows.Forms.ComboBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.cbbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.txtOracleConnection = new System.Windows.Forms.TextBox();
            this.lblOracleConnection = new System.Windows.Forms.Label();
            this.ltlCountSMS = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtRabbitConnection = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.cbbSmsType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPagePushSMS.SuspendLayout();
            this.grbFooter.SuspendLayout();
            this.grbMonitor.SuspendLayout();
            this.grbAppConfig.SuspendLayout();
            this.grbQueue.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagePushSMS
            // 
            this.tabPagePushSMS.Controls.Add(this.grbFooter);
            this.tabPagePushSMS.Controls.Add(this.grbMonitor);
            this.tabPagePushSMS.Controls.Add(this.grbAppConfig);
            this.tabPagePushSMS.Controls.Add(this.grbQueue);
            this.tabPagePushSMS.Location = new System.Drawing.Point(4, 22);
            this.tabPagePushSMS.Name = "tabPagePushSMS";
            this.tabPagePushSMS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePushSMS.Size = new System.Drawing.Size(1176, 635);
            this.tabPagePushSMS.TabIndex = 0;
            this.tabPagePushSMS.Text = "Push SMS CSKH";
            this.tabPagePushSMS.UseVisualStyleBackColor = true;
            // 
            // grbFooter
            // 
            this.grbFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFooter.Controls.Add(this.lblCount);
            this.grbFooter.Controls.Add(this.lblTotal);
            this.grbFooter.Location = new System.Drawing.Point(13, 595);
            this.grbFooter.Name = "grbFooter";
            this.grbFooter.Size = new System.Drawing.Size(1150, 38);
            this.grbFooter.TabIndex = 11;
            this.grbFooter.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblCount.Location = new System.Drawing.Point(46, 16);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(10, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total";
            // 
            // grbMonitor
            // 
            this.grbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMonitor.Controls.Add(this.rtbLog);
            this.grbMonitor.Location = new System.Drawing.Point(13, 150);
            this.grbMonitor.Name = "grbMonitor";
            this.grbMonitor.Size = new System.Drawing.Size(1150, 445);
            this.grbMonitor.TabIndex = 10;
            this.grbMonitor.TabStop = false;
            this.grbMonitor.Text = "Monitor";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbLog.Location = new System.Drawing.Point(3, 16);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1144, 426);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // grbAppConfig
            // 
            this.grbAppConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbAppConfig.Controls.Add(this.chkLogError);
            this.grbAppConfig.Controls.Add(this.chkLogInfo);
            this.grbAppConfig.Controls.Add(this.btnViewLog);
            this.grbAppConfig.Controls.Add(this.btnCleanLog);
            this.grbAppConfig.Controls.Add(this.chkFormatJson);
            this.grbAppConfig.Controls.Add(this.txtLimitLog);
            this.grbAppConfig.Controls.Add(this.lblLimit);
            this.grbAppConfig.Location = new System.Drawing.Point(13, 86);
            this.grbAppConfig.Name = "grbAppConfig";
            this.grbAppConfig.Size = new System.Drawing.Size(1150, 60);
            this.grbAppConfig.TabIndex = 9;
            this.grbAppConfig.TabStop = false;
            this.grbAppConfig.Text = "Log config";
            // 
            // chkLogError
            // 
            this.chkLogError.AutoSize = true;
            this.chkLogError.Checked = true;
            this.chkLogError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogError.Location = new System.Drawing.Point(400, 25);
            this.chkLogError.Name = "chkLogError";
            this.chkLogError.Size = new System.Drawing.Size(69, 17);
            this.chkLogError.TabIndex = 9;
            this.chkLogError.Text = "Log Error";
            this.chkLogError.UseVisualStyleBackColor = true;
            // 
            // chkLogInfo
            // 
            this.chkLogInfo.AutoSize = true;
            this.chkLogInfo.Checked = true;
            this.chkLogInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogInfo.Location = new System.Drawing.Point(329, 25);
            this.chkLogInfo.Name = "chkLogInfo";
            this.chkLogInfo.Size = new System.Drawing.Size(65, 17);
            this.chkLogInfo.TabIndex = 8;
            this.chkLogInfo.Text = "Log Info";
            this.chkLogInfo.UseVisualStyleBackColor = true;
            // 
            // btnViewLog
            // 
            this.btnViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLog.Location = new System.Drawing.Point(982, 21);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(75, 23);
            this.btnViewLog.TabIndex = 10;
            this.btnViewLog.Text = "View log";
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.BtnViewLog_Click);
            // 
            // btnCleanLog
            // 
            this.btnCleanLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCleanLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanLog.Location = new System.Drawing.Point(1063, 21);
            this.btnCleanLog.Name = "btnCleanLog";
            this.btnCleanLog.Size = new System.Drawing.Size(75, 23);
            this.btnCleanLog.TabIndex = 11;
            this.btnCleanLog.Text = "Clean log";
            this.btnCleanLog.UseVisualStyleBackColor = false;
            this.btnCleanLog.Click += new System.EventHandler(this.BtnCleanLog_Click);
            // 
            // chkFormatJson
            // 
            this.chkFormatJson.AutoSize = true;
            this.chkFormatJson.Location = new System.Drawing.Point(220, 25);
            this.chkFormatJson.Name = "chkFormatJson";
            this.chkFormatJson.Size = new System.Drawing.Size(103, 17);
            this.chkFormatJson.TabIndex = 7;
            this.chkFormatJson.Text = "Format message";
            this.chkFormatJson.UseVisualStyleBackColor = true;
            // 
            // txtLimitLog
            // 
            this.txtLimitLog.Location = new System.Drawing.Point(111, 23);
            this.txtLimitLog.Name = "txtLimitLog";
            this.txtLimitLog.Size = new System.Drawing.Size(75, 20);
            this.txtLimitLog.TabIndex = 6;
            this.txtLimitLog.Text = "200";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(10, 26);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(70, 13);
            this.lblLimit.TabIndex = 0;
            this.lblLimit.Text = "Limit write log";
            // 
            // grbQueue
            // 
            this.grbQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbQueue.Controls.Add(this.cbbSmsType);
            this.grbQueue.Controls.Add(this.label1);
            this.grbQueue.Controls.Add(this.cbbCountSMS);
            this.grbQueue.Controls.Add(this.cbbInterval);
            this.grbQueue.Controls.Add(this.txtOracleConnection);
            this.grbQueue.Controls.Add(this.lblOracleConnection);
            this.grbQueue.Controls.Add(this.lblInterval);
            this.grbQueue.Controls.Add(this.ltlCountSMS);
            this.grbQueue.Controls.Add(this.btnStop);
            this.grbQueue.Controls.Add(this.cbbMode);
            this.grbQueue.Controls.Add(this.lblMode);
            this.grbQueue.Controls.Add(this.btnStart);
            this.grbQueue.Controls.Add(this.txtRabbitConnection);
            this.grbQueue.Controls.Add(this.lblHost);
            this.grbQueue.Location = new System.Drawing.Point(13, 3);
            this.grbQueue.Margin = new System.Windows.Forms.Padding(13);
            this.grbQueue.Name = "grbQueue";
            this.grbQueue.Size = new System.Drawing.Size(1150, 78);
            this.grbQueue.TabIndex = 8;
            this.grbQueue.TabStop = false;
            this.grbQueue.Text = "Tool infomation";
            // 
            // cbbCountSMS
            // 
            this.cbbCountSMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbCountSMS.FormattingEnabled = true;
            this.cbbCountSMS.Items.AddRange(new object[] {
            "1",
            "10",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "50000"});
            this.cbbCountSMS.Location = new System.Drawing.Point(901, 47);
            this.cbbCountSMS.Name = "cbbCountSMS";
            this.cbbCountSMS.Size = new System.Drawing.Size(75, 21);
            this.cbbCountSMS.TabIndex = 6;
            this.cbbCountSMS.Text = "200";
            this.cbbCountSMS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbbCountSMS_KeyPress);
            // 
            // cbbInterval
            // 
            this.cbbInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbInterval.FormattingEnabled = true;
            this.cbbInterval.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "2000"});
            this.cbbInterval.Location = new System.Drawing.Point(1063, 19);
            this.cbbInterval.Name = "cbbInterval";
            this.cbbInterval.Size = new System.Drawing.Size(75, 21);
            this.cbbInterval.TabIndex = 3;
            this.cbbInterval.Text = "500";
            this.cbbInterval.Visible = false;
            this.cbbInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbbInterval_KeyPress);
            // 
            // lblInterval
            // 
            this.lblInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(979, 22);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 12;
            this.lblInterval.Text = "Interval";
            this.lblInterval.Visible = false;
            // 
            // cbbMode
            // 
            this.cbbMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMode.FormattingEnabled = true;
            this.cbbMode.Items.AddRange(new object[] {
            "Listener",
            "Timer"});
            this.cbbMode.Location = new System.Drawing.Point(901, 19);
            this.cbbMode.Name = "cbbMode";
            this.cbbMode.Size = new System.Drawing.Size(75, 21);
            this.cbbMode.TabIndex = 2;
            this.cbbMode.Text = "Listener";
            this.cbbMode.SelectedIndexChanged += new System.EventHandler(this.CbbMode_SelectedIndexChanged);
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(834, 22);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 10;
            this.lblMode.Text = "Mode";
            // 
            // txtOracleConnection
            // 
            this.txtOracleConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOracleConnection.Location = new System.Drawing.Point(111, 19);
            this.txtOracleConnection.Name = "txtOracleConnection";
            this.txtOracleConnection.Size = new System.Drawing.Size(717, 20);
            this.txtOracleConnection.TabIndex = 1;
            // 
            // lblOracleConnection
            // 
            this.lblOracleConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOracleConnection.AutoSize = true;
            this.lblOracleConnection.Location = new System.Drawing.Point(10, 22);
            this.lblOracleConnection.Name = "lblOracleConnection";
            this.lblOracleConnection.Size = new System.Drawing.Size(95, 13);
            this.lblOracleConnection.TabIndex = 8;
            this.lblOracleConnection.Text = "Oracle Connection";
            // 
            // ltlCountSMS
            // 
            this.ltlCountSMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltlCountSMS.AutoSize = true;
            this.ltlCountSMS.Location = new System.Drawing.Point(834, 50);
            this.ltlCountSMS.Name = "ltlCountSMS";
            this.ltlCountSMS.Size = new System.Drawing.Size(61, 13);
            this.ltlCountSMS.TabIndex = 6;
            this.ltlCountSMS.Text = "SMS Count";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Tomato;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(1063, 45);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.AllowDrop = true;
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(982, 45);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtRabbitConnection
            // 
            this.txtRabbitConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRabbitConnection.Location = new System.Drawing.Point(111, 47);
            this.txtRabbitConnection.Name = "txtRabbitConnection";
            this.txtRabbitConnection.Size = new System.Drawing.Size(573, 20);
            this.txtRabbitConnection.TabIndex = 4;
            // 
            // lblHost
            // 
            this.lblHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(10, 50);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(95, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Rabbit Connection";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagePushSMS);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1184, 661);
            this.tabControlMain.TabIndex = 0;
            // 
            // cbbSmsType
            // 
            this.cbbSmsType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSmsType.FormattingEnabled = true;
            this.cbbSmsType.Items.AddRange(new object[] {
            "CSKH",
            "QC"});
            this.cbbSmsType.Location = new System.Drawing.Point(753, 47);
            this.cbbSmsType.Name = "cbbSmsType";
            this.cbbSmsType.Size = new System.Drawing.Size(75, 21);
            this.cbbSmsType.TabIndex = 5;
            this.cbbSmsType.Text = "CSKH";
            this.cbbSmsType.SelectedIndexChanged += new System.EventHandler(this.CbbSmsType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "SMS Type";
            // 
            // PushSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1015, 620);
            this.Name = "PushSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Push SMS CSKH Conek - v1.0";
            this.tabPagePushSMS.ResumeLayout(false);
            this.grbFooter.ResumeLayout(false);
            this.grbFooter.PerformLayout();
            this.grbMonitor.ResumeLayout(false);
            this.grbAppConfig.ResumeLayout(false);
            this.grbAppConfig.PerformLayout();
            this.grbQueue.ResumeLayout(false);
            this.grbQueue.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPagePushSMS;
        private System.Windows.Forms.GroupBox grbFooter;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grbMonitor;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox grbAppConfig;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Button btnCleanLog;
        private System.Windows.Forms.CheckBox chkFormatJson;
        private System.Windows.Forms.TextBox txtLimitLog;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.GroupBox grbQueue;
        private System.Windows.Forms.ComboBox cbbCountSMS;
        private System.Windows.Forms.ComboBox cbbInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.ComboBox cbbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TextBox txtOracleConnection;
        private System.Windows.Forms.Label lblOracleConnection;
        private System.Windows.Forms.Label ltlCountSMS;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtRabbitConnection;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.CheckBox chkLogError;
        private System.Windows.Forms.CheckBox chkLogInfo;
        private System.Windows.Forms.ComboBox cbbSmsType;
        private System.Windows.Forms.Label label1;
    }
}


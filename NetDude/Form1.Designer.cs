namespace netDude
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusPic = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHost = new System.Windows.Forms.CheckBox();
            this.chkTCP = new System.Windows.Forms.CheckBox();
            this.chkIP4 = new System.Windows.Forms.CheckBox();
            this.chkIP6 = new System.Windows.Forms.CheckBox();
            this.chkICMP = new System.Windows.Forms.CheckBox();
            this.chkUDP = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chkIP = new System.Windows.Forms.CheckBox();
            this.chkIGMP = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCapStop = new System.Windows.Forms.Button();
            this.btnCapStart = new System.Windows.Forms.Button();
            this.lnkIPColor = new System.Windows.Forms.LinkLabel();
            this.lnkIGMPColor = new System.Windows.Forms.LinkLabel();
            this.lnkICMPColor = new System.Windows.Forms.LinkLabel();
            this.lnkUDPColor = new System.Windows.Forms.LinkLabel();
            this.lnkIP6Color = new System.Windows.Forms.LinkLabel();
            this.lnkIP4Color = new System.Windows.Forms.LinkLabel();
            this.lnkTCPColor = new System.Windows.Forms.LinkLabel();
            this.lnkHostColor = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lnkClearData = new System.Windows.Forms.LinkLabel();
            this.lstTopTalkers = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTopTalker = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHostIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPacketDrop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPacketRcv = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1350, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusPic});
            this.statusStrip1.Location = new System.Drawing.Point(0, 700);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1350, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 20);
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusPic
            // 
            this.lblStatusPic.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatusPic.Image = global::netDude.Properties.Resources.greenoff1;
            this.lblStatusPic.Name = "lblStatusPic";
            this.lblStatusPic.Size = new System.Drawing.Size(20, 20);
            // 
            // cmbDevice
            // 
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(89, 23);
            this.cmbDevice.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(399, 24);
            this.cmbDevice.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDevice);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(508, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device";
            // 
            // chkHost
            // 
            this.chkHost.AutoSize = true;
            this.chkHost.Location = new System.Drawing.Point(61, 26);
            this.chkHost.Margin = new System.Windows.Forms.Padding(4);
            this.chkHost.Name = "chkHost";
            this.chkHost.Size = new System.Drawing.Size(59, 21);
            this.chkHost.TabIndex = 4;
            this.chkHost.Text = "Host";
            this.chkHost.UseVisualStyleBackColor = true;
            this.chkHost.CheckedChanged += new System.EventHandler(this.chkHost_CheckedChanged);
            // 
            // chkTCP
            // 
            this.chkTCP.AutoSize = true;
            this.chkTCP.Location = new System.Drawing.Point(61, 59);
            this.chkTCP.Margin = new System.Windows.Forms.Padding(4);
            this.chkTCP.Name = "chkTCP";
            this.chkTCP.Size = new System.Drawing.Size(57, 21);
            this.chkTCP.TabIndex = 5;
            this.chkTCP.Text = "TCP";
            this.chkTCP.UseVisualStyleBackColor = true;
            this.chkTCP.CheckedChanged += new System.EventHandler(this.chkTCP_CheckedChanged);
            // 
            // chkIP4
            // 
            this.chkIP4.AutoSize = true;
            this.chkIP4.Location = new System.Drawing.Point(223, 26);
            this.chkIP4.Margin = new System.Windows.Forms.Padding(4);
            this.chkIP4.Name = "chkIP4";
            this.chkIP4.Size = new System.Drawing.Size(50, 21);
            this.chkIP4.TabIndex = 6;
            this.chkIP4.Text = "IP4";
            this.chkIP4.UseVisualStyleBackColor = true;
            this.chkIP4.CheckedChanged += new System.EventHandler(this.chkIP4_CheckedChanged);
            // 
            // chkIP6
            // 
            this.chkIP6.AutoSize = true;
            this.chkIP6.Location = new System.Drawing.Point(223, 59);
            this.chkIP6.Margin = new System.Windows.Forms.Padding(4);
            this.chkIP6.Name = "chkIP6";
            this.chkIP6.Size = new System.Drawing.Size(50, 21);
            this.chkIP6.TabIndex = 7;
            this.chkIP6.Text = "IP6";
            this.chkIP6.UseVisualStyleBackColor = true;
            this.chkIP6.CheckedChanged += new System.EventHandler(this.chkIP6_CheckedChanged);
            // 
            // chkICMP
            // 
            this.chkICMP.AutoSize = true;
            this.chkICMP.Location = new System.Drawing.Point(60, 129);
            this.chkICMP.Margin = new System.Windows.Forms.Padding(4);
            this.chkICMP.Name = "chkICMP";
            this.chkICMP.Size = new System.Drawing.Size(62, 21);
            this.chkICMP.TabIndex = 9;
            this.chkICMP.Text = "ICMP";
            this.chkICMP.UseVisualStyleBackColor = true;
            this.chkICMP.CheckedChanged += new System.EventHandler(this.chkICMP_CheckedChanged);
            // 
            // chkUDP
            // 
            this.chkUDP.AutoSize = true;
            this.chkUDP.Location = new System.Drawing.Point(60, 95);
            this.chkUDP.Margin = new System.Windows.Forms.Padding(4);
            this.chkUDP.Name = "chkUDP";
            this.chkUDP.Size = new System.Drawing.Size(59, 21);
            this.chkUDP.TabIndex = 8;
            this.chkUDP.Text = "UDP";
            this.chkUDP.UseVisualStyleBackColor = true;
            this.chkUDP.CheckedChanged += new System.EventHandler(this.chkUDP_CheckedChanged);
            // 
            // chkIP
            // 
            this.chkIP.AutoSize = true;
            this.chkIP.Location = new System.Drawing.Point(223, 129);
            this.chkIP.Margin = new System.Windows.Forms.Padding(4);
            this.chkIP.Name = "chkIP";
            this.chkIP.Size = new System.Drawing.Size(42, 21);
            this.chkIP.TabIndex = 11;
            this.chkIP.Text = "IP";
            this.chkIP.UseVisualStyleBackColor = true;
            this.chkIP.CheckedChanged += new System.EventHandler(this.chkIP_CheckedChanged);
            // 
            // chkIGMP
            // 
            this.chkIGMP.AutoSize = true;
            this.chkIGMP.Location = new System.Drawing.Point(223, 95);
            this.chkIGMP.Margin = new System.Windows.Forms.Padding(4);
            this.chkIGMP.Name = "chkIGMP";
            this.chkIGMP.Size = new System.Drawing.Size(64, 21);
            this.chkIGMP.TabIndex = 10;
            this.chkIGMP.Text = "IGMP";
            this.chkIGMP.UseVisualStyleBackColor = true;
            this.chkIGMP.CheckedChanged += new System.EventHandler(this.chkIGMP_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCapStop);
            this.groupBox2.Controls.Add(this.btnCapStart);
            this.groupBox2.Controls.Add(this.lnkIPColor);
            this.groupBox2.Controls.Add(this.lnkIGMPColor);
            this.groupBox2.Controls.Add(this.lnkICMPColor);
            this.groupBox2.Controls.Add(this.lnkUDPColor);
            this.groupBox2.Controls.Add(this.lnkIP6Color);
            this.groupBox2.Controls.Add(this.lnkIP4Color);
            this.groupBox2.Controls.Add(this.lnkTCPColor);
            this.groupBox2.Controls.Add(this.lnkHostColor);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkIP);
            this.groupBox2.Controls.Add(this.chkHost);
            this.groupBox2.Controls.Add(this.chkIGMP);
            this.groupBox2.Controls.Add(this.chkTCP);
            this.groupBox2.Controls.Add(this.chkICMP);
            this.groupBox2.Controls.Add(this.chkIP4);
            this.groupBox2.Controls.Add(this.chkUDP);
            this.groupBox2.Controls.Add(this.chkIP6);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(16, 110);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(508, 214);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // btnCapStop
            // 
            this.btnCapStop.FlatAppearance.BorderSize = 0;
            this.btnCapStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCapStop.Image = global::netDude.Properties.Resources.greenoff1;
            this.btnCapStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapStop.Location = new System.Drawing.Point(372, 172);
            this.btnCapStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapStop.Name = "btnCapStop";
            this.btnCapStop.Size = new System.Drawing.Size(77, 28);
            this.btnCapStop.TabIndex = 23;
            this.btnCapStop.Text = "Stop";
            this.btnCapStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapStop.UseVisualStyleBackColor = false;
            this.btnCapStop.Click += new System.EventHandler(this.btnCapStop_ItemClick);
            // 
            // btnCapStart
            // 
            this.btnCapStart.FlatAppearance.BorderSize = 0;
            this.btnCapStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCapStart.Image = global::netDude.Properties.Resources.greenoff1;
            this.btnCapStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapStart.Location = new System.Drawing.Point(277, 172);
            this.btnCapStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapStart.Name = "btnCapStart";
            this.btnCapStart.Size = new System.Drawing.Size(77, 28);
            this.btnCapStart.TabIndex = 22;
            this.btnCapStart.Text = "Start";
            this.btnCapStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapStart.UseVisualStyleBackColor = false;
            this.btnCapStart.Click += new System.EventHandler(this.btnCapStart_ItemClick);
            // 
            // lnkIPColor
            // 
            this.lnkIPColor.AutoSize = true;
            this.lnkIPColor.LinkColor = System.Drawing.Color.DeepPink;
            this.lnkIPColor.Location = new System.Drawing.Point(296, 130);
            this.lnkIPColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkIPColor.Name = "lnkIPColor";
            this.lnkIPColor.Size = new System.Drawing.Size(57, 17);
            this.lnkIPColor.TabIndex = 21;
            this.lnkIPColor.TabStop = true;
            this.lnkIPColor.Text = "IP Color";
            // 
            // lnkIGMPColor
            // 
            this.lnkIGMPColor.AutoSize = true;
            this.lnkIGMPColor.LinkColor = System.Drawing.Color.HotPink;
            this.lnkIGMPColor.Location = new System.Drawing.Point(296, 96);
            this.lnkIGMPColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkIGMPColor.Name = "lnkIGMPColor";
            this.lnkIGMPColor.Size = new System.Drawing.Size(79, 17);
            this.lnkIGMPColor.TabIndex = 20;
            this.lnkIGMPColor.TabStop = true;
            this.lnkIGMPColor.Text = "IGMP Color";
            // 
            // lnkICMPColor
            // 
            this.lnkICMPColor.AutoSize = true;
            this.lnkICMPColor.LinkColor = System.Drawing.Color.Yellow;
            this.lnkICMPColor.Location = new System.Drawing.Point(132, 130);
            this.lnkICMPColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkICMPColor.Name = "lnkICMPColor";
            this.lnkICMPColor.Size = new System.Drawing.Size(77, 17);
            this.lnkICMPColor.TabIndex = 19;
            this.lnkICMPColor.TabStop = true;
            this.lnkICMPColor.Text = "ICMP Color";
            // 
            // lnkUDPColor
            // 
            this.lnkUDPColor.AutoSize = true;
            this.lnkUDPColor.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lnkUDPColor.Location = new System.Drawing.Point(132, 96);
            this.lnkUDPColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkUDPColor.Name = "lnkUDPColor";
            this.lnkUDPColor.Size = new System.Drawing.Size(74, 17);
            this.lnkUDPColor.TabIndex = 18;
            this.lnkUDPColor.TabStop = true;
            this.lnkUDPColor.Text = "UDP Color";
            // 
            // lnkIP6Color
            // 
            this.lnkIP6Color.AutoSize = true;
            this.lnkIP6Color.LinkColor = System.Drawing.Color.Cyan;
            this.lnkIP6Color.Location = new System.Drawing.Point(296, 60);
            this.lnkIP6Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkIP6Color.Name = "lnkIP6Color";
            this.lnkIP6Color.Size = new System.Drawing.Size(65, 17);
            this.lnkIP6Color.TabIndex = 17;
            this.lnkIP6Color.TabStop = true;
            this.lnkIP6Color.Text = "IP6 Color";
            // 
            // lnkIP4Color
            // 
            this.lnkIP4Color.AutoSize = true;
            this.lnkIP4Color.LinkColor = System.Drawing.Color.Fuchsia;
            this.lnkIP4Color.Location = new System.Drawing.Point(296, 27);
            this.lnkIP4Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkIP4Color.Name = "lnkIP4Color";
            this.lnkIP4Color.Size = new System.Drawing.Size(65, 17);
            this.lnkIP4Color.TabIndex = 16;
            this.lnkIP4Color.TabStop = true;
            this.lnkIP4Color.Text = "IP4 Color";
            // 
            // lnkTCPColor
            // 
            this.lnkTCPColor.AutoSize = true;
            this.lnkTCPColor.LinkColor = System.Drawing.Color.Thistle;
            this.lnkTCPColor.Location = new System.Drawing.Point(132, 59);
            this.lnkTCPColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkTCPColor.Name = "lnkTCPColor";
            this.lnkTCPColor.Size = new System.Drawing.Size(72, 17);
            this.lnkTCPColor.TabIndex = 15;
            this.lnkTCPColor.TabStop = true;
            this.lnkTCPColor.Text = "TCP Color";
            // 
            // lnkHostColor
            // 
            this.lnkHostColor.AutoSize = true;
            this.lnkHostColor.LinkColor = System.Drawing.Color.Lime;
            this.lnkHostColor.Location = new System.Drawing.Point(132, 27);
            this.lnkHostColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkHostColor.Name = "lnkHostColor";
            this.lnkHostColor.Size = new System.Drawing.Size(74, 17);
            this.lnkHostColor.TabIndex = 14;
            this.lnkHostColor.TabStop = true;
            this.lnkHostColor.Text = "Host Color";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 175);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 22);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Draw Interval [MS]";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pBox1
            // 
            this.pBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox1.BackColor = System.Drawing.Color.Black;
            this.pBox1.Location = new System.Drawing.Point(533, 34);
            this.pBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(807, 660);
            this.pBox1.TabIndex = 5;
            this.pBox1.TabStop = false;
            this.pBox1.Resize += new System.EventHandler(this.pBox1_Resize);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lnkClearData);
            this.groupBox3.Controls.Add(this.lstTopTalkers);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtTopTalker);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtHostIP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtPacketDrop);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPacketRcv);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(16, 332);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(509, 228);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // lnkClearData
            // 
            this.lnkClearData.AutoSize = true;
            this.lnkClearData.LinkColor = System.Drawing.Color.Yellow;
            this.lnkClearData.Location = new System.Drawing.Point(27, 197);
            this.lnkClearData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkClearData.Name = "lnkClearData";
            this.lnkClearData.Size = new System.Drawing.Size(91, 17);
            this.lnkClearData.TabIndex = 13;
            this.lnkClearData.TabStop = true;
            this.lnkClearData.Text = "Clear IP Data";
            this.lnkClearData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearData_LinkClicked);
            // 
            // lstTopTalkers
            // 
            this.lstTopTalkers.FormattingEnabled = true;
            this.lstTopTalkers.ItemHeight = 16;
            this.lstTopTalkers.Location = new System.Drawing.Point(277, 55);
            this.lstTopTalkers.Margin = new System.Windows.Forms.Padding(4);
            this.lstTopTalkers.Name = "lstTopTalkers";
            this.lstTopTalkers.Size = new System.Drawing.Size(211, 148);
            this.lstTopTalkers.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Top Talkers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Top Talker";
            // 
            // txtTopTalker
            // 
            this.txtTopTalker.Location = new System.Drawing.Point(113, 151);
            this.txtTopTalker.Margin = new System.Windows.Forms.Padding(4);
            this.txtTopTalker.Name = "txtTopTalker";
            this.txtTopTalker.Size = new System.Drawing.Size(132, 22);
            this.txtTopTalker.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Host IP";
            // 
            // txtHostIP
            // 
            this.txtHostIP.Location = new System.Drawing.Point(113, 119);
            this.txtHostIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtHostIP.Name = "txtHostIP";
            this.txtHostIP.Size = new System.Drawing.Size(132, 22);
            this.txtHostIP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dropped";
            // 
            // txtPacketDrop
            // 
            this.txtPacketDrop.Location = new System.Drawing.Point(113, 87);
            this.txtPacketDrop.Margin = new System.Windows.Forms.Padding(4);
            this.txtPacketDrop.Name = "txtPacketDrop";
            this.txtPacketDrop.Size = new System.Drawing.Size(132, 22);
            this.txtPacketDrop.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Received";
            // 
            // txtPacketRcv
            // 
            this.txtPacketRcv.Location = new System.Drawing.Point(113, 55);
            this.txtPacketRcv.Margin = new System.Windows.Forms.Padding(4);
            this.txtPacketRcv.Name = "txtPacketRcv";
            this.txtPacketRcv.Size = new System.Drawing.Size(132, 22);
            this.txtPacketRcv.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numFontSize);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(16, 576);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(508, 100);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Font Size";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(113, 36);
            this.numFontSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(120, 22);
            this.numFontSize.TabIndex = 6;
            this.numFontSize.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1350, 725);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "netDude";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHost;
        private System.Windows.Forms.CheckBox chkTCP;
        private System.Windows.Forms.CheckBox chkIP4;
        private System.Windows.Forms.CheckBox chkIP6;
        private System.Windows.Forms.CheckBox chkICMP;
        private System.Windows.Forms.CheckBox chkUDP;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox chkIP;
        private System.Windows.Forms.CheckBox chkIGMP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkIPColor;
        private System.Windows.Forms.LinkLabel lnkIGMPColor;
        private System.Windows.Forms.LinkLabel lnkICMPColor;
        private System.Windows.Forms.LinkLabel lnkUDPColor;
        private System.Windows.Forms.LinkLabel lnkIP6Color;
        private System.Windows.Forms.LinkLabel lnkIP4Color;
        private System.Windows.Forms.LinkLabel lnkTCPColor;
        private System.Windows.Forms.LinkLabel lnkHostColor;
        private System.Windows.Forms.Button btnCapStart;
        private System.Windows.Forms.Button btnCapStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstTopTalkers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTopTalker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHostIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPacketDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPacketRcv;
        private System.Windows.Forms.LinkLabel lnkClearData;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusPic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.Label label8;
    }
}


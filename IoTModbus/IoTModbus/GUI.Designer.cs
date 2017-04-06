namespace IoTModbus
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.tabRaw = new System.Windows.Forms.TabPage();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpSimulator = new System.Windows.Forms.TabPage();
            this.chkControl = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trkA1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trkA2 = new System.Windows.Forms.TrackBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ledAO2 = new System.Windows.Forms.PictureBox();
            this.ledAO1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.rdoD4 = new System.Windows.Forms.RadioButton();
            this.rdo02 = new System.Windows.Forms.RadioButton();
            this.rdoD3 = new System.Windows.Forms.RadioButton();
            this.ledDO1 = new System.Windows.Forms.PictureBox();
            this.ledDO3 = new System.Windows.Forms.PictureBox();
            this.ledDO2 = new System.Windows.Forms.PictureBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.rdoD2 = new System.Windows.Forms.RadioButton();
            this.rdo01 = new System.Windows.Forms.RadioButton();
            this.rdoD1 = new System.Windows.Forms.RadioButton();
            this.ledDO4 = new System.Windows.Forms.PictureBox();
            this.tpgValues = new System.Windows.Forms.TabPage();
            this.chkKeepAlive = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnWriteSH = new System.Windows.Forms.Button();
            this.txtWriteSHV = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtWriteSHStartA = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkWriteSCV1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnWriteSCoil = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWriteSCStartA = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtWriteHStartA = new System.Windows.Forms.TextBox();
            this.btnWriteHoldings = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.txtWriteHV1 = new System.Windows.Forms.TextBox();
            this.txtWriteHNum = new System.Windows.Forms.TextBox();
            this.txtWriteHV2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkWriteCV4 = new System.Windows.Forms.CheckBox();
            this.chkWriteCV3 = new System.Windows.Forms.CheckBox();
            this.chkWriteCV2 = new System.Windows.Forms.CheckBox();
            this.chkWriteCV1 = new System.Windows.Forms.CheckBox();
            this.txtWriteCStartA = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtWriteCNum = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnWriteCoils = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtReadIRegV1 = new System.Windows.Forms.TextBox();
            this.txtReadIRegNum = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtReadIRegStartA = new System.Windows.Forms.TextBox();
            this.btnReadInputReg = new System.Windows.Forms.Button();
            this.txtReadIRegV2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtReadHStartA = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtReadHNum = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtReadHV1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtReadHV2 = new System.Windows.Forms.TextBox();
            this.btnReadHoldings = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReadCoilsV1 = new System.Windows.Forms.TextBox();
            this.txtReadCoilsV2 = new System.Windows.Forms.TextBox();
            this.txtReadCoilsStartA = new System.Windows.Forms.TextBox();
            this.txtReadCoilsV3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtReadCoilsV4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtReadCoilsNum = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReadDNum = new System.Windows.Forms.TextBox();
            this.btnReadDis = new System.Windows.Forms.Button();
            this.txtReadDStartA = new System.Windows.Forms.TextBox();
            this.txtReadDV1 = new System.Windows.Forms.TextBox();
            this.txtReadDV2 = new System.Windows.Forms.TextBox();
            this.txtReadDV3 = new System.Windows.Forms.TextBox();
            this.txtReadDV4 = new System.Windows.Forms.TextBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoBinary = new System.Windows.Forms.RadioButton();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.grpIP = new System.Windows.Forms.GroupBox();
            this.rdoManual = new System.Windows.Forms.RadioButton();
            this.rdoAuto = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblIP = new System.Windows.Forms.Label();
            this.cboIP = new System.Windows.Forms.ComboBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpSimulator.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAO2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAO1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO2)).BeginInit();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO4)).BeginInit();
            this.tpgValues.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.grpIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(80, 426);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(147, 45);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(80, 482);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(147, 45);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(66, 188);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(134, 37);
            this.btnReadCoils.TabIndex = 4;
            this.btnReadCoils.Text = "Read Coils";
            this.btnReadCoils.UseVisualStyleBackColor = true;
            this.btnReadCoils.Click += new System.EventHandler(this.btnReadCoils_Click);
            // 
            // tabRaw
            // 
            this.tabRaw.Location = new System.Drawing.Point(4, 22);
            this.tabRaw.Name = "tabRaw";
            this.tabRaw.Size = new System.Drawing.Size(494, 349);
            this.tabRaw.TabIndex = 2;
            this.tabRaw.Text = "Messages";
            this.tabRaw.UseVisualStyleBackColor = true;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpSimulator);
            this.tbcMain.Controls.Add(this.tpgValues);
            this.tbcMain.Enabled = false;
            this.tbcMain.Location = new System.Drawing.Point(470, 14);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(836, 565);
            this.tbcMain.TabIndex = 6;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbpSimulator
            // 
            this.tbpSimulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(211)))), ((int)(((byte)(0)))));
            this.tbpSimulator.Controls.Add(this.chkControl);
            this.tbpSimulator.Controls.Add(this.panel2);
            this.tbpSimulator.Controls.Add(this.panel1);
            this.tbpSimulator.Location = new System.Drawing.Point(4, 29);
            this.tbpSimulator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpSimulator.Name = "tbpSimulator";
            this.tbpSimulator.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpSimulator.Size = new System.Drawing.Size(828, 532);
            this.tbpSimulator.TabIndex = 1;
            this.tbpSimulator.Text = "Device Simulator";
            // 
            // chkControl
            // 
            this.chkControl.AutoSize = true;
            this.chkControl.Location = new System.Drawing.Point(8, 122);
            this.chkControl.Name = "chkControl";
            this.chkControl.Size = new System.Drawing.Size(142, 24);
            this.chkControl.TabIndex = 2;
            this.chkControl.Text = "Manual Control";
            this.chkControl.UseVisualStyleBackColor = true;
            this.chkControl.CheckedChanged += new System.EventHandler(this.chkControl_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.trkA1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trkA2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.ledAO2);
            this.panel2.Controls.Add(this.ledAO1);
            this.panel2.Location = new System.Drawing.Point(336, 154);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 371);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "10V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "0V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "-10V";
            // 
            // trkA1
            // 
            this.trkA1.Location = new System.Drawing.Point(28, 78);
            this.trkA1.Maximum = 32767;
            this.trkA1.Minimum = -32768;
            this.trkA1.Name = "trkA1";
            this.trkA1.Size = new System.Drawing.Size(154, 69);
            this.trkA1.TabIndex = 16;
            this.trkA1.Scroll += new System.EventHandler(this.trkA1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "10V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "0V";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "-10V";
            // 
            // trkA2
            // 
            this.trkA2.Location = new System.Drawing.Point(28, 260);
            this.trkA2.Maximum = 32767;
            this.trkA2.Minimum = -32768;
            this.trkA2.Name = "trkA2";
            this.trkA2.Size = new System.Drawing.Size(154, 69);
            this.trkA2.TabIndex = 12;
            this.trkA2.Scroll += new System.EventHandler(this.trkA2_Scroll);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(410, 37);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 43);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(410, 125);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(42, 43);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(410, 217);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 43);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(410, 300);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 43);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ledAO2
            // 
            this.ledAO2.Image = ((System.Drawing.Image)(resources.GetObject("ledAO2.Image")));
            this.ledAO2.InitialImage = null;
            this.ledAO2.Location = new System.Drawing.Point(244, 260);
            this.ledAO2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledAO2.Name = "ledAO2";
            this.ledAO2.Size = new System.Drawing.Size(38, 38);
            this.ledAO2.TabIndex = 6;
            this.ledAO2.TabStop = false;
            // 
            // ledAO1
            // 
            this.ledAO1.Image = ((System.Drawing.Image)(resources.GetObject("ledAO1.Image")));
            this.ledAO1.InitialImage = null;
            this.ledAO1.Location = new System.Drawing.Point(244, 83);
            this.ledAO1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledAO1.Name = "ledAO1";
            this.ledAO1.Size = new System.Drawing.Size(38, 38);
            this.ledAO1.TabIndex = 6;
            this.ledAO1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnl2);
            this.panel1.Controls.Add(this.ledDO1);
            this.panel1.Controls.Add(this.ledDO3);
            this.panel1.Controls.Add(this.ledDO2);
            this.panel1.Controls.Add(this.pnl1);
            this.panel1.Controls.Add(this.ledDO4);
            this.panel1.Location = new System.Drawing.Point(0, 154);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 371);
            this.panel1.TabIndex = 0;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.rdoD4);
            this.pnl2.Controls.Add(this.rdo02);
            this.pnl2.Controls.Add(this.rdoD3);
            this.pnl2.Location = new System.Drawing.Point(62, 260);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(184, 35);
            this.pnl2.TabIndex = 9;
            // 
            // rdoD4
            // 
            this.rdoD4.AutoSize = true;
            this.rdoD4.Location = new System.Drawing.Point(108, 3);
            this.rdoD4.Name = "rdoD4";
            this.rdoD4.Size = new System.Drawing.Size(67, 24);
            this.rdoD4.TabIndex = 10;
            this.rdoD4.Text = "DO4";
            this.rdoD4.UseVisualStyleBackColor = true;
            this.rdoD4.CheckedChanged += new System.EventHandler(this.rdoD4_CheckedChanged);
            // 
            // rdo02
            // 
            this.rdo02.AutoSize = true;
            this.rdo02.Checked = true;
            this.rdo02.Location = new System.Drawing.Point(68, 3);
            this.rdo02.Name = "rdo02";
            this.rdo02.Size = new System.Drawing.Size(43, 24);
            this.rdo02.TabIndex = 9;
            this.rdo02.TabStop = true;
            this.rdo02.Text = "0";
            this.rdo02.UseVisualStyleBackColor = true;
            this.rdo02.CheckedChanged += new System.EventHandler(this.rdo02_CheckedChanged);
            // 
            // rdoD3
            // 
            this.rdoD3.AutoSize = true;
            this.rdoD3.Location = new System.Drawing.Point(4, 3);
            this.rdoD3.Name = "rdoD3";
            this.rdoD3.Size = new System.Drawing.Size(67, 24);
            this.rdoD3.TabIndex = 8;
            this.rdoD3.Text = "DO3";
            this.rdoD3.UseVisualStyleBackColor = true;
            this.rdoD3.CheckedChanged += new System.EventHandler(this.rdoD3_CheckedChanged);
            // 
            // ledDO1
            // 
            this.ledDO1.Image = ((System.Drawing.Image)(resources.GetObject("ledDO1.Image")));
            this.ledDO1.InitialImage = null;
            this.ledDO1.Location = new System.Drawing.Point(24, 83);
            this.ledDO1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledDO1.Name = "ledDO1";
            this.ledDO1.Size = new System.Drawing.Size(38, 38);
            this.ledDO1.TabIndex = 0;
            this.ledDO1.TabStop = false;
            // 
            // ledDO3
            // 
            this.ledDO3.Image = ((System.Drawing.Image)(resources.GetObject("ledDO3.Image")));
            this.ledDO3.InitialImage = null;
            this.ledDO3.Location = new System.Drawing.Point(24, 260);
            this.ledDO3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledDO3.Name = "ledDO3";
            this.ledDO3.Size = new System.Drawing.Size(38, 38);
            this.ledDO3.TabIndex = 1;
            this.ledDO3.TabStop = false;
            // 
            // ledDO2
            // 
            this.ledDO2.Image = global::IoTModbus.Properties.Resources.greenOff;
            this.ledDO2.InitialImage = null;
            this.ledDO2.Location = new System.Drawing.Point(249, 83);
            this.ledDO2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledDO2.Name = "ledDO2";
            this.ledDO2.Size = new System.Drawing.Size(38, 38);
            this.ledDO2.TabIndex = 3;
            this.ledDO2.TabStop = false;
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.rdoD2);
            this.pnl1.Controls.Add(this.rdo01);
            this.pnl1.Controls.Add(this.rdoD1);
            this.pnl1.Location = new System.Drawing.Point(62, 82);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(182, 40);
            this.pnl1.TabIndex = 8;
            // 
            // rdoD2
            // 
            this.rdoD2.AutoSize = true;
            this.rdoD2.Location = new System.Drawing.Point(112, 8);
            this.rdoD2.Name = "rdoD2";
            this.rdoD2.Size = new System.Drawing.Size(67, 24);
            this.rdoD2.TabIndex = 7;
            this.rdoD2.Text = "DO2";
            this.rdoD2.UseVisualStyleBackColor = true;
            this.rdoD2.CheckedChanged += new System.EventHandler(this.rdoD2_CheckedChanged);
            // 
            // rdo01
            // 
            this.rdo01.AutoSize = true;
            this.rdo01.Checked = true;
            this.rdo01.Location = new System.Drawing.Point(70, 8);
            this.rdo01.Name = "rdo01";
            this.rdo01.Size = new System.Drawing.Size(43, 24);
            this.rdo01.TabIndex = 6;
            this.rdo01.TabStop = true;
            this.rdo01.Text = "0";
            this.rdo01.UseVisualStyleBackColor = true;
            this.rdo01.CheckedChanged += new System.EventHandler(this.rdo01_CheckedChanged);
            // 
            // rdoD1
            // 
            this.rdoD1.AutoSize = true;
            this.rdoD1.Location = new System.Drawing.Point(8, 8);
            this.rdoD1.Name = "rdoD1";
            this.rdoD1.Size = new System.Drawing.Size(67, 24);
            this.rdoD1.TabIndex = 2;
            this.rdoD1.Text = "DO1";
            this.rdoD1.UseVisualStyleBackColor = true;
            this.rdoD1.CheckedChanged += new System.EventHandler(this.rdoD1_CheckedChanged);
            // 
            // ledDO4
            // 
            this.ledDO4.Image = global::IoTModbus.Properties.Resources.greenOff;
            this.ledDO4.InitialImage = null;
            this.ledDO4.Location = new System.Drawing.Point(249, 260);
            this.ledDO4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledDO4.Name = "ledDO4";
            this.ledDO4.Size = new System.Drawing.Size(38, 38);
            this.ledDO4.TabIndex = 2;
            this.ledDO4.TabStop = false;
            // 
            // tpgValues
            // 
            this.tpgValues.Controls.Add(this.chkKeepAlive);
            this.tpgValues.Controls.Add(this.groupBox9);
            this.tpgValues.Controls.Add(this.groupBox8);
            this.tpgValues.Controls.Add(this.groupBox7);
            this.tpgValues.Controls.Add(this.groupBox6);
            this.tpgValues.Controls.Add(this.groupBox3);
            this.tpgValues.Controls.Add(this.groupBox4);
            this.tpgValues.Controls.Add(this.groupBox2);
            this.tpgValues.Controls.Add(this.groupBox1);
            this.tpgValues.Location = new System.Drawing.Point(4, 29);
            this.tpgValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgValues.Name = "tpgValues";
            this.tpgValues.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgValues.Size = new System.Drawing.Size(828, 532);
            this.tpgValues.TabIndex = 0;
            this.tpgValues.Text = "Function Code Tester";
            this.tpgValues.UseVisualStyleBackColor = true;
            // 
            // chkKeepAlive
            // 
            this.chkKeepAlive.AutoSize = true;
            this.chkKeepAlive.Checked = true;
            this.chkKeepAlive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepAlive.Location = new System.Drawing.Point(712, 502);
            this.chkKeepAlive.Name = "chkKeepAlive";
            this.chkKeepAlive.Size = new System.Drawing.Size(109, 24);
            this.chkKeepAlive.TabIndex = 20;
            this.chkKeepAlive.Text = "Keep Alive";
            this.chkKeepAlive.UseVisualStyleBackColor = true;
            this.chkKeepAlive.CheckedChanged += new System.EventHandler(this.chkKeepAlive_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label26);
            this.groupBox9.Controls.Add(this.btnWriteSH);
            this.groupBox9.Controls.Add(this.txtWriteSHV);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.txtWriteSHStartA);
            this.groupBox9.Location = new System.Drawing.Point(340, 443);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(337, 82);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "FC 06: Write Single Register";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(96, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 20);
            this.label26.TabIndex = 20;
            this.label26.Text = "Value";
            // 
            // btnWriteSH
            // 
            this.btnWriteSH.Location = new System.Drawing.Point(198, 27);
            this.btnWriteSH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWriteSH.Name = "btnWriteSH";
            this.btnWriteSH.Size = new System.Drawing.Size(134, 35);
            this.btnWriteSH.TabIndex = 12;
            this.btnWriteSH.Text = "Write S. Reg";
            this.btnWriteSH.UseVisualStyleBackColor = true;
            this.btnWriteSH.Click += new System.EventHandler(this.btnWriteSR_Click);
            // 
            // txtWriteSHV
            // 
            this.txtWriteSHV.Location = new System.Drawing.Point(100, 45);
            this.txtWriteSHV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteSHV.Name = "txtWriteSHV";
            this.txtWriteSHV.Size = new System.Drawing.Size(90, 26);
            this.txtWriteSHV.TabIndex = 17;
            this.txtWriteSHV.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(68, 20);
            this.label27.TabIndex = 19;
            this.label27.Text = "Address";
            // 
            // txtWriteSHStartA
            // 
            this.txtWriteSHStartA.Location = new System.Drawing.Point(9, 45);
            this.txtWriteSHStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteSHStartA.Name = "txtWriteSHStartA";
            this.txtWriteSHStartA.Size = new System.Drawing.Size(84, 26);
            this.txtWriteSHStartA.TabIndex = 18;
            this.txtWriteSHStartA.Text = "0";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkWriteSCV1);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.btnWriteSCoil);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.txtWriteSCStartA);
            this.groupBox8.Location = new System.Drawing.Point(8, 443);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(323, 82);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "FC 05: Write Single Coil ";
            // 
            // chkWriteSCV1
            // 
            this.chkWriteSCV1.AutoSize = true;
            this.chkWriteSCV1.Location = new System.Drawing.Point(156, 51);
            this.chkWriteSCV1.Name = "chkWriteSCV1";
            this.chkWriteSCV1.Size = new System.Drawing.Size(22, 21);
            this.chkWriteSCV1.TabIndex = 32;
            this.chkWriteSCV1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(128, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Value";
            // 
            // btnWriteSCoil
            // 
            this.btnWriteSCoil.Location = new System.Drawing.Point(185, 28);
            this.btnWriteSCoil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWriteSCoil.Name = "btnWriteSCoil";
            this.btnWriteSCoil.Size = new System.Drawing.Size(134, 35);
            this.btnWriteSCoil.TabIndex = 11;
            this.btnWriteSCoil.Text = "Write S. Coil";
            this.btnWriteSCoil.UseVisualStyleBackColor = true;
            this.btnWriteSCoil.Click += new System.EventHandler(this.btnWriteSCoil_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Address";
            // 
            // txtWriteSCStartA
            // 
            this.txtWriteSCStartA.Location = new System.Drawing.Point(9, 48);
            this.txtWriteSCStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteSCStartA.Name = "txtWriteSCStartA";
            this.txtWriteSCStartA.Size = new System.Drawing.Size(84, 26);
            this.txtWriteSCStartA.TabIndex = 9;
            this.txtWriteSCStartA.Text = "0";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtWriteHStartA);
            this.groupBox7.Controls.Add(this.btnWriteHoldings);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.txtWriteHV1);
            this.groupBox7.Controls.Add(this.txtWriteHNum);
            this.groupBox7.Controls.Add(this.txtWriteHV2);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Location = new System.Drawing.Point(548, 262);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(256, 172);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "FC 16: Write Multiple Registers ";
            // 
            // txtWriteHStartA
            // 
            this.txtWriteHStartA.Location = new System.Drawing.Point(64, 49);
            this.txtWriteHStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteHStartA.Name = "txtWriteHStartA";
            this.txtWriteHStartA.Size = new System.Drawing.Size(82, 26);
            this.txtWriteHStartA.TabIndex = 23;
            this.txtWriteHStartA.Text = "0";
            // 
            // btnWriteHoldings
            // 
            this.btnWriteHoldings.Location = new System.Drawing.Point(62, 122);
            this.btnWriteHoldings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWriteHoldings.Name = "btnWriteHoldings";
            this.btnWriteHoldings.Size = new System.Drawing.Size(134, 35);
            this.btnWriteHoldings.TabIndex = 7;
            this.btnWriteHoldings.Text = "Write Holdings";
            this.btnWriteHoldings.UseVisualStyleBackColor = true;
            this.btnWriteHoldings.Click += new System.EventHandler(this.btnWriteHoldings_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(152, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 20);
            this.label23.TabIndex = 26;
            this.label23.Text = "Value";
            // 
            // txtWriteHV1
            // 
            this.txtWriteHV1.Location = new System.Drawing.Point(152, 51);
            this.txtWriteHV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteHV1.Name = "txtWriteHV1";
            this.txtWriteHV1.Size = new System.Drawing.Size(92, 26);
            this.txtWriteHV1.TabIndex = 20;
            this.txtWriteHV1.Text = "0";
            // 
            // txtWriteHNum
            // 
            this.txtWriteHNum.Location = new System.Drawing.Point(8, 49);
            this.txtWriteHNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteHNum.Name = "txtWriteHNum";
            this.txtWriteHNum.Size = new System.Drawing.Size(49, 26);
            this.txtWriteHNum.TabIndex = 22;
            this.txtWriteHNum.Text = "2";
            // 
            // txtWriteHV2
            // 
            this.txtWriteHV2.Location = new System.Drawing.Point(152, 88);
            this.txtWriteHV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteHV2.Name = "txtWriteHV2";
            this.txtWriteHV2.Size = new System.Drawing.Size(92, 26);
            this.txtWriteHV2.TabIndex = 21;
            this.txtWriteHV2.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(62, 26);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 20);
            this.label24.TabIndex = 25;
            this.label24.Text = "Start Addr.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 20);
            this.label25.TabIndex = 24;
            this.label25.Text = "Num";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkWriteCV4);
            this.groupBox6.Controls.Add(this.chkWriteCV3);
            this.groupBox6.Controls.Add(this.chkWriteCV2);
            this.groupBox6.Controls.Add(this.chkWriteCV1);
            this.groupBox6.Controls.Add(this.txtWriteCStartA);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txtWriteCNum);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.btnWriteCoils);
            this.groupBox6.Location = new System.Drawing.Point(542, 9);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(261, 242);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "FC 15: Write Multiple Coils ";
            // 
            // chkWriteCV4
            // 
            this.chkWriteCV4.AutoSize = true;
            this.chkWriteCV4.Location = new System.Drawing.Point(180, 154);
            this.chkWriteCV4.Name = "chkWriteCV4";
            this.chkWriteCV4.Size = new System.Drawing.Size(22, 21);
            this.chkWriteCV4.TabIndex = 31;
            this.chkWriteCV4.UseVisualStyleBackColor = true;
            // 
            // chkWriteCV3
            // 
            this.chkWriteCV3.AutoSize = true;
            this.chkWriteCV3.Location = new System.Drawing.Point(180, 120);
            this.chkWriteCV3.Name = "chkWriteCV3";
            this.chkWriteCV3.Size = new System.Drawing.Size(22, 21);
            this.chkWriteCV3.TabIndex = 30;
            this.chkWriteCV3.UseVisualStyleBackColor = true;
            // 
            // chkWriteCV2
            // 
            this.chkWriteCV2.AutoSize = true;
            this.chkWriteCV2.Location = new System.Drawing.Point(180, 83);
            this.chkWriteCV2.Name = "chkWriteCV2";
            this.chkWriteCV2.Size = new System.Drawing.Size(22, 21);
            this.chkWriteCV2.TabIndex = 29;
            this.chkWriteCV2.UseVisualStyleBackColor = true;
            // 
            // chkWriteCV1
            // 
            this.chkWriteCV1.AutoSize = true;
            this.chkWriteCV1.Location = new System.Drawing.Point(180, 45);
            this.chkWriteCV1.Name = "chkWriteCV1";
            this.chkWriteCV1.Size = new System.Drawing.Size(22, 21);
            this.chkWriteCV1.TabIndex = 28;
            this.chkWriteCV1.UseVisualStyleBackColor = true;
            // 
            // txtWriteCStartA
            // 
            this.txtWriteCStartA.Location = new System.Drawing.Point(66, 45);
            this.txtWriteCStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteCStartA.Name = "txtWriteCStartA";
            this.txtWriteCStartA.Size = new System.Drawing.Size(82, 26);
            this.txtWriteCStartA.TabIndex = 27;
            this.txtWriteCStartA.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(152, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Value";
            // 
            // txtWriteCNum
            // 
            this.txtWriteCNum.Location = new System.Drawing.Point(8, 45);
            this.txtWriteCNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWriteCNum.Name = "txtWriteCNum";
            this.txtWriteCNum.Size = new System.Drawing.Size(49, 26);
            this.txtWriteCNum.TabIndex = 16;
            this.txtWriteCNum.Text = "4";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(62, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 20);
            this.label18.TabIndex = 21;
            this.label18.Text = "Start Addr.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 20);
            this.label19.TabIndex = 20;
            this.label19.Text = "Num";
            // 
            // btnWriteCoils
            // 
            this.btnWriteCoils.Location = new System.Drawing.Point(66, 192);
            this.btnWriteCoils.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWriteCoils.Name = "btnWriteCoils";
            this.btnWriteCoils.Size = new System.Drawing.Size(134, 37);
            this.btnWriteCoils.TabIndex = 6;
            this.btnWriteCoils.Text = "Write Coils";
            this.btnWriteCoils.UseVisualStyleBackColor = true;
            this.btnWriteCoils.Click += new System.EventHandler(this.btnWriteCoils_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.txtReadIRegV1);
            this.groupBox3.Controls.Add(this.txtReadIRegNum);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtReadIRegStartA);
            this.groupBox3.Controls.Add(this.btnReadInputReg);
            this.groupBox3.Controls.Add(this.txtReadIRegV2);
            this.groupBox3.Location = new System.Drawing.Point(8, 262);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(260, 172);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FC 04: Read Input Register";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(152, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 20);
            this.label28.TabIndex = 20;
            this.label28.Text = "Value";
            // 
            // txtReadIRegV1
            // 
            this.txtReadIRegV1.Location = new System.Drawing.Point(156, 48);
            this.txtReadIRegV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadIRegV1.Name = "txtReadIRegV1";
            this.txtReadIRegV1.ReadOnly = true;
            this.txtReadIRegV1.Size = new System.Drawing.Size(90, 26);
            this.txtReadIRegV1.TabIndex = 17;
            this.txtReadIRegV1.Text = "0";
            // 
            // txtReadIRegNum
            // 
            this.txtReadIRegNum.Location = new System.Drawing.Point(8, 49);
            this.txtReadIRegNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadIRegNum.Name = "txtReadIRegNum";
            this.txtReadIRegNum.Size = new System.Drawing.Size(49, 26);
            this.txtReadIRegNum.TabIndex = 10;
            this.txtReadIRegNum.Text = "2";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(62, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(86, 20);
            this.label29.TabIndex = 19;
            this.label29.Text = "Start Addr.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "Num";
            // 
            // txtReadIRegStartA
            // 
            this.txtReadIRegStartA.Location = new System.Drawing.Point(64, 48);
            this.txtReadIRegStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadIRegStartA.Name = "txtReadIRegStartA";
            this.txtReadIRegStartA.Size = new System.Drawing.Size(84, 26);
            this.txtReadIRegStartA.TabIndex = 18;
            this.txtReadIRegStartA.Text = "0";
            // 
            // btnReadInputReg
            // 
            this.btnReadInputReg.Location = new System.Drawing.Point(64, 120);
            this.btnReadInputReg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadInputReg.Name = "btnReadInputReg";
            this.btnReadInputReg.Size = new System.Drawing.Size(135, 35);
            this.btnReadInputReg.TabIndex = 10;
            this.btnReadInputReg.Text = "Read I. Reg";
            this.btnReadInputReg.UseVisualStyleBackColor = true;
            this.btnReadInputReg.Click += new System.EventHandler(this.btnReadInputReg_Click);
            // 
            // txtReadIRegV2
            // 
            this.txtReadIRegV2.Location = new System.Drawing.Point(156, 85);
            this.txtReadIRegV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadIRegV2.Name = "txtReadIRegV2";
            this.txtReadIRegV2.ReadOnly = true;
            this.txtReadIRegV2.Size = new System.Drawing.Size(90, 26);
            this.txtReadIRegV2.TabIndex = 1;
            this.txtReadIRegV2.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtReadHStartA);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtReadHNum);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtReadHV1);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtReadHV2);
            this.groupBox4.Controls.Add(this.btnReadHoldings);
            this.groupBox4.Location = new System.Drawing.Point(274, 262);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(264, 172);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FC 03: Read Holding Registers ";
            // 
            // txtReadHStartA
            // 
            this.txtReadHStartA.Location = new System.Drawing.Point(64, 48);
            this.txtReadHStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadHStartA.Name = "txtReadHStartA";
            this.txtReadHStartA.Size = new System.Drawing.Size(82, 26);
            this.txtReadHStartA.TabIndex = 17;
            this.txtReadHStartA.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(152, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 20);
            this.label20.TabIndex = 19;
            this.label20.Text = "Value";
            // 
            // txtReadHNum
            // 
            this.txtReadHNum.Location = new System.Drawing.Point(8, 48);
            this.txtReadHNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadHNum.Name = "txtReadHNum";
            this.txtReadHNum.Size = new System.Drawing.Size(49, 26);
            this.txtReadHNum.TabIndex = 14;
            this.txtReadHNum.Text = "2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(62, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 20);
            this.label21.TabIndex = 18;
            this.label21.Text = "Start Addr.";
            // 
            // txtReadHV1
            // 
            this.txtReadHV1.Location = new System.Drawing.Point(158, 48);
            this.txtReadHV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadHV1.Name = "txtReadHV1";
            this.txtReadHV1.ReadOnly = true;
            this.txtReadHV1.Size = new System.Drawing.Size(88, 26);
            this.txtReadHV1.TabIndex = 11;
            this.txtReadHV1.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 20);
            this.label22.TabIndex = 17;
            this.label22.Text = "Num";
            // 
            // txtReadHV2
            // 
            this.txtReadHV2.Location = new System.Drawing.Point(156, 83);
            this.txtReadHV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadHV2.Name = "txtReadHV2";
            this.txtReadHV2.ReadOnly = true;
            this.txtReadHV2.Size = new System.Drawing.Size(90, 26);
            this.txtReadHV2.TabIndex = 12;
            this.txtReadHV2.Text = "0";
            // 
            // btnReadHoldings
            // 
            this.btnReadHoldings.Location = new System.Drawing.Point(66, 118);
            this.btnReadHoldings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadHoldings.Name = "btnReadHoldings";
            this.btnReadHoldings.Size = new System.Drawing.Size(134, 35);
            this.btnReadHoldings.TabIndex = 8;
            this.btnReadHoldings.Text = "Read Holdings";
            this.btnReadHoldings.UseVisualStyleBackColor = true;
            this.btnReadHoldings.Click += new System.EventHandler(this.btnReadHoldings_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReadCoilsV1);
            this.groupBox2.Controls.Add(this.txtReadCoilsV2);
            this.groupBox2.Controls.Add(this.txtReadCoilsStartA);
            this.groupBox2.Controls.Add(this.txtReadCoilsV3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtReadCoilsV4);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtReadCoilsNum);
            this.groupBox2.Controls.Add(this.btnReadCoils);
            this.groupBox2.Location = new System.Drawing.Point(274, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(260, 242);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FC 01: Read Coils";
            // 
            // txtReadCoilsV1
            // 
            this.txtReadCoilsV1.Location = new System.Drawing.Point(154, 48);
            this.txtReadCoilsV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsV1.Name = "txtReadCoilsV1";
            this.txtReadCoilsV1.ReadOnly = true;
            this.txtReadCoilsV1.Size = new System.Drawing.Size(90, 26);
            this.txtReadCoilsV1.TabIndex = 14;
            this.txtReadCoilsV1.Text = "0";
            // 
            // txtReadCoilsV2
            // 
            this.txtReadCoilsV2.Location = new System.Drawing.Point(154, 83);
            this.txtReadCoilsV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsV2.Name = "txtReadCoilsV2";
            this.txtReadCoilsV2.ReadOnly = true;
            this.txtReadCoilsV2.Size = new System.Drawing.Size(90, 26);
            this.txtReadCoilsV2.TabIndex = 15;
            this.txtReadCoilsV2.Text = "0";
            // 
            // txtReadCoilsStartA
            // 
            this.txtReadCoilsStartA.Location = new System.Drawing.Point(64, 48);
            this.txtReadCoilsStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsStartA.Name = "txtReadCoilsStartA";
            this.txtReadCoilsStartA.Size = new System.Drawing.Size(82, 26);
            this.txtReadCoilsStartA.TabIndex = 20;
            this.txtReadCoilsStartA.Text = "0";
            // 
            // txtReadCoilsV3
            // 
            this.txtReadCoilsV3.Location = new System.Drawing.Point(156, 120);
            this.txtReadCoilsV3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsV3.Name = "txtReadCoilsV3";
            this.txtReadCoilsV3.ReadOnly = true;
            this.txtReadCoilsV3.Size = new System.Drawing.Size(90, 26);
            this.txtReadCoilsV3.TabIndex = 16;
            this.txtReadCoilsV3.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 20);
            this.label14.TabIndex = 19;
            this.label14.Text = "Value";
            // 
            // txtReadCoilsV4
            // 
            this.txtReadCoilsV4.Location = new System.Drawing.Point(154, 154);
            this.txtReadCoilsV4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsV4.Name = "txtReadCoilsV4";
            this.txtReadCoilsV4.ReadOnly = true;
            this.txtReadCoilsV4.Size = new System.Drawing.Size(90, 26);
            this.txtReadCoilsV4.TabIndex = 17;
            this.txtReadCoilsV4.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(62, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Start Addr.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "Num";
            // 
            // txtReadCoilsNum
            // 
            this.txtReadCoilsNum.Location = new System.Drawing.Point(8, 48);
            this.txtReadCoilsNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadCoilsNum.Name = "txtReadCoilsNum";
            this.txtReadCoilsNum.Size = new System.Drawing.Size(49, 26);
            this.txtReadCoilsNum.TabIndex = 16;
            this.txtReadCoilsNum.Text = "4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtReadDNum);
            this.groupBox1.Controls.Add(this.btnReadDis);
            this.groupBox1.Controls.Add(this.txtReadDStartA);
            this.groupBox1.Controls.Add(this.txtReadDV1);
            this.groupBox1.Controls.Add(this.txtReadDV2);
            this.groupBox1.Controls.Add(this.txtReadDV3);
            this.groupBox1.Controls.Add(this.txtReadDV4);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(260, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FC 02: Read Discrete Inputs ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Value";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Start Addr.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Num";
            // 
            // txtReadDNum
            // 
            this.txtReadDNum.Location = new System.Drawing.Point(8, 49);
            this.txtReadDNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDNum.Name = "txtReadDNum";
            this.txtReadDNum.Size = new System.Drawing.Size(49, 26);
            this.txtReadDNum.TabIndex = 10;
            this.txtReadDNum.Text = "4";
            // 
            // btnReadDis
            // 
            this.btnReadDis.Location = new System.Drawing.Point(66, 192);
            this.btnReadDis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadDis.Name = "btnReadDis";
            this.btnReadDis.Size = new System.Drawing.Size(134, 37);
            this.btnReadDis.TabIndex = 9;
            this.btnReadDis.Text = "Read Discrete";
            this.btnReadDis.UseVisualStyleBackColor = true;
            this.btnReadDis.Click += new System.EventHandler(this.btnReadDis_Click);
            // 
            // txtReadDStartA
            // 
            this.txtReadDStartA.Location = new System.Drawing.Point(64, 49);
            this.txtReadDStartA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDStartA.Name = "txtReadDStartA";
            this.txtReadDStartA.Size = new System.Drawing.Size(84, 26);
            this.txtReadDStartA.TabIndex = 5;
            this.txtReadDStartA.Text = "0";
            // 
            // txtReadDV1
            // 
            this.txtReadDV1.Location = new System.Drawing.Point(156, 49);
            this.txtReadDV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDV1.Name = "txtReadDV1";
            this.txtReadDV1.ReadOnly = true;
            this.txtReadDV1.Size = new System.Drawing.Size(90, 26);
            this.txtReadDV1.TabIndex = 0;
            this.txtReadDV1.Text = "0";
            // 
            // txtReadDV2
            // 
            this.txtReadDV2.Location = new System.Drawing.Point(156, 85);
            this.txtReadDV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDV2.Name = "txtReadDV2";
            this.txtReadDV2.ReadOnly = true;
            this.txtReadDV2.Size = new System.Drawing.Size(90, 26);
            this.txtReadDV2.TabIndex = 1;
            this.txtReadDV2.Text = "0";
            // 
            // txtReadDV3
            // 
            this.txtReadDV3.Location = new System.Drawing.Point(156, 120);
            this.txtReadDV3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDV3.Name = "txtReadDV3";
            this.txtReadDV3.ReadOnly = true;
            this.txtReadDV3.Size = new System.Drawing.Size(90, 26);
            this.txtReadDV3.TabIndex = 3;
            this.txtReadDV3.Text = "0";
            // 
            // txtReadDV4
            // 
            this.txtReadDV4.Location = new System.Drawing.Point(156, 155);
            this.txtReadDV4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReadDV4.Name = "txtReadDV4";
            this.txtReadDV4.ReadOnly = true;
            this.txtReadDV4.Size = new System.Drawing.Size(90, 26);
            this.txtReadDV4.TabIndex = 4;
            this.txtReadDV4.Text = "0";
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(16, 589);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(1290, 253);
            this.txtMessages.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(428, 872);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 45);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoBinary);
            this.groupBox5.Controls.Add(this.rdoHex);
            this.groupBox5.Location = new System.Drawing.Point(16, 852);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(164, 66);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Representation";
            // 
            // rdoBinary
            // 
            this.rdoBinary.AutoSize = true;
            this.rdoBinary.Location = new System.Drawing.Point(78, 29);
            this.rdoBinary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoBinary.Name = "rdoBinary";
            this.rdoBinary.Size = new System.Drawing.Size(78, 24);
            this.rdoBinary.TabIndex = 1;
            this.rdoBinary.Text = "Binary";
            this.rdoBinary.UseVisualStyleBackColor = true;
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Checked = true;
            this.rdoHex.Location = new System.Drawing.Point(8, 29);
            this.rdoHex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(62, 24);
            this.rdoHex.TabIndex = 0;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(309, 872);
            this.btnResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(112, 45);
            this.btnResume.TabIndex = 4;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(189, 872);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(112, 45);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.label7);
            this.grpSettings.Controls.Add(this.txtUnit);
            this.grpSettings.Controls.Add(this.grpIP);
            this.grpSettings.Controls.Add(this.lblPort);
            this.grpSettings.Controls.Add(this.txtPort);
            this.grpSettings.Location = new System.Drawing.Point(36, 78);
            this.grpSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSettings.Size = new System.Drawing.Size(220, 335);
            this.grpSettings.TabIndex = 7;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(51, 28);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(46, 26);
            this.txtUnit.TabIndex = 11;
            this.txtUnit.Text = "1";
            // 
            // grpIP
            // 
            this.grpIP.Controls.Add(this.rdoManual);
            this.grpIP.Controls.Add(this.rdoAuto);
            this.grpIP.Controls.Add(this.btnRefresh);
            this.grpIP.Controls.Add(this.lblIP);
            this.grpIP.Controls.Add(this.cboIP);
            this.grpIP.Controls.Add(this.txtIP);
            this.grpIP.Location = new System.Drawing.Point(8, 97);
            this.grpIP.Name = "grpIP";
            this.grpIP.Size = new System.Drawing.Size(207, 228);
            this.grpIP.TabIndex = 10;
            this.grpIP.TabStop = false;
            this.grpIP.Text = "IP";
            // 
            // rdoManual
            // 
            this.rdoManual.AutoSize = true;
            this.rdoManual.Checked = true;
            this.rdoManual.Location = new System.Drawing.Point(9, 37);
            this.rdoManual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoManual.Name = "rdoManual";
            this.rdoManual.Size = new System.Drawing.Size(153, 24);
            this.rdoManual.TabIndex = 6;
            this.rdoManual.TabStop = true;
            this.rdoManual.Text = "Known Device IP";
            this.rdoManual.UseVisualStyleBackColor = true;
            this.rdoManual.CheckedChanged += new System.EventHandler(this.rdoManual_CheckedChanged);
            // 
            // rdoAuto
            // 
            this.rdoAuto.AutoSize = true;
            this.rdoAuto.Location = new System.Drawing.Point(8, 105);
            this.rdoAuto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoAuto.Name = "rdoAuto";
            this.rdoAuto.Size = new System.Drawing.Size(151, 24);
            this.rdoAuto.TabIndex = 7;
            this.rdoAuto.Text = "Scan For Device";
            this.rdoAuto.UseVisualStyleBackColor = true;
            this.rdoAuto.CheckedChanged += new System.EventHandler(this.rdoAuto_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(36, 177);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 35);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(4, 66);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(24, 20);
            this.lblIP.TabIndex = 4;
            this.lblIP.Text = "IP";
            // 
            // cboIP
            // 
            this.cboIP.FormattingEnabled = true;
            this.cboIP.Location = new System.Drawing.Point(36, 138);
            this.cboIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboIP.Name = "cboIP";
            this.cboIP.Size = new System.Drawing.Size(148, 28);
            this.cboIP.TabIndex = 8;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(42, 65);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(148, 26);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.1.100";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(3, 60);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 20);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(50, 58);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(94, 26);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "502";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(80, 534);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(147, 45);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Generate Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 928);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.tbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Modbus Client For IoT";
            this.tbcMain.ResumeLayout(false);
            this.tbpSimulator.ResumeLayout(false);
            this.tbpSimulator.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAO2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAO1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO2)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledDO4)).EndInit();
            this.tpgValues.ResumeLayout(false);
            this.tpgValues.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.grpIP.ResumeLayout(false);
            this.grpIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.TabPage tabRaw;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tpgValues;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtReadIRegNum;
        private System.Windows.Forms.TextBox txtWriteSCStartA;
        private System.Windows.Forms.TextBox txtReadIRegV2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReadDStartA;
        private System.Windows.Forms.TextBox txtReadDV1;
        private System.Windows.Forms.TextBox txtReadDV2;
        private System.Windows.Forms.TextBox txtReadDV3;
        private System.Windows.Forms.TextBox txtReadDV4;
        private System.Windows.Forms.TabPage tbpSimulator;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ledAO2;
        private System.Windows.Forms.PictureBox ledAO1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ledDO2;
        private System.Windows.Forms.PictureBox ledDO4;
        private System.Windows.Forms.PictureBox ledDO3;
        private System.Windows.Forms.PictureBox ledDO1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdoBinary;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnWriteCoils;
        private System.Windows.Forms.Button btnWriteHoldings;
        private System.Windows.Forms.Button btnReadHoldings;
        private System.Windows.Forms.Button btnReadDis;
        private System.Windows.Forms.Button btnWriteSCoil;
        private System.Windows.Forms.Button btnReadInputReg;
        private System.Windows.Forms.Button btnWriteSH;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboIP;
        private System.Windows.Forms.RadioButton rdoAuto;
        private System.Windows.Forms.RadioButton rdoManual;
        private System.Windows.Forms.GroupBox grpIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkA2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trkA1;
        private System.Windows.Forms.RadioButton rdoD2;
        private System.Windows.Forms.RadioButton rdo01;
        private System.Windows.Forms.RadioButton rdoD1;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.RadioButton rdoD4;
        private System.Windows.Forms.RadioButton rdo02;
        private System.Windows.Forms.RadioButton rdoD3;
        private System.Windows.Forms.CheckBox chkControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtWriteSHV;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtWriteSHStartA;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtWriteHStartA;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtWriteHV1;
        private System.Windows.Forms.TextBox txtWriteHNum;
        private System.Windows.Forms.TextBox txtWriteHV2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtWriteCStartA;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtWriteCNum;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtReadIRegV1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtReadIRegStartA;
        private System.Windows.Forms.TextBox txtReadHStartA;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtReadHNum;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtReadHV1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtReadHV2;
        private System.Windows.Forms.TextBox txtReadCoilsV1;
        private System.Windows.Forms.TextBox txtReadCoilsV2;
        private System.Windows.Forms.TextBox txtReadCoilsStartA;
        private System.Windows.Forms.TextBox txtReadCoilsV3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtReadCoilsV4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtReadCoilsNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReadDNum;
        private System.Windows.Forms.CheckBox chkWriteSCV1;
        private System.Windows.Forms.CheckBox chkWriteCV4;
        private System.Windows.Forms.CheckBox chkWriteCV3;
        private System.Windows.Forms.CheckBox chkWriteCV2;
        private System.Windows.Forms.CheckBox chkWriteCV1;
        private System.Windows.Forms.CheckBox chkKeepAlive;
    }
}


namespace HengXu
{
    partial class commConfig
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
            this._cmb_curcomm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cmb_data = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._cmb_stop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cmb_jiaoyan = new System.Windows.Forms.ComboBox();
            this._cmb_boad = new System.Windows.Forms.ComboBox();
            this._btn_confirm = new System.Windows.Forms.Button();
            this._btn_commCancel = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this._cmb_commport = new System.Windows.Forms.ComboBox();
            this.采集卡串口 = new System.Windows.Forms.Label();
            this._cmb_acqport = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txt_uptime = new System.Windows.Forms.TextBox();
            this._txt_password = new System.Windows.Forms.TextBox();
            this._txt_mn = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txt_title = new System.Windows.Forms.TextBox();
            this._txt_gasID = new System.Windows.Forms.TextBox();
            this._txt_gasname = new System.Windows.Forms.TextBox();
            this._txt_Xsw = new System.Windows.Forms.TextBox();
            this._txt_M2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._txt_O2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._freq = new System.Windows.Forms.NumericUpDown();
            this._btn_acqcancle = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this._cmb_AO = new System.Windows.Forms.ComboBox();
            this._btn_acq = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this._btn_qt = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this._txt_ptg = new System.Windows.Forms.TextBox();
            this._txt_sudu = new System.Windows.Forms.TextBox();
            this._txt_dqyl = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this._txt_kqxs = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._freq)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cmb_curcomm
            // 
            this._cmb_curcomm.FormattingEnabled = true;
            this._cmb_curcomm.Location = new System.Drawing.Point(77, 26);
            this._cmb_curcomm.Name = "_cmb_curcomm";
            this._cmb_curcomm.Size = new System.Drawing.Size(100, 20);
            this._cmb_curcomm.TabIndex = 0;
            this._cmb_curcomm.SelectedIndexChanged += new System.EventHandler(this._cmb_comm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // _cmb_data
            // 
            this._cmb_data.FormattingEnabled = true;
            this._cmb_data.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this._cmb_data.Location = new System.Drawing.Point(77, 105);
            this._cmb_data.Name = "_cmb_data";
            this._cmb_data.Size = new System.Drawing.Size(100, 20);
            this._cmb_data.TabIndex = 0;
            this._cmb_data.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "校验位";
            // 
            // _cmb_stop
            // 
            this._cmb_stop.FormattingEnabled = true;
            this._cmb_stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this._cmb_stop.Location = new System.Drawing.Point(79, 179);
            this._cmb_stop.Name = "_cmb_stop";
            this._cmb_stop.Size = new System.Drawing.Size(100, 20);
            this._cmb_stop.TabIndex = 0;
            this._cmb_stop.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "停止位";
            // 
            // _cmb_jiaoyan
            // 
            this._cmb_jiaoyan.FormattingEnabled = true;
            this._cmb_jiaoyan.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this._cmb_jiaoyan.Location = new System.Drawing.Point(77, 142);
            this._cmb_jiaoyan.Name = "_cmb_jiaoyan";
            this._cmb_jiaoyan.Size = new System.Drawing.Size(100, 20);
            this._cmb_jiaoyan.TabIndex = 0;
            this._cmb_jiaoyan.Text = "无";
            // 
            // _cmb_boad
            // 
            this._cmb_boad.FormattingEnabled = true;
            this._cmb_boad.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this._cmb_boad.Location = new System.Drawing.Point(77, 64);
            this._cmb_boad.Name = "_cmb_boad";
            this._cmb_boad.Size = new System.Drawing.Size(100, 20);
            this._cmb_boad.TabIndex = 0;
            this._cmb_boad.Text = "9600";
            // 
            // _btn_confirm
            // 
            this._btn_confirm.Location = new System.Drawing.Point(18, 320);
            this._btn_confirm.Name = "_btn_confirm";
            this._btn_confirm.Size = new System.Drawing.Size(75, 23);
            this._btn_confirm.TabIndex = 3;
            this._btn_confirm.Text = "应用";
            this._btn_confirm.UseVisualStyleBackColor = true;
            this._btn_confirm.Click += new System.EventHandler(this._btn_confirm_Click);
            // 
            // _btn_commCancel
            // 
            this._btn_commCancel.Location = new System.Drawing.Point(104, 320);
            this._btn_commCancel.Name = "_btn_commCancel";
            this._btn_commCancel.Size = new System.Drawing.Size(75, 23);
            this._btn_commCancel.TabIndex = 3;
            this._btn_commCancel.Text = "取消";
            this._btn_commCancel.UseVisualStyleBackColor = true;
            this._btn_commCancel.Click += new System.EventHandler(this._btn_commCancel_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 51);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 15;
            this.label31.Text = "通信串口";
            // 
            // _cmb_commport
            // 
            this._cmb_commport.FormattingEnabled = true;
            this._cmb_commport.Location = new System.Drawing.Point(102, 50);
            this._cmb_commport.Name = "_cmb_commport";
            this._cmb_commport.Size = new System.Drawing.Size(75, 20);
            this._cmb_commport.TabIndex = 14;
            // 
            // 采集卡串口
            // 
            this.采集卡串口.AutoSize = true;
            this.采集卡串口.Location = new System.Drawing.Point(18, 24);
            this.采集卡串口.Name = "采集卡串口";
            this.采集卡串口.Size = new System.Drawing.Size(65, 12);
            this.采集卡串口.TabIndex = 16;
            this.采集卡串口.Text = "采集卡串口";
            // 
            // _cmb_acqport
            // 
            this._cmb_acqport.FormattingEnabled = true;
            this._cmb_acqport.Location = new System.Drawing.Point(102, 21);
            this._cmb_acqport.Name = "_cmb_acqport";
            this._cmb_acqport.Size = new System.Drawing.Size(75, 20);
            this._cmb_acqport.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._cmb_curcomm);
            this.groupBox1.Controls.Add(this._cmb_data);
            this.groupBox1.Controls.Add(this._txt_uptime);
            this.groupBox1.Controls.Add(this._txt_password);
            this.groupBox1.Controls.Add(this._txt_mn);
            this.groupBox1.Controls.Add(this._cmb_boad);
            this.groupBox1.Controls.Add(this._cmb_jiaoyan);
            this.groupBox1.Controls.Add(this._btn_commCancel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._btn_confirm);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this._cmb_stop);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(234, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 358);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯设置";
            // 
            // _txt_uptime
            // 
            this._txt_uptime.Location = new System.Drawing.Point(115, 264);
            this._txt_uptime.Name = "_txt_uptime";
            this._txt_uptime.Size = new System.Drawing.Size(50, 21);
            this._txt_uptime.TabIndex = 20;
            this._txt_uptime.Text = "5";
            this._txt_uptime.Visible = false;
            // 
            // _txt_password
            // 
            this._txt_password.Location = new System.Drawing.Point(39, 237);
            this._txt_password.Name = "_txt_password";
            this._txt_password.Size = new System.Drawing.Size(140, 21);
            this._txt_password.TabIndex = 20;
            // 
            // _txt_mn
            // 
            this._txt_mn.Location = new System.Drawing.Point(39, 210);
            this._txt_mn.Name = "_txt_mn";
            this._txt_mn.Size = new System.Drawing.Size(140, 21);
            this._txt_mn.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(167, 267);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 19;
            this.label18.Text = "分钟";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 267);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "分钟数据上传间隔";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "密码";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 213);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "MN";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this._txt_title);
            this.groupBox2.Controls.Add(this._txt_gasID);
            this.groupBox2.Controls.Add(this._txt_gasname);
            this.groupBox2.Controls.Add(this._txt_Xsw);
            this.groupBox2.Controls.Add(this._txt_M2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this._txt_O2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this._freq);
            this.groupBox2.Controls.Add(this.采集卡串口);
            this.groupBox2.Controls.Add(this._cmb_acqport);
            this.groupBox2.Controls.Add(this._btn_acqcancle);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this._cmb_AO);
            this.groupBox2.Controls.Add(this._cmb_commport);
            this.groupBox2.Controls.Add(this._btn_acq);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 358);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采集设置";
            // 
            // _txt_title
            // 
            this._txt_title.Location = new System.Drawing.Point(102, 289);
            this._txt_title.Name = "_txt_title";
            this._txt_title.Size = new System.Drawing.Size(92, 21);
            this._txt_title.TabIndex = 20;
            // 
            // _txt_gasID
            // 
            this._txt_gasID.Location = new System.Drawing.Point(102, 264);
            this._txt_gasID.Name = "_txt_gasID";
            this._txt_gasID.Size = new System.Drawing.Size(92, 21);
            this._txt_gasID.TabIndex = 20;
            // 
            // _txt_gasname
            // 
            this._txt_gasname.Location = new System.Drawing.Point(102, 237);
            this._txt_gasname.Name = "_txt_gasname";
            this._txt_gasname.Size = new System.Drawing.Size(92, 21);
            this._txt_gasname.TabIndex = 20;
            // 
            // _txt_Xsw
            // 
            this._txt_Xsw.Location = new System.Drawing.Point(102, 210);
            this._txt_Xsw.Name = "_txt_Xsw";
            this._txt_Xsw.Size = new System.Drawing.Size(54, 21);
            this._txt_Xsw.TabIndex = 20;
            // 
            // _txt_M2
            // 
            this._txt_M2.Location = new System.Drawing.Point(102, 176);
            this._txt_M2.Name = "_txt_M2";
            this._txt_M2.Size = new System.Drawing.Size(54, 21);
            this._txt_M2.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 292);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "设备名称";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 267);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "排放源编号";
            // 
            // _txt_O2
            // 
            this._txt_O2.Location = new System.Drawing.Point(102, 142);
            this._txt_O2.Name = "_txt_O2";
            this._txt_O2.Size = new System.Drawing.Size(54, 21);
            this._txt_O2.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "排放源名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "秒";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "Xsw";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(159, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "m2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "截面积";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "O2标准值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "采样间隔";
            // 
            // _freq
            // 
            this._freq.Location = new System.Drawing.Point(102, 105);
            this._freq.Name = "_freq";
            this._freq.Size = new System.Drawing.Size(54, 21);
            this._freq.TabIndex = 17;
            this._freq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _btn_acqcancle
            // 
            this._btn_acqcancle.Location = new System.Drawing.Point(102, 320);
            this._btn_acqcancle.Name = "_btn_acqcancle";
            this._btn_acqcancle.Size = new System.Drawing.Size(75, 23);
            this._btn_acqcancle.TabIndex = 3;
            this._btn_acqcancle.Text = "取消";
            this._btn_acqcancle.UseVisualStyleBackColor = true;
            this._btn_acqcancle.Click += new System.EventHandler(this._btn_acqcancle_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "输出串口";
            // 
            // _cmb_AO
            // 
            this._cmb_AO.FormattingEnabled = true;
            this._cmb_AO.Location = new System.Drawing.Point(102, 76);
            this._cmb_AO.Name = "_cmb_AO";
            this._cmb_AO.Size = new System.Drawing.Size(75, 20);
            this._cmb_AO.TabIndex = 14;
            // 
            // _btn_acq
            // 
            this._btn_acq.Location = new System.Drawing.Point(8, 320);
            this._btn_acq.Name = "_btn_acq";
            this._btn_acq.Size = new System.Drawing.Size(75, 23);
            this._btn_acq.TabIndex = 3;
            this._btn_acq.Text = "应用";
            this._btn_acq.UseVisualStyleBackColor = true;
            this._btn_acq.Click += new System.EventHandler(this._btn_acq_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this._txt_kqxs);
            this.groupBox3.Controls.Add(this._txt_dqyl);
            this.groupBox3.Controls.Add(this._txt_sudu);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this._txt_ptg);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this._btn_qt);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Location = new System.Drawing.Point(457, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 358);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他设置";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "皮托管系数";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 1;
            this.label21.Text = "大气压力";
            // 
            // _btn_qt
            // 
            this._btn_qt.Location = new System.Drawing.Point(77, 320);
            this._btn_qt.Name = "_btn_qt";
            this._btn_qt.Size = new System.Drawing.Size(75, 23);
            this._btn_qt.TabIndex = 3;
            this._btn_qt.Text = "应用";
            this._btn_qt.UseVisualStyleBackColor = true;
            this._btn_qt.Click += new System.EventHandler(this._btn_qt_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 66);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 12);
            this.label28.TabIndex = 2;
            this.label28.Text = "速度场系数";
            // 
            // _txt_ptg
            // 
            this._txt_ptg.Location = new System.Drawing.Point(117, 26);
            this._txt_ptg.Name = "_txt_ptg";
            this._txt_ptg.Size = new System.Drawing.Size(92, 21);
            this._txt_ptg.TabIndex = 20;
            // 
            // _txt_sudu
            // 
            this._txt_sudu.Location = new System.Drawing.Point(117, 62);
            this._txt_sudu.Name = "_txt_sudu";
            this._txt_sudu.Size = new System.Drawing.Size(92, 21);
            this._txt_sudu.TabIndex = 20;
            // 
            // _txt_dqyl
            // 
            this._txt_dqyl.Location = new System.Drawing.Point(117, 98);
            this._txt_dqyl.Name = "_txt_dqyl";
            this._txt_dqyl.Size = new System.Drawing.Size(92, 21);
            this._txt_dqyl.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 142);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 12);
            this.label22.TabIndex = 1;
            this.label22.Text = "标准过量空气系数";
            // 
            // _txt_kqxs
            // 
            this._txt_kqxs.Location = new System.Drawing.Point(117, 136);
            this._txt_kqxs.Name = "_txt_kqxs";
            this._txt_kqxs.Size = new System.Drawing.Size(92, 21);
            this._txt_kqxs.TabIndex = 20;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(212, 103);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 1;
            this.label23.Text = "Pa";
            // 
            // commConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "commConfig";
            this.Text = "串口设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._freq)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _cmb_curcomm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmb_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cmb_stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cmb_jiaoyan;
        private System.Windows.Forms.ComboBox _cmb_boad;
        private System.Windows.Forms.Button _btn_confirm;
        private System.Windows.Forms.Button _btn_commCancel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox _cmb_commport;
        private System.Windows.Forms.Label 采集卡串口;
        private System.Windows.Forms.ComboBox _cmb_acqport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _freq;
        private System.Windows.Forms.Button _btn_acqcancle;
        private System.Windows.Forms.Button _btn_acq;
        private System.Windows.Forms.TextBox _txt_Xsw;
        private System.Windows.Forms.TextBox _txt_M2;
        private System.Windows.Forms.TextBox _txt_O2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _txt_gasID;
        private System.Windows.Forms.TextBox _txt_gasname;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _txt_title;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _txt_mn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _txt_password;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _txt_uptime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox _cmb_AO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button _btn_qt;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox _txt_dqyl;
        private System.Windows.Forms.TextBox _txt_sudu;
        private System.Windows.Forms.TextBox _txt_ptg;
        private System.Windows.Forms.TextBox _txt_kqxs;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
    }
}
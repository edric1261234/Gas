namespace HengXu
{
    partial class SysConfig
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._txt_unit = new System.Windows.Forms.TextBox();
            this._btn_apply = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._lbl_uint1 = new System.Windows.Forms.Label();
            this._lbl_uint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._txt_valmax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._txt_valmin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this._cmb_ChName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lbl_ChName = new System.Windows.Forms.Label();
            this._btn0 = new System.Windows.Forms.Button();
            this._btn1 = new System.Windows.Forms.Button();
            this._btn2 = new System.Windows.Forms.Button();
            this._btn3 = new System.Windows.Forms.Button();
            this._btn4 = new System.Windows.Forms.Button();
            this._btn5 = new System.Windows.Forms.Button();
            this._btn6 = new System.Windows.Forms.Button();
            this._btn7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(180, 362);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txt_unit);
            this.groupBox1.Controls.Add(this._btn_apply);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this._cmb_ChName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._lbl_ChName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(180, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 362);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // _txt_unit
            // 
            this._txt_unit.Location = new System.Drawing.Point(98, 72);
            this._txt_unit.Name = "_txt_unit";
            this._txt_unit.ReadOnly = true;
            this._txt_unit.Size = new System.Drawing.Size(112, 21);
            this._txt_unit.TabIndex = 6;
            // 
            // _btn_apply
            // 
            this._btn_apply.Location = new System.Drawing.Point(417, 191);
            this._btn_apply.Name = "_btn_apply";
            this._btn_apply.Size = new System.Drawing.Size(58, 38);
            this._btn_apply.TabIndex = 5;
            this._btn_apply.Text = "应用";
            this._btn_apply.UseVisualStyleBackColor = true;
            this._btn_apply.Click += new System.EventHandler(this.OnSaveChange);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(19, 132);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(343, 218);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this._lbl_uint1);
            this.tabPage1.Controls.Add(this._lbl_uint);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this._txt_valmax);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._txt_valmin);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(335, 193);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "量程对应";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(209, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(48, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "4";
            // 
            // _lbl_uint1
            // 
            this._lbl_uint1.AutoSize = true;
            this._lbl_uint1.Location = new System.Drawing.Point(87, 83);
            this._lbl_uint1.Name = "_lbl_uint1";
            this._lbl_uint1.Size = new System.Drawing.Size(29, 12);
            this._lbl_uint1.TabIndex = 0;
            this._lbl_uint1.Text = "单位";
            // 
            // _lbl_uint
            // 
            this._lbl_uint.AutoSize = true;
            this._lbl_uint.Location = new System.Drawing.Point(85, 42);
            this._lbl_uint.Name = "_lbl_uint";
            this._lbl_uint.Size = new System.Drawing.Size(29, 12);
            this._lbl_uint.TabIndex = 0;
            this._lbl_uint.Text = "单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "mA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "------------";
            // 
            // _txt_valmax
            // 
            this._txt_valmax.Location = new System.Drawing.Point(17, 80);
            this._txt_valmax.Name = "_txt_valmax";
            this._txt_valmax.Size = new System.Drawing.Size(59, 21);
            this._txt_valmax.TabIndex = 2;
            this._txt_valmax.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "mA";
            // 
            // _txt_valmin
            // 
            this._txt_valmin.Location = new System.Drawing.Point(17, 38);
            this._txt_valmin.Name = "_txt_valmin";
            this._txt_valmin.Size = new System.Drawing.Size(59, 21);
            this._txt_valmin.TabIndex = 2;
            this._txt_valmin.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "------------";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(209, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(48, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "20";
            // 
            // _cmb_ChName
            // 
            this._cmb_ChName.FormattingEnabled = true;
            this._cmb_ChName.Location = new System.Drawing.Point(98, 45);
            this._cmb_ChName.Name = "_cmb_ChName";
            this._cmb_ChName.Size = new System.Drawing.Size(112, 20);
            this._cmb_ChName.TabIndex = 3;
            this._cmb_ChName.SelectedIndexChanged += new System.EventHandler(this._cmb_ChName_SelectedIndexChanged);
            this._cmb_ChName.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "对应方式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "通道单位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "通道名称：";
            this.label3.Visible = false;
            // 
            // _lbl_ChName
            // 
            this._lbl_ChName.AutoSize = true;
            this._lbl_ChName.Location = new System.Drawing.Point(17, 17);
            this._lbl_ChName.Name = "_lbl_ChName";
            this._lbl_ChName.Size = new System.Drawing.Size(41, 12);
            this._lbl_ChName.TabIndex = 0;
            this._lbl_ChName.Text = "通道：";
            // 
            // _btn0
            // 
            this._btn0.Location = new System.Drawing.Point(0, 2);
            this._btn0.Name = "_btn0";
            this._btn0.Size = new System.Drawing.Size(180, 47);
            this._btn0.TabIndex = 5;
            this._btn0.Text = "通道1";
            this._btn0.UseVisualStyleBackColor = true;
            this._btn0.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn1
            // 
            this._btn1.Location = new System.Drawing.Point(0, 47);
            this._btn1.Name = "_btn1";
            this._btn1.Size = new System.Drawing.Size(180, 47);
            this._btn1.TabIndex = 5;
            this._btn1.Text = "通道2";
            this._btn1.UseVisualStyleBackColor = true;
            this._btn1.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn2
            // 
            this._btn2.Location = new System.Drawing.Point(0, 92);
            this._btn2.Name = "_btn2";
            this._btn2.Size = new System.Drawing.Size(180, 47);
            this._btn2.TabIndex = 5;
            this._btn2.Text = "通道3";
            this._btn2.UseVisualStyleBackColor = true;
            this._btn2.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn3
            // 
            this._btn3.Location = new System.Drawing.Point(0, 137);
            this._btn3.Name = "_btn3";
            this._btn3.Size = new System.Drawing.Size(180, 47);
            this._btn3.TabIndex = 5;
            this._btn3.Text = "通道4";
            this._btn3.UseVisualStyleBackColor = true;
            this._btn3.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn4
            // 
            this._btn4.Location = new System.Drawing.Point(0, 182);
            this._btn4.Name = "_btn4";
            this._btn4.Size = new System.Drawing.Size(180, 47);
            this._btn4.TabIndex = 5;
            this._btn4.Text = "通道5";
            this._btn4.UseVisualStyleBackColor = true;
            this._btn4.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn5
            // 
            this._btn5.Location = new System.Drawing.Point(0, 226);
            this._btn5.Name = "_btn5";
            this._btn5.Size = new System.Drawing.Size(180, 47);
            this._btn5.TabIndex = 5;
            this._btn5.Text = "通道6";
            this._btn5.UseVisualStyleBackColor = true;
            this._btn5.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn6
            // 
            this._btn6.Location = new System.Drawing.Point(0, 271);
            this._btn6.Name = "_btn6";
            this._btn6.Size = new System.Drawing.Size(180, 47);
            this._btn6.TabIndex = 5;
            this._btn6.Text = "通道7";
            this._btn6.UseVisualStyleBackColor = true;
            this._btn6.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // _btn7
            // 
            this._btn7.Location = new System.Drawing.Point(0, 316);
            this._btn7.Name = "_btn7";
            this._btn7.Size = new System.Drawing.Size(180, 47);
            this._btn7.TabIndex = 5;
            this._btn7.Text = "通道8";
            this._btn7.UseVisualStyleBackColor = true;
            this._btn7.Visible = false;
            this._btn7.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // SysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btn7);
            this.Controls.Add(this._btn5);
            this.Controls.Add(this._btn3);
            this.Controls.Add(this._btn1);
            this.Controls.Add(this._btn6);
            this.Controls.Add(this._btn4);
            this.Controls.Add(this._btn2);
            this.Controls.Add(this._btn0);
            this.Controls.Add(this.splitter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysConfig";
            this.Text = "参数配置页面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysConfig_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _lbl_ChName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txt_valmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txt_valmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btn_apply;
        private System.Windows.Forms.Button _btn0;
        private System.Windows.Forms.Button _btn1;
        private System.Windows.Forms.Button _btn2;
        private System.Windows.Forms.Button _btn3;
        private System.Windows.Forms.Button _btn4;
        private System.Windows.Forms.Button _btn5;
        private System.Windows.Forms.Button _btn6;
        private System.Windows.Forms.Button _btn7;
        private System.Windows.Forms.Label _lbl_uint1;
        private System.Windows.Forms.Label _lbl_uint;
        private System.Windows.Forms.ComboBox _cmb_ChName;
        private System.Windows.Forms.TextBox _txt_unit;
    }
}
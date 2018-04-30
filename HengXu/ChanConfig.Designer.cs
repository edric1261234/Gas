namespace HengXu
{
    partial class ChanConfig
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
            this.label17 = new System.Windows.Forms.Label();
            this._cmb_output = new System.Windows.Forms.ComboBox();
            this._txt_Ib = new System.Windows.Forms.TextBox();
            this._txt_val_b = new System.Windows.Forms.TextBox();
            this._txt_Ik = new System.Windows.Forms.TextBox();
            this._txt_val_k = new System.Windows.Forms.TextBox();
            this._btn_apply = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this._txt_xishu = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._txt_xishu);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this._cmb_output);
            this.groupBox1.Controls.Add(this._txt_Ib);
            this.groupBox1.Controls.Add(this._txt_val_b);
            this.groupBox1.Controls.Add(this._txt_Ik);
            this.groupBox1.Controls.Add(this._txt_val_k);
            this.groupBox1.Controls.Add(this._btn_apply);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._lbl_ChName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(180, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 362);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 12);
            this.label17.TabIndex = 8;
            this.label17.Text = "该通道是否输出为电流";
            // 
            // _cmb_output
            // 
            this._cmb_output.FormattingEnabled = true;
            this._cmb_output.Items.AddRange(new object[] {
            "是",
            "否"});
            this._cmb_output.Location = new System.Drawing.Point(150, 79);
            this._cmb_output.Name = "_cmb_output";
            this._cmb_output.Size = new System.Drawing.Size(56, 20);
            this._cmb_output.TabIndex = 7;
            this._cmb_output.Text = "是";
            this._cmb_output.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // _txt_Ib
            // 
            this._txt_Ib.Location = new System.Drawing.Point(351, 110);
            this._txt_Ib.Name = "_txt_Ib";
            this._txt_Ib.Size = new System.Drawing.Size(67, 21);
            this._txt_Ib.TabIndex = 6;
            this._txt_Ib.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // _txt_val_b
            // 
            this._txt_val_b.Location = new System.Drawing.Point(342, 47);
            this._txt_val_b.Name = "_txt_val_b";
            this._txt_val_b.Size = new System.Drawing.Size(67, 21);
            this._txt_val_b.TabIndex = 6;
            this._txt_val_b.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // _txt_Ik
            // 
            this._txt_Ik.Location = new System.Drawing.Point(139, 110);
            this._txt_Ik.Name = "_txt_Ik";
            this._txt_Ik.Size = new System.Drawing.Size(67, 21);
            this._txt_Ik.TabIndex = 6;
            this._txt_Ik.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // _txt_val_k
            // 
            this._txt_val_k.Location = new System.Drawing.Point(130, 47);
            this._txt_val_k.Name = "_txt_val_k";
            this._txt_val_k.Size = new System.Drawing.Size(67, 21);
            this._txt_val_k.TabIndex = 6;
            this._txt_val_k.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // _btn_apply
            // 
            this._btn_apply.Location = new System.Drawing.Point(507, 69);
            this._btn_apply.Name = "_btn_apply";
            this._btn_apply.Size = new System.Drawing.Size(58, 38);
            this._btn_apply.TabIndex = 5;
            this._btn_apply.Text = "应用";
            this._btn_apply.UseVisualStyleBackColor = true;
            this._btn_apply.Click += new System.EventHandler(this.OnSaveChange);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(212, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "×　实际值 + ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(203, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "×　实际值 + ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(4, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "电流输出值 = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "显示值 = ";
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
            this._btn7.Click += new System.EventHandler(this.OnButtonChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Qsn系数";
            // 
            // _txt_xishu
            // 
            this._txt_xishu.Location = new System.Drawing.Point(122, 261);
            this._txt_xishu.Name = "_txt_xishu";
            this._txt_xishu.Size = new System.Drawing.Size(56, 21);
            this._txt_xishu.TabIndex = 25;
            this._txt_xishu.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChanConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 362);
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
            this.Name = "ChanConfig";
            this.Text = "参数配置页面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _lbl_ChName;
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
        private System.Windows.Forms.TextBox _txt_val_k;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txt_val_b;
        private System.Windows.Forms.TextBox _txt_Ib;
        private System.Windows.Forms.TextBox _txt_Ik;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox _cmb_output;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txt_xishu;
        private System.Windows.Forms.Button button1;
    }
}
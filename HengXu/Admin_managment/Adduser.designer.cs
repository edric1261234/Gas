namespace HengXu
{
    partial class Adduser
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
            this._txt_newname = new System.Windows.Forms.TextBox();
            this._cmb_quanxian = new System.Windows.Forms.ComboBox();
            this._txt_newpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txt_repassword = new System.Windows.Forms.TextBox();
            this._txt_remark = new System.Windows.Forms.TextBox();
            this._btn_cannle = new LxControl.GlassButton();
            this._btn_confrim = new LxControl.GlassButton();
            this.SuspendLayout();
            // 
            // _txt_newname
            // 
            this._txt_newname.Location = new System.Drawing.Point(181, 47);
            this._txt_newname.Name = "_txt_newname";
            this._txt_newname.Size = new System.Drawing.Size(121, 21);
            this._txt_newname.TabIndex = 0;
            // 
            // _cmb_quanxian
            // 
            this._cmb_quanxian.FormattingEnabled = true;
            this._cmb_quanxian.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3"});
            this._cmb_quanxian.Location = new System.Drawing.Point(181, 149);
            this._cmb_quanxian.Name = "_cmb_quanxian";
            this._cmb_quanxian.Size = new System.Drawing.Size(121, 20);
            this._cmb_quanxian.TabIndex = 1;
            // 
            // _txt_newpassword
            // 
            this._txt_newpassword.Location = new System.Drawing.Point(181, 81);
            this._txt_newpassword.Name = "_txt_newpassword";
            this._txt_newpassword.PasswordChar = '*';
            this._txt_newpassword.Size = new System.Drawing.Size(121, 21);
            this._txt_newpassword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "权  限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "备  注";
            // 
            // _txt_repassword
            // 
            this._txt_repassword.Location = new System.Drawing.Point(181, 115);
            this._txt_repassword.Name = "_txt_repassword";
            this._txt_repassword.PasswordChar = '*';
            this._txt_repassword.Size = new System.Drawing.Size(121, 21);
            this._txt_repassword.TabIndex = 0;
            // 
            // _txt_remark
            // 
            this._txt_remark.Location = new System.Drawing.Point(181, 182);
            this._txt_remark.Name = "_txt_remark";
            this._txt_remark.Size = new System.Drawing.Size(121, 21);
            this._txt_remark.TabIndex = 0;
            // 
            // _btn_cannle
            // 
            this._btn_cannle.BackColor = System.Drawing.Color.Silver;
            this._btn_cannle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btn_cannle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_cannle.ForeColor = System.Drawing.Color.Green;
            this._btn_cannle.GlowColor = System.Drawing.Color.Cyan;
            this._btn_cannle.Location = new System.Drawing.Point(199, 251);
            this._btn_cannle.Name = "_btn_cannle";
            this._btn_cannle.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_cannle.Size = new System.Drawing.Size(66, 30);
            this._btn_cannle.TabIndex = 40;
            this._btn_cannle.Text = "取消";
            this._btn_cannle.Click += new System.EventHandler(this._btn_cannle_Click);
            // 
            // _btn_confrim
            // 
            this._btn_confrim.BackColor = System.Drawing.Color.Silver;
            this._btn_confrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_confrim.ForeColor = System.Drawing.Color.Green;
            this._btn_confrim.GlowColor = System.Drawing.Color.Cyan;
            this._btn_confrim.Location = new System.Drawing.Point(96, 251);
            this._btn_confrim.Name = "_btn_confrim";
            this._btn_confrim.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_confrim.Size = new System.Drawing.Size(66, 30);
            this._btn_confrim.TabIndex = 40;
            this._btn_confrim.Text = "确定";
            this._btn_confrim.Click += new System.EventHandler(this._btn_confrim_Click);
            // 
            // Adduser
            // 
            this.AcceptButton = this._btn_confrim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btn_cannle;
            this.ClientSize = new System.Drawing.Size(366, 342);
            this.Controls.Add(this._btn_confrim);
            this.Controls.Add(this._btn_cannle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cmb_quanxian);
            this.Controls.Add(this._txt_remark);
            this.Controls.Add(this._txt_repassword);
            this.Controls.Add(this._txt_newpassword);
            this.Controls.Add(this._txt_newname);
            this.Name = "Adduser";
            this.Text = "添加用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txt_newname;
        private System.Windows.Forms.ComboBox _cmb_quanxian;
        private System.Windows.Forms.TextBox _txt_newpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txt_repassword;
        private System.Windows.Forms.TextBox _txt_remark;
        private LxControl.GlassButton _btn_cannle;
        private LxControl.GlassButton _btn_confrim;
    }
}
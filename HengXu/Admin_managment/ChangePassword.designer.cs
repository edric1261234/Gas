namespace HengXu
{
    partial class ChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._txt_password = new System.Windows.Forms.TextBox();
            this._txt_repassword = new System.Windows.Forms.TextBox();
            this._btn_cancel = new LxControl.GlassButton();
            this._btn_confirm = new LxControl.GlassButton();
            this.label3 = new System.Windows.Forms.Label();
            this._txt_oldpassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入新密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "确 认 密 码";
            // 
            // _txt_password
            // 
            this._txt_password.Location = new System.Drawing.Point(151, 96);
            this._txt_password.Name = "_txt_password";
            this._txt_password.Size = new System.Drawing.Size(100, 21);
            this._txt_password.TabIndex = 1;
            // 
            // _txt_repassword
            // 
            this._txt_repassword.Location = new System.Drawing.Point(151, 140);
            this._txt_repassword.Name = "_txt_repassword";
            this._txt_repassword.Size = new System.Drawing.Size(100, 21);
            this._txt_repassword.TabIndex = 1;
            // 
            // _btn_cancel
            // 
            this._btn_cancel.BackColor = System.Drawing.Color.Silver;
            this._btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_cancel.ForeColor = System.Drawing.Color.Green;
            this._btn_cancel.GlowColor = System.Drawing.Color.Cyan;
            this._btn_cancel.Location = new System.Drawing.Point(169, 184);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_cancel.Size = new System.Drawing.Size(75, 38);
            this._btn_cancel.TabIndex = 44;
            this._btn_cancel.Text = "取消";
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
            // 
            // _btn_confirm
            // 
            this._btn_confirm.BackColor = System.Drawing.Color.Silver;
            this._btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_confirm.ForeColor = System.Drawing.Color.Green;
            this._btn_confirm.GlowColor = System.Drawing.Color.Cyan;
            this._btn_confirm.Location = new System.Drawing.Point(51, 184);
            this._btn_confirm.Name = "_btn_confirm";
            this._btn_confirm.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_confirm.Size = new System.Drawing.Size(75, 38);
            this._btn_confirm.TabIndex = 43;
            this._btn_confirm.Text = "确定";
            this._btn_confirm.Click += new System.EventHandler(this._btn_confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "请输入旧密码";
            // 
            // _txt_oldpassword
            // 
            this._txt_oldpassword.Location = new System.Drawing.Point(151, 60);
            this._txt_oldpassword.Name = "_txt_oldpassword";
            this._txt_oldpassword.Size = new System.Drawing.Size(100, 21);
            this._txt_oldpassword.TabIndex = 1;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 288);
            this.Controls.Add(this._btn_cancel);
            this.Controls.Add(this._btn_confirm);
            this.Controls.Add(this._txt_repassword);
            this.Controls.Add(this._txt_oldpassword);
            this.Controls.Add(this._txt_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txt_password;
        private System.Windows.Forms.TextBox _txt_repassword;
        private LxControl.GlassButton _btn_cancel;
        private LxControl.GlassButton _btn_confirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txt_oldpassword;
    }
}
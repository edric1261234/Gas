namespace 数据采集单元界面设计
{
    partial class Record
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
            this._txt_User_password = new System.Windows.Forms.TextBox();
            this._btn_Record_ID = new System.Windows.Forms.Button();
            this._btn_Record_anony = new System.Windows.Forms.Button();
            this._txt_User_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密  码";
            // 
            // _txt_User_password
            // 
            this._txt_User_password.Location = new System.Drawing.Point(161, 103);
            this._txt_User_password.Name = "_txt_User_password";
            this._txt_User_password.PasswordChar = '*';
            this._txt_User_password.Size = new System.Drawing.Size(122, 21);
            this._txt_User_password.TabIndex = 1;
            this._txt_User_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txt_User_password_KeyDown);
            // 
            // _btn_Record_ID
            // 
            this._btn_Record_ID.Location = new System.Drawing.Point(106, 155);
            this._btn_Record_ID.Name = "_btn_Record_ID";
            this._btn_Record_ID.Size = new System.Drawing.Size(73, 25);
            this._btn_Record_ID.TabIndex = 2;
            this._btn_Record_ID.Text = "ID登录";
            this._btn_Record_ID.UseVisualStyleBackColor = true;
            this._btn_Record_ID.Click += new System.EventHandler(this.On_Record_ID_Click);
            // 
            // _btn_Record_anony
            // 
            this._btn_Record_anony.Location = new System.Drawing.Point(210, 155);
            this._btn_Record_anony.Name = "_btn_Record_anony";
            this._btn_Record_anony.Size = new System.Drawing.Size(73, 25);
            this._btn_Record_anony.TabIndex = 2;
            this._btn_Record_anony.Text = "匿名登录";
            this._btn_Record_anony.UseVisualStyleBackColor = true;
            this._btn_Record_anony.Click += new System.EventHandler(this.On_Record_anony_Click);
            // 
            // _txt_User_name
            // 
            this._txt_User_name.Location = new System.Drawing.Point(161, 49);
            this._txt_User_name.Name = "_txt_User_name";
            this._txt_User_name.Size = new System.Drawing.Size(122, 21);
            this._txt_User_name.TabIndex = 1;
            this._txt_User_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txt_User_password_KeyDown);
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 230);
            this.Controls.Add(this._btn_Record_anony);
            this.Controls.Add(this._btn_Record_ID);
            this.Controls.Add(this._txt_User_name);
            this.Controls.Add(this._txt_User_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Record";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txt_User_password;
        private System.Windows.Forms.Button _btn_Record_ID;
        private System.Windows.Forms.Button _btn_Record_anony;
        private System.Windows.Forms.TextBox _txt_User_name;
    }
}
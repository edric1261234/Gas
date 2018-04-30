namespace HengXu
{
    partial class admin_managment
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btn_Deluser = new LxControl.GlassButton();
            this._btn_Adduser = new LxControl.GlassButton();
            this._lst_userInfo = new System.Windows.Forms.ListView();
            this._column_uername = new System.Windows.Forms.ColumnHeader();
            this._column_permissions = new System.Windows.Forms.ColumnHeader();
            this._column_remark = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lbl_username = new System.Windows.Forms.Label();
            this._btn_changepassword = new LxControl.GlassButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btn_confirm = new LxControl.GlassButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.33255F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.66745F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btn_Deluser);
            this.groupBox1.Controls.Add(this._btn_Adduser);
            this.groupBox1.Controls.Add(this._lst_userInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有用户信息";
            // 
            // _btn_Deluser
            // 
            this._btn_Deluser.BackColor = System.Drawing.Color.Silver;
            this._btn_Deluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_Deluser.ForeColor = System.Drawing.Color.Green;
            this._btn_Deluser.GlowColor = System.Drawing.Color.Cyan;
            this._btn_Deluser.Location = new System.Drawing.Point(260, 177);
            this._btn_Deluser.Name = "_btn_Deluser";
            this._btn_Deluser.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_Deluser.Size = new System.Drawing.Size(75, 38);
            this._btn_Deluser.TabIndex = 39;
            this._btn_Deluser.Text = "删除";
            this._btn_Deluser.Click += new System.EventHandler(this._btn_Deluser_Click);
            this._btn_Deluser.EnabledChanged += new System.EventHandler(this.OnGlassbtnEnabledChanged);
            // 
            // _btn_Adduser
            // 
            this._btn_Adduser.BackColor = System.Drawing.Color.Silver;
            this._btn_Adduser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_Adduser.ForeColor = System.Drawing.Color.Green;
            this._btn_Adduser.GlowColor = System.Drawing.Color.Cyan;
            this._btn_Adduser.Location = new System.Drawing.Point(111, 177);
            this._btn_Adduser.Name = "_btn_Adduser";
            this._btn_Adduser.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_Adduser.Size = new System.Drawing.Size(75, 38);
            this._btn_Adduser.TabIndex = 39;
            this._btn_Adduser.Text = "添加";
            this._btn_Adduser.Click += new System.EventHandler(this._btn_Adduser_Click);
            this._btn_Adduser.EnabledChanged += new System.EventHandler(this.OnGlassbtnEnabledChanged);
            // 
            // _lst_userInfo
            // 
            this._lst_userInfo.BackColor = System.Drawing.Color.Honeydew;
            this._lst_userInfo.CheckBoxes = true;
            this._lst_userInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._column_uername,
            this._column_permissions,
            this._column_remark});
            this._lst_userInfo.GridLines = true;
            this._lst_userInfo.Location = new System.Drawing.Point(48, 44);
            this._lst_userInfo.Name = "_lst_userInfo";
            this._lst_userInfo.Size = new System.Drawing.Size(404, 127);
            this._lst_userInfo.TabIndex = 0;
            this._lst_userInfo.UseCompatibleStateImageBehavior = false;
            this._lst_userInfo.View = System.Windows.Forms.View.Details;
            this._lst_userInfo.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this._lst_userInfo_ItemChecked);
            // 
            // _column_uername
            // 
            this._column_uername.Text = "用户名";
            this._column_uername.Width = 117;
            // 
            // _column_permissions
            // 
            this._column_permissions.Text = "权限";
            this._column_permissions.Width = 158;
            // 
            // _column_remark
            // 
            this._column_remark.Text = "备注";
            this._column_remark.Width = 142;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._lbl_username);
            this.groupBox2.Controls.Add(this._btn_changepassword);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(59, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "修改自身密码请单击此处：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(59, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "当前用户：";
            // 
            // _lbl_username
            // 
            this._lbl_username.Location = new System.Drawing.Point(0, 0);
            this._lbl_username.Name = "_lbl_username";
            this._lbl_username.Size = new System.Drawing.Size(100, 21);
            this._lbl_username.TabIndex = 44;
            // 
            // _btn_changepassword
            // 
            this._btn_changepassword.BackColor = System.Drawing.Color.Silver;
            this._btn_changepassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_changepassword.ForeColor = System.Drawing.Color.Green;
            this._btn_changepassword.GlowColor = System.Drawing.Color.Cyan;
            this._btn_changepassword.Location = new System.Drawing.Point(294, 82);
            this._btn_changepassword.Name = "_btn_changepassword";
            this._btn_changepassword.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_changepassword.Size = new System.Drawing.Size(81, 38);
            this._btn_changepassword.TabIndex = 41;
            this._btn_changepassword.Text = "修改密码";
            this._btn_changepassword.Click += new System.EventHandler(this._btn_changepassword_Click);
            this._btn_changepassword.EnabledChanged += new System.EventHandler(this.OnGlassbtnEnabledChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btn_confirm);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // _btn_confirm
            // 
            this._btn_confirm.BackColor = System.Drawing.Color.Silver;
            this._btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btn_confirm.ForeColor = System.Drawing.Color.Green;
            this._btn_confirm.GlowColor = System.Drawing.Color.Cyan;
            this._btn_confirm.Location = new System.Drawing.Point(176, 6);
            this._btn_confirm.Name = "_btn_confirm";
            this._btn_confirm.ShineColor = System.Drawing.Color.Honeydew;
            this._btn_confirm.Size = new System.Drawing.Size(75, 38);
            this._btn_confirm.TabIndex = 42;
            this._btn_confirm.Text = "确定";
            this._btn_confirm.Click += new System.EventHandler(this._btn_confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "提示:3级为最高级别";
            // 
            // admin_managment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "admin_managment";
            this.Text = "用户管理";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView _lst_userInfo;
        private System.Windows.Forms.ColumnHeader _column_uername;
        private System.Windows.Forms.ColumnHeader _column_permissions;
        private System.Windows.Forms.ColumnHeader _column_remark;
        private LxControl.GlassButton _btn_Deluser;
        private LxControl.GlassButton _btn_Adduser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label _lbl_username;
        private LxControl.GlassButton _btn_changepassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private LxControl.GlassButton _btn_confirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
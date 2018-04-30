using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace HengXu
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void _btn_confirm_Click(object sender, EventArgs e)
        {
            if (_txt_password.Text == _txt_repassword.Text)
            {
                if (_txt_oldpassword.Text == Login.Arraypasswords[Login.userID])
                {
                    if (_txt_password.Text != Login.Arraypasswords[Login.userID])
                    {
                        Login.Arraypasswords[Login.userID] = _txt_password.Text;
                    }
                    else
                    {
                        MessageBox.Show("修改后的密码不能和之前相同");
                    }
                }
                else
                {
                    MessageBox.Show("您输入的旧密码不正确！");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("确认密码不正确！");
            }
        }

        private void _btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
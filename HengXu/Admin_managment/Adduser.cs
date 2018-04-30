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
    public partial class Adduser : Form
    {
        public event EventHandler OkClicked;
        public Adduser()
        {
            InitializeComponent();
        }

        private void _btn_confrim_Click(object sender, EventArgs e)
        {
            if((!string.IsNullOrEmpty(_txt_newname.Text ))
                &&(_txt_newpassword.Text == _txt_repassword.Text)
                &&(!string.IsNullOrEmpty(_txt_newpassword.Text))
                &&(!string.IsNullOrEmpty( _cmb_quanxian.Text )))
            {
                Login.Arraynames[++Login.countofuser] = _txt_newname.Text;
                Login.Arraypasswords[Login.countofuser] = _txt_newpassword.Text;
                Login.Arrayquanxian[Login.countofuser] = _cmb_quanxian.Text;
                Login.Arrayremarks[Login.countofuser] = _txt_remark.Text;
                this.Close();
            }
            else if (_txt_newname.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            else if (_txt_newname.Text == "admin")
            {
                MessageBox.Show("用户名不能为admin！");
                return;
            }
            else if (_cmb_quanxian.Text == "")
            {
                MessageBox.Show("权限不能为空！");
                return;
            }
            else if (_txt_newpassword.Text != _txt_repassword.Text)
            {
                MessageBox.Show("确认密码不正确");
                return;
            }
            else
            {
                MessageBox.Show("填写信息不正确！");
                return;
            }
            string jb = _cmb_quanxian.Text;
            if (Form1.curUserJB < Convert.ToInt16(jb.Substring(jb.Length - 1, 1)))
            {
                MessageBox.Show("不能设置比当前级别还高的用户！");
                return;
            }
            if (OkClicked != null)
                OkClicked(null, null);
        }

        private void _btn_cannle_Click(object sender, EventArgs e)
        {
            //result = false;
            this.Close();
        }

    }
}
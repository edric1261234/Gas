using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LxControl;
using System.Data.OleDb;

namespace HengXu
{
    public partial class admin_managment : Form
    {
        #region 变量定义
        //数据库变量定义
        OleDbConnection oleCon;
        //记录所选删除用户的ID号
        private Dictionary<int, int> selectItems = new Dictionary<int, int>(10);
        //记录选择删除的用户的个数
        private int countofselectItems = 0; 
        #endregion

        #region 构造函数
        public admin_managment()
        {
            InitializeComponent();
            _lbl_username.Text = Login.username;
            Addlistview();
            if ((Login.Arrayquanxian[Login.userID] == "Common User") || (Login.username == "anony"))
            {
                _btn_changepassword.Enabled = false;
                _btn_Adduser.Enabled = false;
                _btn_Deluser.Enabled = false;
            }
            string constr = "provider = microsoft.jet.oledb.4.0; data source = " +
                                  Application.StartupPath + "\\userinfo.mdb;" + "jet oledb:database "
                                  + "Password = " + Login.userfilepassword + "; User Id = admin;";
            oleCon = new OleDbConnection(constr);


        }

        #endregion

        /// <summary>
        /// 向列表中添加信息
        /// </summary>
        private void Addlistview()
        {
            Login.ReadUserInfo();
            for (int i = 0; i < Login.countofuser; ++i)
            {
                _lst_userInfo.Items.Add(Login.Arraynames[i]);
                _lst_userInfo.Items[i].SubItems.Add(Login.Arrayquanxian[i]);
                _lst_userInfo.Items[i].SubItems.Add(Login.Arrayremarks[i]);
            }
        }

        /// <summary>
        /// 响应添加用户事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_Adduser_Click(object sender, EventArgs e)
        {
            if (Login.countofuser <= 10)
            {
                //清除列表中的显示信息
                for (int i = Login.countofuser - 1; i >= 0; --i)
                {
                    _lst_userInfo.Items[i].Remove();
                }
                Adduser ad = new Adduser();
                //点击确定按钮事件，添加新用户
                ad.OkClicked += new EventHandler(ad_OkClicked);
                ad.ShowDialog();
                //都更新listview
                Addlistview(); 
            }
            else
            {
                MessageBox.Show("最多只能添加十个用户");
            }
        }

        void ad_OkClicked(object sender, EventArgs e)
        {
            oleCon.Open();
            string insertstr = "insert into myuserinfo(myusername, mypassword, quanxian, remark)  values ('"
                + Login.Arraynames[Login.countofuser] + "','"
                + Login.Arraypasswords[Login.countofuser] + "','"
                + Login.Arrayquanxian[Login.countofuser] + "','"
                + Login.Arrayremarks[Login.countofuser] + "'" + ")";

            OleDbCommand insertcmd = new OleDbCommand(insertstr, oleCon);
            insertcmd.ExecuteNonQuery();
            oleCon.Close();
        }

        private void _lst_userInfo_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (selectItems.ContainsKey(e.Item.Index))
            {
                selectItems.Remove(e.Item.Index);
                countofselectItems--;
            }
            else
            {
                if (e.Item.Checked)
                {
                    if (e.Item.Index != Login.userID)
                    {
                        selectItems.Add(e.Item.Index, e.Item.Index);
                        countofselectItems++;
                    }
                    else
                    {
                        MessageBox.Show("不能选择删除当前用户!");
                        _lst_userInfo.Items[Login.userID].Checked = false;
                    }
                }
            }
        }

        private void _btn_Deluser_Click(object sender, EventArgs e)
        {
            //先读一遍数据库信息，防止数据更新后变量错误
            Login.ReadUserInfo();
            #region 数据库操作
            oleCon.Open();
            for (int i = 0; i < Login.countofuser; ++i)
            {
                if (selectItems.ContainsKey(i))
                {
                    if (Login.Arraynames[i] == "admin")
                    {
                        MessageBox.Show("不能删除管理员用户!");
                        oleCon.Close();
                        return;
                    }
                    string removeString = "delete from myuserinfo where myusername = '" +
                        Login.Arraynames[i] + "'";
                    OleDbCommand myCommand = new OleDbCommand(removeString, oleCon);
                    myCommand.ExecuteNonQuery();
                }
            }
            oleCon.Close(); 
            #endregion
            //一次清除列表中信息
            for (int i = Login.countofuser - 1; i >= 0; --i)
            {
                _lst_userInfo.Items[i].Remove();
            }
            Addlistview();
        }

        private void _btn_changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpassword = Login.Arraypasswords[Login.userID];
                new ChangePassword().ShowDialog();
                if (oldpassword != Login.Arraypasswords[Login.userID])
                {
                    #region 数据库操作
                    oleCon.Open();
                    string strUpdt = "update myuserinfo set mypassword = '" +
                        Login.Arraypasswords[Login.userID] +
                        "', quanxian = '" + Login.Arrayquanxian[Login.userID] +
                        "', remark = '" + Login.Arrayremarks[Login.userID] +
                        "' where myusername = '" + Login.username + "'";

                    OleDbCommand myCommand = new OleDbCommand(strUpdt, oleCon);
                    myCommand.ExecuteNonQuery();
                    oleCon.Close();
                    #endregion
                    MessageBox.Show("密码修改成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void _btn_confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnGlassbtnEnabledChanged(object sender, EventArgs e)
        {
            GlassButton b = (GlassButton)sender;
            if (b.Enabled)
            {
                b.BackColor = Color.Silver;
            }
            else
            {
                b.BackColor = Color.Transparent;
            }
        }

    }
}
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
    public partial class Login : Form
    {
        #region 全局变量定义
        public static string username;
        public static string[] Arraynames = new string[10];
        public static string[] Arraypasswords = new string[10];
        public static string[] Arrayquanxian = new string[10];
        public static string[] Arrayremarks = new string[10];
        public static int countofuser = 0;
        public static int userID = 0;
        public static string userinfofilepath;
        public static string userfilepassword = "e705";
        #endregion

        #region 构造函数
        public Login()
        {
            InitializeComponent();
            userinfofilepath = Application.StartupPath + "\\userinfo.mdb";
            ReadUserInfo();
        } 
        #endregion
        
        /// <summary>
        /// 读数据库数据
        /// </summary>
        public static void ReadUserInfo()
        {
            try
            {
                if (File.Exists(userinfofilepath))
                {
                    #region 将用到的全局变量清零
                    for (int i = 0; i < 10; ++i)
                    {
                        Arraynames[i] = "";
                        Arraypasswords[i] = "";
                        Arrayquanxian[i] = "";
                        Arrayremarks[i] = "";
                    }
                    countofuser = 0; 
                    #endregion

                    #region 建立数据库连接并读取数据
                    string constr = "provider = microsoft.jet.oledb.4.0; data source = " +
                                  Application.StartupPath + "\\userinfo.mdb;" + "jet oledb:database "
                                  + "Password = " + Login.userfilepassword + "; User Id = admin;";

                    OleDbConnection oleCon = new OleDbConnection(constr);
                    OleDbDataAdapter oleDap = new OleDbDataAdapter("select * from myuserinfo", oleCon);
                    DataSet ds = new DataSet();
                    oleDap.Fill(ds, "userinfo");
                    for (int j = 0; j < ds.Tables[0].Rows.Count; ++j)
                    {
                        Arraynames[j] = ds.Tables[0].Rows[j][0].ToString();
                        Arraypasswords[j] = ds.Tables[0].Rows[j][1].ToString();
                        Arrayquanxian[j] = ds.Tables[0].Rows[j][2].ToString();
                        Arrayremarks[j] = ds.Tables[0].Rows[j][3].ToString();
                        countofuser++;
                    }
                    oleCon.Close(); 
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// 使用用户名和密码登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Record_ID_Click(object sender, EventArgs e)
        {
            //_btn_Record_anony.Enabled = false;
            //_btn_Record_ID.Enabled = false;
            username = _txt_User_name.Text;
            for (int i = 0; i < countofuser; ++i)
            {
                if (username == Arraynames[i])
                {
                    userID = i;
                    if (_txt_User_password.Text == Arraypasswords[userID])
                    {
                        Form1.curUserID = _txt_User_name.Text;
                        if (Arrayquanxian[userID] == "Level 1")
                        {
                            Form1.curUserJB = 1;
                        }
                        else if (Arrayquanxian[userID] == "Level 2")
                        {
                            Form1.curUserJB = 2;
                        }
                        else if (Arrayquanxian[userID] == "Level 3")
                        {
                            Form1.curUserJB = 3;
                        }
                        this.Close();
                    }
                    else
                    {
                        _btn_Record_ID.Enabled = true;
                        MessageBox.Show("您输入密码不正确！");
                        _txt_User_password.Focus();
                    }
                    break;
                }
                if (i == countofuser - 1)
                {
                    _btn_Record_ID.Enabled = true;
                    MessageBox.Show("您输入的用户名不存在！");
                    _txt_User_name.Focus();
                }
            }
        }

        /// <summary>
        /// 匿名登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Record_anony_Click(object sender, EventArgs e)
        {
            username = "anony";
            //_btn_Record_ID.Enabled = false;
            //_btn_Record_anony.Enabled = false;
            userID = 0;
           
        }

        /// <summary>
        /// 响应密码输入框的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _txt_User_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                On_Record_ID_Click(this, null);
        }

        /// <summary>
        /// 退出登录窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
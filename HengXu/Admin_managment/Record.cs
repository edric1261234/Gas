using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace 数据采集单元界面设计
{
    public partial class Record : Form
    {
        public static string username;
        public static string[] Arraynames = new string[10];
        public static string[] Arraypasswords = new string[10];
        public static string[] Arrayquanxian = new string[10];
        public static string[] Arrayremarks = new string[10];
        public static int countofuser = 0 ;
        public static int userID = 0;
        public static string userinfofilepath;

        public Record()
        {
            InitializeComponent();
            userinfofilepath = Application.StartupPath + "\\userinfo.mdb";
            ReadUserInfo();
        }
        
        public static void ReadUserInfo()
        {
            try
            {
                if (File.Exists(userinfofilepath))
                {
                    for (int i = 0; i < 10; ++i)
                    {
                        Arraynames[i] = "";
                        Arraypasswords[i] = "";
                        Arrayquanxian[i] = "";
                        Arrayremarks[i] = "";
                    }
                    countofuser = 0;

                   string constr = "provider = microsoft.jet.oledb.4.0; data source = " +
               Application.StartupPath + "\\userinfo.mdb;" + "jet oledb:database "
               + "Password = sy0703229; User Id = admin;";

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void On_Record_ID_Click(object sender, EventArgs e)
        {
                username = _txt_User_name.Text;
                for (int i = 0; i < countofuser; ++i)
                {
                    if (username == Arraynames[i])
                    {
                        userID = i;
                        if (_txt_User_password.Text == Arraypasswords[userID])
                        {
                            new SelectCtrlMode().Show();
                        }
                        else
                        {
                            MessageBox.Show("您输入密码不正确！");
                        }               
                        break;
                    }

                    if (i == countofuser-1)
                        MessageBox.Show("您输入的用户名不存在！");
                }                
        }

        private void On_Record_anony_Click(object sender, EventArgs e)
        {
            username = "anony";
            new SelectCtrlMode().Show();
            userID = 0;
        }

        private void _txt_User_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                On_Record_ID_Click(this, null);
        }

      
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HengXu
{
    public partial class Setting : Form
    {
 
        public Setting()
        {
            InitializeComponent();
  

            if (Form1.bShowZS)
            {
                _cmb_zhesuan.Text = "��";
            }
            else 
            {
                _cmb_zhesuan.Text = "��";
            }
            if (Form1.showbiaogan)
            {
                _cmb_showbiaogan.Text = "��";
            }
            else
            {
                _cmb_showbiaogan.Text = "��";
            }
            
            if (Form1.bShuCaiYi)
            {
                _cmb_shucaiyi.Text = "��";
                if (Form1.bNew232Version)
                {
                    _cmb_version.Text = "�°�";
                }
                else
                {
                    _cmb_version.Text = "�ɰ�";
                }
            }
            else
            {
                _cmb_shucaiyi.Text = "��";
                _cmb_version.Visible = false;
                _lbl_version.Visible = false;
            }
            if (Form1.bNewEquip)
            {
                _cmb_shucaimokuai.Text = "�°�";
            }
            else
            {
                _cmb_shucaimokuai.Text = "�ɰ�";
            }
           
            if (Form1.bUpLoadTotal)
            {
                _cmb_upTotal.Text = "��";
            }
            else
            {
                _cmb_upTotal.Text = "��";
            }
            if (Form1.bCalZS)
            {
                _cmb_uplodZS.Text = "��";
            }
            else
            {
                _cmb_uplodZS.Text = "��";
            }
            if (Form1.bSaveLogFile)
            {
                _cmb_saveLogFile.Text = "��";
            }
            else
            {
                _cmb_saveLogFile.Text = "��";
            }
            if (Form1.showGongK)
                _cmb_showgongk.Text = "��";
            else
                _cmb_showgongk.Text = "��";
            
        }
        private void _btn_confirm_Click(object sender, EventArgs e)
        {
            if (_cmb_zhesuan.Text == "��")
                Form1.bShowZS = true;
            else
                Form1.bShowZS = false;
            if (_cmb_showbiaogan.Text == "��")
            {
                Form1.showbiaogan = true;
            }
            else
                Form1.showbiaogan = false;

            if (_cmb_showgongk.Text == "��")
                Form1.showGongK = true;
            else
                Form1.showGongK = false;
           
            if (_cmb_shucaiyi.Text == "��")
            {
                Form1.bShuCaiYi = true;
            }
            else
            {
                Form1.bShuCaiYi = false;
            }
            if (_cmb_version.Text == "�°�")
            {
                Form1.bNew232Version = true;
            }
            else
            {
                Form1.bNew232Version = false;
            }
            if (_cmb_shucaimokuai.Text == "�°�")
            {
                Form1.bNewEquip = true;
            }
            else
            {
                Form1.bNewEquip = false;
            }
           
            if (_cmb_upTotal.Text == "��")
            {
                Form1.bUpLoadTotal = true;
            }
            else
            {
                Form1.bUpLoadTotal = false;
            }
            if (_cmb_uplodZS.Text == "��")
            {
                Form1.bCalZS = true;
            }
            else
            {
                Form1.bCalZS = false;
            }
            if (_cmb_saveLogFile.Text == "��")
            {
                Form1.bSaveLogFile = true;
            }
            else
            {
                Form1.bSaveLogFile = false;
            }
        }



        private void _cmb_shucaiyi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmb_shucaiyi.Text == "��")
            {
                _cmb_version.Visible = true;
                _lbl_version.Visible = true;
                if (Form1.bNew232Version)
                {
                    _cmb_version.Text = "�°�";
                }
                else
                {
                    _cmb_version.Text = "�ɰ�";
                }
            }
            else
            {
                _cmb_version.Visible = false;
                _lbl_version.Visible = false;
            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            string value = _txt_orgVal.Text;
            try
            {
                value = value.Trim();
                string[] subValues = value.Split(' ');

                if (subValues.Length != 4)
                {
                    MessageBox.Show("���������������һ���ո�ָ�");
                    return;
                }
                UInt32 v = 0;
                v += Convert.ToUInt32(subValues[0], 16) << 24;
                v += Convert.ToUInt32(subValues[1], 16) << 16;
                v += Convert.ToUInt32(subValues[2], 16) << 8;
                v += Convert.ToUInt32(subValues[3], 16);
                float f = BitConverter.ToSingle(BitConverter.GetBytes(v), 0);
                _lbl_val.Text = "ʵ��ֵΪ��" + f.ToString("f2");

            }
            catch
            { }
        }

    }
}
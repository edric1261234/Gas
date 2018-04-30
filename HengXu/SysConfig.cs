using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace HengXu
{
    public partial class SysConfig : Form
    {
        int[] g = new int[8];
        int[] b = new int[8];
       
        public SysConfig()
        {
            InitializeComponent();
            _lbl_ChName.Text = "ͨ��1";
            Btn[0] = _btn0;
            Btn[1] = _btn1;
            Btn[2] = _btn2;
            Btn[3] = _btn3;
            Btn[4] = _btn4;
            Btn[5] = _btn5;
            Btn[6] = _btn6; 
            Btn[7] = _btn7;

            
            for (int i = 0; i < 8; i++)
            {
                Btn[i].Text = Form1.val_name[i] + "  ͨ��" + (i + 1).ToString();
                g[i] = Convert.ToInt32(Form1.Form_index[i].ToString(), 10);
                b[i] = g[i];
                _cmb_ChName.Items.Add(Form1.initname[i]);
            }
            curIndex = 0;
  
            _cmb_ChName.SelectedIndex = g[0];
            _btn0.BackColor = Color.Chocolate;
            _btn_apply.Enabled = false;
            _lbl_uint.Text = Form1.val_unit[0];
            _lbl_uint1.Text = Form1.val_unit[0];
            
        }
        /// <summary>
        /// �������ݿ��е���Ÿı�����ֵ
        /// </summary>
        /// <param name="i"></param>
        void changeCmb(int i)
        {
            Btn[curIndex].Text = Form1.initname[i] + "  ͨ��" + (curIndex + 1).ToString();
            _cmb_ChName.SelectedIndex = i;
            _txt_unit.Text = Form1.initunit[i];
            _lbl_uint1.Text = Form1.initunit[i];
            _lbl_uint.Text = Form1.initunit[i];
            if (Form1.GetGasType(curIndex) == Form1.GasType.QiYa)
            {
                _txt_valmin.Text = ((Convert.ToDouble(Form1.initk[i]) * 4.0  + Convert.ToDouble(Form1.initb[i]))/1000-101).ToString("f2");
                _txt_valmax.Text = ((Convert.ToDouble(Form1.initk[i]) * 20.0 + Convert.ToDouble(Form1.initb[i]))/1000-101).ToString("f2");
            }
            else 
            {
                _txt_valmin.Text = (Convert.ToDouble(Form1.initk[i]) * 4.0 + Convert.ToDouble(Form1.initb[i])).ToString("f2");
                _txt_valmax.Text = (Convert.ToDouble(Form1.initk[i]) * 20.0 + Convert.ToDouble(Form1.initb[i])).ToString("f2");
            }
           
        }

        int curIndex = 0;

        Button[] Btn = new Button[8];
        private void OnSaveChange(object sender, EventArgs e)
        {
          
            try
            {
                double max = 1.0;
                double min = 0.0;
                if (_txt_valmin.Text != "")
                {
                    min = Convert.ToDouble(_txt_valmin.Text);
                }
                else
                {
                    MessageBox.Show("��������Сֵ");
                    return;
                }
                if (_txt_valmax.Text != "")
                {
                    max = Convert.ToDouble(_txt_valmax.Text);
                }
                else
                {
                    MessageBox.Show("���������ֵ");
                    return;
                }
                if (Form1.GetGasType(curIndex) == Form1.GasType.QiYa)
                {
                    min = (min + 101) * 1000;
                    max = (max + 101) * 1000;
                }
                if (max != min)
                {
                    Form1.Calmax[curIndex] = max;
                    Form1.Calmin[curIndex] = min;
                   
                    Form1.val_k[curIndex] =  (max - min)/16.0;
                    Form1.val_b[curIndex] = (5.0 * min - max) / 4.0;     
                    Form1.val_name[curIndex] = _cmb_ChName.Text;
                    Form1.val_unit[curIndex] = _txt_unit.Text;
                }
            }
            catch
            {
                MessageBox.Show("�����������!");
            }

      
            try
            {
                OracleCommand cmd = Form1.conn.CreateCommand();

                cmd.CommandText = "UPDATE form_index SET formindex = " + g[curIndex] + " WHERE seqid = " + curIndex;    //SQL���
                OracleDataReader rs = cmd.ExecuteReader();
                rs.Close();
                cmd.CommandText = "UPDATE gas_type SET val_k = " + Form1.val_k[curIndex]
                                    + ",val_b=" + Form1.val_b[curIndex]
                                    + ",calmax=" + Form1.Calmax[curIndex]
                                    + ",calmin=" + Form1.Calmin[curIndex] + " WHERE form_index = " + g[curIndex];
                rs = cmd.ExecuteReader();
                rs.Close();
                _btn_apply.Enabled = false;
                Form1.InitDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ʧ�ܣ�����δ���� " + ex.Message);
            }
        }

        private void OnButtonChanged(object sender, EventArgs e)
        {
            
            if (_btn_apply.Enabled)
            {
                if (MessageBox.Show("�����Ѹ��ģ��Ƿ�Ӧ�ã�", "ȷ��", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    OnSaveChange(null, null);
                }
            }
            Button btn = (Button)sender;
            curIndex = Convert.ToInt16(btn.Text[btn.Text.Length-1].ToString()) - 1;
            for (int i = 0; i < 8; i++)
            {
                Btn[i].BackColor = Color.Transparent;  
            }
            changeCmb(g[curIndex]);
            btn.BackColor = Color.Chocolate;
            _lbl_ChName.Text = "ͨ��" + (curIndex + 1).ToString();
            _btn_apply.Enabled = false;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            _btn_apply.Enabled = true;
        }

       


        private void _cmb_ChName_SelectedIndexChanged(object sender, EventArgs e)
        {
            g[curIndex] = _cmb_ChName.SelectedIndex;

            changeCmb(_cmb_ChName.SelectedIndex);
        }


        private void SysConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 8; j++)
                {
                    if (g[i] == g[j])
                    {
                        MessageBox.Show("ͨ��" + (i + 1).ToString() + "��ͨ��" + (j + 1).ToString() + "��ͬ����ı�����һ��");
                        e.Cancel = true;
                    }
                }
            }


        }

        private void tank1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {

        }


    }
}
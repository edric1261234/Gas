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
    public partial class ChanConfig : Form
    {

        public ChanConfig()
        {
            InitializeComponent();
            _lbl_ChName.Text = "通道1";
            Btn[0] = _btn0;
            Btn[1] = _btn1;
            Btn[2] = _btn2;
            Btn[3] = _btn3;
            Btn[4] = _btn4;
            Btn[5] = _btn5;
            Btn[6] = _btn6; 
            Btn[7] = _btn7;

            _txt_xishu.Text = Form1.QswXishu.ToString("f2");
            for (int i = 0; i < 8; i++)
            {
                Btn[i].Text = Form1.val_name[i] + "  通道" + (i + 1).ToString();

            }
            curIndex = 0;
            _txt_val_k.Text = Form1.initjiaozheng_k[Form1.D2F(0)].ToString("f2");
            _txt_val_b.Text = Form1.initjiaozheng_b[Form1.D2F(0)].ToString("f2");

            _btn0.BackColor = Color.Chocolate;
            _btn_apply.Enabled = false;

            if (Form1.boutput[Form1.D2F(0)])
            {
                _cmb_output.Text = "是";
            }
            else
            {
                _cmb_output.Text = "否";
            }
            _txt_Ik.Text = Form1.outputk[Form1.D2F(0)].ToString("f2");
            _txt_Ib.Text = Form1.outputb[Form1.D2F(0)].ToString("f2");
            _btn_apply.Enabled = false;
            
        }
        /// <summary>
        /// 根据数据库中的序号改变界面的值
        /// </summary>
        /// <param name="i"></param>
        void changeCmb()
        {
            int t = (int)Form1.GetGasType(curIndex);
            Btn[curIndex].Text = Form1.initname[t] + "  通道" + (curIndex + 1).ToString();
            _txt_val_k.Text = Form1.initjiaozheng_k[t].ToString("f2");
            _txt_Ik.Text = Form1.outputk[t].ToString("f2");

            if (t == 5)
            {
                _txt_Ib.Text = (Form1.outputb[t]/1000.0).ToString("f2");
                _txt_val_b.Text = (Form1.initjiaozheng_b[t]/1000.0).ToString("f2");
            }
            else if (t == 0)
            {
                _txt_Ib.Text = (Form1.outputb[t] / Form1.M2).ToString("f2");
                _txt_val_b.Text = (Form1.initjiaozheng_b[t] / Form1.M2).ToString("f2");
            }
            else
            {
                _txt_Ib.Text = Form1.outputb[t].ToString("f2");
                _txt_val_b.Text = Form1.initjiaozheng_b[t].ToString("f2");
            }
              
            if (Form1.boutput[t])
            {
                _cmb_output.Text = "是";
            }
            else
            {
                _cmb_output.Text = "否";
            }
        }

        int curIndex = 0;

        Button[] Btn = new Button[8];
        private void OnSaveChange(object sender, EventArgs e)
        {
          
            try
            {
                int  t = (int)Form1.GetGasType(curIndex);
           
                if (_txt_val_k.Text != "")
                {
                    Form1.initjiaozheng_k[t] = Convert.ToDouble(_txt_val_k.Text);
                }
                else
                {
                    MessageBox.Show("请输入k值");
                    return;
                }
                if (_txt_val_b.Text != "")
                {
                    Form1.initjiaozheng_b[t] = Convert.ToDouble(_txt_val_b.Text);
                    if (t == 5)
                    {
                        Form1.initjiaozheng_b[t] *= 1000.0;
                    }
                    if (t == 0)
                    {
                        Form1.initjiaozheng_b[t] *= Form1.M2;
                    }
                }
                else
                {
                    MessageBox.Show("请输入b值");
                    return;
                }


                if (_txt_Ik.Text != "")
                {
                    Form1.outputk[t] = Convert.ToDouble(_txt_Ik.Text);
                }
                else
                {
                    MessageBox.Show("请输入电流k值");
                    return;
                }
                if (_txt_Ib.Text != "")
                {
                    Form1.outputb[t] = Convert.ToDouble(_txt_Ib.Text);
                    if (t == 5)
                    {
                        Form1.outputb[t] *= 1000.0;
                    }
                }
                else
                {
                    MessageBox.Show("请输入电流b值");
                    return;
                }
                if (_cmb_output.Text == "是")
                {
                    Form1.boutput[t] = true;
                }
                else
                {
                    Form1.boutput[t] = false;
                }

                _btn_apply.Enabled = false;
            }
            catch
            {
                MessageBox.Show("输入参数错误!");
            }
        }

        private void OnButtonChanged(object sender, EventArgs e)
        {
            
            if (_btn_apply.Enabled)
            {
                if (MessageBox.Show("配置已更改，是否应用？", "确认", MessageBoxButtons.YesNo) != DialogResult.Yes)
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
            changeCmb();
            btn.BackColor = Color.Chocolate;
            _lbl_ChName.Text = "通道" + (curIndex + 1).ToString();
            _btn_apply.Enabled = false;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            _btn_apply.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.QswXishu = Convert.ToDouble(_txt_xishu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }


    }
}
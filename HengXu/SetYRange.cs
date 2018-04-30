using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace HengXu
{
    public partial class SetYRange : Form
    {
        /// <summary>
        /// ��ǰ�Ƿ��ڲɼ�ҳ��
        /// </summary>
        private bool IsAcquireGraph;
        /// <summary>
        /// �Ƿ��������Ӧģʽ
        /// </summary>
        private bool AutoScaledRange;
        /// <summary>
        /// ��ʾ��ѡ����������
        /// </summary>
        private Label[] ParaNames;
        /// <summary>
        /// �趨��С��Χ
        /// </summary>
        private NumericUpDown[] SetMinRanges;
        /// <summary>
        /// �趨���Χ
        /// </summary>
        private NumericUpDown[] SetMaxRanges;
        /// <summary>
        /// ���ð�ť
        /// </summary>
        private Button[] ResetButton;

        bool bCheckValue = false;
        /// <summary>
        /// ����Y�᷶Χ�Ĺ��캯��
        /// </summary>
        /// <param name="InAcquirePage">�ǲɼ����滹�ǻطŽ���
        /// trueΪ�ɼ����棬falseΪ�طŽ���</param>
        public SetYRange(bool InAcquirePage)
        {
            InitializeComponent();
            IsAcquireGraph = InAcquirePage;
            ParaNames = new Label[8] {_lbl_name1,_lbl_name2,
            _lbl_name3,_lbl_name4,_lbl_name5,_lbl_name6,_lbl_name7,_lbl_name8};
            SetMinRanges = new NumericUpDown[8] { _UpDown_min1,
            _UpDown_min2,_UpDown_min3,_UpDown_min4,_UpDown_min5,_UpDown_min6,_UpDown_min7,_UpDown_min8};
            SetMaxRanges = new NumericUpDown[8] { _UpDown_max1,
            _UpDown_max2,_UpDown_max3,_UpDown_max4,_UpDown_max5,_UpDown_max6,_UpDown_max7,_UpDown_max8};
            ResetButton = new Button[8] { _btn_reset0, _btn_reset1, _btn_reset2, _btn_reset3, _btn_reset4, 
            _btn_reset5, _btn_reset6, _btn_reset7};
    
        }
        private void SetYRange_Load(object sender, EventArgs e)
        {
            try
            {
                //��ѡ�еĲ������ƽ��и�ֵ

                for (int i = 0; i < Form1.ACQUIREWAVECOUNT; ++i)
                {
                    SetMinRanges[i].Enabled = true;
                    SetMaxRanges[i].Enabled = true;
                    ParaNames[i].Text = Form1.Acqlabel[i].Text;
                    string min = Form1.Calmin[i].ToString("f0");//Form1.AcquireGraph[i].Axes.Item("YAxis-1").Minimum.ToString();
                    string max = Form1.Calmax[i].ToString("f0"); //Form1.AcquireGraph[i].Axes.Item("YAxis-1").Maximum.ToString();
                    SetMaxRanges[i].Value = Convert.ToInt32(max, 10);
                    SetMinRanges[i].Value = Convert.ToInt32(min, 10);   
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            bCheckValue = true;
        }
        /// <summary>
        /// ��Ӧ�ֶ������Ƿ���Ч�л��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _rdo_manaulSet_CheckedChanged(object sender, EventArgs e)
        {
            if (_rdo_manaulSet.Checked)
            {
                _grp_manaulSet.Enabled = true;
            }
            else
            {
                _grp_manaulSet.Enabled = false;
            }
        }

        /// <summary>
        /// ��Ӧ����Ӧģʽ�Ƿ���Ч�л��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _rdo_autoScale_CheckedChanged(object sender, EventArgs e)
        {
            //if (_rdo_autoScale.Checked)
            //{
            //    AutoScaledRange = true;
            //    if (IsAcquireGraph)
            //    {
            //        for (int i = 0; i < Form1.ACQUIREWAVECOUNT; ++i)
            //        {
            //            Form1.AcquireGraph[i].Axes.Item("YAxis-1").AutoScaleNow();
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < Form1.REPLAYWAVECOUNT; ++i)
            //        {
            //            Form1.ReplayGraph[i].Axes.Item("YAxis-1").AutoScaleNow();
            //        }
            //    }
            //    this.Close();
            //}
            //else
            //{
            //    AutoScaledRange = false;
            //}
        }

        /// <summary>
        /// У���û�����������Ƿ���Ч
        /// </summary>
        /// <returns>��Ч���뷵��true����Ч����false</returns>
        private bool validate_Input()
        {
            //�ɼ�ҳ��Ĳ��η�ΧУ��
           if (IsAcquireGraph)
           {
               for (int i = 0; i < Form1.ACQUIREWAVECOUNT; ++i )
               {
                   if (SetMinRanges[i].Value >= SetMaxRanges[i].Value)
                   {
                       MessageBox.Show("���������������Ƿ���ȷ����Сֵ����С�����ֵ");
                       return false;
                   }
                   else
                   {
                       continue;
                   }
               }
               return true;
           } 
           else //�ط�ҳ��Ĳ��η�ΧУ��
           {
               for (int i = 0; i < Form1.REPLAYWAVECOUNT; ++i )
               {
                   if (SetMinRanges[i].Value >= SetMaxRanges[i].Value)
                   {
                       MessageBox.Show("���������������Ƿ���ȷ����Сֵ����С�����ֵ");
                       return false;
                   }
                   else
                   {
                       continue;
                   }
               }
               return true;
           }
        }

        /// <summary>
        /// ȷ��Y�᷶Χ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConfirm(object sender, EventArgs e)
        {
            //�����Ƿ�ѡ���λطŲ����������Ը���Y�᷶Χ
            if (validate_Input())
            {
                for (int i = 0; i < Form1.ACQUIREWAVECOUNT; ++i)
                {
                    Form1.Calmax[i] = (double)SetMaxRanges[i].Value;
                    Form1.Calmin[i] = (double)SetMinRanges[i].Value;
                }

                this.Close();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ��������С�ߵ������Զ��Ի�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _UpDown_min1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bCheckValue)
                {
                    NumericUpDown sen = (NumericUpDown)sender;
                    string senderName = sen.Name;
                    int index = Convert.ToInt16(senderName[senderName.Length - 1]) - 48 - 1;
                    if (SetMaxRanges[index].Value <= SetMinRanges[index].Value)
                    {
                        if (senderName.Contains("max"))
                        {
                            sen.Value = SetMinRanges[index].Value + 1;
                        }
                        else
                        {
                            sen.Value = SetMaxRanges[index].Value - 1;
                        }
                    }

                    if (senderName.Contains("max"))
                    {
                        decimal max = Convert.ToDecimal(Form1.val_k[index] * 20 + Form1.val_b[index]);

                    }
                    else
                    {
                        decimal min = Convert.ToDecimal(Form1.val_k[index] * 4 + Form1.val_b[index]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void _btn_reset0_Click(object sender, EventArgs e)
        {
            Button sen = (Button)sender;
            int i =  Convert.ToInt32( sen.Name[sen.Name.Length - 1])-48;
            Form1.Calmax[i] = Form1.val_k[i] * 20 + Form1.val_b[i];
            Form1.Calmin[i] = Form1.val_k[i] * 4 + Form1.val_b[i];
            int ii = Convert.ToInt16(Form1.Calmax[i]);
            SetMaxRanges[i].Value = Convert.ToDecimal( Form1.Calmax[i]);
            SetMinRanges[i].Value = Convert.ToDecimal(Form1.Calmin[i]);
        }


    }
}
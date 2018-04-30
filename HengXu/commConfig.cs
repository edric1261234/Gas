using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace HengXu
{
    public partial class commConfig : Form
    {
        public commConfig()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                _cmb_curcomm.Items.Add(ports[i]);
                Form1.port_name[i] = ports[i];
                _cmb_acqport.Items.Add(ports[i]);
                _cmb_commport.Items.Add(ports[i]);
                _cmb_AO.Items.Add(ports[i]);
            }
            
            _cmb_acqport.Text = Form1.acq_port;
            _cmb_commport.Text = Form1.comm_port;
            _cmb_AO.Text = Form1.ao_port;
            _freq.Value = Form1.acq_freq;
            _txt_O2.Text = Form1.O2.ToString("f2");
            _txt_M2.Text = Form1.M2.ToString("f2");
            _txt_Xsw.Text = Form1.Xsw.ToString("f2");
            _txt_gasname.Text = Form1.gasname;
            _txt_gasID.Text = Form1.gasid;
            _txt_title.Text = Form1.title;
            _txt_mn.Text = Form1.mn;
            _txt_password.Text = Form1.password;

            _cmb_curcomm.Text = Form1.port_name[0];
            _cmb_boad.Text = Form1.port_boad[0];
            _cmb_jiaoyan.Text = Form1.port_jiaoyan[0];
            _cmb_stop.Text = Form1.port_stop[0];
            _cmb_data.Text = Form1.port_data[0];
            _txt_uptime.Text = Form1.uptime;
            _txt_ptg.Text = Form1.ptgXS ;
            _txt_sudu.Text =  Form1.suduXS;
            _txt_dqyl.Text = Form1.yaliXS;
            _txt_kqxs.Text = Form1.kqXS ;
        }
        int index = 0;
       
        private void _btn_confirm_Click(object sender, EventArgs e)
        {
            //Form1.comm_port = _cmb_curcomm.Text;
            Form1.port_boad[index] = _cmb_boad.Text;
            Form1.port_data[index] = _cmb_data.Text;
            Form1.port_jiaoyan[index] = _cmb_jiaoyan.Text;
            Form1.port_stop[index] = _cmb_stop.Text;
            Form1.mn = _txt_mn.Text;
            Form1.password = _txt_password.Text;
            Form1.uptime = _txt_uptime.Text;
        }

        private void _cmb_comm_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = _cmb_curcomm.SelectedIndex;
            _cmb_boad.Text = Form1.port_boad[index];
            _cmb_data.Text = Form1.port_data[index];
            _cmb_jiaoyan.Text = Form1.port_jiaoyan[index];
            _cmb_stop.Text = Form1.port_stop[index];
        }

        private void _btn_acq_Click(object sender, EventArgs e)
        {
            if (_freq.Value == 0 || string.IsNullOrEmpty(_cmb_acqport.Text) || string.IsNullOrEmpty(_cmb_curcomm.Text)
                || string.IsNullOrEmpty(_txt_O2.Text) || string.IsNullOrEmpty(_txt_M2.Text) || string.IsNullOrEmpty(_txt_Xsw.Text) || string.IsNullOrEmpty(_txt_title.Text))
            {
                MessageBox.Show("参数不能为空或0");
            }
            Form1.acq_freq = (int)_freq.Value ;
            Form1.acq_port = _cmb_acqport.Text;
            Form1.comm_port = _cmb_commport.Text;
            Form1.ao_port = _cmb_AO.Text;
            Form1.O2 = Convert.ToDouble(_txt_O2.Text);
            Form1.M2 = Convert.ToDouble(_txt_M2.Text);
            Form1.Xsw = Convert.ToDouble(_txt_Xsw.Text);
            Form1.gasname = _txt_gasname.Text;
            Form1.gasid = _txt_gasID.Text;

           // Form1.Calmax[Form1.D2F(0)] = (Form1.val_k[Form1.D2F(0)] * 20.0 + Form1.val_b[Form1.D2F(0)]) * Form1.M2;
            //Form1.Calmin[Form1.D2F(0)] = (Form1.val_k[Form1.D2F(0)] * 4.0 + Form1.val_b[Form1.D2F(0)]) * Form1.M2;
            Form1.title = _txt_title.Text;
        }

        private void _btn_acqcancle_Click(object sender, EventArgs e)
        {
            _cmb_acqport.Text = Form1.acq_port;
            _cmb_commport.Text = Form1.comm_port;
            _freq.Value = Form1.acq_freq;
        }

        private void _btn_commCancel_Click(object sender, EventArgs e)
        {

        }

        private void _btn_qt_Click(object sender, EventArgs e)
        {
            Form1.ptgXS = _txt_ptg.Text;
            Form1.suduXS = _txt_sudu.Text;
            Form1.yaliXS = _txt_dqyl.Text;
            Form1.kqXS = _txt_kqxs.Text;
        }

    }
}
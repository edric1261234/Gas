using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using AxCWUIControlsLib;
using System.Drawing.Printing;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using NationalInstruments.UI.WindowsForms;





namespace HengXu
{
    public partial class Form1 : Form
    {
        public static string curUserID = "";
        public static int curUserJB = -1;
        public static string str = System.Windows.Forms.Application.StartupPath;
        INIClass iniclass = new INIClass(str+"//1.ini");
        public static OracleConnection conn;
        public static bool bNewEquip = true;
        byte[] PortDataAcq = new byte[1000];
        byte[] PortDataCmd = new byte[5000];
        string notsure = "1";

        #region ����
        public static string[] initname = new string[8];
        public static string[] initunit = new string[8];
        public static string[] initk = new string[8];
        public static string[] initb = new string[8];
        public static string[] initcalmax = new string[8];
        public static string[] initcalmin = new string[8];

        public static double[] val_k = new double[8];
        public static double[] val_b = new double[8];
        public static double[] initjiaozheng_k = new double[8];
        public static double[] initjiaozheng_b = new double[8];
        public static string[] val_name = new string[8];
        public static string[] val_unit = new string[8];
        public static double[] Calmax = new double[8];
        public static double[] Calmin = new double[8];
        public static double[] outputk = new double[8];
        public static double[] outputb = new double[8];
        public static bool[] boutput = new bool[8];

        public static string[] port_boad = new string[22];
        public static string[] port_jiaoyan = new string[22];
        public static string[] port_stop = new string[22];
        public static string[] port_data = new string[22];
        public static string[] port_name = new string[22];

        public static int acq_freq = 5;
        public static string acq_port = "";
        public static string comm_port = "";
        public static string ao_port = "";
 
        public static double O2 = 0;
        public static double M2 = 0;
        public static double Xsw = 0;
        public static string gasname = "";
        public static string gasid = "";
        public static bool showbiaogan = false;
        public static bool showGongK = false;
        string skinPath = "skin\\Diamond\\DiamondBlue.ssk";
        public static string title = "�����ɼ�ϵͳ";
        public static bool bShuCaiYi = false;
        public static bool bNew232Version = true;
        public static bool bSimulator = false;
        public static string mn = "012345678901234";
        public static string password = "";
        public static string uptime = "5";
        public static bool bRtdData = false;
        public static bool bRtdGraph = false;
        public static bool bMinuteData = false;
        public static bool bMinuteGraph = false;
        //�Ƿ��ϴ��ܵ��ŷ���
        public static bool bUpLoadTotal = false;
        //�Ƿ��������
        public static bool bCalZS = false;
        public static bool bSaveLogFile = true;
        public ConfigObj configObj = new ConfigObj();
        //��ѡ�����ĵ�һ֡��ֵ
        double[] initvalue = new double[REPLAYWAVECOUNT];
        //�Ƿ�����ƽ��
        bool bPanning = false;
        //�Ƿ���������
        bool bZooming = false;
        //�Ƿ񵥸�ͼ��Ŵ�
        bool bMax = false;
        #region �������ű���
        //�ϴ�x������ֵ
        DateTime[] former_X_max = new DateTime[10];
        //�ϴ�x�����Сֵ
        DateTime[] former_X_min = new DateTime[10];
        //��¼���Ų����
        int scaleCount;
        /// <summary>
        /// ��ǰ���οؼ�X�᷶Χ����Сֵ
        /// </summary>
        DateTime min_XAxis;
        /// <summary>
        /// ��ǰ���οؼ�X�᷶Χ�����ֵ
        /// </summary>
        DateTime max_XAxis;
        //���οؼ������
        System.Windows.Forms.Cursor CurrentCursor = Cursors.Default;

        #endregion

        public static bool bShowZS = true;
        public static double QswXishu = 1;
        public static int ACQUIREWAVECOUNT = 8;
        public static int REPLAYWAVECOUNT = 8;
        uint Total_Frames = 0;

        public static string ptgXS = "";
        public static string suduXS = "";
        public static string yaliXS = "";
        public static string kqXS = "";

        //�ɼ���ʾ
        public static Tank[] ProgressBarValue = new Tank[16];
        //�طŹ����еĲ�����ʾ�ؼ�����
        public static AxCWGraph[] ReplayGraph = new AxCWGraph[8];
        //�طŹ����еĲ��οؼ�����ֵ��ʾtextbox����
        private TextBox[] Replaytextbox = new TextBox[8];
        //�طŹ����еĲ��οؼ�����������ʾlabel����
        public static Label[] Replaylabel = new Label[8];
        public static TextBox[] Acqtextbox = new TextBox[8];
        public static TextBox[] AcqtextboxN = new TextBox[8];
        public static Label[] Acqlabel = new Label[8];

        public static Label[] Unitbabel = new Label[16];
        public static Label[] ZheSuan = new Label[8];
 
        //�ɼ���������
        float[] AcqData = new float[8];
        float[] AcqDataN = new float[8];
        double[] simuAcq = new double[8];
 
        private SerialPort _port_acq = null;
        private SerialPort _port_comm= null;

        private StringBuilder builder = new StringBuilder();//�������¼��������з����Ĵ��������嵽���档  
        //�ɼ����ݵ�����
        private byte[] SendAcqCmd = new byte[8];
        //�ϴ�������
        private byte[] UpLoadCmd = new byte[200];

        byte[] recvdata = new byte[21];

        string[] ports;
        #endregion

        public static string Form_index = "";
        //���ڱ���ɼ�����ʵʱ����
        List<float>[] RtdData = new List<float>[8];
        //���ڱ���ɼ�������������
        List<float>[] RtdDataN = new List<float>[8];
        List<DateTime> RtdTime = new List<DateTime>();

        StreamWriter wr = File.AppendText("c:\\1.txt");
        UInt32 hHandleSer = 0;
        private bool bSystemRunning = true;
        public Form1()
        {
            InitializeComponent();
            //��ʼ���������������б��      
            ports = SerialPort.GetPortNames();
            _btn_stopAcquire.Enabled = false;

            RegisterHotKey(Handle, 103, KeyModifiers.ctrlAndShift, Keys.I);


            _timer.Interval = acq_freq * 1000;
            for (int i = 0; i < 8; i++)
            {
                RtdData[i] = new List<float>();
                RtdDataN[i] = new List<float>();
            }
            InitDataBase();
            ReadConfig();
            InitForm();
            initAO();
            //skinEngine1.SkinFile = skinPath;
            RegControl();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized; 
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            tableLayoutPanel1.Width =  Screen.PrimaryScreen.WorkingArea.Width;
            tableLayoutPanel1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ReSizeGraph();
            ShowZhesuanText();
            Directory.CreateDirectory("c:\\log");
            //����ȥû���ɵ���������
            new Thread(new ThreadStart(delegate
            {
                FillTheBlankReport();
            })).Start();

        }

        #region ���ģ�麯��

        //�����½��Ĵ������Ӿ����ÿ���½������Ӷ�����һ���µĶ��� 
        [DllImport("ZModbusSdk.dll")]
        static extern UInt32 ZMB_SerConnectMDBServer(int iRtuAscii,
                                                        [MarshalAs(UnmanagedType.LPStr)] string szcom,
                                                        int iBautRate,
                                                        int iByteSize,
                                                        int iParity,
                                                        int iStopBits,
                                                        int iDtrCtl,
                                                        int iRtsCtl,
                                                        int iCtsCtl,
                                                        int iDsrCtl,
                                                        int iResponse);
        //д����Ĵ���
        [DllImport("ZModbusSdk.dll")]
        static extern UInt32 ZMB_WriteRegMulitiple(UInt32 hand,
                                            byte serID,
                                            int nStart,
                                            int nCount,
                                            ref short writeDataArr,
                                            int TranID);

        private void initAO()
        {
            hHandleSer = ZMB_SerConnectMDBServer(0, ao_port, 9600, 8, 0, 0, 0, 0, 0, 0, 200);

            if (hHandleSer == 0)
            {
                MessageBox.Show("����ʧ��");
            }

        } 
        #endregion
       
        private void ShowZhesuanText()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Convert.ToInt32(Form_index[i].ToString()) < 4 && Convert.ToInt32(Form_index[i].ToString()) >0 && bShowZS)
                {
                    ZheSuan[i].Visible = true;
                    AcqtextboxN[i].Visible = true;
                    Unitbabel[i + 8].Visible = true;
                    ProgressBarValue[i + 8].Visible = true;
                }
                else
                {
                    ZheSuan[i].Visible = false;
                    AcqtextboxN[i].Visible = false;
                    Unitbabel[i + 8].Visible = false;
                    ProgressBarValue[i + 8].Visible = false;
                }
            }
            if (showbiaogan)
            {
                _txt_bgLiuLiang.Visible = true;           
                _lbl_bg.Visible = true;      
                _lbl_bgUnit.Visible = true;
            }
            else
            {
                _txt_bgLiuLiang.Visible = false;
                _lbl_bg.Visible = false;
                _lbl_bgUnit.Visible = false;
            }
            if (showGongK)
            {
                _lbl_gk.Visible = true;
                _txt_gkLiuLiang.Visible = true;
                _lbl_gkUnit.Visible = true;
            }
            else
            {
                _txt_gkLiuLiang.Visible = false;
                _lbl_gk.Visible = false;
                _lbl_gkUnit.Visible = false;
            }

        }

        #region ע���ȼ�
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
         IntPtr hWnd, // handle to window 
         int id, // hot key identifier 
         KeyModifiers fsModifiers, // key-modifier options 
         Keys vk // virtual-key code 
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
         IntPtr hWnd, // handle to window 
         int id // hot key identifier 
        );


        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            ctrlAndShift = 6,
            Windows = 8
        } 
        protected override void WndProc(ref Message m)//����Windows��Ϣ
        {
            const int WM_HOTKEY = 0x0312;//����ݼ�
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey();//�������������
                    break;
            }
            base.WndProc(ref m);
        }

        private void ProcessHotkey()
        {
            if (curUserJB >= 1)
            {
                ChanConfig form = new ChanConfig();
                form.ShowDialog();
                SaveCfg();
                ShowZhesuanText();

            }
        } 
        #endregion

        private void ReSizeGraph()
        {
            Size size = _replayArea.Size;
            Point point = _replayArea.Location; ;
            int graphwidth = (int)(size.Width * 0.5 * 0.8);
            int grapheight = (int)(size.Height* 0.26);
            for (int i = 0; i < 4; i++)
            {
                ReplayGraph[i].Size = new Size(graphwidth, grapheight);
                ReplayGraph[i].Location = new Point(point.X, point.Y + grapheight * i + (int)(grapheight * 0.05));
                Replaylabel[i].Location = new Point(point.X + (int)(graphwidth * 1.03), point.Y + grapheight * i + (int)(grapheight * 0.35));
                Replaytextbox[i].Location = new Point(point.X + (int)(graphwidth * 1.03), point.Y + grapheight * i + (int)(grapheight * 0.5));

                ReplayGraph[i+4].Size = new Size(graphwidth, grapheight);
                ReplayGraph[i + 4].Location = new Point(point.X + (int)(size.Width * 0.5), point.Y + grapheight * i + (int)(grapheight * 0.05));
                Replaylabel[i + 4].Location = new Point(point.X + (int)(graphwidth * 1.03) + (int)(size.Width * 0.5), point.Y + grapheight * i + (int)(grapheight * 0.35));
                Replaytextbox[i + 4].Location = new Point(point.X + (int)(graphwidth * 1.03) + (int)(size.Width * 0.5), point.Y + grapheight * i + (int)(grapheight * 0.5));
            }
            
        }

        #region ��������
        public enum GasType
        {
            [Description("��������")]
            LiuSu = 0,
            [Description("Ũ��")]
            NongDu = 1,
            [Description("SO2")]
            SO2 = 2,
            [Description("NOX")]
            NOX = 3,
            [Description("O2")]
            O2 = 4,
            [Description("��ѹ")]
            QiYa = 5,
            [Description("�¶�")]
            WenDu = 6,
            [Description("����")]
            BeiYong = 7,
        };
        public static GasType GetGasType(int index)
        {
            return (GasType)Convert.ToInt32(Form_index[index].ToString());
        }

        public bool RegControl()
        {
            try
            {
                Assembly thisExe = Assembly.GetExecutingAssembly();
                System.IO.Stream myS = thisExe.GetManifestResourceStream("NameSpaceName.dsoframer.ocx");

                string sPath = @"/dsoframer.ocx";
                ProcessStartInfo psi = new ProcessStartInfo("regsvr32", "/s " + sPath);
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }


        private void SendCmd()
        {
            if (_port_acq.IsOpen)
            {
                //ת���б�Ϊ�������
                _port_acq.Write(SendAcqCmd, 0, SendAcqCmd.Length);
            }
        }


        int pos0 = 0;
        byte[] temp0 = new byte[256];
        //�ɼ����ݻص�����
        void acq_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n =  _port_acq.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��
            byte[] buf = new byte[n];
            if (_port_acq != null)
            {
                _port_acq.Read(buf, 0, n);//��ȡ��������
            }
            Array.Copy(buf, 0, PortDataAcq, pos0, n);
            pos0 += n;
            if (pos0 > PortDataAcq.Length - 22)
            {
                pos0 = 0;
            }
            for (int i = 0; i < PortDataAcq.Length - 30; i++)
            {
                if (PortDataAcq[i] == 1 && PortDataAcq[i + 1] == 3 && PortDataAcq[i + 2] == 0x10 && PortDataAcq[i + 21] == 1 && PortDataAcq[i + 22] == 3 && PortDataAcq[i + 23] == 0x10)
                {
                    Array.Copy(PortDataAcq, i, recvdata, 0, 21);
                    plotAcquire(recvdata);
                    Array.Copy(PortDataAcq, i + 21, temp0, 0, 256);

                    Array.Copy(temp0, PortDataAcq, 256);
                    pos0 =0;
                    break;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            acq_CmdReceived(null, null);
        }

        int pos1 = 0;
        byte[] temp1 = new byte[256];
        bool shouldup = false;
      
        //�ϴ����ݻص�����
        void acq_CmdReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = 0;
            byte[] buf;
            if (bSimulator)
            {
                n = 17;
                buf = new byte[] { 0x23, 0x23, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x11, 0x22, 0x26, 0x26 };
               
            }
            else
            {
                n = _port_comm.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��
                buf = new byte[n];
                _port_comm.Read(buf, 0, n);//��ȡ��������
            }
            
           
           
            if (bShuCaiYi)
            {
                if (bSaveLogFile)
                {
                    string ss = "";
                    for (int i = 0; i < buf.Length; i++)
                    {
                        ss += "0x" + buf[i].ToString("x2");
                        ss += " ";
                    }

                    try
                    {
                        DateTime date = DateTime.Now;
                        string str = date.Year.ToString("d4") + "-" + date.Month.ToString("d2") + "-" + date.Day.ToString("d2");
                        StreamWriter wr = File.AppendText("c:\\log\\" + str + "_recvdata.txt");
                        wr.WriteLine("[" + str + " " + date.Hour.ToString("d2") + ":" + date.Minute.ToString("d2") + ":" + date.Second.ToString("d2") + "] " + ss);
                        wr.Flush();
                        wr.Close();
                    }
                    catch
                    {

                    }
                }

                if (bNew232Version)
                {
                    //�����°�ͨ��Э���ʽ��ͨ���������ϴ�
                    for (int i = 0; i < buf.Length - 1 ; i++)
                    {
                        if (buf[i] == 0x23 && buf[i + 1] == 0x23)
                        {
                            shouldup = true;
                            break;
                        }
                    }
                }
                else
                {
                    int cou = 0;
                    for (int i = 0; i < buf.Length; i++)
                    {
                        if (buf[i] == 0)
                        {
                            cou = i;
                            break;
                        }
                    }
                    if (cou == 0)
                    {
                        cou = n;
                    }
                    Array.Copy(buf, 0, PortDataCmd, pos1, cou);
                    pos1 += n;


                    //���þɰ�ͨ��Э���ʽ��ͨ���������ϴ�
                    if (pos1 > PortDataCmd.Length - 22)
                    {
                        pos1 = 0;
                    }
                    for (int i = 0; i < PortDataCmd.Length - 30; i++)
                    {
                        if (PortDataCmd[i] == 0x02 && PortDataCmd[i + 1] == 0x06 && PortDataCmd[i + 31] == 0x02 && PortDataCmd[i + 32] == 0x06)
                        {
                            pos1 = 0;
                            shouldup = true;
                            break;
                        }
                    }
                }
            }
            else
            {  
                ////����212Э�飬ͨ��DTUֱ���ϴ�
                {
                    pos1 = 0;
                }
            }
        }

        void reply212(string QN,bool bstart)
        {
            //ST=91;CN=9011;PW=123456;MN=88888880000001;Flag=0;CP=&&QN=20040516010101001;QnRtn=1&&
            string cmd = "";
            if (bstart)
            {
                cmd = "ST=91;CN=9011;PW=" + password + ";MN=" + mn + ";Flag=0;CP=&&QN=" + QN + ";QnRtn=1&&";
            }
            else
            {
                cmd = "ST=91;CN=9013;PW=" + password + ";MN=" + mn + ";Flag=0;CP=&&QN=" + QN + "&&";
            }
            send212cmd(cmd);
        }
     
        bool shoulduploadRtd = true;
        bool shouldupload10minute = true;
        bool shoulduploadhour = true;
        bool shoulduploadday = true;
        /// <summary>
        /// ��ͼ���ϴ�����
        /// </summary>
        /// <param name="recvdata"></param>
        void plotAcquire(byte[] recvdata)
        {        
            //���ɼ�����������ת���4-20mA��
            GetValueFromBytes(recvdata, ref AcqData);
            outputA(AcqData);
            //��4-20mA��ת��Ϊʵ�ʵ�ֵ
            ChangeValueByCoeff(ref AcqData);
     
            AcqDataN = GetNValue(AcqData);
            for (int i = 0; i < 8; i++)
            {
                 RtdDataN[i].Add(AcqDataN[i]);
                 RtdData[i].Add(AcqData[i]);
            }
            RtdTime.Add(DateTime.Now);

            //�ϴ�����
            if (bShuCaiYi)
            {
                if (bNew232Version)
                {
                    if (shouldup)
                    {
                        //�����°��ͨ��Э���ʽ��ͨ���������ϴ�
                        UploadNewData(AcqData, AcqDataN);
                        shouldup = false;
                    }
                }
                else
                {
                    if (shouldup)
                    {
                        //���þɰ�ͨ��Э���ʽ��ͨ���������ϴ�
                        UploadOldData(AcqData);
                        shouldup = false;
                    }
                }
            }
            else
            {
                 UpLoad212(AcqData, AcqDataN);
            }

            //�洢���������ݿ�
            insertData(AcqData);
            
            //�ڽ�����ʾ
            for (int index = 0; index < 8; index++)
            {
                //��ΪҪ����ui��Դ��������Ҫʹ��invoke��ʽͬ��ui��
                this.Invoke((EventHandler)(delegate
                {
                    //���������
                    if (Form_index[index].ToString() == "0")
                    {
                        ProgressBarValue[index].Value = AcqData[index] / M2;
                        Acqtextbox[index].Text = (AcqData[index] / (float)M2).ToString("f2");
                        _txt_gkLiuLiang.Text = (AcqData[index] * 3600).ToString("f2");
                        _txt_bgLiuLiang.Text = (AcqData[F2D(7)] * 3600).ToString("f2");
                    }
                    else
                    {
                        //�����ѹ��ת��Ϊ-40~40��kpaֵ
                        if (Form_index[index].ToString() == "5")
                        {
                            ProgressBarValue[index].Value = AcqData[index]/1000-101;
                            ProgressBarValue[index + 8].Value = AcqDataN[index] / 1000 - 101;
                            Acqtextbox[index].Text = (AcqData[index] / 1000 - 101).ToString("f3");
                            AcqtextboxN[index].Text = (AcqDataN[index] / 1000 - 101).ToString("f3");
                        }
                        else
                        {
                            ProgressBarValue[index].Value = AcqData[index];
                            ProgressBarValue[index + 8].Value = AcqDataN[index];
                            Acqtextbox[index].Text = AcqData[index].ToString("f2");
                            AcqtextboxN[index].Text = AcqDataN[index].ToString("f2");
                        }
                    }
                }));
            }
        }
        void outputA(float[] value)
        {
            //�������ֵ

            Int16[] wReg = new Int16[4];
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                int t = (int)GetGasType(i);
                if (boutput[t] && count < 4)
                {
                    wReg[count] = (Int16)(value[i] * outputk[t] + outputb[t]);
                    count++;
                }
                
            }


            if (hHandleSer != 0)
            {
                ZMB_WriteRegMulitiple(hHandleSer, 0, 96, 4, ref wReg[0], 0);

            }
        }
        
        byte getBCD(int val)
        {
            if (val < 10)
                return (byte)val;
            else
            {
                return (byte)(val += 6 * (val / 10));
            }
        }
        byte[] getBCDTime()
        {
            byte[] time = new byte[6];
            DateTime t = DateTime.Now;
            time[0] = getBCD(t.Year - 2000);
            time[1] = getBCD(t.Month);
            time[2] = getBCD(t.Day);
            time[3] = getBCD(t.Hour);
            time[4] = getBCD(t.Minute);
            time[5] = getBCD(t.Second);
            return time;
        }
      
        void UpLoad212(float[] val,float[] valN)
        {
            //ÿ5�����ϴ�һ��ʵʱ����
            if (DateTime.Now.Minute % 5 == 0)
            {
                if (shoulduploadRtd)
                {
                    UpLoad212Rtd(val,valN);
                    shoulduploadRtd = false;
                }
            }
            else
            {
                shoulduploadRtd = true;
            }
            //����,ÿ10�����ϴ�һ��
            if ((DateTime.Now.Minute + 2) % 10 == 0)
            {
                if (shouldupload10minute)
                {
                    UpLoad212Minute(10, "2051");
                    shouldupload10minute = false;
                    for (int i = 0; i < 8; i++)
                    {
                        RtdData[i].Clear();
                        RtdDataN[i].Clear();
                    }
                    RtdTime.Clear();
                }
            }
            else
            {
                shouldupload10minute = true;
            }
/*
            //Сʱ,ÿ1��Сʱ�ϴ�һ��
            if (DateTime.Now.Minute % 59 == 0)
            {
                if (shoulduploadhour)
                {
                    UpLoad212Minute(60, "2061");
                    shoulduploadhour = false;
                }
            }
            else
            {
                shoulduploadhour = true;
            }

            //�죬ÿһ���ϴ�һ��
            if (DateTime.Now.Hour == upLoadHour && DateTime.Now.Minute == upLoadMinute)
            {
                if (shoulduploadday)
                {
                    UpLoad212Minute(60 * 24, "2031");
                    for (int i = 0; i < 8; i++)
                    {
                        RtdData[i].Clear();
                        RtdDataN[i].Clear();
                    }
                    RtdTime.Clear();
                    shoulduploadday = false;
                }
            }
            else
            {
                shoulduploadday = true;
            }
 */
        }

        string T_YANCHEN = "01";
        string T_SO2 = "02";
        string T_NO = "03";
        string T_O2 = "S01";
        string T_LIUSU = "B02";
        string T_WENDU = "S03";
        string T_YALI = "S08";
        string T_SHIDU = "S05";


        void UpLoad212Rtd(float[] val, float[] valN)
        {
            #region ׼������
            string sO2 = "0";
            string sLIUSU = "0";
            string sWENDU = "0";
            string sSQRE = "0";
            string sSO2 = "0";
            string sSO2N = "0";
            string sNO = "0";
            string sNON = "0";
            string sYANCHEN = "0";
            string sYANCHENN = "0";
            string sYALI = "0";
            string sSHIDU = (Xsw*100).ToString("f2");
            string time = "0";
            DateTime t = DateTime.Now;
            time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + t.Second.ToString("d2") + "000";
         
            /*
             * 0 567 ˲ʱ�������٣�10837430 Nm3/S [A55DB6��HEX��]
               1 89 �̳�Ũ�ȣ�158 mg/Nm3   [009E (HEX) ]
               2 1011 SO2�� 58 mg/Nm3     [003A (HEX) ]
               3 1213 NOX�� 59 mg/Nm3    [003B (HEX) ]
                 CO 1415
               4 1617 O2��  14%          [000E (HEX)]
               5 181920�̵���ѹ��-750Pa        [8002EE (HEX)]
               6 2122�¶ȣ�94��          [005E (HEX)]
               7 2324ʪ�ȣ�78%          [004E (HEX)]
             */
            sSQRE = M2.ToString("f2");
            for (int i = 0; i < 8; i++)
            {
                string s = Form_index[i].ToString();
                //�ϴ������ٲ��ñ��ֵ������ʵ��ֵ
                if (s == "7")
                {
                    sLIUSU = val[i].ToString("f2");
                }
                else if (s == "1")
                {
                    sYANCHEN = val[i].ToString("f2");
                    sYANCHENN = valN[i].ToString("f2");
                }
                else if (s == "2")
                {
                    sSO2 = val[i].ToString("f2");
                    sSO2N = valN[i].ToString("f2");
                }
                else if (s == "3")
                {
                    sNO = val[i].ToString("f3");
                    sNON = valN[i].ToString("f3");
                }
                else if (s == "4")
                {
                    sO2 = val[i].ToString("f1");
                }
                else if (s == "5")
                {
                    //ѹ���ϴ��ĵ�λ��pa���kpa
                    sYALI = (val[i]/1000-101).ToString("f3");
                }
                else if (s == "6")
                {
                    sWENDU = val[i].ToString("f1");
                }
            }
           
            #endregion

            string cmd = "ST=31;CN=2011;PW=" + password + ";MN=" + mn + ";CP=&&DataTime=" + time;

            cmd += ";01-ZsRtd=" + sYANCHENN + ",01-Flag=N" +
                ";01-Rtd=" + sYANCHEN + ",01-Flag=N" +
            ";02-ZsRtd=" + sSO2N + ",02-Flag=N" +
            ";02-Rtd=" + sSO2 + ",02-Flag=N" +
            ";03-ZsRtd=" + sNON + ",03-Flag=N"+
            ";03-Rtd=" + sNO + ",03-Flag=N"+

             ";S01-Rtd=" + sO2 + ",S01-Flag=N" +
             ";B02-Rtd=" + sLIUSU + ",B02-Flag=N" +
             ";S03-Rtd=" + sWENDU + ",S03-Flag=N" +
             ";S05-Rtd=" + sSHIDU + ",S05-Flag=N" +
             ";S08-Rtd=" + sYALI + ",S08-Flag=N&&";

            send212cmd(cmd);
        }

        void send212cmd(string cmd)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(cmd);
            byte[] temp = crc_ct(b);
            string crc = temp[0].ToString("X2") + temp[1].ToString("X2");
            string fullcmd = "##" + cmd.Length.ToString("d4") + cmd + crc + "\r\n";
            if (!bSimulator)
            {
                if (_port_comm != null)
                {
                    _port_comm.Write(fullcmd);
                }
            }

            if (bSaveLogFile)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    string str = date.Year.ToString("d4") + "-" + date.Month.ToString("d2") + "-" + date.Day.ToString("d2");
                    StreamWriter wr = File.AppendText("c:\\log\\" + str + "_212.txt");
                    wr.WriteLine("[" + str + " " + date.Hour.ToString("d2") + ":" + date.Minute.ToString("d2") + ":" + date.Second.ToString("d2") + "] " + fullcmd);
                    wr.Flush();
                    wr.Close();
                }
                catch
                { }
            }
        }

        byte[] crc_ct(byte[] cmd)
        {
            byte[] re = new byte[2];
            uint wkg = 0xffff;
            int len = cmd.Length;
            for (int i = 0; i < cmd.Length;i++ )
            {
                wkg = (wkg >> 8) & 0x00FF;
                wkg ^= cmd[i];

                for (int j = 0; j < 8; j++)
                {
                    if ((wkg & 0x0001) == 0x01)
                    {
                        wkg = (wkg >> 1) ^ 0xa001;
                    }
                    else
                    {
                        wkg = wkg >> 1;
                    }
                }
            }
            re[0] = (byte)((wkg >> 8) & 0xff);
            re[1] = (byte)(wkg & 0xff);
            return re;
        }









        public byte[] CRC16(byte[] data)
        {
            byte CRC16Lo;
            byte CRC16Hi;   //CRC�Ĵ���       
            byte CL; byte CH;       //����ʽ��&HA001   
            byte SaveHi; byte SaveLo;
            byte[] tmpData;
            int Flag;
            CRC16Lo = 0xFF;
            CRC16Hi = 0xFF;
            CL = 0x01;
            CH = 0xA0;
            tmpData = data;
            for (int i = 0; i < tmpData.Length; i++)
            {
                CRC16Lo = (byte)(CRC16Lo ^ tmpData[i]); //ÿһ��������CRC�Ĵ����������           
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = (byte)(CRC16Hi >> 1);      //��λ����һλ      
                    CRC16Lo = (byte)(CRC16Lo >> 1);      //��λ����һλ            

                    if ((SaveHi & 0x01) == 0x01) //�����λ�ֽ����һλΪ1             
                    {
                        CRC16Lo = (byte)(CRC16Lo | 0x80);   //���λ�ֽ����ƺ�ǰ�油1                 
                    }             //�����Զ���0                 
                    if ((SaveLo & 0x01) == 0x01) //���LSBΪ1���������ʽ��������      
                    {
                        CRC16Hi = (byte)(CRC16Hi ^ CH);
                        CRC16Lo = (byte)(CRC16Lo ^ CL);
                    }
                }
            }
            byte[] ReturnData = new byte[2];
            ReturnData[0] = CRC16Hi;       //CRC��λ       
            ReturnData[1] = CRC16Lo;       //CRC��λ       
            return ReturnData;
        }

        //�ɰ�ӱ�ʡͨ��Э��
        void UploadOldData(float[] val)
        {

            //��ʼ���ϴ�����
            UpLoadCmd[0] = 0x02; //����ͷ    02 06����2���ֽڣ�
            UpLoadCmd[1] = 06;
            UpLoadCmd[2] = 18; //����/ָ�� �������������ݺ�ָ���1���ֽڣ���00Ϊָ�01Ϊ����
            UpLoadCmd[3] = Convert.ToByte(gasid); //����ID
            UpLoadCmd[4] = 01; //���ID 00Ϊˮ�豸  01Ϊ�����豸
            UpLoadCmd[14] = 0xff;
            UpLoadCmd[15] = 0xff; 

            #region ׼������
            /*
             * 0 567 ˲ʱ�������٣�10837430 Nm3/S [A55DB6��HEX��]
               1 89 �̳�Ũ�ȣ�158 mg/Nm3   [009E (HEX) ]
               2 1011 SO2�� 58 mg/Nm3     [003A (HEX) ]
               3 1213 NOX�� 59 mg/Nm3    [003B (HEX) ]
                 CO 1415
               4 1617 O2��  14%          [000E (HEX)]
               5 181920�̵���ѹ��-750Pa        [8002EE (HEX)]
               6 2122�¶ȣ�94��          [005E (HEX)]
               7 2324ʪ�ȣ�78%          [004E (HEX)]
             */
            for (int i = 0; i < 8; i++)
            {
                string s = Form_index[i].ToString();
                if (s == "7")
                {
                    UpLoadCmd[5] = (byte)(((int)val[i] >> 16) & 0xff);
                    UpLoadCmd[6] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[7] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "1")
                {
                    int t = Convert.ToInt32(s, 10);
                    UpLoadCmd[8] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[9] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "2")
                {
                    int t = Convert.ToInt32(s, 10);
                    UpLoadCmd[10] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[11] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "3")
                {
                    int t = Convert.ToInt32(s, 10);
                    UpLoadCmd[12] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[13] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "4")
                {
                    UpLoadCmd[16] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[17] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "5")
                {

                    UpLoadCmd[18] = (byte)(((int)Math.Abs(val[i]) >> 16) & 0xff);
                    UpLoadCmd[19] = (byte)(((int)Math.Abs(val[i]) >> 8) & 0xff);
                    UpLoadCmd[20] = (byte)(((int)Math.Abs(val[i])) & 0xff);
                    if (val[i] < 0)
                    {
                        UpLoadCmd[18] += 0x80;
                    }

                }
                else if (s == "6" )
                {
                    int t = Convert.ToInt32(s, 10);
                    UpLoadCmd[9 + i * 2] = (byte)(((int)val[i] >> 8) & 0xff);
                    UpLoadCmd[10 + i * 2] = (byte)(((int)val[i]) & 0xff);
                }
                else if (s == "7")
                {
                    int t = Convert.ToInt32(s, 10);
                    UpLoadCmd[9 + i * 2] = 0;
                    UpLoadCmd[10 + i * 2] = 0;
                }
            }
            UpLoadCmd[25] = 0;
            UpLoadCmd[26] = 0;
            UpLoadCmd[27] = 0;
            byte[] temp = CRC16_C(UpLoadCmd, 2, 23);
            UpLoadCmd[28] = temp[0];
            UpLoadCmd[29] = temp[1];
            UpLoadCmd[30] = 0x03;
            #endregion

            _port_comm.Write(UpLoadCmd, 0, 31);
            if (bSaveLogFile)
            {
                string ss = "";
                for (int i = 0; i < 0x7e; i++)
                {
                    ss += "0x" + UpLoadCmd[i].ToString("x2");
                    ss += " ";
                }
                try
                {
                    DateTime date = DateTime.Now;
                    string str = date.Year.ToString("d4") + "-" + date.Month.ToString("d2") + "-" + date.Day.ToString("d2");
                    StreamWriter wr = File.AppendText("c:\\log\\" + str + "_old.txt");
                    wr.WriteLine("[" + str + " " + date.Hour.ToString("d2") + ":" + date.Minute.ToString("d2") + ":" + date.Second.ToString("d2") + "] " + ss);
                    wr.Flush();
                    wr.Close();
                }
                catch
                {

                }
            }
        }
      
        void float2Bytes(float val, ref byte[] data, int start)
        {
            uint v = BitConverter.ToUInt32(BitConverter.GetBytes(val), 0);
            if (data.Length < start + 4)
                return;

            data[start] = (byte)((v >> 24) & 0xff);
            data[start + 1] = (byte)((v >> 16) & 0xff);
            data[start + 2] = (byte)((v >> 8) & 0xff);
            data[start + 3] = (byte)(v & 0xff);
        }
        //�°�ӱ�ʡͨ��Э��
        void UploadNewData(float[] val,float[] valN)
        {
            //��ʼ���ϴ�����
            int index = 0;
            UpLoadCmd[0] = 0x23; //����ͷ    0x23 0x23����2���ֽڣ�
            UpLoadCmd[1] = 0x23;
            
            UpLoadCmd[4] = 0x31; //���ϵͳ������
            UpLoadCmd[5] = 0x52; //���ݶ������������ͣ����磺0x52(R)
            UpLoadCmd[6] = 11;  //�ϴ���Ⱦ���������
            index = 7;
            byte[] time = getBCDTime();
            Array.Copy(time, 0, UpLoadCmd, 7, 6);//ǰ�����߼���Ǳ��������ʱ��
            index += 6;

            #region ׼������
            /*
             * 0 567 ˲ʱ�������٣�10837430 Nm3/S [A55DB6��HEX��]
               1 89 �̳�Ũ�ȣ�158 mg/Nm3   [009E (HEX) ]
               2 1011 SO2�� 58 mg/Nm3     [003A (HEX) ]
               3 1213 NOX�� 59 mg/Nm3    [003B (HEX) ]
                 CO 1415
               4 1617 O2��  14%          [000E (HEX)]
               5 181920�̵���ѹ��-750Pa        [8002EE (HEX)]
               6 2122�¶ȣ�94��          [005E (HEX)]
               7 2324ʪ�ȣ�78%          [004E (HEX)]
             */
            for (int i = 0; i < 8; i++)
            {
                string s = Form_index[i].ToString();
                if (s == "7")
                {
                    //����˲ʱ���� 0x42,0x30,0x32
                    UpLoadCmd[index] = 0x42; index++;
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x32; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
                else if (s == "1")
                {
                    //�̳�(01) 0x30,0x31,0x20 ʵʱֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x31; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;

                    //�̳�(01) 0x30,0x31,0x20 ����ֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x31; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x5A; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(valN[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
                else if (s == "2")
                {
                    //�������� 0x30,0x32,0x20 ʵʱֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x32; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;

                    //�������� 0x30,0x32,0x20 ����ֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x32; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x5A; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(valN[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
                else if (s == "3")
                {
                    //NOX 0x30,0x33,0x20 ʵʱֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x33; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;

                    //NOX 0x30,0x33,0x20 ����ֵ
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x33; index++;
                    UpLoadCmd[index] = 0x20; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x5A; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(valN[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
                else if (s == "4")
                {
                    //O2���� 0x53,0x30,0x31
                    UpLoadCmd[index] = 0x53; index++;
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x31; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
                else if (s == "5")
                {
                    //����ѹ�� 0x53,0x30,0x38
                    UpLoadCmd[index] = 0x53; index++;
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x38; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i]/1000-101, ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;

                }
                else if (s == "6")
                {
                    //�����¶� 0x53,0x30,0x33
                    UpLoadCmd[index] = 0x53; index++;
                    UpLoadCmd[index] = 0x30; index++;
                    UpLoadCmd[index] = 0x33; index++;
                    //ʵʱ���� 0x2D,0x52
                    UpLoadCmd[index] = 0x2D; index++;
                    UpLoadCmd[index] = 0x52; index++;
                    //����
                    UpLoadCmd[index] = 0x4E; index++;
                    //��������
                    float2Bytes(val[i], ref UpLoadCmd, index);
                    index += 4;
                    //�ָ��
                    UpLoadCmd[index] = 0x3B; index++;
                }
            }
            //����ʪ�� 0x53 30 35
            UpLoadCmd[index] = 0x53; index++;
            UpLoadCmd[index] = 0x30; index++;
            UpLoadCmd[index] = 0x35; index++;
            //ʵʱ���� 0x2D,0x52
            UpLoadCmd[index] = 0x2D; index++;
            UpLoadCmd[index] = 0x52; index++;
            //����
            UpLoadCmd[index] = 0x4E; index++;
            //��������
            float2Bytes((float)(Xsw*100), ref UpLoadCmd, index);
            index += 4;
            //�ָ��
            UpLoadCmd[index] = 0x3B; index++;

            //���һ��û�зֺţ�������ǰ��һλ
            index--;
            UpLoadCmd[index] = 0xff; index++;
            UpLoadCmd[index] = 0xff; index++;

            UpLoadCmd[2] = (byte)(((index-4) >> 8)& 0xff); //���ȣ�2�ֽ�
            UpLoadCmd[3] = (byte)(((index - 4)) & 0xff); 

            UpLoadCmd[index] = 0x26; index++;
            UpLoadCmd[index] = 0x26; index++;
            #endregion
            
            _port_comm.Write(UpLoadCmd, 0, index);

            if (bSaveLogFile)
            {
                string ss = "";
                for (int i = 0; i < index; i++)
                {
                    ss += "0x" + UpLoadCmd[i].ToString("x2");
                    ss += " ";
                }
                try
                {
                    DateTime date = DateTime.Now;
                    string str = date.Year.ToString("d4") + "-" + date.Month.ToString("d2") + "-" + date.Day.ToString("d2");
                    StreamWriter wr = File.AppendText("c:\\log\\" + str + "_new.txt");
                    wr.WriteLine("[" + str + " " + date.Hour.ToString("d2") + ":" + date.Minute.ToString("d2") + ":" + date.Second.ToString("d2") + "] " + ss);
                    wr.Flush();
                    wr.Close();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// ��ȡ�ɼ������豸ID
        /// </summary>
        void GetEquimentID()
        {
            byte[] senddata = new byte[8];
            //��ʼ����������
            senddata[0] = 0;  //���豸��ַ
            senddata[1] = 3;  //������
            senddata[2] = 0x00;  //��ʼ�Ĵ�����ַ��λ
            senddata[3] = 0x01;  //��ʼ�Ĵ�����ַ��λ
            senddata[4] = 0;
            senddata[5] = 1;
  
            byte[] crc = CRC16_C(senddata,0,5);
            senddata[6] = crc[1]; //CRC У����
            senddata[7] = crc[0];
            Initport();
            if (_port_acq.IsOpen)
            {
                //ת���б�Ϊ�������
                _port_acq.Write(senddata, 0, senddata.Length);
            }
        }
       
     

        #region Oracle���
        /// <summary>
        /// �洢�ɼ���������
        /// </summary>
        /// <param name="data"></param>
        void insertData(float[] data)
        {
            OracleCommand cmd = conn.CreateCommand();
            string scmd = "INSERT INTO gas_data VALUES(seq_gas.nextval";
            scmd += ",to_date('" + GetTimeString(DateTime.Now, "f") + "','yyyymmddhh24miss') ,";
            for (int i = 0; i < 8; i++)
            {
                scmd += "'" + data[F2D(i)].ToString("f2") + "',";              
            }

            scmd += "'')";
            cmd.CommandText = scmd;    //SQL���
            OracleDataReader rs = cmd.ExecuteReader();
            rs.Close();
        }
  
     
        public static bool ReadDataBaseData( DateTime begin, DateTime end, ref float[][] Redata, ref DateTime[] time, ref uint total_frame)
        {
            int interval = 1;
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select count(*) from gas_data where  gasdate between to_date('" + begin + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + end + "','yyyy-mm-dd hh24:mi:ss')";
            OracleDataReader rs = cmd.ExecuteReader();
            rs.Read();

            total_frame = (uint)rs.GetInt32(0);
            rs.Close();
            //�����ѯ���Ϊ0��˵����ʱ���ҵļ������������ҳ�һ�����ڽ�����ʾ����
            if (total_frame == 0)
            {
                cmd.CommandText = "select count(*) from gas_data where gasdate between to_date('" + begin + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + end + "','yyyy-mm-dd hh24:mi:ss')";
                rs = cmd.ExecuteReader();
                rs.Read();
                total_frame = (uint)rs.GetInt32(0);
                rs.Close();
                //�����ʱ��Ϊ0����˵��ȷʵû��ֵ
                if (total_frame == 0)
                {
                    return false;
                }
                else
                {

                    //total_frame = 1;
                    cmd.CommandText = "select * from gas_data where gasdate between to_date('" + begin + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + end + "','yyyy-mm-dd hh24:mi:ss') order by gasdate";
                    rs = cmd.ExecuteReader();
                    rs.Read();
                    time = new DateTime[total_frame];
                    for (int j = 0; j < 8; j++)
                    {
                        Redata[j] = new float[total_frame];
                    }
                    try
                    {
                        rs = cmd.ExecuteReader();
                        int k = 0;
                        while (rs.Read())
                        {
                            time[k] = rs.GetDateTime(1);
                            for (int j = 0; j < 8; j++)
                            {
                                // Redata[j][k] = Convert.ToSingle( rs.GetString(F2D(j) + 2));
                                Redata[j][k] = Convert.ToSingle(rs.GetString(j + 2));
                            }
                            k++;
                        }
                        rs.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("��ȡ���ݳ���" + ex.Message);
                    }
                }
            }
            else
            {

                interval = (int)total_frame / 100;
                if (interval == 0)
                    interval = 1;
                cmd.CommandText = "select count(*) from gas_data where MOD(seqid, " + interval.ToString() + ") =0 and gasdate between to_date('" + begin + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + end + "','yyyy-mm-dd hh24:mi:ss')";
                rs = cmd.ExecuteReader();
                rs.Read();

                total_frame = (uint)rs.GetInt32(0);
                rs.Close();

                for (int j = 0; j < 8; j++)
                {
                    Redata[j] = new float[total_frame];
                }
                time = new DateTime[total_frame];
                cmd.CommandText = "select * from gas_data where  MOD(seqid, " + interval.ToString() + ") =0 and  gasdate between to_date('" + begin + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + end + "','yyyy-mm-dd hh24:mi:ss') order by gasdate";

                try
                {
                    rs = cmd.ExecuteReader();
                    int k = 0;
                    while (rs.Read())
                    {
                        time[k] = rs.GetDateTime(1);
                        for (int j = 0; j < 8; j++)
                        {
                            // Redata[j][k] = Convert.ToSingle( rs.GetString(F2D(j) + 2));
                            Redata[j][k] = Convert.ToSingle(rs.GetString(j + 2));
                        }
                        k++;
                    }
                    rs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("��ȡ���ݳ���" + ex.Message);
                }
            }
            return true;
        }
        public static bool ReadDataBaseData(string begin, string end, ref float[][] Redata, ref DateTime[] time, ref uint total_frame,bool readAll)
        {
            int interval = 1;
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select count(*) from gas_data where  gasdate between to_date('" + begin + "','yyyymmddhh24miss') and to_date('" + end + "','yyyymmddhh24miss')";
            OracleDataReader rs = cmd.ExecuteReader();
            rs.Read();

            total_frame = (uint)rs.GetInt32(0);
            rs.Close();
            //�����ѯ���Ϊ0��˵����ʱ���ҵļ������������ҳ�һ�����ڽ�����ʾ����
            if (total_frame == 0)
            {
                cmd.CommandText = "select count(*) from gas_data where gasdate between to_date('" + begin + "','yyyymmddhh24miss') and to_date('" + end + "','yyyymmddhh24miss')";
                rs = cmd.ExecuteReader();
                rs.Read();
                total_frame = (uint)rs.GetInt32(0);
                rs.Close();
                //�����ʱ��Ϊ0����˵��ȷʵû��ֵ
                if (total_frame == 0)
                {
                    return false;
                }
                else
                {

                    //total_frame = 1;
                    cmd.CommandText = "select * from gas_data where gasdate between to_date('" + begin + "','yyyymmddhh24miss') and to_date('" + end + "','yyyymmddhh24miss') order by gasdate";
                    rs = cmd.ExecuteReader();
                    rs.Read();
                    time = new DateTime[total_frame];
                    for (int j = 0; j < 8; j++)
                    {
                        Redata[j] = new float[total_frame];
                    }
                    try
                    {
                        rs = cmd.ExecuteReader();
                        int k = 0;
                        while (rs.Read())
                        {
                            time[k] = rs.GetDateTime(1);
                            for (int j = 0; j < 8; j++)
                            {
                                // Redata[j][k] = Convert.ToSingle( rs.GetString(F2D(j) + 2));
                                Redata[j][k] = Convert.ToSingle(rs.GetString(j + 2));
                            }
                            k++;
                        }
                        rs.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("��ȡ���ݳ���" + ex.Message);
                    }
                }
            }
            else
            {

                interval = (int)total_frame / 100;
                if (interval == 0)
                    interval = 1;

                if (readAll)
                    interval = 1;
                cmd.CommandText = "select count(*) from gas_data where MOD(seqid, " + interval.ToString() + ") =0 and gasdate between to_date('" + begin + "','yyyymmddhh24miss') and to_date('" + end + "','yyyymmddhh24miss')";
                rs = cmd.ExecuteReader();
                rs.Read();

                total_frame = (uint)rs.GetInt32(0);
                rs.Close();

                for (int j = 0; j < 8; j++)
                {
                    Redata[j] = new float[total_frame];
                }
                time = new DateTime[total_frame];
                cmd.CommandText = "select * from gas_data where  MOD(seqid, " + interval.ToString() + ") =0 and  gasdate between to_date('" + begin + "','yyyymmddhh24miss') and to_date('" + end + "','yyyymmddhh24miss') order by gasdate";

                try
                {
                    rs = cmd.ExecuteReader();
                    int k = 0;
                    while (rs.Read())
                    {
                        time[k] = rs.GetDateTime(1);
                        for (int j = 0; j < 8; j++)
                        {
                            // Redata[j][k] = Convert.ToSingle( rs.GetString(F2D(j) + 2));
                            Redata[j][k] = Convert.ToSingle(rs.GetString(j + 2));
                        }
                        k++;
                    }
                    rs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("��ȡ���ݳ���" + ex.Message);
                }
            }
            return true;
        }

        bool GetReplayData(DateTime TMbegin, DateTime TMend)
        {
            if (TMbegin > TMend)
            {
                MessageBox.Show("��ʼʱ�䲻�ܴ�����ֹʱ��");
                return false;
            }

            ReadDataBaseData(TMbegin, TMend, ref replaydata, ref replaytime, ref Total_Frames);

            for (int k = 0; k < 8; k++)
            {
                if (TMbegin.Day == TMend.Day && TMbegin.Month == TMend.Month && TMbegin.Year == TMend.Year)
                    ReplayGraph[D2F(k)].Axes.Item("XAxis").FormatString = "hh:nn:ss";
                else
                    ReplayGraph[D2F(k)].Axes.Item("XAxis").FormatString = "mm/dd hh:nn:ss";
                ReplayGraph[D2F(k)].Axes.Item("XAxis").SetMinMax(TMbegin, TMend);
            }
            return true;
        }

        #endregion
       
        #endregion


   

        #region ��ʼ������
        /// <summary>
        /// ׼����������
        /// </summary>
        void PrepareSendData()
        {
            //��ʼ����������
            SendAcqCmd[0] = 1;//equiID;  //���豸��ַ
            SendAcqCmd[1] = 3;  //������
            if (!bNewEquip)
            {
                //�ɰ�ɼ�ģ���ַ
                SendAcqCmd[2] = 0x00;  //��ʼ�Ĵ�����ַ��λ
                SendAcqCmd[3] = 0x03;  //��ʼ�Ĵ�����ַ��λ
            }
            else
            {
                //�°�ģ���ַ
                SendAcqCmd[2] = 0x01;  //��ʼ�Ĵ�����ַ��λ
                SendAcqCmd[3] = 0x2c;  //��ʼ�Ĵ�����ַ��λ
            }
            SendAcqCmd[4] = 0;
            SendAcqCmd[5] = 8;


            byte[] crc = CRC16_C(SendAcqCmd,0,5);
            SendAcqCmd[6] = crc[1]; //CRC У����
            SendAcqCmd[7] = crc[0];

         
        }
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void Initport()
        {
            try
            {
                //��ʼ��SerialPort����  
                if (_port_acq == null)
                {
                    _port_acq = new SerialPort();
                }
                if(_port_comm == null)
                {
                    _port_comm = new SerialPort();
                }
              
                _port_acq.NewLine = "/r/n";
                _port_acq.RtsEnable = true;//����ʵ������ɡ� 
                _port_comm.NewLine = "/r/n";
                _port_comm.RtsEnable = true;//����ʵ������ɡ�
                //����¼�ע��      
                _port_acq.DataReceived += acq_DataReceived;
                _port_comm.DataReceived += acq_CmdReceived;
                for (int i = 0; i < ports.Length; i++)
                {
                    if (acq_port == ports[i])
                    {
                        if (_port_acq.IsOpen)
                        {
                            _port_acq.Close();
                        }
                        _port_acq.PortName = port_name[i];
                        if (port_boad[i] != "")
                        {
                            _port_acq.BaudRate = Convert.ToInt32(port_boad[i]);
                            _port_acq.DataBits = Convert.ToInt32(port_data[i]);
                            if (port_jiaoyan[i] == "��")
                            {
                                _port_acq.Parity = Parity.None;
                            }
                            else if (port_jiaoyan[i] == "��У��")
                            {
                                _port_acq.Parity = Parity.Odd;
                            }
                            else if (port_jiaoyan[i] == "żУ��")
                            {
                                _port_acq.Parity = Parity.Even;
                            }
                            if (port_stop[i] == "1")
                            {
                                _port_acq.StopBits = StopBits.One;
                            }
                            else if (port_stop[i] == "1.5")
                            {
                                _port_acq.StopBits = StopBits.OnePointFive;
                            }
                            else if (port_stop[i] == "2")
                            {
                                _port_acq.StopBits = StopBits.Two;
                            }
                            else if (port_stop[i] == "0")
                            {
                                _port_acq.StopBits = StopBits.None;
                            }
                        }
                        else
                        {
                            _port_acq.StopBits = StopBits.One;
                            _port_acq.BaudRate = 9600;
                            _port_acq.DataBits = 8;
                            _port_acq.Parity = Parity.None;
                        }
                        if (!_port_acq.IsOpen)
                        {
                            _port_acq.Open();
                        }
                    }

                    if (comm_port == ports[i])
                    {
                        if (_port_comm.IsOpen)
                        {
                            _port_comm.Close();
                        }
                        _port_comm.PortName = port_name[i];
                        if (port_boad[i] != "")
                        {
                            _port_comm.BaudRate = Convert.ToInt32(port_boad[i]);
                            _port_comm.DataBits = Convert.ToInt32(port_data[i]);
                            if (port_jiaoyan[i] == "��")
                            {
                                _port_comm.Parity = Parity.None;
                            }
                            else if (port_jiaoyan[i] == "��У��")
                            {
                                _port_comm.Parity = Parity.Odd;
                            }
                            else if (port_jiaoyan[i] == "żУ��")
                            {
                                _port_comm.Parity = Parity.Even;
                            }
                            if (port_stop[i] == "1")
                            {
                                _port_comm.StopBits = StopBits.One;
                            }
                            else if (port_stop[i] == "1.5")
                            {
                                _port_comm.StopBits = StopBits.OnePointFive;
                            }
                            else if (port_stop[i] == "2")
                            {
                                _port_comm.StopBits = StopBits.Two;
                            }
                            else if (port_stop[i] == "0")
                            {
                                _port_comm.StopBits = StopBits.None;
                            }
                        }
                        else
                        {
                            _port_comm.StopBits = StopBits.One;
                            _port_comm.BaudRate = 9600;
                            _port_comm.DataBits = 8;
                            _port_comm.Parity = Parity.None;
                        }
                        if (!_port_comm.IsOpen)
                        {
                            _port_comm.Open();
                        }
                    }

                   
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show("���ڴ򿪳���" +ex.Message);
            }

        }

        /// <summary>
        /// ������ؼ�ͳһ����
        /// </summary>
        void InitForm()
        {
          
            #region �Կؼ�ͳһ����

            ProgressBarValue[0] = tank0;
            ProgressBarValue[1] = tank1;
            ProgressBarValue[2] = tank2;
            ProgressBarValue[3] = tank3;
            ProgressBarValue[4] = tank4;
            ProgressBarValue[5] = tank5;
            ProgressBarValue[6] = tank6;
            ProgressBarValue[7] = tank7;
            ProgressBarValue[8] = tank8;
            ProgressBarValue[9] = tank9;
            ProgressBarValue[10] = tank10;
            ProgressBarValue[11] = tank11;
            ProgressBarValue[12] = tank12;
            ProgressBarValue[13] = tank13;
            ProgressBarValue[14] = tank14;
            ProgressBarValue[15] = tank15;

            ReplayGraph[0] = _Rpgraph0;
            ReplayGraph[1] = _Rpgraph1;
            ReplayGraph[2] = _Rpgraph2;
            ReplayGraph[3] = _Rpgraph3;
            ReplayGraph[4] = _Rpgraph4;
            ReplayGraph[5] = _Rpgraph5;
            ReplayGraph[6] = _Rpgraph6;
            ReplayGraph[7] = _Rpgraph7;

            Replaytextbox[0] = _txt_replay0;
            Replaytextbox[1] = _txt_replay1;
            Replaytextbox[2] = _txt_replay2;
            Replaytextbox[3] = _txt_replay3;
            Replaytextbox[4] = _txt_replay4;
            Replaytextbox[5] = _txt_replay5;
            Replaytextbox[6] = _txt_replay6;
            Replaytextbox[7] = _txt_replay7;

            Replaylabel[0] = _lbl_replay0;
            Replaylabel[1] = _lbl_replay1;
            Replaylabel[2] = _lbl_replay2;
            Replaylabel[3] = _lbl_replay3;
            Replaylabel[4] = _lbl_replay4;
            Replaylabel[5] = _lbl_replay5;
            Replaylabel[6] = _lbl_replay6;
            Replaylabel[7] = _lbl_replay7;

            Acqtextbox[0] = _txt_acq0;
            Acqtextbox[1] = _txt_acq1;
            Acqtextbox[2] = _txt_acq2;
            Acqtextbox[3] = _txt_acq3;
            Acqtextbox[4] = _txt_acq4;
            Acqtextbox[5] = _txt_acq5;
            Acqtextbox[6] = _txt_acq6;
            Acqtextbox[7] = _txt_acq7;

            AcqtextboxN[0] = _txt_acqN0;
            AcqtextboxN[1] = _txt_acqN1;
            AcqtextboxN[2] = _txt_acqN2;
            AcqtextboxN[3] = _txt_acqN3;
            AcqtextboxN[4] = _txt_acqN4;
            AcqtextboxN[5] = _txt_acqN5;
            AcqtextboxN[6] = _txt_acqN6;
            AcqtextboxN[7] = _txt_acqN7;

            Acqlabel[0] = _lbl_acq0;
            Acqlabel[1] = _lbl_acq1;
            Acqlabel[2] = _lbl_acq2;
            Acqlabel[3] = _lbl_acq3;
            Acqlabel[4] = _lbl_acq4;
            Acqlabel[5] = _lbl_acq5;
            Acqlabel[6] = _lbl_acq6;
            Acqlabel[7] = _lbl_acq7;

            Unitbabel[0] = _lbl_unit0;
            Unitbabel[1] = _lbl_unit1;
            Unitbabel[2] = _lbl_unit2;
            Unitbabel[3] = _lbl_unit3;
            Unitbabel[4] = _lbl_unit4;
            Unitbabel[5] = _lbl_unit5;
            Unitbabel[6] = _lbl_unit6;
            Unitbabel[7] = _lbl_unit7;
            Unitbabel[8] = _lbl_unitN0;
            Unitbabel[9] = _lbl_unitN1;
            Unitbabel[10] = _lbl_unitN2;
            Unitbabel[11] = _lbl_unitN3;
            Unitbabel[12] = _lbl_unitN4;
            Unitbabel[13] = _lbl_unitN5;
            Unitbabel[14] = _lbl_unitN6;
            Unitbabel[15] = _lbl_unitN7;

            ZheSuan[0] = _lbl_zhesuan0;
            ZheSuan[1] = _lbl_zhesuan1;
            ZheSuan[2] = _lbl_zhesuan2;
            ZheSuan[3] = _lbl_zhesuan3;
            ZheSuan[4] = _lbl_zhesuan4;
            ZheSuan[5] = _lbl_zhesuan5;
            ZheSuan[6] = _lbl_zhesuan6;
            ZheSuan[7] = _lbl_zhesuan7;
            #endregion

            InitConfig();
            _btn_formerstep.Enabled = false;
            _btn_init.Enabled = false;
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void SaveCfg()
        {
            iniclass.IniWriteValue("config", "gasname", gasname);
            iniclass.IniWriteValue("config", "gasid", gasid);
            iniclass.IniWriteValue("config", "acqport", acq_port);
            iniclass.IniWriteValue("config", "commport", comm_port);
            iniclass.IniWriteValue("config", "acq_freq", acq_freq.ToString());
            iniclass.IniWriteValue("config", "O2", O2.ToString("f2"));
            iniclass.IniWriteValue("config", "M2", M2.ToString("f2"));
            iniclass.IniWriteValue("config", "Xsw", Xsw.ToString("f2"));
            iniclass.IniWriteValue("config", "title", title);
            
            if (bShowZS)
            {
                iniclass.IniWriteValue("config", "zhesuan", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "zhesuan", "false");
            }
            iniclass.IniWriteValue("config", "QswXishu", QswXishu.ToString("f2"));
           
           
            for (int i = 0; i < ports.Length; i++)
            {
                iniclass.IniWriteValue("config", "port_name" + i.ToString(), port_name[i].ToString());
                iniclass.IniWriteValue("config", "port_boad" + i.ToString(), port_boad[i].ToString());
                iniclass.IniWriteValue("config", "port_data" + i.ToString(), port_data[i].ToString());
                iniclass.IniWriteValue("config", "port_jiaoyan" + i.ToString(), port_jiaoyan[i].ToString());
                iniclass.IniWriteValue("config", "port_stop" + i.ToString(), port_stop[i].ToString());
            }
            
            for (int i = 0; i < 8; i++)
            {
                iniclass.IniWriteValue("config", "jiaozheng_k" + i.ToString(), initjiaozheng_k[i].ToString("f2"));
                iniclass.IniWriteValue("config", "jiaozheng_b" + i.ToString(), initjiaozheng_b[i].ToString("f2"));
            }
            if (bShuCaiYi)
            {
                iniclass.IniWriteValue("config", "shucaiyi", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "shucaiyi", "false");
            }
            if (bNew232Version)
            {
                iniclass.IniWriteValue("config", "232newVersion", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "232newVersion", "false");
            }

            if (bNewEquip)
            {
                iniclass.IniWriteValue("config", "newVersion", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "newVersion", "false");
            }
            if (bRtdData)
            {
                iniclass.IniWriteValue("config", "bRtdData", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "bRtdData", "false");
            }
            if (bRtdGraph)
            {
                iniclass.IniWriteValue("config", "bRtdGraph", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "bRtdGraph", "false");
            }
            if (bMinuteData)
            {
                iniclass.IniWriteValue("config", "bMinuteData", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "bMinuteData", "false");

            }
            if (bMinuteGraph)
            {
                iniclass.IniWriteValue("config", "bMinuteGraph", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "bMinuteGraph", "false");
            }
            if (bUpLoadTotal)
            {
                iniclass.IniWriteValue("config", "bUpLoadTotal", "true");
            }
            else
            {
                iniclass.IniWriteValue("config", "bUpLoadTotal", "false");
            }
            
            iniclass.IniWriteValue("config", "mn",mn);
            iniclass.IniWriteValue("config", "password", password);
            iniclass.IniWriteValue("config", "uptime", uptime);
            try
            {
                OracleCommand cmd = Form1.conn.CreateCommand();

                for (int i = 0; i < 8; i++)
                {
                    cmd.CommandText = "UPDATE form_index SET formindex = " + Form_index[i] + " WHERE seqid = " + i.ToString();    //SQL���
                    OracleDataReader rs = cmd.ExecuteReader();
                    rs.Close();
                    cmd.CommandText = "UPDATE gas_type SET val_k = " + Form1.val_k[i]
                                        + ",val_b=" + Form1.val_b[i]
                                        + ",calmax=" + Form1.Calmax[i]
                                        + ",calmin=" + Form1.Calmin[i] + " WHERE form_index = " + Form_index[i];
                    rs = cmd.ExecuteReader();
                    rs.Close();
                }

                //InitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ʧ�ܣ�����δ���� " + ex.Message);
            }
            for (int i = 0; i < 8; i++)
            {
                configObj.setValue("boutput"+i.ToString(), boutput[i], ConfigType.boolType);
                configObj.setValue("outputk"+i.ToString(), outputk[i], ConfigType.doubleType);
                configObj.setValue("outputb" + i.ToString(), outputb[i], ConfigType.doubleType);
            }
            configObj.setValue("ao_port" , ao_port, ConfigType.stringType);
            configObj.setValue("bUpLoadZS", bCalZS, ConfigType.boolType);
            configObj.setValue("bSaveLogFile", bSaveLogFile, ConfigType.boolType);
            configObj.setValue("biaogan",showbiaogan,ConfigType.boolType);
            configObj.setValue("gongkuang", showGongK, ConfigType.boolType);

            configObj.setValue("ptgXS",ptgXS, ConfigType.stringType);
            configObj.setValue("suduXS",suduXS, ConfigType.stringType);
            configObj.setValue("yaliXS", yaliXS,ConfigType.stringType);
            configObj.setValue("kqXS",kqXS, ConfigType.stringType);
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        private void ReadConfig()
        {
            skinPath = iniclass.IniReadValue("config", "skin");
            gasname = iniclass.IniReadValue("config", "gasname");
            gasid = iniclass.IniReadValue("config", "gasid");
            acq_port = iniclass.IniReadValue("config", "acqport");
            comm_port = iniclass.IniReadValue("config", "commport");
            title = iniclass.IniReadValue("config", "title");
                  
            if (iniclass.IniReadValue("config", "newVersion")=="true")
            {
                bNewEquip = true;
            }
            else
            {
                bNewEquip = false;
            }
            if (!string.IsNullOrEmpty(iniclass.IniReadValue("config", "acq_freq")))
            {
                acq_freq = Convert.ToInt32(iniclass.IniReadValue("config", "acq_freq"));
            }
            else
            {
                acq_freq = 5;
            }
            if (!string.IsNullOrEmpty(iniclass.IniReadValue("config", "O2")))
            {
                O2 = Convert.ToDouble(iniclass.IniReadValue("config", "O2"));
            }
            else
            {
                O2 = 0;
            }
            if (!string.IsNullOrEmpty(iniclass.IniReadValue("config", "M2")))
            {
                M2 = Convert.ToDouble(iniclass.IniReadValue("config", "M2"));
            }
            else
            {
                M2 = 0;
            }
            if (!string.IsNullOrEmpty(iniclass.IniReadValue("config", "Xsw")))
            {
                Xsw = Convert.ToDouble(iniclass.IniReadValue("config", "Xsw"));
            }
            else
            {
                Xsw = 0;
            }
            for (int i = 0; i < ports.Length; i++)
            {
                port_name[i] = ports[i];
                if (iniclass.IniReadValue("config", "port_data" + i.ToString()) != "")
                {
                    port_data[i] = iniclass.IniReadValue("config", "port_data" + i.ToString());
                }
                else
                {
                    port_data[i] = "8";
                }
                if (iniclass.IniReadValue("config", "port_boad" + i.ToString()) != "")
                {
                    port_boad[i] = iniclass.IniReadValue("config", "port_boad" + i.ToString());
                }
                else
                {
                    port_boad[i] = "9600";
                }
                if (iniclass.IniReadValue("config", "port_jiaoyan" + i.ToString()) != "")
                {
                    port_jiaoyan[i] = iniclass.IniReadValue("config", "port_jiaoyan" + i.ToString());
                }
                else
                {
                    port_jiaoyan[i] = "��";
                }
                if (iniclass.IniReadValue("config", "port_stop" + i.ToString()) != "")
                {
                    port_stop[i] = iniclass.IniReadValue("config", "port_stop" + i.ToString());
                }
                else
                {
                    port_stop[i] = "1";
                }
            }
            for (int i = 0; i < 8; i++)
            {
                initjiaozheng_k[i] = Convert.ToDouble(iniclass.IniReadValue("config", "jiaozheng_k" + i.ToString()));
                initjiaozheng_b[i] = Convert.ToDouble(iniclass.IniReadValue("config", "jiaozheng_b" + i.ToString()));
                simuAcq[i] = Convert.ToDouble(iniclass.IniReadValue("config", "ͨ��" + (i + 1).ToString() + "ģ���������"));
            }
            notsure = iniclass.IniReadValue("config", "notsure");
            if (iniclass.IniReadValue("config", "zhesuan") == "true")
                bShowZS = true;
            else
                bShowZS = false;
            try
            {
                Form1.QswXishu = Convert.ToDouble(iniclass.IniReadValue("config", "QswXishu"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
            if (iniclass.IniReadValue("config", "shucaiyi") == "true")
            {
                bShuCaiYi = true;
            }
            else
            {
                bShuCaiYi = false;
            }
            if (iniclass.IniReadValue("config", "232newVersion") == "true")
            {
                bNew232Version = true;
            }
            else
            {
                bNew232Version = false;
            }
            if (iniclass.IniReadValue("config", "bSimulator") == "true")
            {
                bSimulator = true;
            }
            else
            {
                bSimulator = false;
            }
            if (iniclass.IniReadValue("config", "bRtdData") == "true")
            {
                bRtdData = true;
            }
            else
            {
                bRtdData = false;
            }
            if (iniclass.IniReadValue("config", "bRtdGraph") == "true")
            {
                bRtdGraph = true;
            }
            else
            {
                bRtdGraph = false;
            }
            if (iniclass.IniReadValue("config", "bMinuteData") == "true")
            {
                bMinuteData = true;
            }
            else
            {
                bMinuteData = false;
            }
            if (iniclass.IniReadValue("config", "bMinuteGraph") == "true")
            {
                bMinuteGraph = true;
            }
            else
            {
                bMinuteGraph = false;
            }
            if (iniclass.IniReadValue("config", "bUpLoadTotal") == "true")
            {
                bUpLoadTotal = true;
            }
            else
            {
                bUpLoadTotal = false;
            }
            mn = iniclass.IniReadValue("config", "mn");
            password = iniclass.IniReadValue("config", "password");
            uptime = iniclass.IniReadValue("config", "uptime");

            for (int i = 0; i < 8; i++)
            {
                boutput[i] = (bool)configObj.getValue("boutput" + i.ToString(), ConfigType.boolType);
                outputk[i] = (double)configObj.getValue("outputk" + i.ToString(), ConfigType.doubleType);
                outputb[i] = (double)configObj.getValue("outputb" + i.ToString(), ConfigType.doubleType);
            }
            ao_port = (string)configObj.getValue("ao_port" , ConfigType.stringType);
            bCalZS = (bool)configObj.getValue("bUpLoadZS", ConfigType.boolType);
            bSaveLogFile = (bool)configObj.getValue("bSaveLogFile", ConfigType.boolType);
            showGongK = (bool)configObj.getValue("gongkuang", ConfigType.boolType);
            showbiaogan = (bool)configObj.getValue("biaogan",ConfigType.boolType);
            ptgXS = (string)configObj.getValue("ptgXS", ConfigType.stringType);
            suduXS = (string)configObj.getValue("suduXS", ConfigType.stringType);
            yaliXS = (string)configObj.getValue("yaliXS", ConfigType.stringType);
            kqXS = (string)configObj.getValue("kqXS", ConfigType.stringType);
        }

        public static void InitDataBase()
        {
            #region ��ʼ�����ݿ�
            string ConnectionString = "Data Source=orcl; User Id=gas; Password=gas";  //�����ַ���
            conn = new OracleConnection(ConnectionString);    //����һ��������

            try
            {
                conn.Open();    //������

                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandText = "select * from form_index";    //SQL���
                OracleDataReader rs = cmd.ExecuteReader();
                Form_index = "";
                while (rs.Read())    //��ȡ���ݣ����rs.Read()����Ϊfalse�Ļ�����˵������¼����β����
                {
                    Form_index += rs.GetInt32(1).ToString();

                }
                rs.Close();
                cmd.CommandText = "select * from GAS_TYPE";    //SQL���
                rs = cmd.ExecuteReader();
                int i = 0;




                while (rs.Read() && i < 8)    //��ȡ���ݣ����rs.Read()����Ϊfalse�Ļ�����˵������¼����β����
                {
                    initname[i] = rs.GetString(1);
                    initunit[i] = rs.GetString(2);
                    initk[i] = rs.GetString(3);
                    initb[i] = rs.GetString(4);
                    initcalmax[i] = rs.GetString(5);
                    initcalmin[i] = rs.GetString(6);
                    
                    if (initunit[i] == "Pa")
                    {
                        initunit[i] = "KPa";
                    }
                    i++;
                }
                rs.Close();
                for (i = 0; i < 8; i++)
                {
                    int t = D2F(i);
                    val_name[i] = initname[t];
                    val_unit[i] = initunit[t];
                    val_k[i] = Convert.ToDouble(initk[t]);
                    val_b[i] = Convert.ToDouble(initb[t]);
                    Calmax[i] = Convert.ToDouble(initcalmax[t]);
                    Calmin[i] = Convert.ToDouble(initcalmin[t]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            #endregion
        }
        /// <summary>
        /// �������ó�ʼ������
        /// </summary>
        void InitConfig()
        {

            for (int i = 0; i < 8; i++)
            {
                Acqlabel[i].Text = val_name[i];
                ZheSuan[i].Text = val_name[i] + "����";
                Replaylabel[i].Text = val_name[i];
                Unitbabel[i].Text = "(" + val_unit[i] + ")";
                Unitbabel[i + 8].Text = "(" + val_unit[i] + ")";
                if (GetGasType(i) == GasType.QiYa)
                {
                    ProgressBarValue[i].Range = new NationalInstruments.UI.Range(Calmin[i] / 1000 - 101, Calmax[i] / 1000 - 101);
                    ProgressBarValue[i + 8].Range = new NationalInstruments.UI.Range(Calmin[i] / 1000 - 101, Calmax[i] / 1000 - 101);
                }
                else
                {
                    ProgressBarValue[i].Range = new NationalInstruments.UI.Range(Calmin[i], Calmax[i]);
                    ProgressBarValue[i + 8].Range = new NationalInstruments.UI.Range(Calmin[i], Calmax[i]);
                }           
            }
            _timer.Interval = acq_freq * 1000;
            this.Text = title;
            
        }
        
        #endregion
     
        #region �ַ�������
        /// <summary>
        /// database to form
        /// </summary>
        /// <param name="d">���ݿ������</param>
        /// <returns>�������</returns>
        public static int D2F(int d)
        {
            return Convert.ToInt32(Form_index[d].ToString(), 10);
        }
        /// <summary>
        /// form to database
        /// </summary>
        /// <param name="f">�������</param>
        /// <returns>���ݿ������</returns>
        public static int F2D(int f)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    if (f == Convert.ToInt32(Form_index[i].ToString(), 10))
                        return i;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            return 0;
            
        }
        /// <summary>
        /// ��4-20mA��ת��Ϊʵ�ʵ�ֵ
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private void ChangeValueByCoeff(ref float[] val)
        {
            int liuSuIndex = 0;
            for (int i = 0; i < val.Length; i++)
            {
                val[i] = val[i] * (float)val_k[i] + (float)val_b[i];
                if (GetGasType(i) == GasType.LiuSu)
                {
                    val[i] *= (float)M2;
                    liuSuIndex = i;
                }
                int t = (int)GetGasType(i);
                val[i] = val[i] * (float)initjiaozheng_k[t] + (float)initjiaozheng_b[t];
                
                //ֵ����Ϊ����
                if (val[i] < 0)
                {
                    val[i] = 0;
                }
            }
            //�����һ��ͨ����ֵ��Ϊ�����ʹ��
            float qiya = val[F2D(5)];
            float wendu = val[F2D(6)];
            //�����ĵ�λ��m/s
            val[F2D(7)] = ((float)QswXishu * AcqData[liuSuIndex] * 273 * (qiya) * (1 - (float)Form1.Xsw) / ((273 + wendu) * 101325));

        }

        /// <summary>
        /// ����ʵ��ֵ�������ֵ
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private float[] GetNValue(float[] val)
        {
            float[] NValue = new float[8];
            //�����������ֵ�������
            if (bCalZS)
            {
                //����ʵ��ֵ
                float o2 = 0; 
                double s = O2 + M2 + Xsw;
                if (Math.Abs(s) < 0.000001)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        o2 = val[i];
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (Form_index[i].ToString() == "4")
                    {
                        o2 = val[i];
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (Form_index[i].ToString() == "1" || Form_index[i].ToString() == "2" || Form_index[i].ToString() == "3")
                    {
                        NValue[i] = (float)(val[i] * (21.0 - O2) / (21.0 - o2));
                        if (NValue[i] < 0)
                        {
                            NValue[i] = 0;
                        }
                    }
                    else
                    {
                        NValue[i] = val[i];
                    }
                }
            }
            //��������ֵ����ʵ��ֵ
            else
            {
                for (int i = 0; i < val.Length; i++)
                {
                    NValue[i] = val[i];
                }
            }
            return NValue;
        }

        /// <summary>
        /// ���ɼ�����32������ת��Ϊ8��float������
        /// </summary>
        /// <param name="recvdata"></param>
        /// <returns></returns>
        void GetValueFromBytes(byte[] recvdata,ref float[] reValue)
        {
            //�°�Ĵ�����ȷ��0.001ma������Ϊ1000���ϰ�Ϊ100
            int n = 100;
            if (bNewEquip)
            {
                n = 1000;
            }
            for (int i = 0; i < 8; i++)
            {
                reValue[i] = (float)(recvdata[3 + 2 * i] << 8 | recvdata[3 + 2 * i + 1]) / n;
            }
        }
     
        /// <summary>
        /// ��CRC16λУ�飬�����modbusЭ��Ļ���Ӧ���ǵ�һλ�ǵ�λ���ڶ�λ�Ǹ�λ
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public byte[] CRC16_C(byte[] data,int start,int end)
        {
            byte CRC16Lo;
            byte CRC16Hi;   //CRC�Ĵ���    
            byte CL; byte CH;       //����ʽ��&HA001     
            byte SaveHi;
            byte SaveLo;
            byte[] tmpData = new byte[end-start+1];
            int Flag; CRC16Lo = 0xFF; CRC16Hi = 0xFF; CL = 0x01; CH = 0xA0;
            Array.Copy(data, start, tmpData, 0, tmpData.Length);
  
            for (int i = 0; i < tmpData.Length; i++)
            {
                CRC16Lo = (byte)(CRC16Lo ^ tmpData[i]); //ÿһ��������CRC�Ĵ����������          
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = (byte)(CRC16Hi >> 1);      //��λ����һλ           
                    CRC16Lo = (byte)(CRC16Lo >> 1);      //��λ����һλ   
                    if ((SaveHi & 0x01) == 0x01) //�����λ�ֽ����һλΪ1      
                    {
                        CRC16Lo = (byte)(CRC16Lo | 0x80);   //���λ�ֽ����ƺ�ǰ�油1   
                    }             //�����Զ���0             
                    if ((SaveLo & 0x01) == 0x01) //���LSBΪ1���������ʽ��������     
                    {
                        CRC16Hi = (byte)(CRC16Hi ^ CH);
                        CRC16Lo = (byte)(CRC16Lo ^ CL);
                    }
                }
            }
            byte[] ReturnData = new byte[2];
            ReturnData[0] = CRC16Hi;       //CRC��λ         
            ReturnData[1] = CRC16Lo;       //CRC��λ     
            return ReturnData;
        }
        
        /// <summary>
        /// ��õ�ǰʱ���ַ���
        /// </summary>
        /// <returns></returns>
        public static String GetTimeString(DateTime t,string format)
        {
            int Year = t.Year;
            int Month = t.Month;
            int Day = t.Day;
            int Hour = t.Hour;
            int Minute = t.Minute;
            int Second = t.Second;
            if (format == "f")
            {
                string date = Year.ToString("d4") + Month.ToString("d2") + Day.ToString("d2") +
                              Hour.ToString("d2") + Minute.ToString("d2") + Second.ToString("d2");
                return date;
            }
            else if (format == "mi")
            {
                string date = Year.ToString("d4") + Month.ToString("d2") + Day.ToString("d2") + Hour.ToString("d2") + Minute.ToString("d2");
                return date;
            }
            else if (format == "h")
            {
                string date = Year.ToString("d4") + Month.ToString("d2") + Day.ToString("d2") +Hour.ToString("d2");
                return date;
            }
            else if (format == "d")
            {
                string date = Year.ToString("d4") + Month.ToString("d2") + Day.ToString("d2") ;
                return date;
            }
            else if (format == "m")
            {
                string date = Year.ToString("d4") + Month.ToString("d2") ;
                return date;
            }
            else if (format == "y")
            {
                string date = Year.ToString("d4");
                return date;
            }
            else
            {
                string date = Year.ToString("d4") + Month.ToString("d2") + Day.ToString("d2") +
                                             Hour.ToString("d2") + Minute.ToString("d2") + Second.ToString("d2");
                return date;
            }
        }
   
        #endregion



        float[][] replaydata = new float[8][]; //������ѡ��������֡��ֵ
        DateTime[] replaytime;

      /// <summary>
      /// ������ͼ
      /// </summary>
        private void plot()
        {
            for (int i = 0; i < 8; i++)
            {
                ReplayGraph[i].ClearData();
            }
            for (int i = 0; i < 8; i++)
            {
                int k = D2F(i);

                if (k == 0)
                {
                    for (int j = 0; j < Total_Frames; j++)
                    {
                        ReplayGraph[i].ChartXvsY(replaytime[j], replaydata[k][j]/(float)M2);
                    }
                }
                else if (k == 5)
                {
                    for (int j = 0; j < Total_Frames; j++)
                    {
                        ReplayGraph[i].ChartXvsY(replaytime[j], replaydata[k][j] / 1000 -101);
                    }
                }
                else
                {
                    for (int j = 0; j < Total_Frames; j++)
                    {
                        ReplayGraph[i].ChartXvsY(replaytime[j], replaydata[k][j]);
                    }
                }

                //Replaytextbox[k].Text = replaydata[i][currentPlayFrame].ToString("f2");

            }
        }

    
        #region ���ú���Ӧ�طŵĲ�����ʾ�ؼ���״̬
        /// <summary>
        /// ˫���κ�һ�����οؼ����������긴λ�����״̬��
        /// x��Χ��[0, ��֡�� -1]��y��Χ��[��ʼ��Сֵ����ʼ���ֵ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Rpgraph0_DblClick(object sender, EventArgs e)
        {
            for (int i = 0; i < REPLAYWAVECOUNT; ++i)
            {
                ReplayGraph[i].Axes.Item("XAxis").SetMinMax(former_X_min[0], former_X_max[0]);
            }
        }

        /// <summary>
        /// ��¼���οؼ�x������֮��ķ�Χ���ڻ�ԭ���귶Χ��ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Rpgraph0_MouseUpEvent(object sender,
            _DCWGraphEvents_MouseUpEvent e)
        {
            if (bZooming)
            {
                AxCWGraph graph = (AxCWGraph)sender;
                ////����������һ�����Σ����еĲ��οؼ�X�ᶼ���ŵ�ͬ���ķ�Χ
                DateTime min = DateTime.FromOADate((double)graph.Axes.Item("XAxis").Minimum);
                DateTime max = DateTime.FromOADate((double)graph.Axes.Item("XAxis").Maximum);


                if (!GetReplayData(min, max))
                    return;
                for (int i = 0; i < REPLAYWAVECOUNT; ++i)
                {
                    ReplayGraph[i].Axes.Item("XAxis").SetMinMax(min, max);
                    min_XAxis = min;
                    max_XAxis = max;
                }
                if (Total_Frames > 0)
                {
                    plot();
                }
                if (scaleCount < 10)
                {
                    scaleCount++;
                    former_X_min[scaleCount] = min;
                    former_X_max[scaleCount] = max;
                }
                else
                {
                    for (int j = 0; j < 9; ++j)
                    {
                        former_X_min[j] = former_X_min[j + 1];
                        former_X_max[j] = former_X_max[j + 1];
                    }
                    former_X_max[9] = DateTime.FromOADate((double)graph.Axes.Item("XAxis").Maximum);
                    former_X_min[9] = DateTime.FromOADate((double)graph.Axes.Item("XAxis").Minimum);
                }
                _btn_formerstep.Enabled = true;
                _btn_init.Enabled = true;
            }
        }
        /// <summary>
        /// ��Ӧ���οؼ�������ƶ��¼�������в��λ��ƣ����������λ�õ�֡�Լ���֡
        /// ��Ӧ�Ĳ���ֵ��ʾ��Annotation�С�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Rpgraph0_MouseMoveEvent(object sender,
            _DCWGraphEvents_MouseMoveEvent e)
        {
            //�ı䵱ǰ��꣬����ģʽTrackMode��ͬ����
            System.Windows.Forms.Cursor.Current = CurrentCursor;
            AxCWGraph graph = (AxCWGraph)sender;
            PointF p = ClientToPlotArea(graph, new Point(e.x, e.y));
            //�������ڵ�ǰ��ͼ����ʾ��������ʾ�����������ʾ
            if (p.X != 0 && p.Y != 0)
            {
                graph.Annotations.Item("Annotation-1").Caption.Text = "(" + DateTime.FromOADate(p.X).ToString() +
               "�� " + p.Y.ToString("f2") + ")";
                //graph.Annotations.Item("Annotation-1").Caption.XCoordinate = p.X;
                //graph.Annotations.Item("Annotation-1").Caption.YCoordinate = p.Y;
                //

                graph.Annotations.Item("Annotation-1").CoordinateType =
                    CWUIControlsLib.CWCoordinateTypes.cwScreenCoordinates;
                graph.Annotations.Item("Annotation-1").Caption.XCoordinate = 220;
                graph.Annotations.Item("Annotation-1").Caption.YCoordinate = 20;
                graph.Annotations.Item("Annotation-1").Caption.Color = 0x0000FF;
            }
            else
            {
                graph.Annotations.Item("Annotation-1").Caption.Text = "";
            }
        }



        /// <summary>
        /// ��Ӧ�����϶��¼������Կ��Ʋ��������ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_Pan_Click(object sender, EventArgs e)
        {
            if (!bPanning)
            {
                if (bZooming)
                {
                    _btn_zoom_Click(null, null);
                }
                //��ɫ
                _btn_Pan.BackColor = Color.Chocolate;

                CurrentCursor = Cursors.Hand;
      
                for (int i = 0; i < REPLAYWAVECOUNT; i++)
                {
                    ReplayGraph[i].TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackPanPlotAreaX;
                    //ʮ�ֹ��ɼ�
                    ReplayGraph[i].Cursors.Item("Cursor-2").Visible = false;
                }
            }
            else
            {
                _btn_Pan.BackColor = Color.White;
                CurrentCursor = Cursors.Arrow;
                for (int i = 0; i < REPLAYWAVECOUNT; i++)
                {
                    ReplayGraph[i].TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackDragCursor;
                    //ʮ�ֹ��ɼ�
                    ReplayGraph[i].Cursors.Item("Cursor-2").Visible = false;
                }
            }
            bPanning = !bPanning;
        }

        private void _btn_zoom_Click(object sender, EventArgs e)
        {
            if (!bZooming)
            {
                if (bPanning)
                {
                    _btn_Pan_Click(null, null);
                }
                _btn_zoom.BackColor = Color.Chocolate;
                //���
                CurrentCursor = Cursors.VSplit;
       
                for (int i = 0; i < REPLAYWAVECOUNT; i++)
                {
                    ReplayGraph[i].TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackZoomRectX;
                    //ʮ�ֹ�겻�ɼ�
                    ReplayGraph[i].Cursors.Item("Cursor-2").Visible = false;
                }
            }
            else
            {
                _btn_zoom.BackColor = Color.White;
                CurrentCursor = Cursors.Arrow;
                for (int i = 0; i < REPLAYWAVECOUNT; i++)
                {
                    ReplayGraph[i].TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackDragCursor;
                    //ʮ�ֹ��ɼ�
                    ReplayGraph[i].Cursors.Item("Cursor-2").Visible = false;
                }
            
            }
            bZooming = !bZooming;
        }
        /// <summary>
        /// �����οؼ��ϵĵ�����ת��Ϊ����ڻ�ͼ����ĵ�����
        /// </summary>
        /// <param name="graph">��ת���ĵ����ڵĲ��οؼ�</param>
        /// <param name="point">����ڲ��οؼ��ĵ�����</param>
        /// <returns>ת����ĵ�����</returns>
        private PointF ClientToPlotArea(AxCWUIControlsLib.AxCWGraph graph, Point point)
        {
            try
            {
                int left = 0;
                int top = 0;
                int width = 0;
                int height = 0;
                int x = 0;
                int y = 0;
                graph.GetPlotAreaBounds(ref left, ref top, ref width, ref height);
                Rectangle clientRect = graph.ClientRectangle;
                PointF p = new PointF();
                //x����left����
                x = point.X - left;
                //y��ת + ����
                y = -point.Y + top + height;

                if (x < 0 || y < 0 || x > width || y > height)
                {
                    x = 0;
                    y = 0;
                    p.X = (float)x;
                    p.Y = (float)y;
                    return p;
                }
                else
                {
                    double max_x = (double)(graph.Axes.Item("XAxis").Maximum);
                    double min_x = (double)(graph.Axes.Item("XAxis").Minimum);
                    double max_y = (double)(graph.Axes.Item("YAxis-1").Maximum);
                    double min_y = (double)(graph.Axes.Item("YAxis-1").Minimum);
                    p.X = ((float)x / (float)width * (float)(max_x - min_x)) + (float)min_x;
                    p.Y = ((float)y / (float)height * (float)(max_y - min_y)) + (float)min_y;
                    return p;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ת��ʧ�ܣ�ԭ��" + ex.Message);
                return new PointF(0, 0);
            }
        }


        /// <summary>
        /// ������һ����x������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviousStep(object sender, EventArgs e)
        {
            //����Ҫ�󣬵�һ�������Ų������ڶ�����ǰû�лص�����ǰ��״̬

            if (scaleCount > 0)
            {
                scaleCount--;
                min_XAxis = former_X_min[scaleCount];
                max_XAxis = former_X_max[scaleCount];


                if (!GetReplayData(min_XAxis, max_XAxis))
                    return;
                for (int i = 0; i < REPLAYWAVECOUNT; ++i)
                {
                    ReplayGraph[i].Axes.Item("XAxis").SetMinMax(min_XAxis, max_XAxis);
                }
                if (Total_Frames > 0)
                {
                    plot();
                }
            }
            if (scaleCount == 0)
            {
                _btn_formerstep.Enabled = false;
                _btn_init.Enabled = false;
            }
        }

        /// <summary>
        /// ��Ӧ�ɼ�����������Y�᷶Χ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btn_setAcqYRange_Click(object sender, EventArgs e)
        {
            //new SetYRange(true).Show();
        }

        /// <summary>
        /// ���ûطŲ��ε�Y�᷶Χ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSetReplayYRange(object sender, EventArgs e)
        {
            //����Ѿ�ѡ���˻طŲ��������������Y�᷶Χ��ûѡҲ����
            //new SetYRange(false).Show();
        }

        /// <summary>
        /// Զ��ģʽ�½���Y����������
        /// </summary>
        /// <param name="ranges"></param>
        private void SetYRangebyControl(byte[] ranges)
        {
            try
            {
                double[] detail = new double[12];
                for (int i = 0; i < detail.Length; ++i)
                {
                    detail[i] = BitConverter.ToDouble(ranges, i * 8);
                }
                for (int i = 0; i < REPLAYWAVECOUNT; ++i)
                {
                    ReplayGraph[i].Axes.Item("YAxis-1").SetMinMax(
                        detail[i * 2], detail[i * 2 + 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Զ��״̬�����ûطŲ��οؼ���Y����ʾģʽΪ����Ӧ
        /// </summary>
        private void SetYRangeInAutoMode()
        {
            for (int i = 0; i < REPLAYWAVECOUNT; ++i)
            {
                ReplayGraph[i].Axes.Item("YAxis-1").AutoScaleNow();
            }
        }
        #endregion   

        Point initPoint = new Point();
        Size initSize = new Size();

        #region �ؼ���Ӧ����

        private void _btn_confirm_Click(object sender, EventArgs e)
        {
            DateTime TMbegin = _dat_begin.Value;
            DateTime TMend = _dat_end.Value;
            if (TMbegin == TMend)
            {
                MessageBox.Show("��ѡ����ʼʱ�����ֹʱ��");
                return;
            }
            scaleCount = 0;
            former_X_min[0] = TMbegin;
            former_X_max[0] = TMend;
            if (!GetReplayData(TMbegin, TMend))
                return;
            if (Total_Frames > 0)
            {
                plot();
            }
        }


        private void _btn_start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(acq_port) || string.IsNullOrEmpty(comm_port))
            {
                MessageBox.Show("��ѡ��ͨ�Ŷ˿ںͲɼ��˿�");
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                //AcquireGraph[i].Axes.Item("XAxis").SetMinMax(Xmin[i], Xmax[i]);
                if (GetGasType(i) == GasType.QiYa)
                {
                    ProgressBarValue[i].Range = new NationalInstruments.UI.Range(Calmin[i] / 1000 - 101, Calmax[i] / 1000 - 101);
                    ProgressBarValue[i + 8].Range = new NationalInstruments.UI.Range(Calmin[i] / 1000 - 101, Calmax[i] / 1000 - 101);
                }
                else
                {
                    ProgressBarValue[i].Range = new NationalInstruments.UI.Range(Calmin[i], Calmax[i]);
                    ProgressBarValue[i + 8].Range = new NationalInstruments.UI.Range(Calmin[i], Calmax[i]);
                }     
            }

            Initport();
            //GetEquimentID();
            PrepareSendData();
            _timer.Enabled = true;
            _btn_startAcquire.Enabled = false;
            _btn_stopAcquire.Enabled = true;
            _report.Enabled = true;
            if (bSimulator)
            {
                timer1.Enabled = true;
            }
        }


        private void _timer_Tick(object sender, EventArgs e)
        {
            SendCmd();
            if (bSimulator)
            {
                byte[] dd = new byte[16+3];
                for (int i = 0; i < 8; i++)
                {
                    int ii = (int)(simuAcq[i] * 1000);
                    byte[] temp = BitConverter.GetBytes(ii);
                    dd[3 + i * 2 + 1] = temp[0];
                    dd[3 + i * 2 ] = temp[1];
                }
                plotAcquire(dd);  
            }
        }

        private void _btn_stop_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;

            _btn_startAcquire.Enabled = true;
            _btn_stopAcquire.Enabled = false;
            _report.Enabled = false;
        }

      

        private void _Rpgraph0_DblClick_1(object sender, EventArgs e)
        {
            if (bZooming)
            {
                _btn_zoom_Click(null, null);
            }
            AxCWGraph graph = (AxCWGraph)sender;
            int index = Convert.ToInt32(graph.Name[graph.Name.Length - 1].ToString(), 10);
       
            if (!bMax)
            {
                initPoint = ReplayGraph[index].Location;
                initSize = ReplayGraph[index].Size;

                ReplayGraph[index].Size = new Size(1100, 600);
                ReplayGraph[index].BringToFront();
                ReplayGraph[index].Location = ReplayGraph[0].Location;
            }
            else
            {
                ReplayGraph[index].Size = initSize;
                ReplayGraph[index].Location = initPoint;
            }
            bMax = !bMax;
        }

        private void _btn_init_Click(object sender, EventArgs e)
        {
           /* GetReplayData(former_X_min[0], former_X_max[0]);
            for (int i = 0; i < REPLAYWAVECOUNT; ++i)
            {
                ReplayGraph[i].Axes.Item("XAxis").SetMinMax(
                    former_X_min[0],
                    former_X_max[0]);
                min_XAxis = former_X_min[0];
                max_XAxis = former_X_max[0];
            }*/
            _btn_confirm_Click(null, null);
            scaleCount = 0;
            _btn_init.Enabled = false;
            _btn_formerstep.Enabled = false;
        }

        private void OnSettingRange(object sender, EventArgs e)
        {
            SetYRange form = new SetYRange(true);
            form.ShowDialog();
            InitConfig();
            SaveCfg();
        }

        private void  OnUserMange(object sender, EventArgs e)
        {
            if (curUserJB == -1)
            {
                Login frm = new Login();
                frm.ShowDialog();
                if (curUserJB == -1)
                {
                    return;
                }
            }
            _lbl_user.Text = curUserID;
            _lbl_user.Text = curUserID;
            admin_managment frm1 = new admin_managment();
            frm1.ShowDialog();
        }

        private void ��ʼ�ɼ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _btn_start_Click(null, null);
            _btn_startAcquire.Enabled = false;
            _btn_stopAcquire.Enabled = true;
        }

        private void ֹͣ�ɼ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _btn_stop_Click(null, null);
            _btn_startAcquire.Enabled = true;
            _btn_stopAcquire.Enabled = false;
        }

        private void _AcqGraph2_CursorChange(object sender, _DCWGraphEvents_CursorChangeEvent e)
        {

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 103);//ж�ؿ�ݼ�
            bSystemRunning = false;
            SaveCfg();
            _btn_stop_Click(null, null);
        }

        private void OnSettingComm(object sender, EventArgs e)
        {
            if (curUserJB == -1)
            {
                Login frm = new Login();
                frm.ShowDialog();
                if (curUserJB == -1)
                {
                    return;
                }
            }
           
            _lbl_user.Text = curUserID;
            if (curUserJB < 1)
            {
                MessageBox.Show("���ļ��𲻹�������ϵ����Ա��");
                return;
            }
            if (!_btn_startAcquire.Enabled)
            {
                MessageBox.Show("����ֹͣ�ɼ��ٽ���ͨ������");
                return;
            }
            commConfig form = new commConfig();
            form.ShowDialog();
            InitConfig();
            SaveCfg();
            //�������ε������´�ȥ�ֳ��ٸ�
            //Initport();
        }

        private void OnViewReport(object sender, EventArgs e)
        {
            //new Thread(new ThreadStart(delegate
            //{
                Report form = new Report();
                form.Show();
           // })).Start();
        }

        private void OnSysConfig(object sender, EventArgs e)
        {
            if (curUserJB == -1)
            {
                Login frm = new Login();
                frm.ShowDialog();
                if (curUserJB == -1)
                {
                    return;
                }
            }
            _lbl_user.Text = curUserID;
            if (!_btn_startAcquire.Enabled)
            {
                MessageBox.Show("����ֹͣ�ɼ��ٽ���ͨ������");
                return;
            }
            new SysConfig().ShowDialog();
            InitConfig();
            SaveCfg();
            ShowZhesuanText();
        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dat_end.Value = DateTime.Now;
            _dat_begin.Value = DateTime.Now - TimeSpan.FromDays(1);
        }

        private void ϵ������XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curUserJB == -1)
            {
                Login frm = new Login();
                frm.ShowDialog();
                if (curUserJB == -1)
                {
                    return;
                }
            }
            _lbl_user.Text = curUserID;
            if (curUserJB == 3)
            {
                ChanConfig form = new ChanConfig();
                form.ShowDialog();
                SaveCfg();
                ShowZhesuanText();
            }
            else
            {
                MessageBox.Show("���ļ��𲻹�������ϵ����Ա��");
            }
        }

        private void �˳���¼QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ���˳���¼��?", "ȷ���˳�", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                curUserJB = -1;
                _lbl_user.Text = "δ��¼";
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            _lbl_system.Text = time.Year.ToString("d4") + "-" + time.Month.ToString("d2") + "-" + time.Day.ToString("d2") + " " +time.Hour.ToString("d2")+":" +time.Minute.ToString("d2")+":" + time.Second.ToString("d2");
        }

        private void OnversionClick(object sender, EventArgs e)
        {
            //3������߼�����߽��Ĳ���Ȩ�޵�¼
            if (curUserJB < 3)
            {
                Login frm = new Login();
                frm.ShowDialog();
                if (curUserJB == -1)
                {
                    return;
                }
                else if (curUserJB < 3)
                {
                    MessageBox.Show("���ļ��𲻹�������ϵ����Ա!");
                    return;
                }
            }
            curUserJB = 3;
            _lbl_user.Text = curUserID;
            if (!_btn_startAcquire.Enabled)
            {
                MessageBox.Show("����ֹͣ�ɼ��ٽ���ͨ������");
                return;
            }
            new Setting().ShowDialog();
            InitConfig();
            SaveCfg();
            ShowZhesuanText();
        }

        #region ���ɱ���

        int recordminute = -1;
        int recordhour = -1;
        int recordday = -1;
        int recordmonth = -1;

        /// <summary>
        /// �������ӱ���,��������ʱ�����걨��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GenerateMinutedData(DateTime t)
        {
            OracleCommand cmd = conn.CreateCommand();

            float[] hisData = new float[15];
            float[][] data = new float[8][];
            DateTime[] time = new DateTime[8];
            string scmd = "";
            uint total_frame = 0;
            bool readSucc = false;

            string begin = "";
            string end = "";
            string recordtime = "";
            begin = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + "00";
            end = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + "59";
            recordtime = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + "30";

            try
            {
                readSucc = ReadDataBaseData(begin, end, ref data, ref time, ref total_frame, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (readSucc)
            {
                float[] sumArray = new float[8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < data[0].Length; j++)
                    {
                        sumArray[i] += data[i][j];
                    }
                    sumArray[i] = sumArray[i] / total_frame;
                }
                //���� m3/h
                hisData[9] = (float)QswXishu * 3600 * sumArray[0] * 273 * (sumArray[5]) * (1 - (float)Form1.Xsw) / ((273 + sumArray[6]) * 101325);

                if(hisData[9] < 0)
                {
                    hisData[9] = 0;
                }

                if (bCalZS)
                {
                    //������
                    hisData[0] = sumArray[1];
                    hisData[1] = (float)(sumArray[1] * (21.0 - (Form1.O2)) / (21.0 - sumArray[4]));
                    //kg/h
                    hisData[2] = hisData[9] * hisData[0] / 1000000;

                    //SO2
                    hisData[3] = sumArray[2];
                    hisData[4] = (float)(sumArray[2] * (21.0 - (float)Form1.O2) / (21.0 - sumArray[4]));
                    //kg/h
                    hisData[5] = hisData[9] * hisData[3] / 1000000;

                    //NOx
                    hisData[6] = sumArray[3];
                    hisData[7] = (float)(sumArray[3] * (21.0 - (float)Form1.O2) / (21.0 - sumArray[4]));
                    //kg/h
                    hisData[8] = hisData[9] * hisData[6] / 1000000;
                }
                else
                {
                    //������
                    hisData[0] = sumArray[1];
                    hisData[1] = sumArray[1];
                    hisData[2] = hisData[9] * sumArray[1] / 1000000;

                    //SO2
                    hisData[3] = sumArray[2];
                    hisData[4] = sumArray[2];
                    hisData[5] = hisData[9] * sumArray[2] / 1000000;
                    //NOx
                    hisData[6] = sumArray[3];
                    hisData[7] = sumArray[3];
                    hisData[8] = hisData[9] * sumArray[3] / 1000000;
                }
                //O2
                hisData[10] = sumArray[4];
                //�¶�
                hisData[11] = sumArray[6];
                //������ѹ��
                hisData[12] = sumArray[5];
                //����������
                hisData[13] = sumArray[0];
                //�����еĸ������0
                for (int i = 0; i < 14; i++)
                {
                    if (hisData[i] < 0 && (i != 12))
                    {
                        hisData[i] = 0;
                    }
                }
                try
                {
                    scmd = "INSERT INTO day_report VALUES(seq_gas.nextval";
                    scmd += ",to_date('" + recordtime + "','yyyymmddhh24miss') ,";
                    for (int i = 0; i < hisData.Length; i++)
                    {
                        scmd += "'" + hisData[i].ToString("f2") + "',";
                    }

                    scmd += "'mi','";
                    scmd += total_frame.ToString() + "','" + t.Minute + "')";


                    cmd.CommandText = scmd;    //SQL���
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("����������ݱ��������ǰʱ��Ϊ" + end + "������ϢΪ" + ex.Message + "sql=" + scmd + " " + ex.StackTrace);
                }
            }

            cmd.Dispose();
        }

        void UpLoad212Minute(int Minutes, string code)
        {
            float[] min = new float[8];
            float[] minN = new float[8];
            float[] max = new float[8];
            float[] maxN = new float[8];
            float[] avg = new float[8];
            float[] avgN = new float[8];
            float totalYanchen = 0;
            float totalYanchenN = 0;
            float totalSO2 = 0;
            float totalSO2N = 0;
            float totalNO = 0;
            float totalNON = 0;
            DateTime t1 = DateTime.Now - TimeSpan.FromMinutes(Minutes);
            for (int i = 0; i < 8; i++)
            {
                min[i] = RtdData[i][RtdData[i].Count - 1];
                minN[i] = RtdDataN[i][RtdDataN[i].Count - 1];
                max[i] = RtdData[i][RtdData[i].Count - 1];
                maxN[i] = RtdDataN[i][RtdDataN[i].Count - 1];
                avg[i] = 0;
                avgN[i] = 0;
            }
            int count = 0;
            for (int i = 0; i < RtdData[0].Count; i++)
            {
                if (RtdTime[i] > t1)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (RtdData[j][i] < min[j])
                        {
                            min[j] = RtdData[j][i];
                        }
                        if (RtdDataN[j][i] < minN[j])
                        {
                            minN[j] = RtdDataN[j][i];
                        }
                        if (RtdData[j][i] > max[j])
                        {
                            max[j] = RtdData[j][i];
                        }
                        if (RtdDataN[j][i] > maxN[j])
                        {
                            maxN[j] = RtdDataN[j][i];
                        }
                        avg[j] += RtdData[j][i];
                        avgN[j] += RtdDataN[j][i];

                    }
                    count++;
                }
            }
            if (count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    avg[i] /= count;
                    avgN[i] /= count;
                }
            }
            #region ׼������



            /*
             * 0 567 ˲ʱ�������٣�10837430 Nm3/S [A55DB6��HEX��]
               1 89 �̳�Ũ�ȣ�158 mg/Nm3   [009E (HEX) ]
               2 1011 SO2�� 58 mg/Nm3     [003A (HEX) ]
               3 1213 NOX�� 59 mg/Nm3    [003B (HEX) ]
                 CO 1415
               4 1617 O2��  14%          [000E (HEX)]
               5 181920�̵���ѹ��-750Pa        [8002EE (HEX)]
               6 2122�¶ȣ�94��          [005E (HEX)]
               7 2324ʪ�ȣ�78%          [004E (HEX)]
             */

            int iLIUSU = 0; int iYANCHEN = 0; int iSO2 = 0; int iNO = 0; int iO2 = 0; int iYALI = 0; int iWendu = 0;
            for (int i = 0; i < 8; i++)
            {
                string s = Form_index[i].ToString();
                //�ϴ������ٲ��ñ��ֵ������ʵ��ֵ
                if (s == "7")
                {
                    iLIUSU = i;
                }
                else if (s == "1")
                {
                    iYANCHEN = i;
                }
                else if (s == "2")
                {
                    iSO2 = i;
                }
                else if (s == "3")
                {
                    iNO = i;
                }
                else if (s == "4")
                {
                    iO2 = i;
                }
                else if (s == "5")
                {
                    iYALI = i;
                }
                else if (s == "6")
                {
                    iWendu = i;
                }
            }
            string time = "0";
            DateTime t = DateTime.Now;
            //��������
            if (Minutes < 60)
            {
                time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + "00000";
                totalYanchen = avg[iLIUSU] * 60 * avg[iYANCHEN] / 1000000;
                totalYanchenN = avg[iLIUSU] * 60 * avgN[iYANCHEN] / 1000000;
                totalSO2 = avg[iLIUSU] * 60 * avg[iSO2] / 1000000;
                totalSO2N = avg[iLIUSU] * 60 * avgN[iSO2] / 1000000;
                totalNO = avg[iLIUSU] * 60 * avg[iNO] / 1000000;
                totalNON = avg[iLIUSU] * 60 * avgN[iNO] / 1000000;
            }
            //Сʱ����
            else if (Minutes == 60)
            {
                time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + "0000000";
                totalYanchen = avg[iLIUSU] * 3600 * avg[iYANCHEN] / 1000000;
                totalYanchenN = avg[iLIUSU] * 3600 * avgN[iYANCHEN] / 1000000;
                totalSO2 = avg[iLIUSU] * 3600 * avg[iSO2] / 1000000;
                totalSO2N = avg[iLIUSU] * 3600 * avgN[iSO2] / 1000000;
                totalNO = avg[iLIUSU] * 3600 * avg[iNO] / 1000000;
                totalNON = avg[iLIUSU] * 3600 * avgN[iNO] / 1000000;
            }
            //������
            else if (Minutes == 60 * 24)
            {
                time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + "000000000";
                //time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + "0000000";
                totalYanchen = avg[iLIUSU] * 3600 * 24 * avg[iYANCHEN] / 1000000;
                totalYanchenN = avg[iLIUSU] * 3600 * 24 * avgN[iYANCHEN] / 1000000;
                totalSO2 = avg[iLIUSU] * 3600 * 24 * avg[iSO2] / 1000000;
                totalSO2N = avg[iLIUSU] * 3600 * 24 * avgN[iSO2] / 1000000;
                totalNO = avg[iLIUSU] * 3600 * 24 * avg[iNO] / 1000000;
                totalNON = avg[iLIUSU] * 3600 * 24 * avgN[iNO] / 1000000;
            }
            else
            {
                time = t.Year.ToString("d4") + t.Month.ToString("d2") + t.Day.ToString("d2") + t.Hour.ToString("d2") + t.Minute.ToString("d2") + t.Second.ToString("d2") + "000";

            }
            #endregion


            string cmd = "ST=31;CN=" + code + ";PW=" + password + ";MN=" + mn + ";CP=&&DataTime=" + time;

            //�̳�
            cmd += ";" + T_YANCHEN + "-ZsMin=" + minN[iYANCHEN].ToString("f2") + "," + T_YANCHEN + "-ZsMax=" + maxN[iYANCHEN].ToString("f2") + "," + T_YANCHEN + "-ZsAvg=" + avgN[iYANCHEN].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_YANCHEN + "-Cou=" + totalYanchen.ToString("f2");
            }
            cmd += ";" + T_YANCHEN + "-Min=" + min[iYANCHEN].ToString("f2") + "," + T_YANCHEN + "-Max=" + max[iYANCHEN].ToString("f2") + "," + T_YANCHEN + "-Avg=" + avg[iYANCHEN].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_YANCHEN + "-Cou=" + totalYanchen.ToString("f2");
            }

            //SO2
            cmd += ";" + T_SO2 + "-ZsMin=" + minN[iSO2].ToString("f2") + "," + T_SO2 + "-ZsMax=" + maxN[iSO2].ToString("f2") + "," + T_SO2 + "-ZsAvg=" + avgN[iSO2].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_SO2 + "-Cou=" + totalSO2.ToString("f2");
            }
            cmd += ";" + T_SO2 + "-Min=" + min[iSO2].ToString("f2") + "," + T_SO2 + "-Max=" + max[iSO2].ToString("f2") + "," + T_SO2 + "-Avg=" + avg[iSO2].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_SO2 + "-Cou=" + totalSO2.ToString("f2");
            }

            //NOx
            cmd += ";" + T_NO + "-ZsMin=" + minN[iNO].ToString("f2") + "," + T_NO + "-ZsMax=" + maxN[iNO].ToString("f2") + "," + T_NO + "-ZsAvg=" + avgN[iNO].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_NO + "-Cou=" + totalNO.ToString("f2");
            }
            cmd += ";" + T_NO + "-Min=" + min[iNO].ToString("f2") + "," + T_NO + "-Max=" + max[iNO].ToString("f2") + "," + T_NO + "-Avg=" + avg[iNO].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_NO + "-Cou=" + totalNO.ToString("f2");
            }


            string sSHIDU = (Xsw * 100).ToString("f2");

            cmd += ";" + T_O2 + "-Min=" + min[iO2].ToString("f2") + "," + T_O2 + "-Max=" + max[iO2].ToString("f2") + "," + T_O2 + "-Avg=" + avg[iO2].ToString("f2");
            cmd += ";" + T_LIUSU + "-Min=" + min[iLIUSU].ToString("f2") + "," + T_LIUSU + "-Max=" + max[iLIUSU].ToString("f2") + "," + T_LIUSU + "-Avg=" + avg[iLIUSU].ToString("f2");
            //ѹ����ѹ����pa���kpa
            cmd += ";" + T_YALI + "-Min=" + (min[iYALI] / 1000 - 101).ToString("f2") + "," + T_YALI + "-Max=" + (max[iYALI] / 1000 - 101).ToString("f2") + "," + T_YALI + "-Avg=" + (avg[iYALI] / 1000 - 101).ToString("f2");
            cmd += ";" + T_SHIDU + "-Min=" + sSHIDU + "," + T_SHIDU + "-Max=" + sSHIDU + "," + T_SHIDU + "-Avg=" + sSHIDU;
            cmd += ";" + T_WENDU + "-Min=" + min[iWendu].ToString("f2") + "," + T_WENDU + "-Max=" + max[iWendu].ToString("f2") + "," + T_WENDU + "-Avg=" + avg[iWendu].ToString("f2");
            cmd += "&&";

            //";S02-Cou=16.00,S02-Min=5.00,S02-Max=7.00,S02-Avg=6.00;01-Cou=16.00,01-Min=5.00,01-Max=7.00,01-Avg=6.00;02-Cou=16.00,02-Min=5.00,02-Max=7.00,02-Avg=6.00;03-Cou=16.00,03-Min=5.00,03-Max=7.00,03-Avg=6.00;&&";

            send212cmd(cmd);

        }

        void UpLoad212HourAndDay(float[][] hisData,float[] total,string time, string code,bool bupLoad)
        {
            float[] min = new float[15];
            float[] max = new float[15];

            for (int i = 0; i < 15; i++)
            {
                min[i] = max[i] = hisData[0][i];
            }

            for (int i = 0; i < hisData.Length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (hisData[i][j] < min[j])
                    {
                        min[j] = hisData[i][j];
                    }
                    if (hisData[i][j] > max[j])
                    {
                        max[j] = hisData[i][j];
                    }
                }
            }

            string cmd = "ST=31;CN=" + code + ";PW=" + password + ";MN=" + mn + ";CP=&&DataTime=" + time;

            //�̳�
            cmd += ";" + T_YANCHEN + "-ZsMin=" + min[1].ToString("f2") + "," + T_YANCHEN + "-ZsMax=" + max[1].ToString("f2") + "," + T_YANCHEN + "-ZsAvg=" + total[1].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_YANCHEN + "-Cou=" + total[2].ToString("f2");
            }
            cmd += ";" + T_YANCHEN + "-Min=" + min[0].ToString("f2") + "," + T_YANCHEN + "-Max=" + max[0].ToString("f2") + "," + T_YANCHEN + "-Avg=" + total[0].ToString("f2");
    

            //SO2
            cmd += ";" + T_SO2 + "-ZsMin=" + min[4].ToString("f2") + "," + T_SO2 + "-ZsMax=" + max[4].ToString("f2") + "," + T_SO2 + "-ZsAvg=" + total[4].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_SO2 + "-Cou=" + total[5].ToString("f2");
            }
            cmd += ";" + T_SO2 + "-Min=" + min[3].ToString("f2") + "," + T_SO2 + "-Max=" + max[3].ToString("f2") + "," + T_SO2 + "-Avg=" + total[3].ToString("f2");


            //NOx
            cmd += ";" + T_NO + "-ZsMin=" + min[7].ToString("f2") + "," + T_NO + "-ZsMax=" + max[7].ToString("f2") + "," + T_NO + "-ZsAvg=" + total[7].ToString("f2");
            if (bUpLoadTotal)
            {
                cmd += "," + T_NO + "-Cou=" + total[8].ToString("f2");
            }
            cmd += ";" + T_NO + "-Min=" + min[6].ToString("f2") + "," + T_NO + "-Max=" + max[6].ToString("f2") + "," + T_NO + "-Avg=" + total[6].ToString("f2");


            cmd += ";" + T_O2 + "-Min=" + min[10].ToString("f2") + "," + T_O2 + "-Max=" + max[10].ToString("f2") + "," + T_O2 + "-Avg=" + total[10].ToString("f2");
            cmd += ";" + T_LIUSU + "-Min=" + min[9].ToString("f2") + "," + T_LIUSU + "-Max=" + min[9].ToString("f2") + "," + T_LIUSU + "-Avg=" + total[9].ToString("f2");
            //ѹ����ѹ����pa���kpa
            cmd += ";" + T_YALI + "-Min=" + (min[12] / 1000).ToString("f2") + "," + T_YALI + "-Max=" + (max[12] / 1000).ToString("f2") + "," + T_YALI + "-Avg=" + (total[12] / 1000).ToString("f2");
            cmd += ";" + T_WENDU + "-Min=" + min[11].ToString("f2") + "," + T_WENDU + "-Max=" + max[11].ToString("f2") + "," + T_WENDU + "-Avg=" + total[11].ToString("f2");
            cmd += "&&";

            //";S02-Cou=16.00,S02-Min=5.00,S02-Max=7.00,S02-Avg=6.00;01-Cou=16.00,01-Min=5.00,01-Max=7.00,01-Avg=6.00;02-Cou=16.00,02-Min=5.00,02-Max=7.00,02-Avg=6.00;03-Cou=16.00,03-Min=5.00,03-Max=7.00,03-Avg=6.00;&&";
           //������Ƿ���ģʽ���ϴ�
            if (!bSimulator && bupLoad)
            {
                send212cmd(cmd);
            }
            else
            {
                //����ģʽ��Ҳд��־
                string str = time.Substring(0, 4) + "-" + time.Substring(4, 2) + "-" + time.Substring(6, 2);
                StreamWriter wr = File.AppendText("c:\\log\\" + str + "_212.txt");
                wr.WriteLine("[" + str + " " + time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2) + "] " + cmd + "\r\n");
                wr.Flush();
                wr.Close();
            }
        }

        public static bool ReadRecordData(string begintime, string endtime, ref float[][] Redata, ref int[] count, ref int[] value, string type)
        {
            OracleCommand cmd = conn.CreateCommand();

            int total_frame = 0;
            if (type == "mi")
            {
                total_frame = 60;
            }
            if (type == "h")
            {
                total_frame = 24;
            }
            else if (type == "d")
            {
                string days = endtime.Substring(6, 2);
                total_frame = Convert.ToInt32(days);
            }
            else if (type == "m")
            {
                total_frame = 12;
            }


            cmd.CommandText = "select * from day_report where date_time between to_date('" + begintime + "','yyyymmddhh24miss') and to_date('" + endtime + "','yyyymmddhh24miss') and flag = '" + type + "' order by date_time";
            OracleDataReader rs = cmd.ExecuteReader();
            //����������������
            if (rs.HasRows)
            {
                Redata = new float[total_frame][];
                value = new int[total_frame];
                count = new int[total_frame];
                for (int i = 0; i < total_frame; i++)
                {
                    Redata[i] = new float[15];
                    Redata[i][14] = -1;
                    value[i] = -1;
                }
                while (rs.Read())
                {
                    int curIndex = Convert.ToInt32(rs.GetString(19));
                    if (curIndex >= total_frame)
                    {
                        continue;
                    }
                    string sa = rs.GetString(18);
                    count[curIndex] = Convert.ToInt32(sa);
                    value[curIndex] = curIndex;

                    for (int j = 0; j < 15; j++)
                    {
                        string s = rs.GetString(j + 2);
                        Redata[curIndex][j] = Convert.ToSingle(s);
                    }
                    Redata[curIndex][14] = 0;
                }
                rs.Close();
                cmd.Dispose();
                return true;
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                return false;
            }

        }
       
        private void GenerateRecordData(string begintime,string endtime,string recordtime,int value, string flag,bool loadup)
        {
            float[][] hisData = null;
            int[] count = null;
            int[] val = null;
            int totalcount = 0;
            bool hasData = false;
            if (flag == "h")
            {
                hasData = ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "mi");
            }
            if (flag == "d")
            {
                hasData = ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "h");
            }
            else if(flag == "m")
            {
                hasData = ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "d");
            }
            //���û�ж���������ֱ�ӷ���
            if (!hasData)
            {
                return;
            }
            float[] total = new float[15];
            //��ʾ��Ч����������
            int effectiveCount = 0;
            for (int i = 0; i < 15; i++)
            {
                total[i] = 0;
                for (int j = 0; j < hisData.Length; j++)
                {
                    total[i] += hisData[j][i];
                }
            }
            for (int i = 0; i < hisData.Length; i++)
            {
                if (hisData[i][14] > -0.5)
                {
                    effectiveCount++;
                }
            }

            if (effectiveCount != 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    //�ձ����ÿһ�����Ҫ����60��
                    if (flag == "h")
                    {
                        total[i] = total[i] / effectiveCount;
                    }
                    else
                    {
                        if ((i == 2) || (i == 5) || (i == 8) || (i == 9))
                        {
                            total[i] = total[i];
                        }
                        else
                        {
                            total[i] = total[i] / effectiveCount;
                        }
                    }

                    //�ձ�������Ҫ����60��
                    /*if ((i == 2) || (i == 5) || (i == 8) || ((i == 9) && (flag != "h")))
                    {
                        total[i] = total[i];
                    }
                    else
                    {
                        total[i] = total[i] / effectiveCount;
                    }*/
                }
                for (int i = 0; i < count.Length; i++)
                {
                    totalcount += count[i];
                }
            }

            total[14] = 0;


            if (flag == "h")
            {
                UpLoad212HourAndDay(hisData, total, begintime, "2061", loadup);
            }
            if (flag == "d")
            {
                UpLoad212HourAndDay(hisData, total, begintime, "2031", loadup);
            }


            string scmd = "";
            try
            {
                if (effectiveCount != 0)
                {
                    OracleCommand cmd = conn.CreateCommand();

                    scmd = "INSERT INTO day_report VALUES(seq_gas.nextval";
                    scmd += ",to_date('" + recordtime + "','yyyymmddhh24miss') ,";
                    for (int i = 0; i < total.Length; i++)
                    {
                        scmd += "'" + total[i].ToString("f2") + "',";
                    }
                    scmd += "'" + flag + "','" + totalcount.ToString() + "','" + value + "')";
                    cmd.CommandText = scmd;    //SQL���
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("GenerateRecordData�������ݱ��������ǰʱ��Ϊ" + scmd + "������ϢΪ" + ex.Message + "sql=" + scmd + " " + ex.StackTrace);
            }
        }

        private void _report_Tick(object sender, EventArgs e)
        {
            //ÿ��Сʱ�ĵ�һ����������һСʱ��Сʱ����
            DateTime now = DateTime.Now;
            ThreadReport(now,true);

        }
        private void ThreadReport(DateTime now,bool loadup)
        {
            if (recordminute != now.Minute)
            {
                DateTime time = now - TimeSpan.FromMinutes(1);
                GenerateMinutedData(time);
                recordminute = now.Minute;
            }
            if ((now.Minute) == 0 && (recordhour != now.Hour))
            {
                //Сʱ���ݵļ�¼ʱ��Ϊyyyy-mm-dd hh:30:30
                DateTime time = now - TimeSpan.FromMinutes(5);
                string begintime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + time.Hour.ToString("d2") + "0000";
                string endtime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + time.Hour.ToString("d2") + "5959";
                string recordtime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + time.Hour.ToString("d2") + "3040";
                GenerateRecordData(begintime, endtime, recordtime, time.Hour, "h", loadup);
                recordhour = now.Hour;
            }
            if ((now.Hour == 0) && (now.Minute == 1) && (recordday != now.Day))
            {
                //�����ݵļ�¼ʱ��Ϊyyyy-mm-dd 12:30:40
                DateTime time = now - TimeSpan.FromHours(1);
                string begintime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + "000000";
                string endtime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + "235959";
                string recordtime = time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + "123040";
                GenerateRecordData(begintime, endtime, recordtime, time.Day - 1, "d", loadup);
                recordday = now.Day;
            }

            if ((now.Day == 1) && (now.Hour == 0) && (now.Minute == 2) && (recordmonth != now.Month))
            {
                //�����ݵļ�¼ʱ��Ϊyyyy-mm-12 12:30:50
                DateTime time = now - TimeSpan.FromDays(1);
                string begintime = time.Year.ToString("d4") + time.Month.ToString("d2") + "01000000";
                int days = DateTime.DaysInMonth(time.Year, time.Month);
                string endtime = time.Year.ToString("d4") + time.Month.ToString("d2") + days.ToString("d2") + "235959";
                string recordtime = time.Year.ToString("d4") + time.Month.ToString("d2") + "12123050";
                GenerateRecordData(begintime, endtime, recordtime, time.Month - 1, "m", loadup);
                recordmonth = now.Month;
            }
            saveRecordTime(now);
        }
        private void saveRecordTime(DateTime time)
        {
            iniclass.IniWriteValue("config", "shutdowntime", time.Year.ToString("d4") + time.Month.ToString("d2") + time.Day.ToString("d2") + time.Hour.ToString("d2") + time.Minute.ToString("d2") + time.Second.ToString("d2"));
        }

        private void FillTheBlankReport()
        {
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select max(gasdate) from GAS_DATA";
            OracleDataReader rs1 = cmd.ExecuteReader();
            rs1.Read();
            OracleDateTime tGasData = rs1.GetOracleDateTime(0);
            rs1.Close();
            if (tGasData.IsNull)
            {
                cmd.Dispose();
                return;
            }

            cmd.CommandText = "select max(date_time) from DAY_REPORT";
            OracleDataReader rs2 = cmd.ExecuteReader();
            rs2.Read();
            OracleDateTime tReportData = rs2.GetOracleDateTime(0);
            rs2.Close();
            if (tReportData.IsNull)
            {
                cmd.CommandText = "select min(gasdate) from GAS_DATA";
                OracleDataReader rs3 = cmd.ExecuteReader();
                rs3.Read();
                tReportData = rs3.GetOracleDateTime(0);
                rs3.Close();
            }
            cmd.Dispose();

            if (tReportData < tGasData)
            {
                DateTime now = (DateTime)(tGasData);
                DateTime tmp = (DateTime)(tReportData);
                while ((tmp < now) && bSystemRunning)
                {
                    tmp += TimeSpan.FromMinutes(1);
                    ThreadReport(tmp, false);
                }
            }

        }
        #endregion
        
    }

}
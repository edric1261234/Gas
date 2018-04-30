using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Word;
using System.IO;
using System.Data.OracleClient;




namespace HengXu
{
    public partial class Report : Form
    {

        public Report()
        {
            InitializeComponent();
            _dat_day.Value = DateTime.Now;
            this.WindowState = FormWindowState.Maximized;

        }

        void GetMinMax(float[][] rawdata, ref float[] max, ref float[] min, ref float[] avg)
        {
            max = new float[15];
            min = new float[15];
            avg = new float[15];
            for (int j = 0; j < 15; j++)
            {
                float sum = 0;
                max[j] = rawdata[0][j]; min[j] = rawdata[0][j]; avg[j] = 0;
                for (int i = 0; i < rawdata.Length; i++)
                {
                    if (rawdata[i][j] > max[j])
                    {
                        max[j] = rawdata[i][j];
                    }
                    if (rawdata[i][j] < min[j])
                    {
                        min[j] = rawdata[i][j];
                    }
                    sum += rawdata[i][j];
                }
                avg[j] = sum / rawdata.Length;
            }
        }

        void FileTableHour(Word.Document wdoc, string beginTime, float[][] hisData, int[] count, int[] val)
        {
            Tables t = wdoc.Tables;
            DateTime date = DateTime.ParseExact(beginTime, "yyyyMMddHHmmss", null);
            //填写用户信息和日期
            t[1].Cell(1, 2).Range.Text = Form1.gasname;
            t[1].Cell(2, 2).Range.Text = Form1.gasid;
            t[1].Cell(2, 4).Range.Text = date.Year.ToString("d4");
            t[1].Cell(2, 6).Range.Text = date.Month.ToString("d2");
            t[1].Cell(2, 8).Range.Text = date.Day.ToString("d2");
            t[1].Cell(2, 10).Range.Text = date.Hour.ToString("d2");
            for (int i = 0; i < 60; i++)
            {

                for (int j = 0; j < hisData.Length; j++)
                {
                    if (val[j] == i)
                    {
                        t[2].Cell(2 + i, 1).Range.Text = date.Hour.ToString("d2") + ":" + i.ToString("d2");
                        //颗粒物
                        t[2].Cell(2 + i, 2).Range.Text = hisData[j][0].ToString("f1");
                        t[2].Cell(2 + i, 3).Range.Text = hisData[j][1].ToString("f1");
                        //SO2
                        t[2].Cell(2 + i, 4).Range.Text = hisData[j][3].ToString("f1");
                        t[2].Cell(2 + i, 5).Range.Text = hisData[j][4].ToString("f1");
                        //NOX
                        t[2].Cell(2 + i, 6).Range.Text = hisData[j][6].ToString("f1");
                        t[2].Cell(2 + i, 7).Range.Text = hisData[j][7].ToString("f1");
                        //O2
                        t[2].Cell(2 + i, 8).Range.Text = hisData[j][10].ToString("f1");
                        float qiya = hisData[j][12];
                        float wendu = hisData[j][11];
                        float liuliang = hisData[j][13];
                        //流速
                        t[2].Cell(2 + i, 9).Range.Text = (liuliang / Form1.M2).ToString("f1");
                        //工况
                        t[2].Cell(2 + i, 10).Range.Text = (liuliang * 3600).ToString("f2");
                        //标杆
                        t[2].Cell(2 + i, 11).Range.Text = ((float)Form1.QswXishu * 3600 * liuliang * 273 * (qiya) * (1 - (float)Form1.Xsw) / ((273 + wendu) * 101325)).ToString("f2");
                        //温度
                        t[2].Cell(2 + i, 12).Range.Text = hisData[j][11].ToString("f1");
                        //break;
                    }
                }
            }
        }
        void FillCommonTable(Word.Document wdoc, DateTime date, string flag)
        {
            float[][] hisData = null;
            int[] count = null;
            int[] val = null;
            int tableRows = 0;
            bool hasdata = false;
            if (flag == "h")
            {
                string begintime = date.Year.ToString("d4") + date.Month.ToString("d2") + date.Day.ToString("d2") + date.Hour.ToString("d2") + "0000";
                string endtime = date.Year.ToString("d4") + date.Month.ToString("d2") + date.Day.ToString("d2") + date.Hour.ToString("d2") + "5959";
                hasdata = Form1.ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "mi");
                tableRows = 60;
                //小时数据比较特殊，需要单独填写
                FileTableHour(wdoc, begintime, hisData, count, val);
                return;
            }
            if (flag == "d")
            {
                string begintime = date.Year.ToString("d4") + date.Month.ToString("d2") + date.Day.ToString("d2") + "000000";
                string endtime = date.Year.ToString("d4") + date.Month.ToString("d2") + date.Day.ToString("d2") + "235959";
                hasdata = Form1.ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "h");
                tableRows = 24;
            }
            else if (flag == "m")
            {
                string begintime = date.Year.ToString("d4") + date.Month.ToString("d2") + "01000000";
                int days = DateTime.DaysInMonth(date.Year, date.Month);
                string endtime = date.Year.ToString("d4") + date.Month.ToString("d2") + days.ToString("d2") + "235959";
                hasdata = Form1.ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "d");
                tableRows = days;
            }
            else if (flag == "y")
            {
                string begintime = date.Year.ToString("d4") + "0101000000";
                int days = DateTime.DaysInMonth(date.Year, date.Month);
                string endtime = date.Year.ToString("d4") + "0101235959";
                hasdata = Form1.ReadRecordData(begintime, endtime, ref hisData, ref count, ref val, "m");
                tableRows = 12;
            }
            if (!hasdata)
            {
                MessageBox.Show("没有查到数据，请重新选择日期!");
                return;
            }
            List<int> tmpList = new List<int>();

            for (int i = 0; i < val.Length; i++)
            {
                tmpList.Add(i);
            }
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] != -1)
                    tmpList.Remove(val[i]);
            }
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == -1)
                {
                    val[i] = tmpList[0];
                    tmpList.Remove(tmpList[0]);
                }
            }

            Tables t = wdoc.Tables;
            //填写用户信息和日期
            t[1].Cell(1, 2).Range.Text = Form1.gasname;
            t[1].Cell(2, 2).Range.Text = Form1.gasid;
            t[1].Cell(2, 4).Range.Text = date.Year.ToString("d4");
            t[1].Cell(2, 6).Range.Text = date.Month.ToString("d2");
            t[1].Cell(2, 8).Range.Text = date.Day.ToString("d2");
            //首先填每行的前12列，这是具体的内容
            for (int i = 0; i < tableRows; i++)
            {
                for (int j = 0; j < hisData.Length; j++)
                {
                    if (val[j] == i)
                    {
                        for (int k = 0; k < 12; k++)
                        {
                            if (k == 2 || k == 5 || k == 8)
                            {
                                //日报表单位是kg，月报表和年报是顿
                                if (flag == "d")
                                {
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f3");
                                }
                                else if (flag == "m")
                                {
                                    hisData[j][k] /= 1000;
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f4");
                                }
                                else if (flag == "y")
                                {
                                    hisData[j][k] /= 1000;
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f1");
                                }
                            }
                            else if (k == 9)
                            {
                                if (flag == "d")
                                {
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f3");
                                }
                                else if (flag == "m")
                                {
                                    hisData[j][k] /= 10000;
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f3");
                                }
                                else if (flag == "y")
                                {
                                    hisData[j][k] /= 10000;
                                    t[2].Cell(3 + i, k + 2).Range.Text = (hisData[j][k]).ToString("f1");
                                }
                            }
                            else
                            {
                                if (flag == "d")
                                {
                                    t[2].Cell(3 + i, k + 2).Range.Text = hisData[j][k].ToString("f3"); ;
                                }
                                else if (flag == "m")
                                {
                                    t[2].Cell(3 + i, k + 2).Range.Text = hisData[j][k].ToString("f1"); ;
                                }
                                else if (flag == "y")
                                {
                                    t[2].Cell(3 + i, k + 2).Range.Text = hisData[j][k].ToString("f1"); ;
                                }


                            }
                        }
                        t[2].Cell(3 + i, 12 + 2).Range.Text = "-";
                        t[2].Cell(3 + i, 13 + 2).Range.Text = "-";
                        t[2].Cell(3 + i, 14 + 2).Range.Text = "-";
                        break;
                    }
                }
            }
            //填写平均值等4行
            float[] max = null;
            float[] min = null;
            float[] avg = null;
            GetMinMax(hisData, ref max, ref min, ref avg);
            int total_count = 0;
            for (int i = 0; i < tableRows; i++)
            {
                total_count += count[i];
            }

            float t1 = 0;
            float t2 = 0;
            float t3 = 0;
            float t4 = 0;
            for (int i = 0; i < tableRows; i++)
            {
                t1 += hisData[i][2];
                t2 += hisData[i][5];
                t3 += hisData[i][8];
                t4 += hisData[i][9];
            }

            if (flag == "m")
            {
                tableRows = 31;
            }
            for (int i = 0; i < 12; i++)
            {
                t[2].Cell(3 + tableRows, i + 2).Range.Text = avg[i].ToString("f1");
                t[2].Cell(3 + tableRows + 1, i + 2).Range.Text = max[i].ToString("f1");
                t[2].Cell(3 + tableRows + 2, i + 2).Range.Text = min[i].ToString("f1");
                t[2].Cell(3 + tableRows + 3, i + 2).Range.Text = total_count.ToString();
            }
            t[2].Cell(3 + tableRows, 12 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows, 13 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows, 14 + 2).Range.Text = "-";

            t[2].Cell(3 + tableRows + 1, 12 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 1, 13 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 1, 14 + 2).Range.Text = "-";

            t[2].Cell(3 + tableRows + 2, 12 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 2, 13 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 2, 14 + 2).Range.Text = "-";

            t[2].Cell(3 + tableRows + 3, 12 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 3, 13 + 2).Range.Text = "-";
            t[2].Cell(3 + tableRows + 3, 14 + 2).Range.Text = "-";

          
            //日报表总的排放量单位不一致
            if (flag == "d")
            {
                t[2].Cell(3 + tableRows + 4, 3).Range.Text = (t1 / 1000).ToString("f3");
                t[2].Cell(3 + tableRows + 4, 5).Range.Text = (t2 / 1000).ToString("f3");
                t[2].Cell(3 + tableRows + 4, 7).Range.Text = (t3 / 1000).ToString("f3");
                t[2].Cell(3 + tableRows + 4, 8).Range.Text = (t4 / 10000).ToString("f3");
            }
            else
            {
                t[2].Cell(3 + tableRows + 4, 3).Range.Text = t1.ToString("f3");
                t[2].Cell(3 + tableRows + 4, 5).Range.Text = t2.ToString("f3");
                t[2].Cell(3 + tableRows + 4, 7).Range.Text = t3.ToString("f3");
                t[2].Cell(3 + tableRows + 4, 8).Range.Text = t4.ToString("f3");
            }

        }


        private void OnDayReport(object sender, EventArgs e)
        {

            if (_cmb_type.Text == "小时报表")
            {
                hourReport(_dat_day.Value);
            }
            else if (_cmb_type.Text == "日报表")
            {
                dayReport(_dat_day.Value);
            }
            else if (_cmb_type.Text == "月报表")
            {
                monthReport(_dat_day.Value);
            }
            else if (_cmb_type.Text == "年报表")
            {
                yearReport(_dat_day.Value);
            }

        }
        void hourReport(DateTime dates)
        {
            try
            {
                //if (dates.Year == DateTime.Now.Year && dates.Month == DateTime.Now.Month && dates.Day == DateTime.Now.Day)
                //{
                //    MessageBox.Show("只能选择今天之前的日期查看");
                //    return;
                //}
                string date = Form1.str + "//小时报表" + dates.ToShortDateString() + ".doc";
                File.Copy(Form1.str + "//hour.doc", date, true);
                this.axFramerControl1.Open(date);
                this.axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
                this.axFramerControl1.Toolbars = false;
                this.axFramerControl1.Titlebar = false;
                //写保护，只能读取
                Object myObj = this.axFramerControl1.ActiveDocument;
                if (myObj == null)
                {
                    return;
                }

                Word.Document wdoc = (Word.Document)myObj;
                Word.Application ThisApplication = wdoc.Application;
                object missing = Type.Missing;
                FillCommonTable(wdoc, _dat_day.Value, "h");
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建小时报表出错！" + ex.Message);
            }
        }
        void dayReport(DateTime dates)
        {
            try
            {
                //if (dates.Year == DateTime.Now.Year && dates.Month == DateTime.Now.Month && dates.Day == DateTime.Now.Day)
                //{
                //    MessageBox.Show("只能选择今天之前的日期查看");
                //    return;
                //}
                string date = Form1.str + "//日报表" + dates.ToShortDateString() + ".doc";
                File.Copy(Form1.str + "//day.doc", date, true);
                this.axFramerControl1.Open(date);
                this.axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
                this.axFramerControl1.Toolbars = false;
                this.axFramerControl1.Titlebar = false;
                //写保护，只能读取
                Object myObj = this.axFramerControl1.ActiveDocument;
                if (myObj == null)
                {
                    return;
                }

                Word.Document wdoc = (Word.Document)myObj;
                Word.Application ThisApplication = wdoc.Application;
                object missing = Type.Missing;
                //wdoc.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref missing, ref missing, ref missing, ref missing);
                FillCommonTable(wdoc, _dat_day.Value, "d");

            }
            catch (Exception ex)
            {
                MessageBox.Show("创建日报表出错！" + ex.Message);
            }
        }
        void monthReport(DateTime dates)
        {
            try
            {
                if (dates > DateTime.Now)
                {
                    MessageBox.Show("只能选择本月之前的日期查看");
                    return;
                }

                string date = Form1.str + "//月报表" + dates.Year.ToString("d4") + "-" + dates.Month.ToString("d2") + ".doc";
                File.Copy(Form1.str + "//month.doc", date, true);
                this.axFramerControl1.Open(date);
                this.axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
                this.axFramerControl1.Toolbars = false;
                this.axFramerControl1.Titlebar = false;
                //写保护，只能读取
                Object myObj = this.axFramerControl1.ActiveDocument;
                if (myObj == null)
                {
                    return;
                }

                Word.Document wdoc = (Word.Document)myObj;
                Word.Application ThisApplication = wdoc.Application;
                object missing = Type.Missing;
                //wdoc.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref missing, ref missing, ref missing, ref missing);
                try
                {
                    FillCommonTable(wdoc, dates, "m");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("创建月报表出错！" + ex.Message + ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("创建月报表出错！" + ex.Message);
            }
        }
        void yearReport(DateTime dates)
        {
            try
            {
                if (dates > DateTime.Now)
                {
                    MessageBox.Show("只能选择本月之前的日期查看");
                    return;
                }

                string date = Form1.str + "//年报表" + dates.Year.ToString("d4") + ".doc";
                File.Copy(Form1.str + "//year.doc", date, true);
                this.axFramerControl1.Open(date);
                this.axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
                this.axFramerControl1.Toolbars = false;
                this.axFramerControl1.Titlebar = false;
                //写保护，只能读取
                Object myObj = this.axFramerControl1.ActiveDocument;
                if (myObj == null)
                {
                    return;
                }

                Word.Document wdoc = (Word.Document)myObj;
                Word.Application ThisApplication = wdoc.Application;
                object missing = Type.Missing;
                //wdoc.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref missing, ref missing, ref missing, ref missing);
                try
                {
                    FillCommonTable(wdoc, dates, "y");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("adf" + ex.Message + ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("创建月报表出错！" + ex.Message);
            }
        }

        private void _cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmb_type.Text == "小时报表")
            {
                _dat_day.CustomFormat = "yyyy-MM-dd HH";
            }
            else if (_cmb_type.Text == "日报表")
            {
                _dat_day.CustomFormat = "yyyy-MM-dd";
            }
            else if (_cmb_type.Text == "月报表")
            {
                _dat_day.CustomFormat = "yyyy-MM";
            }
            else if (_cmb_type.Text == "年报表")
            {
                _dat_day.CustomFormat = "yyyy";
            }
        }



    }

}
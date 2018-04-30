namespace HengXu
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dat_day = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this._cmb_type = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axFramerControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 658);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._dat_day);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._cmb_type);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _dat_day
            // 
            this._dat_day.CustomFormat = "yyyy-MM-dd HH:00:00";
            this._dat_day.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dat_day.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._dat_day.Location = new System.Drawing.Point(283, 21);
            this._dat_day.Name = "_dat_day";
            this._dat_day.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._dat_day.Size = new System.Drawing.Size(178, 21);
            this._dat_day.TabIndex = 21;
            this._dat_day.Value = new System.DateTime(2013, 3, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "报表类型";
            // 
            // _cmb_type
            // 
            this._cmb_type.FormattingEnabled = true;
            this._cmb_type.Items.AddRange(new object[] {
            "日报表",
            "月报表",
            "年报表",
            "小时报表"});
            this._cmb_type.Location = new System.Drawing.Point(94, 20);
            this._cmb_type.Name = "_cmb_type";
            this._cmb_type.Size = new System.Drawing.Size(121, 20);
            this._cmb_type.TabIndex = 2;
            this._cmb_type.Text = "日报表";
            this._cmb_type.SelectedIndexChanged += new System.EventHandler(this._cmb_type_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnDayReport);
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(1030, 605);
            this.axFramerControl1.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 658);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Report";
            this.Text = " 报表";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _cmb_type;
        private System.Windows.Forms.Button button1;
        private AxDSOFramer.AxFramerControl axFramerControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _dat_day;

    }
}
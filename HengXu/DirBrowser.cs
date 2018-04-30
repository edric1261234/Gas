using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace HengXu
{
  
    public class DirectorySelect : FolderNameEditor
    {
        private FolderBrowser fb = new FolderBrowser();
        private string fDescription = "Choose Directory";
        private string fReturnPath = String.Empty;

        public string Description
        {
            set { fDescription = value; }
            get { return fDescription; }
        }

        public string ReturnPath
        {
            get { return fReturnPath; }
        }

        public DirectorySelect()
        {

        }

        private DialogResult RunDialog()
        {
            fb.Description = this.Description;
            fb.StartLocation = FolderBrowserFolder.MyComputer;
            fb.Style = FolderBrowserStyles.RestrictToSubfolders;
            //|FolderBrowserStyles.RestrictToDomain;
            return fb.ShowDialog();
        }

        public DialogResult ShowDialog()
        {
            DialogResult dRes = DialogResult.None;
            dRes = RunDialog();
            if (dRes == DialogResult.OK)
                this.fReturnPath = fb.DirectoryPath;
            else
                this.fReturnPath = String.Empty;
            return dRes;
        }
    }

    //一般选择文件保存地址都用弹出对话框来进行选择
    //调用   
    //DirBrowser   myDirBrowser=new   DirBrowser();   
    //if(myDirBrowser.ShowDialog()!=DialogResult.Cancel)   
    //MessageBox.Show(myDirBrowser.ReturnPath);   

    public class DirBrowser : FolderNameEditor
    {
        FolderBrowser fb = new FolderBrowser();
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string ReturnPath
        {
            get { return _returnPath; }
        }

        public DirBrowser() { }
        public DialogResult ShowDialog()
        {
            fb.Description = _description;
            fb.StartLocation = FolderBrowserFolder.MyComputer;
            DialogResult r = fb.ShowDialog();
            if (r == DialogResult.OK)
                _returnPath = fb.DirectoryPath;
            else
                _returnPath = String.Empty;

            return r;
        }

        //private   string   _description   =   "Choose   Directory";     
        //private   string   _returnPath   =   String.Empty;  
        private string _description = "请选择文件夹";
        private string _returnPath = String.Empty;
    } 


}

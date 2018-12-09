using PicturePinSystemModel;
using PicturePintSystem.Comm;
using PicturePintSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class SettingForm :BaseForm
    {
        public string pageSize;
        public bool landscape;
        public int marginLeft;
        public int marginRight;
        public int marginTop;
        public int marginBottom;

        public SettingForm()
        {
            InitializeComponent();
            this.LoadSize();
            this.LoadDisplay();
        }
        #region 内部函数
        /// <summary>
        /// 加载默认值
        /// </summary>
        private void LoadDisplay()
        {
            Task.Run(()=> {
                this.wifiTxt.Text = FormConfigUtil.WifiPath;
                this.localTxt.Text = FormConfigUtil.LocationPath;
                this.logTxt.Text = FormConfigUtil.LogPath;
                this.ipTxt.Text = FormConfigUtil.IpPath;
                this.countTxt.Text = FormConfigUtil.PrintCount.ToString();
                var list = new List<object> {
                    new {key="默认居中",value="默认居中"}
                };
                this.localComboBox.DataSource = list;
                this.localComboBox.ValueMember = "value";
                this.localComboBox.DisplayMember = "key";
                this.localComboBox.SelectedValue = FormConfigUtil.ImgLocation;
                this.pageSize =ImageSizeUtil.ConverntPaperSizeName(FormConfigUtil.PageSize);
                this.landscape = FormConfigUtil.Landscape;
                this.marginLeft=FormConfigUtil.MarginLeft;
                this.marginRight=FormConfigUtil.MarginRight;
                this.marginTop=FormConfigUtil.MarginTop;
                this.marginBottom=FormConfigUtil.MarginBottom;
                this.printDocument.DefaultPageSettings.PaperSize = FormConfigUtil.GetPaperSize(printDocument,pageSize);   
                this.printDocument.DefaultPageSettings.Margins.Top = this.marginTop;
                this.printDocument.DefaultPageSettings.Margins.Left = this.marginLeft;
                this.printDocument.DefaultPageSettings.Margins.Right = this.marginRight;
                this.printDocument.DefaultPageSettings.Margins.Bottom = this.marginBottom;
                this.portTxt.Text = FormConfigUtil.Host;
            });
        }
        #endregion

        private void wifiBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();     //显示选择文件对话框
            
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                var path = openFolder.SelectedPath;
                this.wifiTxt.Text = path;
            }
        }

        private void localBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();     //显示选择文件对话框

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                var path = openFolder.SelectedPath;
                this.localTxt.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();     //显示选择文件对话框
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JPEG|*.jpeg|JPG|*.jpg|GIF|*.gif|PNG|*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                this.logTxt.Text = path;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            if (check.Checked)
            {
                this.ipTxt.Text = Controlles.GetIP();
                this.ipTxt.ReadOnly = true;
            }
            else
            {
                this.ipTxt.ReadOnly =false;
            }
        }

        private  void saveBtn_Click(object sender, EventArgs e)
        {
            var wifiPath = this.wifiTxt.Text;
            var loaclPath = this.localTxt.Text;
            var logPath = this.logTxt.Text;
            var ipPath = this.ipTxt.Text;
            var countPath = this.countTxt.Text;
            var imgPath = this.localComboBox.SelectedValue.ToString();
            var printCount = this.countTxt.Text;
            var port = this.portTxt.Text;
            string size = ImageSizeUtil.ConverntPaperSize(this.pageSize);
            var dic = new Dictionary<string, string> {
                {"wifiPath",wifiPath},
                { "locationPath",loaclPath},
                { "logPath",logPath},
                { "ipPath",ipPath},
                { "imgLocation",imgPath},
                { "printCount",printCount},
                {"pageSize",size},
                {"landscape",this.landscape.ToString()},
                {"marginLeft",this.marginLeft.ToString()},
                {"marginRight",this.marginRight.ToString()},
                {"marginTop",this.marginTop.ToString()},
                {"marginBottom",this.marginBottom.ToString() },
                { "host",port}
            };
            FormConfigUtil.SetConfig(dic);
            FormFactory.MainForm.InitForm();
            FormFactory.MainForm.ReloadService(x=> {
                if (x)
                {
                    MessageBox.Show("设置保存成功");
                }
                else
                {
                    MessageBox.Show("端口已被占用，请重新设置端口");
                }
            });
        }
        protected override void SetForm()
        {
            return;
        }
        /// <summary>
        /// 打印设置
        /// </summary>
        private void printBtn_Click(object sender, EventArgs e)
        {
            //打印前的弹框
            //this.printDialog.ShowDialog();
            //打印页面设置
            if (this.pageSetupDialog.ShowDialog()==DialogResult.OK)
            {
               this.pageSize=printDocument.DefaultPageSettings.PaperSize.PaperName;
               this.landscape = printDocument.DefaultPageSettings.Landscape;
               this.marginLeft = printDocument.DefaultPageSettings.Margins.Left;
               this.marginRight = printDocument.DefaultPageSettings.Margins.Right;
               this.marginTop = printDocument.DefaultPageSettings.Margins.Top;
               this.marginBottom = printDocument.DefaultPageSettings.Margins.Bottom;             
            }
        }
    }
}

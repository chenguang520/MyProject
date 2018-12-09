using PicturePinSystemModel;
using PicturePintSystem.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class SettingForm1 : PicturePintSystem.BaseForm1
    {
        /// <summary>
        /// 保存当前队列中的图片
        /// </summary>
        public List<ImageParamEdit> Images { get; set; }
        /// <summary>
        /// 图片列表占位框
        /// </summary>
        public List<PictureBox> PicList { get; set; }
        /// <summary>
        /// 打印参数
        /// </summary>
        public PrintSettingParam SettingParam { get; set; }

        /// <summary>
        /// 获取选中的PicName
        /// </summary>
        public List<string> SelPicNames = new List<string>();

        public SettingForm1()
        {
            InitializeComponent();
            //加载图片列表
            LoadImgList();
        }
        /// <summary>
        /// 选择打印机
        /// </summary>
        private void selPrintBtn_Click(object sender, EventArgs e)
        {
            //打印页面设置
            //this.pageSetupDialog.ShowDialog();
            //return;
            //设置纸张大小
            var pageSize=new PaperSize("A3", 297, 420);
            foreach (System.Drawing.Printing.PaperSize pSize in printDocument.PrinterSettings.PaperSizes)
            {
                if (pSize.Kind == System.Drawing.Printing.PaperKind.A4)
                {
                    pageSize = pSize;
                    break;
                }
            }
            printDocument.DefaultPageSettings.PaperSize = pageSize;
            printDocument.PrinterSettings.Copies = 2;
            printDocument.OriginAtMargins =false;//启用页边距
            var printerName = this.ShowPrintList();
            if (!string.IsNullOrEmpty(printerName))
            {
                printDocument.PrinterSettings.PrinterName = printerName;
            }
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog.ShowDialog();
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void startBtn_Click(object sender, EventArgs e)
        {
            this.printDocument.Print();
            return;
            if (this.printDialog.ShowDialog() == DialogResult.OK)
            {
              
            }
        }
        /// <summary>
        /// 打印内容设置
        /// </summary>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////打印内容 为 整个Form
            //Image myFormImage=this.pictureBox1.Image;
            //打印内容 为 局部的 this.groupBox1
            //e.Graphics.DrawImage(myFormImage, 0, 0,myFormImage.Width,myFormImage.Height);
        }

        #region 内部方法
        /// <summary>
        ///渲染图片队列控件
        /// </summary>
        private void LoadImgList()
        {
            if (this.Images == null)
            {
                this.Images = new List<ImageParamEdit>();
            }
            if (this.PicList == null)
            {
                this.PicList = new List<PictureBox>();
            }
            var y = 21;
            for (int i = 0; i <12; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new System.Drawing.Point(20, y);
                pic.Name = "pic" + i;
                pic.Tag = i;
                pic.Size = new System.Drawing.Size(143, 138);
                pic.TabIndex = 0;
                pic.TabStop = false;
                pic.Cursor = Cursors.Hand;
                pic.Click += picPicBox_Click;
                pic.Paint += picPicBox_Paint;
                //队列里存在图片就按索引对应
                if (i < this.Images.Count)
                {
                    pic.Image = this.Images[i].SuoImg;
                }
                else
                {
                    pic.Image = ImageCodeUtil.CreateImageCode("aaa",6);
                }
                this.PicList.Add(pic);
                this.SetDetailImg();
                y += 150;
            }
            this.picPanel.Controls.AddRange(this.PicList.ToArray());
        }
        /// <summary>
        /// 设置图片明细
        /// </summary>
        private void SetDetailImg()
        {

        }
        /// <summary>
        /// 缩略图点击事件
        /// </summary>
        private void picPicBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null)
            {
                return;
            }
            var defaultFlag = pic.Image.Tag;
            //默认图片不处理
            if (defaultFlag != null && defaultFlag.Equals("defaultImg"))
            {
                return;
            }
            //设置明细图片显示
            SetDetailImg(pic);
            if (this.SelPicNames.Contains(pic.Name))
            {
                this.SelPicNames.Remove(pic.Name);
            }
            else
            {
                this.SelPicNames.Add(pic.Name);
            }
            pic.Invalidate();
        }
        /// <summary>
        /// 设置明细图片显示
        /// </summary>
        private void SetDetailImg(PictureBox pic)
        {
            var image = this.Images.Find(x => x.SuoImg == pic.Image);
            if (image != null)
            {
                this.detailPic.Image = image.DetailImg;
            }
        }
        /// <summary>
        /// 图片控件重绘事件
        /// </summary>
        private void picPicBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (this.SelPicNames.Contains(pic.Name))
            {
                Pen pp = new Pen(Color.Red);
                pp.Width = 6;
                e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y,
                e.ClipRectangle.X + e.ClipRectangle.Width - 1,
                e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            }
        }
        #endregion
    }
}

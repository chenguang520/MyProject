using PicturePinSystemModel;
using PicturePintSystem.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class PrintForm : BaseForm
    {
        private const int width = 150;
        private const int height = 150;

        /// <summary>
        /// 是否开始打印
        /// </summary>
        private bool isBegin=false;

        /// <summary>
        /// 保存当前队列中的图片
        /// </summary>
        public List<ImageEditParam> Images = new List<ImageEditParam>();
        /// <summary>
        /// 图片列表占位框
        /// </summary>
        public List<PictureBox> PicList = new List<PictureBox>();
        /// <summary>
        /// 纸张大小
        /// </summary>
        public string PagerSize { get; set; }
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrintName { get; set; }

        /// <summary>
        /// 获取选中的PicName
        /// </summary>
        public List<string> SelPicNames = new List<string>();

        public PrintForm(List<ImageEditParam> imgParam,string pagerSize)
        {
            InitializeComponent();
            this.LoadSize();
            this.InitData(imgParam, pagerSize);
            //设置打印机
            this.SetPrint();
        }

        #region 内部函数
        /// <summary>
        /// 设置打印机
        /// </summary>
        private void SetPrint() {
            //设置打印份数
            printDocument.PrinterSettings.Copies =short.Parse(this.countTxt.Text);
            //启用页边距
            printDocument.OriginAtMargins = false;
            //横向纵向设置
            printDocument.DefaultPageSettings.Landscape = FormConfigUtil.Landscape;
            //尺寸设置
            printDocument.DefaultPageSettings.PaperSize = FormConfigUtil.GetPaperSize(printDocument,this.PagerSize);
            //打印机名称
            printDocument.PrinterSettings.PrinterName = this.PrintName;
        }
        private void InitData(List<ImageEditParam> imgParam,string pagerSize)
        {
            var widthD = this.detailPic.Width;
            var heightD = this.detailPic.Height;
            this.Images = imgParam.Select(x => new ImageEditParam {
                  YuanImg=x.YuanImg,
                  DetailImg=ImageUtil.CreateThumbnailImage(x.ScreenshotImg,widthD,heightD),
                  ImagePath=x.ImagePath,
                  ImageType=x.ImageType,
                  SuoImg= ImageUtil.CreateThumbnailImage(x.ScreenshotImg,width,height),
                  ScreenshotImg=x.ScreenshotImg,
                  IsPrint=true  
            }).ToList();
            //将pageSize转换成A3类型的名称
            this.PagerSize =ImageSizeUtil.ConverntPaperSizeName(pagerSize);
            this.countTxt.Text = FormConfigUtil.PrintCount.ToString();
        }
        /// <summary>
        /// 加载Log
        /// </summary>
        private async void LoadLog()
        {
            await Task.Run(() =>
            {
                var path = Application.StartupPath + "/Content/Image/logo.jpg";
                var image = Image.FromFile(path);
                this.logPic.Image = ImageUtil.CreateThumbnailImage(image, 189, 100);
            });
        }

        /// <summary>
        ///渲染图片队列控件
        /// </summary>
        private void LoadImgList()
        {
            var picCount = this.Images.Count;
            var x =90;
            var y = 3;
            var marginY = 170;
            for (int i = 0; i < picCount; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new System.Drawing.Point(x, y);
                pic.Name = "pic" + i;
                pic.Tag = i;
                pic.Size = new System.Drawing.Size(width,height);
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
                    pic.Image = null;
                }
                this.PicList.Add(pic);
                y += marginY;
            }
            this.picPanel.Controls.AddRange(this.PicList.ToArray());
            this.SetDetailImg();
        }
        /// <summary>
        /// 加入到图片队列
        /// </summary>
        public void PushImages(Image img, string imgPath, string imgType)
        {
           
            var detailW = this.detailPic.Size.Width;
            var detailH = this.detailPic.Size.Height;
            //构建Pic容器
            var x = 90;
            var y = 3;
            var marginY = 170;
            var tag = 0;
            //获取最后一个Pic
            var lastPic = this.PicList.LastOrDefault();
            if (lastPic != null)
            {
                x = lastPic.Location.X;
                y = lastPic.Location.Y+marginY;
                tag = Convert.ToInt16(lastPic.Tag) + 1;
            }
            PictureBox pic = new PictureBox();
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "pic" + tag;
            pic.Tag = tag;
            pic.Size = new System.Drawing.Size(width, height);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            pic.Click += picPicBox_Click;
            pic.Paint += picPicBox_Paint;
            var imgParam = new ImageEditParam
            {
                YuanImg = img,
                SuoImg = ImageUtil.CreateThumbnailImage(img, width, height),
                DetailImg = ImageUtil.CreateThumbnailImage(img, detailW, detailH),
                ImagePath = imgPath,
                ImageType = imgType,
                ScreenshotImg=img
            };
            pic.Image = imgParam.SuoImg;
            this.PicList.Add(pic);
            this.Images.Add(imgParam);
            //添加缩略图
            if (this.picPanel.InvokeRequired)
            {
                ThreadMethood t = () => {
                    this.picPanel.Controls.Add(pic);
                };
                this.picPanel.Invoke(t);
                this.SetDetailImg();
            }
            else
            {
                this.picPanel.Controls.Add(pic);
                this.SetDetailImg();
            }
        }

        /// <summary>
        /// 刷新图片
        /// </summary>
        private void RefImgList()
        {
            var count = this.PicList.Count();
            var picCopy = new PictureBox[count];
            this.PicList.CopyTo(picCopy);
            for (int i = 0; i < picCopy.Count(); i++)
            {
                //队列里存在图片就按索引对应
                if (i < this.Images.Count)
                {
                    this.PicList[i].Image = this.Images[i].SuoImg;
                }
                else
                {
                    var removePic = picCopy[i];
                    this.PicList.Remove(removePic);
                    this.picPanel.Controls.Remove(removePic);
                }
            }
            this.SetDetailImg();
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
            this.SetDetailImg(pic);
            if (this.SelPicNames.Contains(pic.Name))
            {
                this.SelPicNames.Remove(pic.Name);
            }
            else
            {
                if (this.SelPicNames.Count == FormConfigUtil.PrintPicListCount)
                {
                    MessageBox.Show($"您最多只能选择{FormConfigUtil.PrintPicListCount}张图片");
                    return;
                }
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
        /// 设置图片明细(大图展示)
        /// </summary>
        private void SetDetailImg()
        {
            var firstImg = this.Images.Where(x => x != null && x.YuanImg != null).FirstOrDefault();
            if (firstImg != null)
            {
                this.detailPic.Image = firstImg.DetailImg;
            }
        }
        #endregion

        private void PrintForm_Load(object sender, EventArgs e)
        {   
            //加载内部函数
            this.LoadLog();
            //加载图片控件
            this.LoadImgList();
            this.PrintName = FormConfigUtil.PrintName;
        }
        /// <summary>
        /// 选择打印机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selPrintBtn_Click(object sender, EventArgs e)
        {
            var printerName = this.ShowPrintList();
            if (!string.IsNullOrEmpty(printerName))
            {
                this.PrintName = printerName;
                FormConfigUtil.SetConfig(new Dictionary<string, string> {
                    {"printName",this.PrintName}
                });
            }
        }
        /// <summary>
        /// 加入打印列
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = FormConfigUtil.LocationPath.Replace('/', '\\');
            openFileDialog1.Filter = "JPEG|*.jpeg|JPG|*.jpg|GIF|*.gif|PNG|*.png|BMP|*.bmp";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            var imageCheck = new string[]{
                "JPEG",
                "jpeg",
                "JPG",
                "jpg",
                "GIF",
                "gif",
                "PNG",
                "png",
                "BMP",
                "bmp"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                var extension = Path.GetExtension(path);
                extension = extension.TrimStart('.');
                if (imageCheck.Contains(extension))
                {
                    var image = Image.FromFile(path);
                    this.PushImages(image,path,extension);
                }
                else
                {
                    MessageBox.Show("请选择图片类型的文件");
                }
            }
        }
        /// <summary>
        /// 队列打印
        /// </summary>
        private void saveBtn_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(this.PrintName))
            {
                MessageBox.Show("请先选择打印机再进行操作！");
                return;
            }
            this.SetPrint();
            this.Print();
        }
        private async void Print()
        {
           this.isBegin = true;
           await Task.Run(()=> {
               //对列存在继续打印，并且是开始状态
               if (this.Images.Count(x=>x.IsPrint)>0&&this.isBegin) {
                   this.printDocument.Print();
               }
           });
        }
        /// <summary>
        /// 打印内容设置
        /// </summary>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //每次获取首位(参加打印的图片)
            var imageParam = this.Images.FirstOrDefault(x=>x.IsPrint);
            if (imageParam!= null)
            {
                var myFormImage = imageParam.ScreenshotImg;
                //打印内容 为 局部的 this.groupBox1
                e.Graphics.DrawImage(myFormImage, 0, 0, myFormImage.Width, myFormImage.Height);
            }
        }
        /// <summary>
        /// 开始打印
        /// </summary>
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        /// <summary>
        /// 移除选择的图片
        /// </summary>
        private void RemoveSelect(PictureBox pic)
        {
            if (pic!=null)
            {
                this.SelPicNames.Remove(pic.Name);
                pic.Invalidate();
            }
        }
        /// <summary>
        /// 结束打印
        /// </summary>
        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //移除队列首位元素
            if (this.Images.Count>0) {
                var firImg = this.Images.FirstOrDefault();
                var firPic = this.PicList.Find(x => x.Image ==firImg.SuoImg);
                //移除首张元素
                this.RemoveSelect(this.PicList.FirstOrDefault());
                var lastImg = this.Images.LastOrDefault();
                var lastPic=this.PicList.Find(x => x.Image == lastImg.SuoImg);
                //移除末尾图片
                this.RemoveSelect(lastPic);
                this.Images.RemoveAt(0);
                //刷新图片
                this.RefImgList();
                //移除后存在元素
                if (this.Images.Count>0&&this.isBegin)
                {  
                    //缓解性能
                    Thread.Sleep(2000);
                    this.printDocument.Print();
                }
            }
        }
        /// <summary>
        /// 暂停
        /// </summary>
        private void zhanBtn_Click(object sender, EventArgs e)
        {
            this.isBegin = false;
        }
        /// <summary>
        /// 队列前移
        /// </summary>
        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (this.SelPicNames==null||this.SelPicNames.Count==0)
            {
                MessageBox.Show("请先选择图片，在进行前移操作！");
                return;
            }
            //找到选中图片的集合对应的位置
            var imgs = this.Images.Select(x => x.SuoImg).ToList();
            var indexs = new List<int>();
            this.SelPicNames.ForEach(x=> {
                //获取当前的图片框
                var pic = this.PicList.Find(y=>y.Name==x);
                var index=imgs.IndexOf(pic.Image);
                indexs.Add(index);
            });
            var array = this.Images.ToArray();
           indexs.ForEach(x=> {
               if (x>0)
               {
                   //找出旧的选中的图片
                   var oldPic=this.PicList.Find(p => p.Image == this.Images[x].SuoImg);
                   this.RemoveSelect(oldPic);
                   var newIndex = x - 1;
                   var newPic=this.PicList.Find(p => p.Image == this.Images[newIndex].SuoImg);
                   this.SelPicNames.Add(newPic.Name);
                   newPic.Invalidate();
                   ArrayMove(ref array, x, newIndex);
               }
            });
            this.Images = array.ToList();
            this.RefImgList();
            
        }
        /// <summary>
        /// 将数组元素移动位置
        /// </summary>
        public void ArrayMove<T>(ref T[] array, int fromIndex, int toIndex)
        {
            if (
            fromIndex > array.Length - 1 ||
            toIndex > array.Length - 1 ||
            fromIndex == toIndex
            ) return;

            T[] tempArray = new T[array.Length];
            if (fromIndex > toIndex)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == toIndex)
                    {
                        tempArray[i] = array[fromIndex];
                    }
                    else
                    {
                        if (i > fromIndex || i < toIndex)
                        {
                            tempArray[i] = array[i];
                        }
                        else
                        {
                            tempArray[i] = array[i - 1];
                        }
                    }
                }
            }
            else if (fromIndex < toIndex)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == toIndex)
                    {
                        tempArray[i] = array[fromIndex];
                    }
                    else
                    {
                        if (i < fromIndex || i > toIndex)
                        {
                            tempArray[i] = array[i];
                        }
                        else
                        {
                            tempArray[i] = array[i + 1];
                        }
                    }
                }
            }
            array = tempArray;
        }
        /// <summary>
        /// 队列后移
        /// </summary>
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (this.SelPicNames == null || this.SelPicNames.Count == 0)
            {
                MessageBox.Show("请先选择图片，再进行后移操作！");
                return;
            }
            //找到选中图片的集合对应的位置
            var imgs = this.Images.Select(x => x.SuoImg).ToList();
            var indexs = new List<int>();
            this.SelPicNames.ForEach(x => {
                //获取当前的图片框
                var pic = this.PicList.Find(y => y.Name == x);
                var index = imgs.IndexOf(pic.Image);
                indexs.Add(index);
            });
            var array = this.Images.ToArray();
            indexs.ForEach(x => {
                if (x<this.Images.Count-1)
                {
                    //找出旧的选中的图片
                    var oldPic = this.PicList.Find(p => p.Image == this.Images[x].SuoImg);
                    this.RemoveSelect(oldPic);
                    var newIndex = x+1;
                    var newPic = this.PicList.Find(p => p.Image == this.Images[newIndex].SuoImg);
                    this.SelPicNames.Add(newPic.Name);
                    newPic.Invalidate();
                    ArrayMove(ref array, x, newIndex);
                }
            });
            this.Images = array.ToList();
            this.RefImgList();

        }

        /// <summary>
        /// 取消打印
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {  
            //取消所有打印
            this.Images.ForEach(x=> {
                x.IsPrint = false;
            });
            MessageBox.Show("取消成功！");
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (this.SelPicNames == null||this.SelPicNames.Count==0)
            {
                MessageBox.Show("请选择您要移除的图片！");
                return;
            }
            var result=MessageBox.Show("您确定要移除选中的图片吗？", "提示", MessageBoxButtons.OKCancel);
            if (result==DialogResult.OK)
            {
                var images = this.PicList.Where(x => this.SelPicNames.Contains(x.Name)).Select(x => x.Image);
                this.Images.RemoveAll(x => images.Contains(x.SuoImg));
                this.RefImgList();
                var selPic = this.PicList.Where(x=>this.SelPicNames.Contains(x.Name)).ToList();
                this.SelPicNames.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicturePinSystemModel;
using PicturePintSystem.Comm;
using PicturePintSystem.Controllers;
using static PicturePintSystem.Comm.ImageCodeUtil;

namespace PicturePintSystem
{
    public partial class EditForm : PicturePintSystem.BaseForm1
    {
        /// <summary>
        /// 保存当前队列中的图片
        /// </summary>
        public List<ImageEditParam> Images { get; set; }
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

        public EditForm(PrintSettingParam setting)
        { 
            InitializeComponent();
            //初始化数据
            this.InitData(setting);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            //加载内部图标
            LoadLog();
            //加载图片队列控件
            LoadImgList();
           
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
            //设置裁剪图片
            this.SetCaiImg();
            if (this.SelPicNames.Contains(pic.Name))
            {
                this.SelPicNames.Remove(pic.Name);
            }
            else
            { 
                if (this.SelPicNames.Count==FormConfigUtil.PrintPicListCount)
                {
                    MessageBox.Show($"您最多只能选择{FormConfigUtil.PrintPicListCount}张图片");
                    return;
                }
                this.SelPicNames.Add(pic.Name);
            }
            pic.Invalidate();
        }


        #region 内部函数
        public void InitData(PrintSettingParam setting)
        {
            this.SettingParam = setting;
            var imageList = setting.Images;
            if (imageList != null)
            {
                this.Images = imageList.Select(x => new ImageEditParam
                {  
                    YuanImg = x.YuanImg,
                    DetailImg = x.YuanImg,
                    SuoImg = ImageUtil.CreateThumbnailImage(x.YuanImg, 154, 134),
                    //裁剪的图片
                    ScreenshotImg =x.YuanImg,  
                    ScreenshotImgSuo=ImageUtil.CreateThumbnailImage(x.YuanImg,196,265),
                    ImagePath = x.ImagePath,
                    ImageType = x.ImageType
                }).ToList();
            }
            else
            {
                this.Images = new List<ImageEditParam>();
            }
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
            if (this.Images == null)
            {
                this.Images = new List<ImageEditParam>();
            }
            if (this.PicList == null)
            {
                this.PicList = new List<PictureBox>();
            }
            var y = 3;
            for (int i = 0; i <FormConfigUtil.EditPicListCount; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new System.Drawing.Point(3, y);
                pic.Name = "pic" + i;
                pic.Tag = i;
                pic.Size = new System.Drawing.Size(125, 130);
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
                    pic.Image =null;
                }
                this.PicList.Add(pic);
                y += 140;
            }
            this.picPanel.Controls.AddRange(this.PicList.ToArray());
            this.SetDetailImg();
            this.SetCaiImg();
        }

        /// <summary>
        /// 设置图片明细
        /// </summary>
        private void SetDetailImg()
        {
            var firstImg = this.Images.Where(x => x != null && x.YuanImg != null).FirstOrDefault();
            if (firstImg != null)
            {
                this.detailPic.Image = firstImg.DetailImg;
            }
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
        /// 设置裁剪图片
        /// </summary>
        private void SetCaiImg()
        {
            var detailImg = this.detailPic.Image;
            var firstImg = this.Images.Find(x => x != null && x.DetailImg==detailImg);
            if (firstImg != null)
            {
                this.showPic.Image = firstImg.ScreenshotImgSuo;
            }
        }

        protected override void CloseForm()
        {
            base.CloseForm();
            this.Close();
        }
        #endregion
        /// <summary>
        /// 打印
        /// </summary>
        private void printBtn_Click(object sender, EventArgs e)
        {
            var list = new List<ImageEditParam>();
            this.SelPicNames.ForEach(x => {
                var pic = this.PicList.Find(y => y.Name == x);
                var imgParam = this.Images.Find(z => z.SuoImg == pic.Image);
                var imageEdit = new ImageEditParam
                {
                    YuanImg = imgParam.YuanImg,
                    ScreenshotImg = imgParam.ScreenshotImg,
                    ImagePath = imgParam.ImagePath,
                    ImageType = imgParam.ImageType
                };
                list.Add(imageEdit);
            });
            var printForm = new PrintForm(list,"A3");
            printForm.ShowDialog();
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (this.SelPicNames==null||this.SelPicNames.Count==0)
            {
                MessageBox.Show("请选择图片再进行保存");
                return;
            }
            this.SelPicNames.ForEach(x=> {
                var pic=this.PicList.Find(y => y.Name == x);
                var imgParam = this.Images.Find(z => z.SuoImg == pic.Image);
                var img = imgParam.ScreenshotImg;
                string fileName= Guid.NewGuid().ToString("N") + "." +imgParam.ImageType;
                this.WriteImg(img,fileName);
            });
            MessageBox.Show("保存成功！");
        }
        private async void WriteImg(Image img,string fileName)
        {
           await Task.Run(()=>{
                var path = FormConfigUtil.LocationPath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var saveImgClone = (img.Clone()) as Image;
                //写入本地持久化关联
                MemoryStream mStream = new MemoryStream();
                byte[] ImgByte = null;
                Bitmap bmp = new Bitmap(saveImgClone);
                bmp.Save(mStream, ImageFormat.Png);
                ImgByte = mStream.ToArray();
                bmp.Dispose();
                mStream.Close();
                MemoryStream mstream = new MemoryStream(ImgByte);
                var image = Image.FromStream(mstream);
                image.Save(path + "/" + fileName);
                mstream.Close();
            });
        }
    }
}

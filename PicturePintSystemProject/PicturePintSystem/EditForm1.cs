using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicturePintSystem;
using PicturePintSystem.Comm;
using System.IO;
using System.Drawing.Imaging;
using PicturePinSystemModel;

namespace PicturePintSystem
{
    public partial class EditForm1 : BaseForm1
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
        /// 当前应保存到磁盘的文件
        /// </summary>
        public ImageParamEdit SaveImg { get; set; }

        public EditForm1(PrintSettingParam setting)
        {
            InitializeComponent();
            //初始化数据
            this.InitData(setting);
        }
        #region 内部逻辑处理
        public void InitData(PrintSettingParam setting)
        {
            this.SettingParam = setting;
            var imageList = setting.Images;
            if (imageList!=null)
            {
                this.Images = imageList.Select(x => new ImageParamEdit {
                    YuanImg=x.YuanImg,
                    DetailImg=x.YuanImg,
                    SuoImg=ImageUtil.CreateThumbnailImage(x.YuanImg,154,134),
                    ImagePath=x.ImagePath,
                    ImageType=x.ImageType 
                }).ToList();
                //写死赋值保存的图片
                this.SaveImg = this.Images.FirstOrDefault();
            }
            else
            {
                this.Images = new List<ImageParamEdit>();
            }
        }
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
            var y = 22;
            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new System.Drawing.Point(29,y);
                pic.Name = "pic" + i;
                pic.Tag = i;
                pic.Size = new System.Drawing.Size(154,134);
                pic.TabIndex = 0;
                pic.TabStop = false;
                pic.Cursor = Cursors.Hand;
                //pic.Click += picPicBox_Click;
                //pic.Paint += picPicBox_Paint;
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
                this.SetDetailImg();
                y += 145;
            }
            this.picPanel.Controls.AddRange(this.PicList.ToArray());
        }
        /// <summary>
        /// 设置图片明细
        /// </summary>
        private void SetDetailImg()
        {

        }
        #endregion
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void EditForm_Load(object sender, EventArgs e)
        {  
            //队列控件
            this.LoadImgList();
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            var fileName =Guid.NewGuid().ToString("N")+"."+this.SaveImg.ImageType;
            var path = FormConfigUtil.LocationPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var saveImgClone=(this.SaveImg.YuanImg.Clone()) as Image;
            //写入本地持久化关联
            MemoryStream mStream = new MemoryStream();
            byte[] ImgByte = null;
            Bitmap bmp = new Bitmap(saveImgClone);
            bmp.Save(mStream, ImageFormat.Png);
            ImgByte = mStream.ToArray();
            bmp.Dispose();
            mStream.Close();
            MemoryStream mstream = new MemoryStream(ImgByte);
            var image= Image.FromStream(mstream);
            image.Save(path + "/" + fileName);
            mstream.Close();
        }
    }
}

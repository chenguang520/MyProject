using DrawCoreLib;
using PicEditNew.PicEditControl;
using PicturePinSystemModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicEditNew
{
    public partial class MainForm : Form
    {   
        public Action<Image> Action { get; set;}
        /// <summary>
        /// 需要保存的图片
        /// </summary>
        public Image PrintImage { get; set; }

        public ImageEditRequest Request { get; set; }
        /// <summary>
        /// 打印页面窗体
        /// </summary>
        public Form PrintForm { get; set; }

        public MainForm()
        {
            InitializeComponent();

        }
        public MainForm(ImageEditRequest request,Action<Image> action)
        {
            InitializeComponent();
            //加载当前数据
            this.LoadData(request,action);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void LoadData(ImageEditRequest request, Action<Image> action)
        {
            this.Request = request;
            this.Action = action;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //注册控件消息
            userControlPicEdit.OnPrintEditPic += UserControlPicEdit_OnPrintEditPic;
            userControlPicEdit.OnSaveEditPic += UserControlPicEdit_OnSaveEditPic;
            //图片保存的位置
            userControlPicEdit.ImageSavePath = this.Request.SaveImgPath;
            //AddPicToEdit();
            this.AddPicToEditNew();
        }

        /// <summary>
        /// 保存之后的回调
        /// </summary>
        private void UserControlPicEdit_OnSaveEditPic(UserControlPicEdit ctrl, Bitmap bitmap)
        {
            this.PrintImage = bitmap;
        }
        /// <summary>
        /// 打印之后的回调
        /// </summary>
        private void UserControlPicEdit_OnPrintEditPic(UserControlPicEdit ctrl, Bitmap bitmap)
        {
            this.PrintImage = bitmap;
            if (this.Action!=null)
            {
                this.Action(bitmap);
            }
        }
        private void AddPicToEditNew()
        {
            try
            {
                var printSize = new SizeParam(this.Request.PrintSize);
                var paperSize = new SizeParam(this.Request.PaperSize);
                //设置纸张 印刷区域大小
                userControlPicEdit.SetArea(new Size(paperSize.Width, paperSize.Height), new Size(printSize.Width,printSize.Height));
                List<ImageProperty> listImageInfo = new List<ImageProperty>();
                if (this.Request.Images != null)
                {
                    this.Request.Images.ForEach(x => {
                        ImageProperty imageInfo = new ImageProperty() { Name = x.Path };
                        imageInfo.EditImage = x.Image;
                        //设定图片显示时 初始大小
                        imageInfo.DrawSize = new Size(280, 280);
                        //显示比例 大小锁定
                        imageInfo.LockSizeRate = true;
                        listImageInfo.Add(imageInfo);
                    });
                }
                userControlPicEdit.SetImage(listImageInfo);
            }
            catch (Exception ex)
            {

            }
        }
        private void AddPicToEdit()
        {
            try
            {
                //设置纸张 印刷区域大小
                userControlPicEdit.SetArea(new Size(1024, 1024), new Size(900, 900));

                List<string> listPath = GetImagePath();

                List<ImageProperty> listImageInfo = new List<ImageProperty>();
                foreach (string path in listPath)
                {
                    ImageProperty imageInfo = new ImageProperty() { Name = path };
                    Bitmap image = new Bitmap(path, true);
                    imageInfo.EditImage = image;
                    //设定图片显示时 初始大小
                    imageInfo.DrawSize = new Size(280,280);
                    //显示比例 大小锁定
                    imageInfo.LockSizeRate = true;
                    listImageInfo.Add(imageInfo);
                }
                userControlPicEdit.SetImage(listImageInfo);
            }
            catch (Exception ex)
            {

            }
        }
        List<string> GetImagePath()
        {
            List<string> result = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(@".\pic");

            FileInfo[] fileInfoArray = directory.GetFiles();
            foreach (FileInfo info in fileInfoArray)
            {
                if (info.FullName.EndsWith(".jpg") || info.FullName.EndsWith(".png"))
                {
                    result.Add(info.FullName);

                }
            }
            return result;
        }

       
    }
    /// <summary>
    /// 编辑页面参数
    /// </summary>
    public class ImageEditRequest
    {
        /// <summary>
        ///纸张大小
        /// </summary>
        public string PaperSize;
        /// <summary>
        ///尺寸
        /// </summary>
        public string PrintSize;
        /// <summary>
        /// 图片原图
        /// </summary>
        public List<ImageDetail> Images;
        /// <summary>
        /// 图片保存的地址
        /// </summary>
        public string SaveImgPath { get; set; }
    }
    public class ImageDetail
    {
        public Image Image { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
    }
}

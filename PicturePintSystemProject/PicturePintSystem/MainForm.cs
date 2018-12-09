using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicEditNew;
using PicturePinSystemModel;
using PicturePintSystem.Comm;
using PicturePintSystem.Controllers;
using static PicturePintSystem.Comm.ImageCodeUtil;

namespace PicturePintSystem
{
    public delegate void ThreadMethood();
    public partial class MainForm : BaseForm
    {
        private Controlles service;
        private Controlles Service
        {
            get
            {
                if (service == null)
                {
                    service = Controlles.GetControlles(this);
                }
                return service;
            }
        }

        /// <summary>
        /// 保存当前队列中的图片
        /// </summary>
        public List<ImageParamEdit> Images = new List<ImageParamEdit>();
        /// <summary>
        /// 图片列表占位框
        /// </summary>
        public List<PictureBox> PicList = new List<PictureBox>();
        /// <summary>
        ///尺寸按钮
        /// </summary>
        public List<Button> SizeList { get; set; }
        /// <summary>
        /// 获取选中的PicName
        /// </summary>
        public List<string> SelPicNames = new List<string>();

        /// <summary>
        /// 印刷区域尺寸
        /// </summary>
        public string PrintSize { get; set; }
        /// <summary>
        /// 纸张大小
        /// </summary>
        public string PaperSize { get; set; }
        public MainForm()
        {
            InitializeComponent();
            this.LoadSize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //开启服务器
            this.StartService();
            this.InitForm();
            //设置默认图片
            this.SetDefaultImg();
            //加载按钮尺寸
            //this.LoadSizeBtn();

            this.LoadSizeBtnbyJson();

        }

        #region 内部方法 
        public void InitForm()
        {
            //加载Log
            this.LoadLog();
            //加载二维码
            this.LoadImageCode(this.ImageCodeBox);
            //初始化控件默认值
            this.LoadDisplay();
        }
        public async void ReloadService(Action<bool> after = null)
        {
            string ip = FormConfigUtil.IpPath;
            string port = FormConfigUtil.Host;
            await Task.Run(() => {
                try
                {
                    Service.Reload(ip, port);
                    after(true);
                }
                catch (Exception ex)
                {
                    if (after != null)
                    {
                        after(false);
                    }
                    LogUtil.WriteLog(ex.StackTrace + "=" + DateTime.Now);
                }
            });
        }

        /// <summary>
        /// 开启服务器
        /// </summary>
        private async void StartService()
        {
            //开启服务器
            await Task.Run(() => {
                try
                {
                    Service.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("端口已被占用,请重新设置端口");
                    LogUtil.WriteLog(ex.StackTrace + "=" + DateTime.Now);
                }
            });
        }

        /// <summary>
        /// 初始化控件默认值
        /// </summary>
        private void LoadDisplay()
        {
            this.ipTxt.Text = FormConfigUtil.IpPath;
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        private void StopService()
        {
            Service.Stop();
        }

        /// <summary>
        /// 加载Log
        /// </summary>
        private async void LoadLog()
        {
            await Task.Run(() =>
            {
                var path = FormConfigUtil.LogPath;
                var image = Image.FromFile(path);
                var w = this.logPic.Size.Width;
                var h = this.logPic.Size.Height;
                this.logPic.Image = ImageUtil.CreateThumbnailImage(image, w, h);
            });
        }
        /// <summary>
        ///渲染图片队列控件
        /// </summary>
        private void LoadImgList(Image image)
        {
            //设置全局控件不检测线程安全
            //Panel.CheckForIllegalCrossThreadCalls = false;
            if (this.Images == null)
            {
                this.Images = new List<ImageParamEdit>();
            }
            if (this.PicList == null)
            {
                this.PicList = new List<PictureBox>();
                //添加默认图片
                CheckDefaultImg();
            }
            var x = 20;
            for (int i = 0; i < FormConfigUtil.MainPicListCount; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new System.Drawing.Point(x, 13);
                pic.Name = "pic" + i;
                pic.Tag = i;
                pic.Size = new System.Drawing.Size(90, 90);
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
                    //为null自动不可见,Visible影响性能
                    pic.Image = null;
                }
                this.PicList.Add(pic);
                this.SetDetailImg();
                x += 110;
            }
            this.picPanel.Controls.AddRange(this.PicList.ToArray());
        }
        /// <summary>
        /// 是否显示默认图片
        /// </summary>
        public void CheckDefaultImg()
        {
            if (this.PicList.Count == 0)
            {
                var path = Application.StartupPath + "/Content/Image/noimg.jpg";
                var defaultImg = Image.FromFile(path);
                var detailW = this.detailPic.Width;
                var detailH = this.detailPic.Height;
                var detailImg = ImageUtil.CreateThumbnailImage(defaultImg, detailW, detailH);
                detailImg.Tag = "defaultImg";
                this.detailPic.Image = detailImg;
            }
        }
        /// <summary>
        /// 设置默认图片
        /// </summary>
        public void SetDefaultImg()
        {
            var path = Application.StartupPath + "/Content/Image/noimg.jpg";
            var defaultImg = Image.FromFile(path);
            var detailW = this.detailPic.Width;
            var detailH = this.detailPic.Height;
            var detailImg = ImageUtil.CreateThumbnailImage(defaultImg, detailW, detailH);
            detailImg.Tag = "defaultImg";
            this.detailPic.Image = detailImg;
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
            else
            {
                //设为默认图片显示
                this.SetDefaultImg();
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
        /// <summary>
        /// 加入到图片队列
        /// </summary>
        public void PushImages(Image img, string imgPath, string imgType, ResoponseResult resoponse = null)
        {
            if (resoponse != null)
            {
                resoponse.Count++;
                resoponse.Code = "ok";
                resoponse.Message = $"上传{resoponse.Count}张图片成功！";
            }
            var detailW = this.detailPic.Size.Width;
            var detailH = this.detailPic.Size.Height;
            var width = 150;
            var height = 150;
            //构建Pic容器
            var x = 20;
            var y = 0;
            var tag = 0;
            //获取最后一个Pic
            var lastPic = this.PicList.LastOrDefault();
            if (lastPic != null)
            {
                x = lastPic.Location.X + 170;
                y = lastPic.Location.Y;
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
            var imgParam = new ImageParamEdit
            {
                YuanImg = img,
                SuoImg = ImageUtil.CreateThumbnailImage(img, width, height),
                DetailImg = ImageUtil.CreateThumbnailImage(img, detailW, detailH),
                IsUpImg = true,
                ImagePath = imgPath,
                ImageType = imgType
            };
            pic.Image = imgParam.SuoImg;
            this.PicList.Add(pic);
            this.Images.Add(imgParam);
            //添加缩略图
            if (this.picPanel.InvokeRequired)
            {
                ThreadMethood t = () => {
                    this.picPanel.Controls.Add(pic);
                    this.SetDetailImg();
                };
                this.picPanel.Invoke(t);
            }
            else
            {
                this.picPanel.Controls.Add(pic);
                this.SetDetailImg();
            }
        }

        /// <summary>
        /// 选择本地图片
        /// </summary>
        private void detailPic_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPEG|*.jpeg|JPG|*.jpg|GIF|*.gif|PNG|*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            var detailW = this.detailPic.Size.Width;
            var detailH = this.detailPic.Size.Height;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                var img = Image.FromFile(path);
                var type = Path.GetFileName(openFileDialog.FileName);
                var result = new ResoponseResult();
                this.PushImages(img, path, type, result);
                if (result.Code == "errorMax")
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                this.detailPic.Image = ImageUtil.CreateThumbnailImage(img, detailW, detailH);
            }
        }
        /// <summary>
        /// 加载尺寸按钮
        /// </summary>
        private async void LoadSizeBtn()
        {
            await Task.Run(() => {
                int maxCount = 7;
                int y = 25;
                int x = 30;
                int rightY = 21;
                ThreadMethood t = () => {
                    var btnList = new List<Button>();
                    var backColor = System.Drawing.Color.Teal;
                    var font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    var foreColor = System.Drawing.Color.White;
                    var tabIndex = 0;
                    var useVisualStyleBackColor = false;
                    var cursor = Cursors.Hand;
                    int width = 120;
                    int height = 70;
                    int marginY = 110;
                    int marginX = 40;
                    //先竖后横
                    for (int i = 0; i < maxCount; i++)
                    {
                        Button btn = new Button();
                        btn.BackColor = backColor;
                        btn.Font = font;
                        btn.ForeColor = foreColor;
                        btn.Location = new System.Drawing.Point(x, y);
                        btn.Name = "sizeBtn" + i;
                        btn.Size = new System.Drawing.Size(width, height);
                        btn.TabIndex = tabIndex;
                        btn.Cursor = cursor;
                        btn.Tag = "PrintSize";
                        if (i < 4)
                        {
                            btn.Text = $"{i + 1}寸";
                        }
                        else
                        {
                            btn.Text = $"{i + 2}寸";
                        }
                        btn.UseVisualStyleBackColor = useVisualStyleBackColor;
                        btn.Click += sizeBtn_Click;
                        btnList.Add(btn);
                        //前四个 画两列
                        if (i != 4 && i != 6)
                        {
                            Button btnRight = new Button();
                            btnRight.BackColor = backColor;
                            btnRight.Font = font;
                            btnRight.ForeColor = foreColor;
                            btnRight.Cursor = cursor;
                            if (i == 3)
                            {
                                btnRight.Size = new System.Drawing.Size(width, height * 2 + 30);
                            }
                            else if (i == 5)
                            {
                                btnRight.Size = new System.Drawing.Size(width, height * 2 + 30);
                            }
                            else
                            {
                                btnRight.Size = new System.Drawing.Size(width, height);
                            }
                            btnRight.Location = new System.Drawing.Point(x + width + marginX, y);
                            btnRight.Name = "sizeBtn_Right";
                            btnRight.TabIndex = tabIndex;
                            if (i == 0)
                            {
                                btnRight.Text = "10寸";
                                btnRight.Tag = "PrintSize";
                            }
                            else if (i == 1)
                            {
                                btnRight.Text = "A3";
                                btnRight.Tag = "PaperSize";
                            }
                            else if (i == 2)
                            {
                                btnRight.Text = "A4";
                                btnRight.Tag = "PaperSize";
                            }
                            else if (i == 3)
                            {
                                btnRight.Text = "自定义尺寸";
                                btnRight.Tag = "PrintSizeSet";
                            }
                            else if (i == 5)
                            {
                                btnRight.Text = "自定义大小";
                                btnRight.Tag = "PaperSizeSet";
                            }
                            btnRight.UseVisualStyleBackColor = useVisualStyleBackColor;
                            btnRight.Click += sizeBtn_Click;
                            btnList.Add(btnRight);
                        }
                        y += marginY;
                    }
                    this.SizeList = btnList;
                    this.btnPanel.Controls.AddRange(btnList.ToArray());
                };
                if (this.btnPanel.InvokeRequired)
                {
                    this.btnPanel.Invoke(t);
                }
                else
                {
                    t();
                }
            });
        }

        /// <summary>
        /// 加载尺寸按钮（读配置）
        /// </summary>
        private async void LoadSizeBtnbyJson()
        {
            var btndetails = ConfigUtil.FormConfig.ButtonDeatils;
            if (btndetails == null||btndetails.Count==0)
            {
                return;
            }
            await Task.Run(() => {
                ThreadMethood t = () => {
                    var btnList = new List<Button>();
                    var backColor = System.Drawing.Color.Black;
                    var font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    var foreColor = System.Drawing.Color.White;
                    var tabIndex = 0;
                    var useVisualStyleBackColor = false;
                    var cursor = Cursors.Hand;
                    var startBtn = btndetails.Find(j => j.IsStartPosition);
                    int startx = startBtn.X != null ? (int)startBtn.X : 120;
                    int starty = startBtn.Y != null ? (int)startBtn.Y : 70;
                    int x =startx;
                    int y= starty;
                    for (int i = 0; i <btndetails.Count; i++)
                    {   
                        var btndetail = btndetails[i];
                        int width = btndetail.Width != null ? (int)btndetail.Width : 70;
                        int height = btndetail.Height != null ? (int)btndetail.Height : 50;
                        Button btn = new Button();
                        btn.BackColor = backColor;
                        btn.Font = font;
                        btn.ForeColor = foreColor;
                        btn.TabIndex = tabIndex;
                        btn.Cursor = cursor;
                        btn.UseVisualStyleBackColor = useVisualStyleBackColor;
                        btn.Click += sizeBtn_Click;
                        btn.Name = "sizeBtn" + i;
                        btn.Text = btndetail.Text;
                        btn.Size = new System.Drawing.Size(width, height);
                        btn.Location = new System.Drawing.Point(x, y);
                        var btnType = btndetail.BtnType;
                        if (btnType == "PrintSize")
                        {
                            btn.Tag = "PrintSize";
                        }
                        else if (btnType == "PaperSize")
                        {
                            btn.Tag = "PaperSize";
                        }
                        else if (btnType == "PrintSizeSet")
                        {
                            btn.Tag = "PrintSizeSet";
                        }
                        else if (btnType == "PaperSizeSet")
                        {
                            btn.Tag = "PaperSizeSet";
                        }
                        if (btndetail.IsLast)
                        {
                            y = starty;
                            x +=width+ (int)btndetail.MarginX;
                        }
                        else {
                            y += height +(int)btndetail.MarginY;
                        }
                        btnList.Add(btn);
                    }
                    this.SizeList = btnList;
                    this.btnPanel.Controls.AddRange(btnList.ToArray());                 
                };
                if (this.btnPanel.InvokeRequired)
                {
                    this.btnPanel.Invoke(t);
                }
                else
                {
                    t();
                }
            });
        }
        /// <summary>
        /// 打印按钮
        /// </summary>
        private void printBtn_Click(object sender, EventArgs e)
        {
            if (!this.CheckImg(FormConfigUtil.PrintPicListCount))
            {
                return;
            }
            var list = new List<ImageEditParam>();
            this.SelPicNames.ForEach(x => {
                var pic = this.PicList.Find(y => y.Name == x);
                var imgParam = this.Images.Find(z => z.SuoImg == pic.Image);
                var imageEdit = new ImageEditParam {
                     YuanImg=imgParam.YuanImg,
                     ScreenshotImg=imgParam.YuanImg,
                     ImagePath=imgParam.ImagePath,
                     ImageType=imgParam.ImageType 
                };
                list.Add(imageEdit);
            });
            var printForm = new PrintForm(list,this.PaperSize);
            printForm.ShowDialog();
        }

        #endregion
        /// <summary>
        /// 尺寸按钮点击事件
        /// </summary>
        private void sizeBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var text = btn.Text;
            var tag = btn.Tag as string;

            //清除其余的尺寸
            this.SizeList.ForEach(x => {
                if (btn != x && ((tag.Equals("PrintSizeSet") && x.Tag.Equals("PrintSize")) || (tag.Equals("PrintSize") && x.Tag.Equals("PrintSizeSet"))))
                {
                    x.ForeColor = Color.White;
                }
                else if (btn != x && ((tag.Equals("PaperSize") && x.Tag.Equals("PaperSizeSet")) || (tag.Equals("PaperSizeSet") && x.Tag.Equals("PaperSize"))))
                {
                    x.ForeColor = Color.White;
                }
                else if (btn != x && x.Tag.Equals(tag))
                {
                    x.ForeColor = Color.White;
                }
            });
            btn.ForeColor = Color.Blue;
            //印刷大小
            if (tag == "PrintSize")
            {
                this.PrintSize=ImageSizeUtil.ConverntPaperSize(text);
            }
            //纸张大小
            else if (tag == "PaperSize")
            {
                this.PaperSize = ImageSizeUtil.ConverntPaperSize(text);
            }
            //自定义尺寸
            else if (tag == "PrintSizeSet")
            {
                var defaultSize = "";
                if (this.PrintSize!=null)
                {
                    defaultSize = this.PrintSize.ToString();
                }
                var size=this.ShowSize(defaultSize);
                if (!string.IsNullOrEmpty(size)&&size!= "empty")
                {
                    this.PrintSize =size;
                }
            }
            //自定义大小
            else if (tag == "PaperSizeSet")
            {
                var defaultSize = "";
                if (this.PaperSize != null)
                {
                    defaultSize = this.PaperSize.ToString();
                }
                var size = this.ShowPaperSize(defaultSize);
                if (!string.IsNullOrEmpty(size)&&size!= "empty")
                {
                    this.PaperSize = size;
                }
            }

        }
        
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.StopService();
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Task.Run(()=> {
                if (this.detailPic == null)
                {
                    return;
                }
                if (this.detailPic.Size == null)
                {
                    return;
                }
                var width = this.detailPic.Size.Width;
                var height = this.detailPic.Size.Height;
                if (this.Images != null)
                {
                    var img = this.Images.Find(x => x.DetailImg == this.detailPic.Image);
                    if (img != null)
                    {
                        var newImg = ImageUtil.CreateThumbnailImage(img.YuanImg, width, height);
                        this.detailPic.Image = newImg;
                        img.DetailImg = newImg;
                    }

                }
            });
        }
        /// <summary>
        /// 校验
        /// </summary>
        private bool CheckImg(int? maxCount)
        {
            if (string.IsNullOrEmpty(this.PaperSize))
            {
                MessageBox.Show("请选择纸张大小,再进行操作");
                return false;
            }
            else if (this.PrintSize == null)
            {
                MessageBox.Show("请选择印刷区域尺寸,再进行操作");
                return false;
            }
            else if (this.SelPicNames == null || this.SelPicNames.Count == 0)
            {
                MessageBox.Show("请选择图片,再进行操作");
                return false;
            }
            else if (this.SelPicNames != null)
            {
                if (this.SelPicNames.Count > maxCount)
                {
                    MessageBox.Show($"您最多只能选择{maxCount}张图片");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (!this.CheckImg(FormConfigUtil.EditPicListCount))
            {
                return;
            }
            var list = new List<ImageDetail>();
            this.SelPicNames.ForEach(x => {
                var pic = this.PicList.Find(y => y.Name == x);
                if (pic != null)
                {
                    //获取图片框保存的图片
                    var img = pic.Image;
                    //获取对应的图片所有资源
                    var image = this.Images.Find(z => z.SuoImg == img);
                    //保存原图
                    list.Add(new ImageDetail
                    {
                        Image = image.YuanImg,
                         Path = image.ImagePath,
                         Type = image.ImageType
                    });
                }
            });
            //配置图片参数，提交给子窗体
            var printParam = new ImageEditRequest
            {
                Images = list,
                PaperSize = this.PaperSize,
                PrintSize = this.PrintSize,
                SaveImgPath=FormConfigUtil.LocationPath   
            };
            EditFormFactory.ShowEditForm(printParam,img=> {
                var  imageEditList= new List<ImageEditParam>();
                var imageEdit1 = new ImageEditParam
                {
                    YuanImg = img,
                    ScreenshotImg = img
                };
                imageEditList.Add(imageEdit1);
                var printForm = new PrintForm(imageEditList,this.PaperSize);
                printForm.ShowDialog();
            });
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (this.ipTxt.Text=="")
            {
                MessageBox.Show("IP不能为空！");
                return;
            }
            this.LoadImageCode(this.ImageCodeBox, this.ipTxt.Text);
        }
        /// <summary>
        /// 移除选择的图片
        /// </summary>
        private void RemoveSelect(PictureBox pic)
        {
            if (pic != null)
            {
                this.SelPicNames.Remove(pic.Name);
                pic.Invalidate();
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
            for (int i = 0; i <picCopy.Count(); i++)
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
            //设置默认图片
            this.SetDetailImg();
        }

        /// <summary>
        /// 删除选中的图片
        /// </summary>
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.SelPicNames == null || this.SelPicNames.Count == 0)
            {
                MessageBox.Show("请选择您要移除的图片！");
                return;
            }
            var result = MessageBox.Show("您确定要移除选中的图片吗？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                var images = this.PicList.Where(x => this.SelPicNames.Contains(x.Name)).Select(x => x.Image);
                this.Images.RemoveAll(x => images.Contains(x.SuoImg));
                this.RefImgList();
                this.SelPicNames.Clear();
            }
        }

        #region 加载尺寸
        protected override void LoadSize()
        {
            base.LoadSize();
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using DrawCoreLib;

namespace PicEditNew.PicEditControl
{
    public partial class UserControlPicEdit : UserControl
    {
        ImageEditInfoGroup _imageGroup = new ImageEditInfoGroup();
        ImageEditManage _imageEditManage = new ImageEditManage();
        MouseActionInfo _mouseActionOfPrintArea = new MouseActionInfo();
       
        /// <summary>
        /// 图片保存路径
        /// </summary>
        public string ImageSavePath { get; set; }

        public event Action<UserControlPicEdit, Bitmap> OnSaveEditPic;
        public event Action<UserControlPicEdit, Bitmap> OnPrintEditPic;

        public UserControlPicEdit()
        {
            InitializeComponent();

            _imageEditManage.ImageGroup = _imageGroup;
            _imageEditManage.ParentPanel = panelPrintArea;
            _imageEditManage.MouseAction = _mouseActionOfPrintArea;

            _imageEditManage.EventImageSizeChanged += SelectImage_SizeChanged;
            ShowPrintAreaProperty();
        }

        #region 外部调用
        public void SetArea(Size paper, Size printArea)
        {
            panelEditPaper.Location = new Point(20, 20);
            panelEditPaper.Size = paper;

            panelPrintArea.Size = printArea;
            SetPrintAreaInCenter();
        }

        void SetPrintAreaInCenter()
        {
            panelPrintArea.Location = new Point((panelEditPaper.Width - panelPrintArea.Width) / 2,
                    (panelEditPaper.Height - panelPrintArea.Height) / 2);
            panelPrintArea.Refresh();
            if (_selectAreaType == ENAreaType.打印区域)
            {
                ShowPrintAreaProperty();
            }
        }

        public void SetImage(List<ImageProperty> listImage)
        {
            listBoxImage.Visible = false;
            listBoxImage.ClearItems();
            foreach (ImageProperty info in listImage)
            {
                listBoxImage.AddImage(info);
            }
            listBoxImage.Visible = true;
        }
        #endregion

        private void listBoxImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxImage.SelectedItem == null)
                return;

            ImageProperty item = listBoxImage.SelectedItem as ImageProperty;
            if (item == null)
                return;

            AddImageToEdit(item);
        }


        private void AddImageToEdit(ImageProperty imageInfo)
        {
            ImageEditInfo info = new ImageEditInfo() { ImageProperty = imageInfo };
            info.Location = new Point(100, 100);
            if (imageInfo.LockSizeRate)
                info.AdjustRateByWidth();

            _imageGroup.AddImage(info);
            _imageEditManage.ShowInCenter(info);
            panelPrintArea.Refresh();
        }

        private void panelEditPaper_Paint(object sender, PaintEventArgs e)
        {
            if (_selectAreaType == ENAreaType.纸张)
            {
                ShowPanelSelect(e.Graphics, panelEditPaper);
            }
        }

        private void panelEditPaper_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelect(ENAreaType.纸张);
            ShowPaperProperty();
        }
        private void ShowPaperProperty()
        {
            textBoxPicX.Text = panelEditPaper.Location.X.ToString();
            textBoxPicY.Text = panelEditPaper.Location.Y.ToString();

            textBoxPicHieght.Text = panelEditPaper.Height.ToString();
            textBoxPicWidth.Text = panelEditPaper.Width.ToString();
        }

        private void panelEditPaper_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panelEditPaper_MouseMove(object sender, MouseEventArgs e)
        {

        }


        #region  panelPrintArea 打印区

        public Pen SelectBorderPen = new Pen(Color.Red, 1);
        SolidBrush SelectCornerBrush = new SolidBrush(Color.FromArgb(200, 255, 0, 0));
        int SelectCornerRadius = 5;

        public int OutCtrlPadding = 2;
        public int SelectLineWith = 1;
        DrawProperty _drawProperty = new DrawProperty();
        private void panelPrintArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _imageEditManage.Draw(g);

            //画选中状态
            if (_selectAreaType == ENAreaType.打印区域)
            {
                ShowPanelSelect(g, panelPrintArea);
            }

            //显示信息
            string info = string.Format($"({panelPrintArea.Location.X},{panelPrintArea.Location.Y}) ({panelPrintArea.Width}X{panelPrintArea.Height})");

            SizeF sizeF = g.MeasureString(info, _drawProperty.TxtFont);
            g.FillRectangle(_drawProperty.TxtBackgroundBrush,
                new RectangleF(new Point(), sizeF));

            g.DrawString(info, _drawProperty.TxtFont, _drawProperty.TxtBrush, new Point());
        }

        void ShowPanelSelect(Graphics g, Panel panel)
        {
            int totalPadding = OutCtrlPadding + SelectLineWith;
            int startX = 0;
            int startY = 0;
            int width = panel.Width - 1;
            int height = panel.Height - 1;

            g.DrawRectangle(SelectBorderPen, startX, startY, width, height);

            int len = 2 * SelectCornerRadius;
            g.FillEllipse(SelectCornerBrush, startX - SelectCornerRadius, startY - SelectCornerRadius, len, len);

            g.FillEllipse(SelectCornerBrush, startX + width - SelectCornerRadius, startY - SelectCornerRadius, len, len);
            g.FillEllipse(SelectCornerBrush, startX + width - SelectCornerRadius, startY + height - SelectCornerRadius, len, len);
            g.FillEllipse(SelectCornerBrush, startX - SelectCornerRadius, startY + height - SelectCornerRadius, len, len);

        }

        private void panelPrintArea_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseActionOfPrintArea.MousePress = true;
            _mouseActionOfPrintArea.LastMouseScreenPoint = panelPrintArea.PointToScreen(e.Location);

            if (_curSpliteDir == EN_LinePart.无)
            {
                _imageEditManage.OnMouseDown(sender, e);

                if (!_imageEditManage.ImageGroup.HasSelectImage)
                {
                    SetSelect(ENAreaType.打印区域);
                    ShowPrintAreaProperty();
                }
                else
                {
                    SetSelect(ENAreaType.图片);
                }
            }
            else
            {
                if (_imageEditManage.ImageGroup.HasSelectImage)
                {
                    if (DrawHelper.IsRotationAdjust(_curSpliteDir))
                    {
                        ImageEditInfo image = _imageEditManage.ImageGroup.SelectImage;
                        Point pt = image.GetRotationPoint(_curSpliteDir);

                        Point ptOfCenter = DrawHelper.RotationAt(pt, image.Location, image.RotateAngle, true);
                        _mouseActionOfPrintArea.RotationCenter = panelPrintArea.PointToScreen(ptOfCenter);
                    }
                }
            }
        }

        //设置图片旋转点
        private void ToolStripMenuItemSetRotationBase_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (_imageEditManage.ImageGroup.HasSelectImage)
            {
                ImageEditInfo image = _imageEditManage.ImageGroup.SelectImage;
                if (menuItem.Tag.ToString() == "add")
                {
                    _imageEditManage.SetRotationBasePoint(image, _mouseActionOfPrintArea.LastMouseScreenPoint);
                }
                else if (menuItem.Tag.ToString() == "del")
                {
                    _imageEditManage.DelRotationBasePoint(image);
                }
                panelPrintArea.Refresh();
            }
        }

        private void ShowPrintAreaProperty()
        {
            textBoxPicX.Text = panelPrintArea.Location.X.ToString();
            textBoxPicY.Text = panelPrintArea.Location.Y.ToString();

            textBoxPicHieght.Text = panelPrintArea.Height.ToString();
            textBoxPicWidth.Text = panelPrintArea.Width.ToString();
        }

        private void panelPrintArea_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseActionOfPrintArea.MousePress = false;
            _imageEditManage.OnMouseUp(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                Point curPoint = panelPrintArea.PointToScreen(e.Location);

                if (_imageEditManage.ImageGroup.HasSelectImage)
                {
                    contextMenuOfPrintAreaPic.Show(curPoint);
                }
                else
                {
                    contextMenuStripPintArea.Show(curPoint);
                }
            }
        }

        private void panelPrintArea_MouseMove(object sender, MouseEventArgs e)
        {
            _imageEditManage.OnMouseMove(sender, e);

            Point ptToScreen = panelPrintArea.PointToScreen(e.Location);
            //调整所选图片大小
            if (_mouseActionOfPrintArea.MousePress
                && _imageEditManage.ImageGroup.HasSelectImage
                && _curSpliteDir != EN_LinePart.无)
            {
                ImageEditInfo selectImage = _imageEditManage.ImageGroup.SelectImage;
                if (_imageEditManage.AdjustImage(_curSpliteDir, selectImage, ptToScreen))
                {
                    if (selectImage.LockSizeRate && DrawHelper.IsSizeAdjust(_curSpliteDir))
                    {
                        if (_curSpliteDir == EN_LinePart.上 || _curSpliteDir == EN_LinePart.下)
                        {
                            selectImage.AdjustRateByHeight();

                        }
                        else
                        {
                            selectImage.AdjustRateByWidth();
                        }
                    }

                    ShowImageProperty(_imageEditManage.ImageGroup.SelectImage);
                    panelPrintArea.Refresh();
                }
                _mouseActionOfPrintArea.LastMouseScreenPoint = ptToScreen;
                return;
            }

            //移动 打印区域
            if (_mouseActionOfPrintArea.MousePress
                && !_imageEditManage.ImageGroup.HasSelectImage)
            {
                int xSpan = ptToScreen.X - _mouseActionOfPrintArea.LastMouseScreenPoint.X;
                int ySpan = ptToScreen.Y - _mouseActionOfPrintArea.LastMouseScreenPoint.Y;

                panelPrintArea.Location = new Point(panelPrintArea.Location.X + xSpan, panelPrintArea.Location.Y + ySpan);
                panelPrintArea.Refresh();
                panelEditPaper.Refresh();

                ShowPrintAreaProperty();
            }

            if (!_mouseActionOfPrintArea.MousePress) //探测鼠标所在位置
            {
                SetSpliteOperation(e.Location);
            }

            _mouseActionOfPrintArea.LastMouseScreenPoint = ptToScreen;
        }


        public Point PointPicToScreen(Point pt)
        {
            return panelPrintArea.PointToScreen(pt);
        }
        public Point PointPicToClient(Point pt)
        {
            return panelPrintArea.PointToClient(pt);
        }

        EN_LinePart _curSpliteDir = EN_LinePart.无;
        private void SetSpliteOperation(Point location)
        {
            _curSpliteDir = _imageGroup.MouseMove_HitTest(location);
            if (_curSpliteDir == EN_LinePart.上 || _curSpliteDir == EN_LinePart.下)
            {
                Cursor = Cursors.HSplit;
            }
            else if (_curSpliteDir == EN_LinePart.左 || _curSpliteDir == EN_LinePart.右)
            {
                Cursor = Cursors.VSplit;
            }
            else if (DrawHelper.IsRotationAdjust(_curSpliteDir))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void menuDeletePic_Click(object sender, EventArgs e)
        {
            ImageEditInfo image = _imageEditManage.ImageGroup.SelectImage;
            if (image == null)
            {
                Debug.Assert(false);
                return;
            }

            _imageEditManage.ImageGroup.DeleteImage(image);
            panelPrintArea.Refresh();
        }

        private void menuShowInCenter_Click(object sender, EventArgs e)
        {
            ImageEditInfo image = _imageEditManage.ImageGroup.SelectImage;
            if (image == null)
            {
                Debug.Assert(false);
                return;
            }

            _imageEditManage.ShowInCenter(image);
            panelPrintArea.Refresh();
        }
        private void toolStripMenuItemShowRate_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            double rate = double.Parse(menuItem.Tag.ToString()) / 100;

            ImageEditInfo image = _imageEditManage.ImageGroup.SelectImage;
            if (image == null)
            {
                Debug.Assert(false);
                return;
            }

            _imageEditManage.AdjustSizeByRate(image, rate);
            if (!_imageEditManage.IsCanSee(image))
            {
                _imageEditManage.ShowInCenter(image);
            }
            panelPrintArea.Refresh();
        }

        #endregion

        private void buttonLayerAdjust_Click(object sender, EventArgs e)
        {
            ImageEditInfo selectPic = _imageEditManage.ImageGroup.SelectImage;
            if (selectPic == null)
            {
                return;
            }

            if (sender == buttonLayerTop)
            {
                _imageEditManage.LayerToTop(selectPic);
            }
            else if (sender == buttonLayerBottom)
            {
                _imageEditManage.LayerToBottom(selectPic);
            }
            else if (sender == buttonLayerUp)
            {
                _imageEditManage.LayerToUp(selectPic);
            }
            else if (sender == buttonLayerDown)
            {
                _imageEditManage.LayerToDown(selectPic);
            }
        }

        private void SelectImage_SizeChanged(ImageEditManage sender, ImageEditInfo image)
        {
            ShowImageProperty(image);
        }

        private void ShowImageProperty(ImageEditInfo image)
        {
            textBoxPicX.Text = image.Location.X.ToString();
            textBoxPicY.Text = image.Location.Y.ToString();

            textBoxPicWidth.Text = image.DrawSize.Width.ToString();
            textBoxPicHieght.Text = image.DrawSize.Height.ToString();
            checkBoxLockRate.Checked = image.LockSizeRate;
            checkBoxShowImageTip.Checked = image.ShowImageTip;
        }

        private void buttonSetProperty_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_selectAreaType)
                {
                    case ENAreaType.图片:
                        {
                            ImageEditInfo selectImage = _imageEditManage.ImageGroup.SelectImage;
                            if (selectImage != null)
                            {
                                Point point = new Point();
                                point.X = AppHelper.IntParse(textBoxPicX.Text);
                                point.Y = AppHelper.IntParse(textBoxPicY.Text);

                                Size size = new Size();
                                size.Width = AppHelper.IntParse(textBoxPicWidth.Text);
                                size.Height = AppHelper.IntParse(textBoxPicHieght.Text);
                                selectImage.LockSizeRate = checkBoxLockRate.Checked;

                                selectImage.Location = point;
                                selectImage.DrawSize = size;
                                if (selectImage.LockSizeRate)
                                    selectImage.AdjustRateByWidth();
                                panelPrintArea.Refresh();
                            }
                            break;
                        }

                    case ENAreaType.打印区域:
                        {
                            Point point = new Point();
                            point.X = AppHelper.IntParse(textBoxPicX.Text);
                            point.Y = AppHelper.IntParse(textBoxPicY.Text);

                            Size size = new Size();
                            size.Width = AppHelper.IntParse(textBoxPicWidth.Text);
                            size.Height = AppHelper.IntParse(textBoxPicHieght.Text);

                            panelPrintArea.Location = point;
                            panelPrintArea.Size = size;
                            panelPrintArea.Refresh();
                            break;
                        }

                    case ENAreaType.纸张:
                        {
                            //位置调整没意义 只调整大小
                            //Point point = new Point();
                            //point.X = AppHlper.IntParse(textBoxPicX.Text);
                            //point.Y = AppHlper.IntParse(textBoxPicY.Text);
                            //panelPrintArea.Location = point;

                            Size size = new Size();
                            size.Width = AppHelper.IntParse(textBoxPicWidth.Text);
                            size.Height = AppHelper.IntParse(textBoxPicHieght.Text);

                            panelEditPaper.Size = size;
                            panelEditPaper.Refresh();
                            break;
                        }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxShowImageTip_CheckedChanged(object sender, EventArgs e)
        {
            ImageEditInfo selectImage = _imageEditManage.ImageGroup.SelectImage;
            if (selectImage != null)
            {
                selectImage.ShowImageTip = checkBoxShowImageTip.Checked;
                panelPrintArea.Refresh();
            }                
        }

        private void checkBoxLockRate_CheckedChanged(object sender, EventArgs e)
        {                                                  
        }

        ENAreaType _selectAreaType = ENAreaType.打印区域;
        void SetSelect(ENAreaType areaType)
        {
            _selectAreaType = areaType;

            panelEditPaper.Refresh();
            panelPrintArea.Refresh();
        }

        private void buttonSavePic_Click(object sender, EventArgs e)
        {  
            if (sender == buttonPrint)
            {
                SaveEditPic(false);
                OnPrintEditPic?.Invoke(this, GetEditBitmap());
            }
            else 
            {
                SaveEditPic(true);
                OnSaveEditPic?.Invoke(this, GetEditBitmap());
            }
        }

        //获取编辑后的图片
        public Bitmap GetEditBitmap()
        {
            Bitmap imagePaper = DrawPaperArea();
            Bitmap imagePrint = DrawPrintArea();

            using (Graphics g = Graphics.FromImage(imagePaper))
            {
                ImageHelper.SetHighQuality(g);
                g.DrawImage(imagePrint, panelPrintArea.Location);
            }
        
            imagePrint.Dispose();
            return imagePaper;
        }

        private void SaveEditPic(bool isShowDiag=true)
        {
            try
            {
                string subPath = ".\\NewImage";
                System.IO.Directory.CreateDirectory(subPath);

                string strTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string imageFileName = string.Format($"NewImage_{strTime}.bmp");
                var imagePath = string.Format($"{this.ImageSavePath}\\{imageFileName}");
                if (string.IsNullOrEmpty(imagePath))
                {
                    imagePath = string.Format($"{subPath}\\{imageFileName}");
                }
                GetEditBitmap().Save(imagePath);

                string dir = Path.GetDirectoryName(imagePath);
                string fileName = Path.GetFileName(imagePath);

                FormPicSaveMessage dlg = new FormPicSaveMessage();
                dlg.FileName = Path.GetFileName(imagePath);
                dlg.FilePath = Path.GetDirectoryName(Path.GetFullPath(imagePath));
                dlg.Message = "图片已保存成功！";
                dlg.StartPosition = FormStartPosition.CenterScreen;
                if (isShowDiag)
                {
                    dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Bitmap DrawPaperArea()
        {
            Bitmap paperImage = new Bitmap(panelEditPaper.Width, panelEditPaper.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(paperImage))
            {
                g.Clear(panelEditPaper.BackColor);
            }
            return paperImage;
        }

        private Bitmap DrawPrintArea()
        {
            Bitmap printImage = new Bitmap(panelPrintArea.Width, panelPrintArea.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(printImage))
            {
              //  g.Clear(panelPrintArea.BackColor);
                g.Clear(Color.White);
                _imageEditManage.DrawToFile(g);
               // DrawTestFlag(g);
            }
            return printImage;
        }

        private void DrawTestFlag(Graphics g)
        {
            //显示信息
            string info = string.Format($"*******打印测试*******");

            Font TxtFont = new Font("Verdana", 22);
            g.DrawString(info, TxtFont, _drawProperty.TxtBrush, new Point(10, 100));

            g.DrawString(info, TxtFont, _drawProperty.TxtBrush, new Point(10, 300));

        }

        private void ToolStripMenuItemPintInCenter_Click(object sender, EventArgs e)
        {
            SetPrintAreaInCenter();
        }

        private void toolStripMenuItemRotationDegree_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            float angle = float.Parse(menuItem.Tag.ToString());
            if(_imageGroup.HasSelectImage)
            {
                _imageGroup.SelectImage.SetAngle(angle);
                panelPrintArea.Refresh();
            }
        }


 
    }

    public enum ENAreaType
    {
        纸张, 打印区域, 图片
    }

}

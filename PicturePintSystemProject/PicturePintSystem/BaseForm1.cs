using PicturePintSystem.Comm;
using PicturePintSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class BaseForm1 : Form
    {
        public BaseForm1()
        {
            InitializeComponent();
        }

        #region 隐藏标题栏后移动窗口
        private bool m_isMouseDown = false;
        private Point m_mousePos = new Point();
        /// <summary>
        /// 鼠标按下，开启移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_mousePos = Cursor.Position;
            m_isMouseDown = true;
        }

        /// <summary>
        /// 鼠标抬起，关闭移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_isMouseDown = false;
            this.Focus();
        }

        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (m_isMouseDown)
            {
                Point tempPos = Cursor.Position;
                this.Location = new Point(Location.X + (tempPos.X - m_mousePos.X), Location.Y + (tempPos.Y - m_mousePos.Y));
                m_mousePos = Cursor.Position;
            }

        }
        #endregion

        /// <summary>
        /// 加载二维码
        /// </summary>
        protected async void LoadImageCode(PictureBox pictureBox)
        {
            await Task.Run(() => {
                var ip = FormConfigUtil.IpPath;
                string host = FormConfigUtil.Host;
                var url = string.Format(ConfigUtil.ConfigData["imageCodeKey"], ip, host);
                var img=ImageCodeUtil.CreateImageCode(url,5);
                pictureBox.Image =ImageUtil.CreateThumbnailImage(img,pictureBox.Width,pictureBox.Height);
            });
        }
        /// <summary>
        /// 加载二维码(含IP)
        /// </summary>
        protected async void LoadImageCode(PictureBox pictureBox,string ipTxt,string host=null)
        {
            await Task.Run(() => {
                var ip = ipTxt;
                if (string.IsNullOrEmpty(host))
                {
                    host = ConfigUtil.ConfigData["host"];
                }
                var url = string.Format(ConfigUtil.ConfigData["imageCodeKey"], ip, host);
                var img = ImageCodeUtil.CreateImageCode(url, 5);
                pictureBox.Image = ImageUtil.CreateThumbnailImage(img, pictureBox.Width, pictureBox.Height);
            });
        }
       
        protected virtual void CloseForm()
        {

        }
        protected virtual void MaxForm(object sender)
        {
            var btn = sender as Button;
            var text = btn.Text;
            if (text == "最大化")
            {
                this.WindowState = FormWindowState.Maximized;
                btn.Text = "还原";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btn.Text = "最大化";
            }
        }

        protected virtual void SetForm()
        {
            var setFrom = new SettingForm();
            setFrom.ShowDialog();
        }
        protected virtual void MinForm() {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 设置尺寸
        /// </summary>
        protected virtual void LoadSize()
        {
            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Width = iActulaWidth;
            this.Height = iActulaHeight;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        /// <summary>
        /// 最大化
        /// </summary>
        private void maxBtn_Click(object sender, EventArgs e)
        {
            this.MaxForm(sender);
        }
        /// <summary>
        /// 最小化
        /// </summary>
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.MinForm();
        }
        /// <summary>
        /// 设置
        /// </summary>
        private void setbtn_Click(object sender, EventArgs e)
        {
            this.SetForm();
        }
    }
}

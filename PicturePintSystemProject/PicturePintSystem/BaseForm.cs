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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载二维码
        /// </summary>
        protected async void LoadImageCode(PictureBox pictureBox)
        {
            await Task.Run(() => {
                var ip = FormConfigUtil.IpPath;
                string host = FormConfigUtil.Host;
                var url = string.Format(ConfigUtil.ConfigData["imageCodeKey"], ip, host);
                var img = ImageCodeUtil.CreateImageCode(url, 5);
                pictureBox.Image = ImageUtil.CreateThumbnailImage(img, pictureBox.Width, pictureBox.Height);
            });
        }
        /// <summary>
        /// 加载二维码(含IP)
        /// </summary>
        protected async void LoadImageCode(PictureBox pictureBox, string ipTxt, string host = null)
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

        protected virtual void SetForm()
        {
            var setFrom = new SettingForm();
            setFrom.ShowDialog();
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
        /// 设置按钮
        /// </summary>
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            this.SetForm();
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}


using PicturePintSystem.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 取消
        /// </summary>
        private void canelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// 确定
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            base.WndProc(ref msg);
        }
        private void MessageForm_Load(object sender, EventArgs e)
        {
            List<object> list = new List<object>();
            foreach (String s in PrinterSettings.InstalledPrinters)
            {
                var item = new {
                    key=s,
                    value=s
                };
                list.Add(item);
            }
            this.selComboBox.DataSource = list;
            this.selComboBox.DisplayMember = "key";
            this.selComboBox.ValueMember = "value";
            var defaultValue = FormConfigUtil.PrintName;
            if (!string.IsNullOrEmpty(defaultValue))
            {
                this.selComboBox.SelectedValue = defaultValue;
            }
            else
            {
                this.selComboBox.SelectedIndex = 0;
            }
        }
    }
}

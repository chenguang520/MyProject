using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    public partial class SizeForm : Form
    {  
        /// <summary>
        /// 当前框内容
        /// </summary>
        public string FormType { get; set;}
        /// <summary>
        /// 默认尺寸
        /// </summary>
        public string DefaultValue { get; set; }

        public SizeForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            var txt = this.textBox1.Text;
            if (txt=="")
            {
                MessageBox.Show("尺寸不可为空");
                return;
            }
            string pattern = @"^[0-9]*[1-9][0-9]*$";
            if (!Regex.IsMatch(txt, pattern))
            {
                MessageBox.Show("请输入合法数字！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void SizeForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefaultValue))
            {
                var sizes = DefaultValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (sizes!=null&&sizes.Length>=2)
                {
                    this.textBox1.Text =sizes[0];
                    this.textBox2.Text = sizes[1];
                }
            }
        }
    }
}

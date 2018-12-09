using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicEditNew.PicEditControl
{
    public partial class FormPicSaveMessage : Form
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Message { get; set; }

        public FormPicSaveMessage()
        {
            InitializeComponent();
        }

        private void FormPicSaveMessage_Load(object sender, EventArgs e)
        {
            textBoxFileName.Text = FileName;
            textBoxFilePath.Text = FilePath;
            labelMessage.Text = Message;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOpenPath_Click(object sender, EventArgs e)
        {
            string arg = string.Format($"/select,\"{textBoxFilePath.Text}\\{textBoxFileName.Text}\"");
            System.Diagnostics.Process.Start("explorer.exe", arg);
            this.Close();
        }
    }
}

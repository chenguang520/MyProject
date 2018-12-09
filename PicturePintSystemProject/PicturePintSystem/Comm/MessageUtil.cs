using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem.Comm
{   
    /// <summary>
    /// 消息帮助类
    /// </summary>
    public static class MessageUtil
    {  
        /// <summary>
        /// 显示所有的打印机列表
        /// </summary>
        public static string ShowPrintList(this Form from)
        {
            var selPrint = string.Empty;
            var messageForm = new MessageForm() {
                 Text="请选择打印机"
            };
            var diaResult=messageForm.ShowDialog();
            if (diaResult== DialogResult.OK)
            {  
                selPrint = messageForm.selComboBox.SelectedValue.ToString();
               
            }
            return selPrint;
        }
        /// <summary>
        /// 显示尺寸
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string ShowSize(this Form from,string printSize)
        {
            var size = string.Empty;
            var messageForm = new SizeForm()
            {
                Text = "请输入尺寸大小",
                FormType= "PrintSize",
                DefaultValue=printSize
            };
            var diaResult = messageForm.ShowDialog();
            if (diaResult == DialogResult.OK)
            {
                var width = messageForm.textBox1.Text;
                var height = messageForm.textBox2.Text;
                size =width+","+height;
                if (size==",")
                {
                    size = "empty";
                }
            }
            return size;
        }
        /// <summary>
        /// 显示纸张大小
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string ShowPaperSize(this Form from,string paperSize)
        {
            var size = string.Empty;
            var messageForm = new SizeForm()
            {
                Text = "请输入纸张大小",
                FormType= "PaperSize",
                DefaultValue=paperSize  
            };
            var diaResult = messageForm.ShowDialog();
            if (diaResult == DialogResult.OK)
            {
                var width = messageForm.textBox1.Text;
                var height = messageForm.textBox2.Text;
                size =width+","+height;
                if (size == ",")
                {
                    size = "empty";
                }
            }
            return size;
        }
    }
}

using PicturePintSystem.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePintSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //加载应用程序配置
            WinApplication.StartConfig();
            var form = new MainForm();
            FormFactory.MainForm = form;
            Application.Run(form);
        }
    }
}

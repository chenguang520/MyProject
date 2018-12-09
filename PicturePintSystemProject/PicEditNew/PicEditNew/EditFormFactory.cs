using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicEditNew
{
    public class EditFormFactory
    {
        public static void ShowEditForm(ImageEditRequest request,Action<Image> action)
        {
            var mainForm = new MainForm(request,action);
            mainForm.ShowDialog();
        }
    }
}

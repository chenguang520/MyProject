using PicturePinSystemModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePintSystem.Comm
{   
    /// <summary>
    /// 打印设置参数
    /// </summary>
    public class PrintSettingParam
    {  
        /// <summary>
        /// 印刷尺寸
        /// </summary>
        public int? PrintSize { get; set; }
        /// <summary>
        /// 纸张大小
        /// </summary>
        public string PaperSize { get; set;}
        /// <summary>
        /// 选中的图片
        /// </summary>
        public List<ImageParamEdit> Images { get; set; } 
    }
}

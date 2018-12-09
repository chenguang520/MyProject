using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePinSystemModel
{   
    /// <summary>
    ///表单
    /// </summary>
    public class FormConfigModel
    {  
        /// <summary>
        /// 按钮尺寸，纸张大小
        /// </summary>
        public List<ButtonDeatil> ButtonDeatils { get; set; }
    }
    /// <summary>
    /// 按钮明细
    /// </summary>
    public class ButtonDeatil {
        /// <summary>
        /// 是否第一个位置
        /// </summary>
        public bool IsStartPosition { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// X轴位置
        /// </summary>
        public int? X { get; set; }
        /// <summary>
        /// Y轴位置
        /// </summary>
        public int? Y { get; set; }
        /// <summary>
        /// 按钮类型
        /// </summary>
        public string  BtnType{ get; set;}
        /// <summary>
        /// X 外边距
        /// </summary>
        public int? MarginX { get; set; }
        /// <summary>
        /// Y外边距
        /// </summary>
        public int? MarginY { get; set; }
        /// <summary>
        /// 显示内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 是否为最后一个
        /// </summary>
        public bool IsLast { get; set; }
    }
}

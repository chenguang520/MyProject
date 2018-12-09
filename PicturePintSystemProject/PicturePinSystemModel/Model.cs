using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePinSystemModel
{
    /// <summary>
    /// 图片帮助类
    /// </summary>
    public class ImageParamEdit
    {
        /// <summary>
        /// 原图
        /// </summary>
        public Image YuanImg { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public Image SuoImg { get; set; }
        /// <summary>
        /// 明细图片
        /// </summary>
        public Image DetailImg { get; set; }
        /// <summary>
        /// 是否为上传的图片
        /// </summary>
        public bool IsUpImg { get; set; }
        /// <summary>
        /// 图片物理路径
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 图片类型(后缀名)
        /// </summary>
        public string ImageType { get; set; }
    }
    public class ImageEditParam : ImageParamEdit
    {
        /// <summary>
        /// 裁剪后的图片
        /// </summary>
        public Image ScreenshotImg { get; set; }
        /// <summary>
        /// 裁剪后的缩略图
        /// </summary>
        public Image ScreenshotImgSuo { get; set; }
        /// <summary>
        /// 是否参加打印
        /// </summary>
        public bool IsPrint { get; set; }
    }
}
